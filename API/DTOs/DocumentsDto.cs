using System;
using API.Entities;

namespace API.DTOs
{
    public class DocumentsDto
    {
        public int Id { get; set; }
        public string NaslovDokumenta { get; set; }
        // public enum VrstaDokumenta { Faktura, Potvrda, Ugovor, Ponuda, Opomena, Dopis }

        // public enum TipDokumenta { Ulazni, Izlazni }

        public string VrstaDokumenta { get; set; }

        public string TipDokumenta { get; set; }

        public DateTime? DatumDokumenta { get; set; }

        public DateTime DatumUnosaDokumenta { get; set; }
        public string FizickoLice { get; set; }
        public string Napomena { get; set; }

        public int? Vrijednost { get; set; }

#nullable enable
        public string? Posiljaoc { get; set; }
        public string? Primaoc { get; set; }

#nullable disable
        public int AppUserId { get; set; }

    }
}