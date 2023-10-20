namespace WebBiblioteca.Infraestructure.Entities
{
    public class AlquilerLibro
    {
        public int AlquilerID { get; set; } 
        public int LibroID { get; set; }    
        public Alquiler Alquiler { get; set; }
        public Libro Libro { get; set; }
    }

}
