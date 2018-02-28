using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPfeBackEnd.Models
{
    public class Administrateur
    {
        public int Id { get; set; }
        public String AdresseEmail { get; set; }
        public String MotDePasse { get; set; }
    }
}