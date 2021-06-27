using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shift.Core;
using System;
using Shift.Core.ViewModels.User;
using Shift.Core.Models.Entities;
using Shift.Core.Interfaces;
using Shift.Utils.Interfaces;
using MvvmCross.Navigation;
using MvvmCross.Commands;
using System.Threading.Tasks;
using System.Diagnostics;
using MvvmCross;

namespace Shift.Test
{
    [TestClass]
    public class RegistroTest
    {
        
        [TestMethod]
        public async Task CheckInputsEmptyTest()
        {
            MockEditUserViewModel mockEditUserViewModel = new MockEditUserViewModel();

            UserModel user = new UserModel();

            user.Password = "";
            user.Email = "";
            user.FirstName = "";
            user.LastName = "";
            user.City = "";
            user.Birthday = new DateTime();
            user.Street = "";
            user.PC = "";
            user.Mobile = 0;

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, ""));


            user.Email = "agustin.tamayo@e-campus.uab.cat";
            user.FirstName = "Agustin";
            user.LastName = "Tamayo Quiñones";
            user.City = "Terrassa";
            user.Birthday = new DateTime(1996, 10, 01);
            user.Street = "Rambla Francesc Macia";
            user.PC = "08226";
            user.Mobile = 646808080;


            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));

            user.Password = "Agustin!123";
            user.Email = "";
            

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));


            
            user.Email = "agustin.tamayo@e-campus.uab.cat";
            user.FirstName = "";
   

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));


            
            user.FirstName = "Agustin";
            user.LastName = "";

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));


           
            user.LastName = "Tamayo Quiñones";
            user.City = "";

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));

            user.City = "Terrassa";
            user.Birthday = new DateTime();

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));

            user.Birthday = new DateTime(1996, 10, 01);
            user.Street = "";

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));

            user.Street = "Rambla Francesc Macia";
            user.PC = "";

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));

            user.PC = "08226";
            user.Mobile = 0;

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));

            
            user.Mobile = 646808080;
            

            Boolean task = mockEditUserViewModel.CheckInputs(user, "Agustin!123");

      
            Assert.IsTrue(task);
          

        }

        [TestMethod]
        public void CheckInputsPasswordTest()
        {
            MockEditUserViewModel mockEditUserViewModel = new MockEditUserViewModel();

            UserModel user = new UserModel();
            user.Password = "Agustin!123";
            user.Email = "agustin.tamayo@e-campus.uab.cat";
            user.FirstName = "Agustin";
            user.LastName = "Tamayo Quiñones";
            user.City = "Terrassa";
            user.Street = "Rambla Francesc Macia";
            user.PC = "08226";
            user.Mobile = 646808080;
            user.Birthday = new DateTime(1996,10,01);

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!1234"));

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, ""));

            Assert.IsTrue(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));

            user.Password = "";

            Assert.IsFalse(mockEditUserViewModel.CheckInputs(user, "Agustin!123"));

        }

        [TestMethod]
        public void IsValidPasswordTest()
        {
            MockEditUserViewModel mockEditUserViewModel = new MockEditUserViewModel();

            Assert.IsTrue(mockEditUserViewModel.IsValidPassword("Agustin!123"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword(""));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("Agustin.123"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("agustin!123"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("AGUSTIN!123"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("Agustin123"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("Agustin!"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("!123"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("123"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("Agustin"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("Agustin!1234567890"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("Ag!1"));
            Assert.IsFalse(mockEditUserViewModel.IsValidPassword("!!!!!!!!!"));
        }

        [TestMethod]
        public void IsValidEmailTest()
        {
            MockEditUserViewModel mockEditUserViewModel = new MockEditUserViewModel();

            Assert.IsTrue(mockEditUserViewModel.IsValidEmail("agustin.tamayo@e-campus.uab.cat"));
            Assert.IsFalse(mockEditUserViewModel.IsValidEmail("agustin.tamayo@e-campusuabcat"));
            Assert.IsFalse(mockEditUserViewModel.IsValidEmail("agustin.tamayoe-campus.uab.cat"));
            Assert.IsFalse(mockEditUserViewModel.IsValidEmail("agustintamayoe-campusuabcat"));
            Assert.IsFalse(mockEditUserViewModel.IsValidEmail("@agustin.tamayoe-campus.uab.cat"));
            Assert.IsFalse(mockEditUserViewModel.IsValidEmail("agustin.tamayoe-campus.uab.cat@"));

        }

    }
}
