using System;
using System.Collections.Generic;
using System.Text;

namespace AppUser.Models
{
    public class PublicationPecheur
    {
        public int Id { get; set; }
        public int IdPecheur{ get; set; }
        public String nom { get; set; }
        public String lieu { get; set; }
        public DateTime dateDePeche { get; set; }
        public String choix { get; set; }
        public Double poids { get; set; }
        public Byte[] photoPoisson { get; set; }
    }
}
