using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PeluquerosDAO
    {


        public void agregarPeluquero(PeluqueroEntity peluquero) { 
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Peluquero pel = new Peluquero
                    {
                        ID_PELUQUERO = peluquero.idPeluquero,
                        NOMBRE_APELLIDO = peluquero.nombreApellidoPeluquero,
                        TELEFONO = peluquero.telefono,
                        Fecha_Nacimiento = peluquero.FechaNacimiento,
                        FECHA_INGRESO = peluquero.fechaIngreso
                        
                    };

                    turnosContext.Peluquero.Add(pel);
                    turnosContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<PeluqueroEntity> listarPeluqueros()
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    List<Peluquero> peluqueroLista = turnosContext.Peluquero.ToList();

                    return peluqueroLista.Select(peluquero => getPeluqueroEntityByPeluquero(peluquero)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EliminarPeluquero(int id)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Peluquero peluquero = turnosContext.Peluquero.FirstOrDefault(t => t.ID_PELUQUERO == id);

                    turnosContext.Peluquero.Remove(peluquero);
                    turnosContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public PeluqueroEntity getbyID(int id)
        {
            try
            {
                using (TurnosContext turnosContext = new TurnosContext())
                {
                    Peluquero cliente = turnosContext.Peluquero.FirstOrDefault(t => t.ID_PELUQUERO == id);
                    return getPeluqueroEntityByPeluquero(cliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PeluqueroEntity getPeluqueroEntityByPeluquero(Peluquero peluquero)
        {

            if (peluquero == null) return null;

            return new PeluqueroEntity
            {
                nombreApellidoPeluquero = peluquero.NOMBRE_APELLIDO,
                idPeluquero = peluquero.ID_PELUQUERO,
                fechaIngreso = peluquero.FECHA_INGRESO,
                telefono = peluquero.TELEFONO,
                FechaNacimiento = peluquero.Fecha_Nacimiento,
            };

        }
    }
}
