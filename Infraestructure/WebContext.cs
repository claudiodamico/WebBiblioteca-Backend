using Microsoft.EntityFrameworkCore;
using System.Data;
using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Infraestructure
{
    public class WebContext : DbContext
    {
        public WebContext() { }

        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=WebBiblioteca;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre Alquiler y Libro (muchos a muchos)
            modelBuilder.Entity<Alquiler>()
                .HasMany(a => a.Libros)
                .WithMany(l => l.Alquileres)
                .UsingEntity<AlquilerLibro>(
                    j => j
                        .HasOne(al => al.Libro)
                        .WithMany()
                        .HasForeignKey(al => al.LibroID),
                    j => j
                        .HasOne(al => al.Alquiler)
                        .WithMany()
                        .HasForeignKey(al => al.AlquilerID)
                );

            // Configuración de la relación entre Alquiler y Cliente (muchos a muchos)
            modelBuilder.Entity<Alquiler>()
                .HasMany(a => a.Clientes)
                .WithMany(c => c.Alquileres)
                .UsingEntity<AlquilerCliente>(
                    j => j
                        .HasOne(ac => ac.Cliente)
                        .WithMany()
                        .HasForeignKey(ac => ac.ClienteID),
                    j => j
                        .HasOne(ac => ac.Alquiler)
                        .WithMany()
                        .HasForeignKey(ac => ac.AlquilerID)
                );
          
            modelBuilder.Entity<Libro>().HasData(
               new Libro
               {
                   LibroID = 1,
                   Nombre = "Cementerio de animales",
                   Autor = "Stephen King",
                   FechaPublicacion = new DateTime(2023, 10, 15),
                   ISBN = "9789877255133",
                   Paginas = 488,
                   Clasificacion = "Suspenso",
                   Idioma = "Español",
                   Imagen = "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704929.jpg",
                   Stock = 10
               },
               new Libro
               {
                   LibroID = 2,
                   Nombre = "Doctor sueño",
                   Autor = "Stephen King",
                   FechaPublicacion = new DateTime(2020, 5, 13),
                   ISBN = "9789877255164",
                   Paginas = 608,
                   Clasificacion = "Suspenso",
                   Idioma = "Español",
                   Imagen = "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704922.jpg",
                   Stock = 10
               },
               new Libro
               {
                   LibroID = 3,
                   Nombre = "La milla verde",
                   Autor = "Stephen King",
                   FechaPublicacion = new DateTime(2022, 7, 11),
                   ISBN = "9789877255195",
                   Paginas = 448,
                   Clasificacion = "Suspenso",
                   Idioma = "Español",
                   Imagen = "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704927.jpg",
                   Stock = 10
               },
               new Libro
               {
                   LibroID = 4,
                   Nombre = "Misery",
                   Autor = "Stephen King",
                   FechaPublicacion = new DateTime(2019, 1, 1),
                   ISBN = "9789877255089",
                   Paginas = 400,
                   Clasificacion = "Suspenso",
                   Idioma = "Español",
                   Imagen = "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704219.jpg",
                   Stock = 10
               },
               new Libro
               {
                   LibroID = 5,
                   Nombre = "La zona muerta",
                   Autor = "Stephen King",
                   FechaPublicacion = new DateTime(2022, 10, 10),
                   ISBN = "9789877255218",
                   Paginas = 456,
                   Clasificacion = "Terror",
                   Idioma = "Español",
                   Imagen = "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/699599.jpg",
                   Stock = 10
               },
               new Libro
               {
                   LibroID = 6,
                   Nombre = "It",
                   Autor = "Stephen King",
                   FechaPublicacion = new DateTime(2018, 10, 23),
                   ISBN = "9789877255300",
                   Paginas = 1504,
                   Clasificacion = "Suspenso",
                   Idioma = "Español",
                   Imagen = "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704323.jpg",
                   Stock = 10
               },
               new Libro
               {
                   LibroID = 7,
                   Nombre = "Carrie",
                   Autor = "Stephen King",
                   FechaPublicacion = new DateTime(2018, 3, 23),
                   ISBN = "9789877255058",
                   Paginas = 256,
                   Clasificacion = "Suspenso",
                   Idioma = "Español",
                   Imagen = "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704940.jpg",
                   Stock = 10
               },
                new Libro
                {
                    LibroID = 8,
                    Nombre = "El resplandor",
                    Autor = "Stephen King",
                    FechaPublicacion = new DateTime(2023, 8, 29),
                    ISBN = "9789877255140",
                    Paginas = 656,
                    Clasificacion = "Suspenso",
                    Idioma = "Español",
                    Imagen = "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704925.jpg",
                    Stock = 10
                },
                new Libro
                {
                    LibroID = 9,
                    Nombre = "La niebla",
                    Autor = "Stephen King",
                    FechaPublicacion = new DateTime(2023, 10, 12),
                    ISBN = "9875661244",
                    Paginas = 320,
                    Clasificacion = "Suspenso",
                    Idioma = "Español",
                    Imagen = "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/421497.jpg",
                    Stock = 10
                },
                new Libro
                {
                    LibroID = 10,
                    Nombre = "Mientras escribo",
                    Autor = "Stephen King",
                    FechaPublicacion = new DateTime(2023, 5, 13),
                    ISBN = "9871138989",
                    Paginas = 320,
                    Clasificacion = "Suspenso",
                    Idioma = "Español",
                    Imagen = "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/384849.jpg",
                    Stock = 10
                }
            );
        }
    }
}
