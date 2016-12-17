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

    public class Usuario
    {
        public int id { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public byte?[] foto { get; set; }
        public Endereco endereco { get; set; }
        public ICollection<JogoDesejado> JogosDesejados { get; set; }
        public ICollection<JogoPossuido> JogosPossuidos { get; set; }
    }

    public class Endereco
    {
        public int id { get; set; }
        public string cidade { get; set; }
    }

    public class JogoDesejado : Jogo
    {
        public new int id { get; set; }
        public int usuarioID { get; set; }
        public CondicaoJogo? estado { get; set; }

        public virtual Usuario usuario { get; set; }
    }

    public class JogoPossuido : Jogo
    {
        public new int id { get; set; }
        public int usuarioID { get; set; }
        public string detalhes { get; set; }
        public DateTime dataDeCompra { get; set; }
        public CondicaoJogo? estado { get; set; }

        public virtual Usuario usuario { get; set; }
    }

    public class Jogo
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime anoLancamento { get; set; }
        public ConsoleGame console { get; set; }
        public decimal valor { get; set; }
    }

    public enum CondicaoJogo
    {
        PerfeitoEstado,
        CapaAvariada,
        SemCapa
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

        static async Task<List<JogoPossuido>> BuscarTrocaAsync(string path)
        {
            List<JogoPossuido> jogosEquivalentes = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                jogosEquivalentes = await response.Content.ReadAsAsync<List<JogoPossuido>>();
            }
            return jogosEquivalentes;
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
                Usuario u1 = new Usuario
                {
                    id = 1,
                    nome = "Teste1",
                    endereco = new Endereco { cidade = "Rio de Janeiro" },
                    JogosPossuidos = new List<JogoPossuido>()
                    {
                        new JogoPossuido() {
                            nome = "A", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        },
                        new JogoPossuido() {
                            nome = "B", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        },
                        new JogoPossuido() {
                            nome = "C", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        }
                    },
                    JogosDesejados = new List<JogoDesejado>()
                    {
                        new JogoDesejado() {
                            nome = "D", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        },
                        new JogoDesejado() {
                            nome = "E", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        },
                        new JogoDesejado() {
                            nome = "F", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        }
                    }
                };
                Usuario u2 = new Usuario
                {
                    id = 2,
                    nome = "Teste2",
                    endereco = new Endereco { cidade = "Rio de Janeiro" },
                    JogosDesejados = new List<JogoDesejado>()
                    {
                        new JogoDesejado() {
                            nome = "F", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        },
                        new JogoDesejado() {
                            nome = "G", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        },
                        new JogoDesejado() {
                            nome = "H", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        }
                    },
                    JogosPossuidos = new List<JogoPossuido>()
                    {
                        new JogoPossuido() {
                            nome = "C", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        },
                        new JogoPossuido() {
                            nome = "D", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        },
                        new JogoPossuido() {
                            nome = "E", estado = CondicaoJogo.PerfeitoEstado, valor = 100
                        }
                    }
                };

                List<JogoPossuido> jogosEquivalentes = await BuscarTrocaAsync($"api/TrocaJogo/{u2.id}");


                List<JogoPossuido> jogosEquivalentes = await BuscarTrocaAsync($"api/TrocaJogo/{u2.id}");

                //// Create a new console
                //ConsoleGame console = new ConsoleGame { Nome = "NINTENDO 64", Ano = 2010 };

                //var url = await CreateConsoleGameAsync(console);
                //Console.WriteLine($"Created at {url}");

                //// Get the console
                ////console = await GetConsoleGameAsync($"api/consolegames/2");
                //console = await GetConsoleGameAsync(url.PathAndQuery);
                //ShowConsole(console);

                ////Update the console
                //Console.WriteLine("Atualizando ano...");
                //console.Ano = 2016;
                //await UpdateConsoleGameAsync(console);

                ////// Get the updated console
                //console = await GetConsoleGameAsync(url.PathAndQuery);
                //ShowConsole(console);

                ////// Delete the console
                ////var statusCode = await DeleteConsoleGameAsync(console.ConsoleGameID.ToString());
                ////Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}
