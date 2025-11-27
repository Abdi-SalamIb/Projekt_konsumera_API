using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab_4_del_VG
{
    class ProgramVG
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("**************************************************************");
            Console.WriteLine("----------- Lab4 - Konsumera Web API --------------------------");
            Console.WriteLine("----------------- Version G -----------------------------------");
            Console.WriteLine("----------------- Abdi-Salam Ibrahim --------------------------");
            Console.WriteLine("--------------------Kyh 2025-----------------------------------");
            Console.WriteLine("**************************************************************=\n");


            await GetGitHubRepos();

            Console.WriteLine("\n\n" + new string('*', 70) + "\n");

            // Zippopotam API 
            await GetMontvaleInfo();

            Console.WriteLine("\n\nTryck på en tangent för att avsluta...");
            Console.ReadKey();
        }

        // Hämtar repositories från GitHub API 
        static async Task GetGitHubRepos()
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Laboration4-DotNet-App");

            try
            {
                Console.WriteLine(" GITHUB API - .NET Foundation Repositories");
                Console.WriteLine(new string('-', 70));
                Console.WriteLine("Hämtar data från GitHub API...\n");

                string url = "https://api.github.com/orgs/dotnet/repos";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<Repository>? repos = JsonSerializer.Deserialize<List<Repository>>(jsonResponse);

                if (repos == null || repos.Count == 0)
                {
                    Console.WriteLine("Inga repositories hittades.");
                    return;
                }

                Console.WriteLine($" Hittade {repos.Count} repositories. Visar de första 5:\n");

                int count = 0;
                foreach (var repo in repos)
                {
                    if (count >= 5) break;

                    Console.WriteLine($"Name: {repo.Name}");
                    Console.WriteLine($"Homepage: {repo.Homepage ?? ""}");
                    Console.WriteLine($"GitHub: {repo.HtmlUrl}");
                    Console.WriteLine($"Description: {repo.Description ?? ""}");
                    Console.WriteLine($"Watchers: {repo.Watchers}");
                    Console.WriteLine($"Last push: {repo.PushedAt:yyyy-MM-dd HH:mm:ss}");
                    Console.WriteLine();

                    count++;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($" HTTP Fel: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Ett fel uppstod: {ex.Message}");
            }
        }

       
        // Hämtar information om Montvale, New Jersey från Zippopotam API
        
        static async Task GetMontvaleInfo()
        {
            using HttpClient client = new HttpClient();

            try
            {
                Console.WriteLine(" ZIPPOPOTAM API - Location Information");
                Console.WriteLine(new string('-', 70));
                Console.WriteLine("Hämtar information om Montvale, New Jersey...\n");

                // API URL för Montvale, NJ
                string url = "https://api.zippopotam.us/us/nj/montvale";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialisera till våra ZipLocation och Place klasser
                ZipLocation? location = JsonSerializer.Deserialize<ZipLocation>(jsonResponse);

                if (location == null || location.Places.Count == 0)
                {
                    Console.WriteLine("Ingen information hittades för Montvale.");
                    return;
                }

                Console.WriteLine("Information hittad!\n");
                Console.WriteLine(new string('=', 70));
                Console.WriteLine($"Land: {location.Country} ({location.CountryAbbreviation})");
                Console.WriteLine($"Stat: {location.State} ({location.StateAbbreviation})");
                Console.WriteLine();

                // Visa information för varje plats 
                foreach (var place in location.Places)
                {
                    Console.WriteLine($"Plats: {place.PlaceName}");
                    Console.WriteLine($"Postnummer: {place.PostCode}");
                    Console.WriteLine($"Latitud: {place.Latitude}");
                    Console.WriteLine($"Longitud: {place.Longitude}");
                    Console.WriteLine();
                }
                Console.WriteLine(new string('=', 70));

                // Extra: Visa koordinaterna i ett mer användbart format
                if (location.Places.Count > 0)
                {
                    var place = location.Places[0];
                    Console.WriteLine($"\n Google Maps länk:");
                    Console.WriteLine($"https://www.google.com/maps?q={place.Latitude},{place.Longitude}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($" HTTP Fel: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Ett fel uppstod: {ex.Message}");
            }
        }
    }

    
    
   
}