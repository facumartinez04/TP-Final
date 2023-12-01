using BLL.Model;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthBusiness
    {
        private ContraModel contra = new ContraModel();
        private AuthDAO AuthDAO = new AuthDAO();
        private ClienteDAO clienteDAO = new ClienteDAO();
        public void registro(AuthEntity auth)
        {

            AuthEntity authEntity = AuthDAO.getByUser(auth.Usuario);
            if (authEntity != null) throw new Exception("El usuario ya esta registrado");

            auth.password = contra.Encriptar(auth.password);

            ClienteEntity cliente = new ClienteEntity {
                nombreApellido = auth.nombreyApellido,
                telefono = auth.telefono,
                usuario = auth.Usuario
            };

            clienteDAO.agregarCliente(cliente);
            AuthDAO.Registro(auth);
        }


        public AuthEntity Login(AuthEntity auth)
        {
            AuthEntity authEntity = AuthDAO.getByUser(auth.Usuario);
            if (authEntity == null) throw new Exception("El usuario no esta registrado");
            if (auth.password !=  contra.DesEncriptar(authEntity.password)) throw new Exception("La contraseña es incorrecta");
            if (auth.Usuario == "admin") return authEntity;

            ClienteEntity cliente = clienteDAO.getByUsuario(auth.Usuario);
            authEntity.telefono = cliente.telefono;
            authEntity.nombreyApellido = cliente.nombreApellido;
            authEntity.idCliente = cliente.idCliente;
            return authEntity;

        }


    }
}
