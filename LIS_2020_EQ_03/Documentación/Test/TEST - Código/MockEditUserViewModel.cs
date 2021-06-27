using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Shift.Core.Models.Entities;

namespace Shift.Test
{
    public class MockEditUserViewModel
    {
        public MockEditUserViewModel()
        {



        }

        public object Dialogs { get; private set; }

        public bool CheckInputs(UserModel User, string ConfirmPassword)
        {
            if (string.IsNullOrEmpty(User.Password) || string.IsNullOrEmpty(User.Email) ||
                 string.IsNullOrEmpty(User.FirstName) || string.IsNullOrEmpty(User.LastName) ||
                 string.IsNullOrEmpty(User.City) || string.IsNullOrEmpty(User.Street) ||
                 string.IsNullOrEmpty(User.PC) || User.Mobile == null || User.Mobile == 0 ||
                 User.Birthday == null || User.Birthday == new DateTime())
            {
             
                return false;
            }
            if (string.Compare(User.Password, ConfirmPassword) != 0)
            {
                
                return false;
            }
            if (!IsValidPassword(User.Password))
            { 
                return false;
            }
            if (!IsValidEmail(User.Email))
            {
               
                return false;
            }
            return true;
        }


        public bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, "^(?=.*[!@#$&*])(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z]).{10,14}$");
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        }
}
