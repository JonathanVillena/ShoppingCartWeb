using System;

namespace ShoppingCartWeb.Models
{
    public class Cart
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Album Album { get; set; }
        public Album GetAlbum()
        {
            return new ShoppingCartWeb.Repositories.AlbumRepository().Get(this.AlbumId);
        }
    }
}