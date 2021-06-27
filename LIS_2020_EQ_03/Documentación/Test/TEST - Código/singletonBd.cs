using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Test
{
    public sealed class SingletonBD
    {
        private SingletonBD()
        {
            User.Add("judith@gmail.com", "judith");
            User.Add("agustin@tamayo.com", "agustin");
            User.Add("martinsusin@gmail.com", "martin");
            User.Add("dasdsadd", "judith");
            User.Add("dsdasdasd", "susin");
        }

        private static SingletonBD instance = null;
        private Hashtable User = new Hashtable();
        public static SingletonBD Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonBD();
                }
                return instance;
            }
        }
        public void register(String user, String Password)
        {
            User.Add(user, Password);
        }
        public bool getlogin(String username, String password)
        {
            bool logueado = false;
            if (User.ContainsKey(username))
            {
                if (User[username] == password)
                {
                    logueado = true;
                }

            }
            return logueado;
        }
    }
}