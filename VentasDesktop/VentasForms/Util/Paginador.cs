using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasForms.Util
{
    public class Paginador
    {

        private int tamPagina;
        private int totalItem;
        private int paginaActual = 1;

        /**
         *
         * @param tamPagina
         * @param totalItem
         */
        public Paginador(int tamPagina, int totalItem)
        {
            this.tamPagina = tamPagina;
            this.totalItem = totalItem;
        }

        public int getTamPagina()
        {
            return tamPagina;
        }

        public int getTotalItem()
        {
            return totalItem;
        }

        public void setTotalItem(int totalItem)
        {
            this.totalItem = totalItem;
        }

        public int getTotalPaginas()
        {
            double v = 196 / 10;
            double s = (double)totalItem / tamPagina;
            return (int)Math.Ceiling(Convert.ToDouble(totalItem) / tamPagina);
        }

        public int getPaginaActual()
        {
            return paginaActual;
        }

        public void setPaginaActual(int paginaActual)
        {
            this.paginaActual = paginaActual;
        }

        public int getCurrentItem()
        {

            return (paginaActual > 0 ? paginaActual - 1 : 1) * tamPagina ;
        }

        public void siguientePagina()
        {
            paginaActual++;
        }

        public void anteriorPagina()
        {
            paginaActual--;
        }

        public void primeraPagina()
        {
            paginaActual = 1;
        }

        public void ultimaPagina()
        {
            paginaActual = getTotalPaginas();
        }

        public bool existeSiguientePagina()
        {
            bool val = paginaActual < getTotalPaginas();
            return paginaActual < getTotalPaginas();
        }

        public bool existeAnteriorPagina()
        {
            return paginaActual > 1;
        }
    }
}