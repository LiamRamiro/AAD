using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProvinciaRepositorio : IProvinciaRepositorio
    {

        private readonly GeografiaDbContext context;

        public ProvinciaRepositorio(GeografiaDbContext context)
        {
            this.context = context;
        }

        public Provincia GetProvinciaByCod(int cod)
        {
            SqlParameter parameter = new SqlParameter("@Cod", cod);

            return context.Provincia.Find(cod);
        }

        public IEnumerable<Provincia> GetProvincias()
        {
            return context.Provincia.FromSqlRaw<Provincia>("SELECT * FROM Provincia").ToList();
        }

        public void Add(Provincia nuevoProvincia)
        {
            context.Database.ExecuteSqlRaw("insertarProvincia {0}, {1}, {2}, {3}, {4}, {5}",
                nuevoProvincia.codProvincia,
                nuevoProvincia.nomProvincia,
                nuevoProvincia.superfie,
                nuevoProvincia.numHabitantes,
                nuevoProvincia.codComunidad);
                

            return;
        }

        public void Update(Provincia provinciaActualizado)
        {
            var equipo = context.Provincia.Attach(provinciaActualizado);
            equipo.State = EntityState.Modified;
            context.SaveChanges();
        }

        public Provincia Delete(int id)
        {
            Provincia provinciaDelete = context.Provincia.Find(id);
            if (provinciaDelete != null)
            {
                context.Provincia.Remove(provinciaDelete);
                context.SaveChanges();
            }
            return provinciaDelete;
        }

        public Provincia GetProvinciaByNombre(string nombreABuscar)
        {
            SqlParameter parameter = new SqlParameter("@nombreABuscar", nombreABuscar);

            return context.Provincia.FromSqlRaw<Provincia>("SELECT * FROM provincias WHERE nomProvincia = @nombreABuscar", parameter).FirstOrDefault();
        }

        public IEnumerable<Provincia> BuscarProvincias(string elementoABuscar)
        {
            if (string.IsNullOrEmpty(elementoABuscar))
            {
                return context.Provincia;
            }
            return context.Provincia.Where(p => p.nomProvincia.Contains(elementoABuscar));

        }



    }
}
