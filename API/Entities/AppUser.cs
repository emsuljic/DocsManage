using System;
using System.Collections.Generic;
using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string MjestoStanovanja { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string UserName { get; set; }
        public DateTime Kreiran { get; set; } = DateTime.Now;
        public DateTime PosljednjeAktivan { get; set; } = DateTime.Now;
        public string Spol { get; set; }
        public ICollection<Documents> Docs { get; set; }
        public ICollection<Photo> Photos { get; set; }

        // public int GetAge()
        // {
        //     return DatumRodjenja.IzracunajGodine();
        // }

    }
}