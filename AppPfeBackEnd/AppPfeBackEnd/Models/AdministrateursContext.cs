﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppPfeBackEnd.Models
{
    public class AdministrateursContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AdministrateursContext() : base("name=AdministrateursContext")
        {
        }

        public System.Data.Entity.DbSet<AppPfeBackEnd.Models.Administrateur> Administrateurs { get; set; }


        public System.Data.Entity.DbSet<AppPfeBackEnd.Models.Commercant> Commercants { get; set; }

        public System.Data.Entity.DbSet<AppPfeBackEnd.Models.Pecheur> Pecheurs { get; set; }

        public System.Data.Entity.DbSet<AppPfeBackEnd.Models.Abonnee> Abonnees { get; set; }

        public System.Data.Entity.DbSet<AppPfeBackEnd.Models.PublicationPecheur> PublicationPecheurs { get; set; }
    }
}
