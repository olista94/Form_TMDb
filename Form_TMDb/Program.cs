using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMDbFormApp;

namespace Form_TMDb
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        private const string TMDbApiKey = "2485efbdb1367ebd2417ba38d297df22";

        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Application.Run(new Form1());
            Application.Run(new Form1());

            Console.WriteLine("Bienvenido a la aplicaci�n de b�squeda de pel�culas en TMDb!");

            // while (true)
            // {
            //     Console.Write("Escribe el nombre de la pel�cula (o escriba 'salir' para cerrar el programa): ");
            //     string userInput = Console.ReadLine();
            // 
            //     if (userInput.ToLower() == "salir")
            //     {
            //         break;
            //     }
            // 
            //     if (string.IsNullOrWhiteSpace(userInput))
            //     {
            //         Console.WriteLine("Por favor, ingrese un nombre de pel�cula v�lido.");
            //         continue;
            //     }
            // 
            //     await BuscarPelicula(userInput);
            // }
            // 
            // Console.WriteLine("Gracias por usar la aplicaci�n");
        }

        static async Task BuscarPelicula(string titulo)
        {

            using var httpClient = new HttpClient();
            var url = $"https://api.themoviedb.org/3/search/movie?api_key={TMDbApiKey}&query={titulo}";

            try
            {
                // Solicitud a la API de TMDb para obtener detalles de la pel�cula
                var respuesta = await httpClient.GetStringAsync(url);
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<TMDbSearchResult<MovieDetails>>(respuesta);

                if (resultado.Results.Count > 0)
                {
                    // Informaci�n detallada de la pel�cula
                    var detallesPelicula = resultado.Results[0];

                    Console.WriteLine("\nInformaci�n de la pel�cula:");
                    Console.WriteLine($"T�tulo: {detallesPelicula.title}");
                    Console.WriteLine($"T�tulo original: {detallesPelicula.original_title}");
                    Console.WriteLine($"Puntuaci�n media: {detallesPelicula.vote_average}");
                    Console.WriteLine($"Fecha de estreno: {detallesPelicula.release_date}");
                    Console.WriteLine($"Sinopsis: {detallesPelicula.overview}");

                    // Obtener pel�culas similares
                    var peliculasSimilares = await ObtenerPeliculasSimilares(detallesPelicula.Id);

                    if (peliculasSimilares.Count > 0)
                    {
                        Console.WriteLine("Pel�culas similares:");
                        foreach (var peliculaSimilar in peliculasSimilares.Take(5))
                        {
                            Console.WriteLine($"{peliculaSimilar.title} ({ObtenerA�oEstreno(peliculaSimilar.release_date)})");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron pel�culas similares.");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron resultados para la pel�cula especificada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar la pel�cula: {ex.Message}");
            }
        }

        // Obtener una lista de pel�culas similares
        private static async Task<List<MovieDetails>> ObtenerPeliculasSimilares(int peliculaId)
        {
            using var httpClient = new HttpClient();
            var url = $"https://api.themoviedb.org/3/movie/{peliculaId}/similar?api_key={TMDbApiKey}";
            var respuesta = await httpClient.GetStringAsync(url);
        
            var resultado = JsonConvert.DeserializeObject<TMDbSearchResult<MovieDetails>>(respuesta);
            return resultado.Results;
        }

        // Obtener una el a�o de la pelicula
        private static int ObtenerA�oEstreno(string fechaEstreno)
        {
            if (DateTime.TryParse(fechaEstreno, out var fecha))
            {
                return fecha.Year;
            }
            return 0;
        }

        public class TMDbSearchResult<T>
        {
            public List<T> Results { get; set; }
        }

        public class MovieDetails
        {
            public int Id { get; set; }
        
            public string title { get; set; }
        
            public string original_title { get; set; }
        
            public double vote_average { get; set; }
        
            public string release_date { get; set; }
        
            public string overview { get; set; }

            public string poster_path { get; set; }
        }

    }
}