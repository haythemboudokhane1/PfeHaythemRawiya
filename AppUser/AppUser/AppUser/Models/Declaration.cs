using System;
using System.Collections.Generic;
using System.Text;

namespace AppUser.Models
{
    public class Declaration
    {
        public int IdAbonnee { get; set; }
        public String Commentaire { get; set; }
        public String lieuDeDepassement { get; set; }
        public Byte[] Photo { get; set; }
    }
}
