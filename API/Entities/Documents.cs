using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace API.Entities
{
    [Table("Documents")]
    public class Documents
    {
        [Key]
        public int Id { get; set; }
        public string NaslovDokumenta { get; set; }

        public string VrstaDokumenta { get; set; }

        public string TipDokumenta { get; set; }
        // public enum VrstaDokumenta { Faktura, Potvrda, Ugovor, Ponuda, Opomena, Dopis }

        // public enum TipDokumenta { Ulazni, Izlazni }

        public DateTime? DatumDokumenta { get; set; }

        public DateTime DatumUnosaDokumenta { get; set; } = DateTime.Now;
        public string FizickoLice { get; set; }
        public string Napomena { get; set; }

        //samo ako je faktura
        public int? Vrijednost { get; set; }

#nullable enable
        public string? Posiljaoc { get; set; }
        public string? Primaoc { get; set; }

#nullable disable
    public string PublicId { get; set; }
    public AppUser AppUser { get; set; }
    public int AppUserId { get; set; }
    }
}