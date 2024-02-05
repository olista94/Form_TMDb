using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_TMDb.Models
{

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
