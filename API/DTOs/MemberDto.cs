using System;
using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Age { get; set; }
        public string MjestoStanovanja { get; set; }
        public string Username { get; set; }
        public DateTime Kreiran { get; set; } 
        public DateTime PosljednjeAktivan { get; set; } 
        public string Spol { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<Documents> Docs { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
        
    }
}