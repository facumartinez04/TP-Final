using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class PeluqueroBusiness
    {
        private PeluquerosDAO peluquerosDAO = new PeluquerosDAO();
        
        public List<PeluqueroEntity> listaPeluqueros()
        {
            return peluquerosDAO.listarPeluqueros();
        }


        public void EliminarPeluquero(int id)
        {


            PeluqueroEntity pelBuscado = peluquerosDAO.getbyID(id);
            if (pelBuscado == null) throw new Exception("El id que ingreso no existe");
            using (var transaction = new TransactionScope())
            {
                
                peluquerosDAO.EliminarPeluquero(id);
                transaction.Complete();
            }
        }

        public void AgregarPeluquero(PeluqueroEntity peluquero)
        {
            using (var transaction = new TransactionScope())
            {
                peluquerosDAO.agregarPeluquero(peluquero);
                transaction.Complete();             
            }
        }



    }
}
