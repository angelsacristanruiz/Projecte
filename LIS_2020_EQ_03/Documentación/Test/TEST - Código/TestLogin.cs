using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shift.Core.Interfaces;
using Shift.Core.Models.Entities;
using Shift.Core.Services;
using Shift.Core.ViewModels.User;
using Shift.Utils.Interfaces;
using MvvmCross.Navigation;

namespace Shift.Test
{
    [TestClass]
    public class LoginTest
    {
        private MockObjectUserLogin _user = new MockObjectUserLogin(null, null);


        [TestMethod]
        public void Login()
        {
            String[] _username = new String[5] { "judith@gmail.com", "agustin@tamayo.com", "martinsusin@gmail.com", "dasdsadd", "dsdasdasd" }, _password = new String[5] { "judith", "agustin", "martin", "susin", "" };
            bool _login;
            bool[] _assert = new bool[5] { true, true, true, false, false };
            for (int i = 0; i < _username.Length; i++)
            {
                _login = _user.Login(_username[i], _password[i]);
                Assert.AreEqual(_login, _assert[i]);
            }

        }
    }
}