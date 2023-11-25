using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AuthDAO
    { 

        public void Registro(AuthEntity authEntity)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    LogIn cuenta = new LogIn {
                        Usuario = authEntity.Usuario,
                        Contraseña = authEntity.password
                    };
                    turnosContext.LogIn.Add(cuenta);
                    turnosContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  


        public AuthEntity getByUser(string User)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    LogIn user = turnosContext.LogIn.FirstOrDefault(t => t.Usuario == User);
                    if (user == null) return null;
                    return new AuthEntity { 
                        Usuario = user.Usuario,
                        password = user.Contraseña,
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
