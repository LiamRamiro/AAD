using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public interface IEquipoRepositorio
	{
		IEnumerable<Equipo> GetEquipos();

		Equipo GetEquipoById(int Id);

		Equipo Delete(int Id);

		void Update(Equipo equipoActualizado);

		void Add(Equipo equipoNuevo);

		IEnumerable<Equipo> BuscarEquipo(string elementoABuscar);

		

	}
}
