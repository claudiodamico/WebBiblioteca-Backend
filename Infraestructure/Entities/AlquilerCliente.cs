namespace WebBiblioteca.Infraestructure.Entities
{
    public class AlquilerCliente
    {
        public int AlquilerID { get; set; }  
        public int ClienteID { get; set; }   
        public Alquiler Alquiler { get; set; }
        public Cliente Cliente { get; set; }
    }
}
