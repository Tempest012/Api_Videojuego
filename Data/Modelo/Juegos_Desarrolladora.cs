namespace Api_Videojuego.Data.Modelo
{
    public class Juegos_Desarrolladora
    {
        public int Id { get; set; }
        public int IdJuegos { get; set; }
        public Juegos Juegos { get; set; }
        public int IdDesarrolladora { get; set; }
        public Desarrolladora Desarrolladora { get; set; }
    }
}
