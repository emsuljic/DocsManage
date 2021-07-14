using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace API.Entities
{
    public class Documents
    {
        [Key]
        public int Id  { get; private set; }
        public static int globalId;

        public Documents(string naslovDokumenta, DateTime? datumDokumenta, 
            DateTime datumUnosaDokumenta, string fizickoLice, string napomena, int? vrijednost, 
                string posiljaoc, string primaoc)
        {
            Id = Interlocked.Increment(ref globalId);;
            this.NaslovDokumenta = naslovDokumenta;
            this.DatumDokumenta = datumDokumenta;
            this.DatumUnosaDokumenta = datumUnosaDokumenta;
            this.FizickoLice = fizickoLice;
            this.Napomena = napomena;
            this.Vrijednost = vrijednost;
            this.Posiljaoc = posiljaoc;
            this.Primaoc = primaoc;
       }

        public string NaslovDokumenta { get; set; }
        public enum VrstaDokumenta { Faktura, Potvrda, Ugovor, Ponuda, Opomena, Dopis }

        public enum TipDokumenta { Ulazni, Izlazni }

        public DateTime? DatumDokumenta { get; set; }

        public DateTime DatumUnosaDokumenta { get; set; }
        public string FizickoLice { get; set; }
        public string Napomena { get; set; }

        //samo ako je faktura
        public int? Vrijednost { get; set; }

        #nullable enable
        public string? Posiljaoc { get; set; }
        public string? Primaoc { get; set; }

        #nullable disable
        
        public AppUser korisnik { get; set; }
    }
}