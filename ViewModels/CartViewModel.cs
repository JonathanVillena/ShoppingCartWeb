using System;
using ShoppingCartWeb.Models;
using System.Collections;
using System.Collections.Generic;

namespace ShoppingCartWeb.ViewModels
{
    public class CartViewModel
    {
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
    public class CartDeleteViewModel
    {
        public string ShoppingCartId { get; set; }
        public int RecordId { get; set; }
    }
    public class MigrateCardViewModel
    {
        public string OldCartId { get; set; }
        public string CartId { get; set; }
    }
}