using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedDocument(DataContext context)
        {
            if (await context.Docs.AnyAsync()) return;

            var docData = await System.IO.File.ReadAllTextAsync("Data/DocumentsSeedData.json");
            var documents = JsonSerializer.Deserialize<List<Documents>>(docData);
            foreach (var document in documents)
            {
                document.NaslovDokumenta = document.NaslovDokumenta;
                document.VrstaDokumenta = document.VrstaDokumenta;
                document.TipDokumenta = document.TipDokumenta;
                document.DatumDokumenta = Convert.ToDateTime(document.DatumDokumenta);
                document.DatumUnosaDokumenta = Convert.ToDateTime(document.DatumUnosaDokumenta);
                document.FizickoLice = document.FizickoLice;
                document.Napomena = document.Napomena;
                document.Vrijednost = document.Vrijednost;
                document.Posiljaoc = document.Posiljaoc;
                document.Primaoc = document.Primaoc;
                document.AppUserId = document.AppUserId;
                
                context.Docs.Add(document);
            }
            await context.SaveChangesAsync();
        }
    }
}