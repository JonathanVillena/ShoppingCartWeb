using System;
using System.Collections.Generic;

namespace ShoppingCartWeb.Models
{
    public class Album
    {
        public Album()
        {

        }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }

    }
}
