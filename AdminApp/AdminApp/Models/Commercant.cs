using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    class Commercant
    {
        public int Id { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String adressEmail { get; set; }
        public String motDePasse { get; set; }
        public String ConfirmerMotDePasse { get; set; }
        public String adressMagasin { get; set; }
        public int NumeroTelephone { get; set; }
        public Byte[] photo { get; set; }
    }
}
