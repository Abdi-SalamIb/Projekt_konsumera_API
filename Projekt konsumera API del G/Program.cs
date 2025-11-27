using System.Text.Json;


namespace Projekt_konsumera_API
{

    class Program
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

            Console.WriteLine("\nTryck på en tangent för att avsluta...");
            Console.ReadKey();
        }

        
        // Hämtar repositories från GitHub API 
        
        static async Task GetGitHubRepos()
        {
            // Skapa en HttpClient för att göra HTTP requests
            using HttpClient client = new HttpClient();

            // GitHub API kräver en User-Agent header
            client.DefaultRequestHeaders.Add("User-Agent", " Min_Projekt_konsumera_API");

            try
            {
                Console.WriteLine("Hämtar data från GitHub API...\n");

                // URL till GitHub API för .NET Foundation repositories
                string url = "https://api.github.com/orgs/dotnet/repos";

                // Gör en HTTP GET request
                HttpResponseMessage response = await client.GetAsync(url);

                // Kontrollera att requesten lyckades
                response.EnsureSuccessStatusCode();

                // Läs JSON-svaret som en sträng
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialisera JSON till en lista av Repository objekt
                List<Repository>? repos = JsonSerializer.Deserialize<List<Repository>>(jsonResponse);

                if (repos == null || repos.Count == 0)
                {
                    Console.WriteLine("Inga repositories hittades.");
                    return;
                }

                Console.WriteLine($"Hittade {repos.Count} repositories. Visar de första 5:\n");
                Console.WriteLine(new string('=', 70));

                // Visa de första 5 repositories
                int count = 0;
                foreach (var repo in repos)
                {
                    if (count >= 5) break;

                    Console.WriteLine($"\nName: {repo.Name}");
                    Console.WriteLine($"Homepage: {repo.Homepage ?? ""}");
                    Console.WriteLine($"GitHub: {repo.HtmlUrl}");
                    Console.WriteLine($"Description: {repo.Description ?? ""}");
                    Console.WriteLine($"Watchers: {repo.Watchers}");
                    Console.WriteLine($"Last push: {repo.PushedAt:yyyy-MM-dd HH:mm:ss}");

                    count++;
                }

                Console.WriteLine("\n" + new string('=', 70));
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Fel: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
            }
        }
    }



}
