using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlumnosAPI.Controllers
{
    public class ProfesorController : ApiController
    {
        public IEnumerable<Profesores> Get()
        {
            using (ColegioEntities colegio = new ColegioEntities())
            {
                return colegio.Profesores.ToList();
            }
        }

        public Profesores Get(int id)
        {
            using (ColegioEntities colegio = new ColegioEntities())
            {
                return colegio.Profesores.Find(id);
            }
        }
    }
}
