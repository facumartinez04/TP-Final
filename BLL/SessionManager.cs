using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SessionManager
    {


        private static SessionManager _instance = null;
        private static object _cerrado = new Object();
        public AuthEntity authDAO { get; set; }

        private SessionManager() { 
            
        }

        public static SessionManager Instance
        {
            get
            {

                lock (_cerrado)
                {
                    if (_instance == null)
                    {
                        throw new Exception("Sesion no iniciada");
                    }
                }
                return _instance;

            }
        }

        public static void Login(AuthEntity auth)
        {
            if(_instance == null)
            {
                _instance = new SessionManager();
                _instance.authDAO = auth;
            }
            else
            {
                throw new Exception("Sesion ya iniciada");
            }
        }

        public static void Logout()
        {
            if (_instance != null)
            {
                _instance = null;
            }
            else
            {
                throw new Exception("Sesion no iniciada");
            }
        }

    }
}
