using System;
using System.Collections.Generic;
using System.Text;

namespace AppUser.Models
{
    public class Abonnee
    {
        public int Id { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String adressEmail { get; set; }
        public String motDePasse { get; set; }
        public String confirmerMotDePasse { get; set; }
        public Byte[] photo { get; set; }
    }
}

    