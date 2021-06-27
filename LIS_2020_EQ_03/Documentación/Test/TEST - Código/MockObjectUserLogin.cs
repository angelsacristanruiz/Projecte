using Shift.BFF.Contracts.Interfaces;
using Shift.BFF.DTOs;
using Shift.Core.Models.Entities;
using Shift.Core.Services;
using Shift.Utils.Interfaces;
using System;
using System.Threading.Tasks;


namespace Shift.Test
{
    class MockObjectUserLogin : UserLogin
    {
        private SingletonBD BD = SingletonBD.Instance;
        public MockObjectUserLogin(IUserWebService userWebService, IDatabaseService databaseService) : base(userWebService, databaseService)
        {

        }
        public bool Login(string username, string password)
        {
            return BD.getlogin(username, password);
        }
    }
}