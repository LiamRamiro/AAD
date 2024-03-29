﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlumnosAPI.Controllers
{
    public class SucursalController : ApiController
    {
        public IEnumerable<Sucursal> Get()
        {
            using (ColegioEntities colegio = new ColegioEntities())
            {
                return colegio.Sucursales.ToList();
            }
        }

        public Sucursales Get(int id)
        {
            using (ColegioEntities colegio = new ColegioEntities())
            {
                return colegio.Sucursales.Find(id);
            }
        }
    }
}
