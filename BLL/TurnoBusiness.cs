using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{

    public class TurnoBusiness
    {
        private TurnoDAO turnosDAO = new TurnoDAO();

        private ClienteDAO clienteDAO = new ClienteDAO();

        public List<TurnoEntity> listaTurnos()
        {
            return turnosDAO.listarTurnos();
        }




        public void agregarTurno(TurnoEntity turno)
        {
            turno.Estado = "Asignado";
            turno.FechaRegistro = DateTime.Now.Date;
            ClienteEntity cliente = clienteDAO.getbyID(turno.cliente.usuario);
            if(cliente == null)
            {
                clienteDAO.agregarCliente(new ClienteEntity
                {
                    nombreApellido = turno.cliente.nombreApellido,
                    telefono = turno.cliente.telefono,
                    usuario = turno.cliente.usuario
                });
                cliente = clienteDAO.getbyID(turno.cliente.usuario);
            }
            turno.cliente.idCliente = cliente.idCliente;
            
            turnosDAO.agregarTurno(turno);
        }


        public void eliminarTurno(int id)
        {
            TurnoEntity turnoBuscado =  turnosDAO.getbyID(id);
            if (turnoBuscado == null) throw new Exception("El id que ingreso no existe");

            turnosDAO.EliminarTurno(id);
        }

        public void editarTurno(TurnoEntity turnoeditar)
        {
            if (turnoeditar.idTurno == 0) throw new Exception("Ingresa un id");
            if(turnoeditar.DiaTurno.Date < DateTime.Now.Date) throw new Exception("Debe ser un dia mas adelante");
            TurnoEntity turnoBuscado = turnosDAO.getbyID(turnoeditar.idTurno);
            if (turnoBuscado == null) throw new Exception("El id que ingreso no existe");
            turnosDAO.EditarTurno(turnoeditar);
        }


    }
}
