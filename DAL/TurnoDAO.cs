using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TurnoDAO
    {

        public void agregarTurno(TurnoEntity turno)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Turnos nuevoTurno = new Turnos
                    {
                        ID_CLIENTE = turno.cliente.idCliente,
                        ID_PELUQUERO = turno.peluquero.idPeluquero,
                        FECHA_REGISTRO = turno.FechaRegistro,
                        HORA = turno.Hora,
                        ESTADO = turno.Estado,
                        SERVICIO = turno.Servicio,
                        DIA_TURNO = turno.DiaTurno
                    };

                    turnosContext.Turnos.Add(nuevoTurno);
                    turnosContext.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }


        public List<TurnoEntity> listarTurnos()
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {

                    List<Cliente> clientelista = turnosContext.Cliente.ToList();
                    List<Turnos> turnosLista = turnosContext.Turnos.ToList();
                    List<Peluquero> peluquerosLista = turnosContext.Peluquero.ToList();
                    var nuevaLista = (from c in clientelista
                                      join t in turnosLista    
                                      on c.ID_CLIENTE equals t.ID_CLIENTE
                                      join p in peluquerosLista 
                                      on t.ID_PELUQUERO equals p.ID_PELUQUERO

                                      select new TurnoEntity
                                      {
                                          idTurno = t.ID_TURNO,
                                          peluquero = new PeluqueroEntity
                                          {
                                              idPeluquero = p.ID_PELUQUERO,
                                              nombreApellidoPeluquero = p.NOMBRE_APELLIDO
                                          },
                                          cliente = new ClienteEntity
                                          {
                                              idCliente = c.ID_CLIENTE,
                                              nombreApellido = c.NOMBRE_APELLIDO,
                                          },
                                          FechaRegistro = t.FECHA_REGISTRO,
                                          Hora = t.HORA,
                                          Estado = t.ESTADO,
                                          Servicio = t.SERVICIO,
                                          DiaTurno = t.DIA_TURNO
                                      }).ToList();

                    return nuevaLista;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<TurnoEntity> listarPorUsuario(string usuario)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {

                    List<Cliente> clientelista = turnosContext.Cliente.ToList();
                    List<Turnos> turnosLista = turnosContext.Turnos.ToList();
                    List<Peluquero> peluquerosLista = turnosContext.Peluquero.ToList();
                    var nuevaLista = (from c in clientelista
                                      join t in turnosLista
                                      on c.ID_CLIENTE equals t.ID_CLIENTE
                                      join p in peluquerosLista
                                      on t.ID_PELUQUERO equals p.ID_PELUQUERO
                                     
                                      select new TurnoEntity
                                      {
                                          idTurno = t.ID_TURNO,
                                          peluquero = new PeluqueroEntity
                                          {
                                              idPeluquero = p.ID_PELUQUERO,
                                              nombreApellidoPeluquero = p.NOMBRE_APELLIDO
                                          },
                                          cliente = new ClienteEntity
                                          {
                                              idCliente = c.ID_CLIENTE,
                                              nombreApellido = c.NOMBRE_APELLIDO,
                                              usuario = c.usuario,
                                              telefono = c.TELEFONO
                                          },
                                          FechaRegistro = t.FECHA_REGISTRO,
                                          Hora = t.HORA,
                                          Estado = t.ESTADO,
                                          Servicio = t.SERVICIO,
                                          DiaTurno = t.DIA_TURNO
                                      }).ToList();

                    return nuevaLista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public  TurnoEntity getbyID(int id)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Turnos turno = turnosContext.Turnos.FirstOrDefault(t => t.ID_TURNO == id);
                    return getTurnoEntityByTurno(turno);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }


        public void EliminarTurno(int id)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Turnos turno = turnosContext.Turnos.FirstOrDefault(t => t.ID_TURNO == id);


                    turnosContext.Turnos.Remove(turno);
                    turnosContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EditarTurno(TurnoEntity turno)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Turnos turnoEditar = turnosContext.Turnos.FirstOrDefault(t => t.ID_TURNO == turno.idTurno);

                    turnoEditar.DIA_TURNO = turno.DiaTurno;
                    turnoEditar.HORA = turno.Hora;
                    turnoEditar.SERVICIO = turno.Servicio;

                    turnosContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private TurnoEntity getTurnoEntityByTurno(Turnos turno) {
            
            if(turno == null) return null;

            return new TurnoEntity
            {

                idTurno = turno.ID_TURNO,
                cliente = new ClienteEntity
                {
                    idCliente = turno.ID_CLIENTE,

                },
                peluquero = new PeluqueroEntity
                {
                    idPeluquero = turno.ID_PELUQUERO
                },
                FechaRegistro = turno.FECHA_REGISTRO,
                Hora = turno.HORA,
                Estado = turno.ESTADO,
                Servicio = turno.SERVICIO,
                DiaTurno = turno.DIA_TURNO
            };

        }

    }
}
