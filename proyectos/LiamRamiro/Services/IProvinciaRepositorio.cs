using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Services
{
    public interface IProvinciaRepositorio
    {


        IEnumerable<Provincia> GetProvincias();
        Provincia GetProvinciaByCod(int cod);

        void Update(Provincia provinciaActualizado);

        void Add(Provincia nuevaProvincia);

        Provincia Delete(int id);

        IEnumerable<Provincia> BuscarProvincias(string elementoABuscar);

        IEnumerable<Provincia> BuscarProvinciasPorComunidad(Comunidad elementoABuscar);


    }
}
