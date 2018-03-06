using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPfeBackEnd.Models
{
    public class Pecheur
    {
        public int Id { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String adressEmail { get; set; }
        public String motDePasse { get; set; }
        public String confirmerMotDePasse { get; set; }
        public String adressMagasin { get; set; }
        public String Experience { get; set; }
        public int NumeroTelephone { get; set; }
        public Byte[] photo { get; set; }
    }
}