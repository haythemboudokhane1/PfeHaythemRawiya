using System;
using System.Collections.Generic;
using System.Text;

namespace AppUser.Models
{
    public class PublicationCommercant
    {
        public int IdCommercant { get; set; }
        public DateTime datePub { get; set; }
        public byte[] photoProduit { get; set; }
        public String nomProduit { get; set; }
        public Double prixProduit { get; set; }
    }
}
