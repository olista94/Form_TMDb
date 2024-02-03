using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Form_TMDb.Program;
using RestSharp;
using static System.Net.WebRequestMethods;
using System.Net;
using System.Drawing;

namespace TMDbFormApp
{
    public partial class Form1 : Form
    {
        private const string TMDbApiKey = "2485efbdb1367ebd2417ba38d297df22"; // Reemplaza 'tu_api_key' con la clave de tu cuenta en TMDb

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string tituloPelicula = txtTituloPelicula.Text.Trim();

            if (string.IsNullOrWhiteSpace(tituloPelicula))
            {
                MessageBox.Show("Por favor, ingrese un nombre de película válido.");
                return;
            }

            await BuscarPelicula(tituloPelicula);
        }

        private async Task BuscarPelicula(string titulo)
        {
            using var httpClient = new HttpClient();
            var url = $"https://api.themoviedb.org/3/search/movie?api_key={TMDbApiKey}&query={titulo}";

            try
            {
                var respuesta = await httpClient.GetStringAsync(url);
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<TMDbSearchResult<MovieDetails>>(respuesta);

                if (resultado.Results.Count > 0)
                {
                    var primeraPelicula = resultado.Results[0];

                    string urlImage = $"https://image.tmdb.org/t/p/original{primeraPelicula.poster_path}";

                    // Convertir la cadena a objeto DateTime en estilo estadounidense
                    // DateTime fechaEnFormatoUSAObj = 

                    // Formatear el objeto DateTime en estilo español
                    //string fechaEnFormatoEspanol = DateTime.ParseExact(primeraPelicula.release_date, "yyyy-MM-dd", null).ToString("dd/MM/yyyy");

                    // Mostrar información en los controles del formulario
                    lblTitulo.Text = $"Título: {primeraPelicula.title}";
                    lblTituloOriginal.Text = $"Título Original: {primeraPelicula.original_title}";
                    lblPuntuacionMedia.Text = $"Puntuación Media: {primeraPelicula.vote_average}";
                    lblFechaEstreno.Text = $"Fecha de Estreno: {DateTime.ParseExact(primeraPelicula.release_date, "yyyy-MM-dd", null).ToString("dd/MM/yyyy")}";
                    lblSinopsis.Text = $"Sinopsis: {primeraPelicula.overview}";

                    // Descargar la imagen desde la URL
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] data = webClient.DownloadData(urlImage);
                        using (MemoryStream ms = new MemoryStream(data))
                        {
                            // Crear un objeto de imagen desde la secuencia de bytes descargada
                            Image imagen = Image.FromStream(ms);

                            // Asignar la imagen al PictureBox en el formulario
                            pictureBox1.Image = imagen;
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }

                    // Obtener y mostrar películas similares
                    var peliculasSimilares = await ObtenerPeliculasSimilares(primeraPelicula.Id);
                    MostrarPeliculasSimilares(peliculasSimilares);
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados para la película especificada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar la película: {ex.Message}");
            }
        }

        private async Task<List<MovieDetails>> ObtenerPeliculasSimilares(int peliculaId)
        {
            using var httpClient = new HttpClient();
            var url = $"https://api.themoviedb.org/3/movie/{peliculaId}/similar?api_key={TMDbApiKey}";
            var respuesta = await httpClient.GetStringAsync(url);

            var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<TMDbSearchResult<MovieDetails>>(respuesta);
            return resultado.Results;
        }

        private void MostrarPeliculasSimilares(List<MovieDetails> peliculasSimilares)
        {
            // Limpia el ListBox antes de agregar nuevas películas
            listBoxSimilares.Items.Clear();

            if (peliculasSimilares != null && peliculasSimilares.Count > 0)
            {
                foreach (var peliculaSimilar in peliculasSimilares.Take(5))
                {
                    listBoxSimilares.Items.Add($"{peliculaSimilar.title} ({ObtenerAñoEstreno(peliculaSimilar.release_date)})");
                }
            }
            else
            {
                listBoxSimilares.Items.Add("No se encontraron películas similares.");
            }
        }

        private int ObtenerAñoEstreno(string fechaEstreno)
        {
            if (DateTime.TryParse(fechaEstreno, out var fecha))
            {
                return fecha.Year;
            }
            return 0;
        }
    }
}
