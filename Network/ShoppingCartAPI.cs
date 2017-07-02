namespace ShoppingCartWeb.Network
{
    public static class ShoppingCartAPI
    {
        public static string Audience = "http://localhost:44307";
        public static string Issuer = "ShoppingCart";
        public static string SigningKey = "cc4435685b40b2e9ddcb357fd79423b2d8e293b897d86f5336cb61c5fd31c9a3";
        public static string BaseApiURL = "http://localhost:5001";
        public static string AlbumURL = BaseApiURL + "/api/Albums";
        public static string ArtistURL = BaseApiURL + "/api/Artists";
        public static string GenreURL = BaseApiURL + "/api/Genres";
        public static string CartURL = BaseApiURL + "/api/Carts";
        public static string OrderURL = BaseApiURL + "/api/Orders";
        public static string OrderDetailURL = BaseApiURL + "/api/OrderDetails";
        public static string ShoppingCartURL = BaseApiURL + "/api/ShoppingCarts";
        public static string AddToCartURL = ShoppingCartURL + "/AddToCart";
        public static string RemoveFromCartURL = ShoppingCartURL + "/RemoveFromCart";
        public static string AddressAndPaymentURL = BaseApiURL + "/api/Checkout/AddressAndPayment";
        public static string MigrateCartURL = BaseApiURL + "/api/Checkout/AddressAndPayment";
    }
}