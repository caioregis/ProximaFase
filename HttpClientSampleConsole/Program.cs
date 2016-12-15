using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientSampleConsole
{
    public class ConsoleGame
    {
        public int ConsoleGameID { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowConsole(ConsoleGame console)
        {
            Console.WriteLine($"ID: {console.ConsoleGameID}\tNome: {console.Nome}\tAno: {console.Ano}");
        }

        static async Task<Uri> CreateConsoleGameAsync(ConsoleGame console)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/consolegames", console);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<ConsoleGame> GetConsoleGameAsync(string path)
        {
            ConsoleGame console = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                console = await response.Content.ReadAsAsync<ConsoleGame>();
            }
            return console;
        }

        static async Task<ConsoleGame> UpdateConsoleGameAsync(ConsoleGame console)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/consolegames/{console.ConsoleGameID}", console);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated console from the response body.
            console = await response.Content.ReadAsAsync<ConsoleGame>();
            return console;
        }

        static async Task<HttpStatusCode> DeleteConsoleGameAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/consolegames/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:62280/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new console
                ConsoleGame console = new ConsoleGame { Nome = "NINTENDO 64", Ano = 2010 };

                var url = await CreateConsoleGameAsync(console);
                Console.WriteLine($"Created at {url}");

                // Get the console
                //console = await GetConsoleGameAsync($"api/consolegames/2");
                console = await GetConsoleGameAsync(url.PathAndQuery);
                ShowConsole(console);

                //Update the console
                Console.WriteLine("Atualizando ano...");
                console.Ano = 2016;
                await UpdateConsoleGameAsync(console);

                //// Get the updated console
                console = await GetConsoleGameAsync(url.PathAndQuery);
                ShowConsole(console);

                //// Delete the console
                var statusCode = await DeleteConsoleGameAsync(console.ConsoleGameID.ToString());
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}
