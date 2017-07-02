using ShoppingCartWeb.Repositories;
namespace ShoppingCartWeb.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Album Album { get; set; }
        public Album GetAlbum()
        {
            return new AlbumRepository().Get(this.AlbumId);
        }
        public virtual Order Order { get; set; }
    }
}