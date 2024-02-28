using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Services
{
	public class EquipoRepositorio : IEquipoRepositorio
	{
		private readonly FutbolDbContext context;

		public EquipoRepositorio(FutbolDbContext context)
		{
			this.context = context;
		}

		public IEnumerable<Equipo> GetEquipos()
		{
			return context.Equipo.FromSqlRaw<Equipo>("SELECT * FROM Equipo").ToList();
		}

		public Equipo GetEquipoById(int Id)
		{
            SqlParameter parameter = new SqlParameter("@Id", Id);

			return context.Equipo.Find(Id);
        }

        public Equipo Delete(int id)
        {
            Equipo equipoDelete = context.Equipo.Find(id);
            if (equipoDelete != null)
            {
                context.Equipo.Remove(equipoDelete);
                context.SaveChanges();
            }
            return equipoDelete;
        }

        public void Add(Equipo nuevoEquipo)
        {
            context.Database.ExecuteSqlRaw("insertarEquipo {0}, {1}, {2}, {3}, {4}, {5}",
                nuevoEquipo.nomEquipo,
                nuevoEquipo.ciudad,
                nuevoEquipo.nomEstadio,
                nuevoEquipo.anoFundacion,
                nuevoEquipo.foto,
                nuevoEquipo.categoria);

            return;
        }

        public void Update(Equipo equipoActualizado)
        {
            var equipo = context.Equipo.Attach(equipoActualizado);
            equipo.State = EntityState.Modified;
            context.SaveChanges();
        }


        public IEnumerable<Equipo> BuscarEquipo(string elementoABuscar)
        {
            if (string.IsNullOrEmpty(elementoABuscar))
            {
                return context.Equipo;
            }
            return context.Equipo.Where(e => e.nomEquipo.Contains(elementoABuscar));

        }


    }
}
