using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    AlquilerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSocio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlquiler = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.AlquilerID);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    NumeroSocio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    LibroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paginas = table.Column<int>(type: "int", nullable: false),
                    Clasificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idioma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.LibroID);
                });

            migrationBuilder.CreateTable(
                name: "AlquilerCliente",
                columns: table => new
                {
                    AlquilerID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlquilerCliente", x => new { x.AlquilerID, x.ClienteID });
                    table.ForeignKey(
                        name: "FK_AlquilerCliente_Alquileres_AlquilerID",
                        column: x => x.AlquilerID,
                        principalTable: "Alquileres",
                        principalColumn: "AlquilerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlquilerCliente_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlquilerLibro",
                columns: table => new
                {
                    AlquilerID = table.Column<int>(type: "int", nullable: false),
                    LibroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlquilerLibro", x => new { x.AlquilerID, x.LibroID });
                    table.ForeignKey(
                        name: "FK_AlquilerLibro_Alquileres_AlquilerID",
                        column: x => x.AlquilerID,
                        principalTable: "Alquileres",
                        principalColumn: "AlquilerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlquilerLibro_Libros_LibroID",
                        column: x => x.LibroID,
                        principalTable: "Libros",
                        principalColumn: "LibroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteLibro",
                columns: table => new
                {
                    ClientesClienteID = table.Column<int>(type: "int", nullable: false),
                    LibrosLibroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteLibro", x => new { x.ClientesClienteID, x.LibrosLibroID });
                    table.ForeignKey(
                        name: "FK_ClienteLibro_Clientes_ClientesClienteID",
                        column: x => x.ClientesClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteLibro_Libros_LibrosLibroID",
                        column: x => x.LibrosLibroID,
                        principalTable: "Libros",
                        principalColumn: "LibroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "LibroID", "Autor", "Clasificacion", "Disponible", "FechaPublicacion", "ISBN", "Idioma", "Imagen", "Nombre", "Paginas", "Stock" },
                values: new object[,]
                {
                    { 1, "Stephen King", "Suspenso", true, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789877255133", "Español", "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704929.jpg", "Cementerio de animales", 488, 10 },
                    { 2, "Stephen King", "Suspenso", true, new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789877255164", "Español", "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704922.jpg", "Doctor sueño", 608, 10 },
                    { 3, "Stephen King", "Suspenso", true, new DateTime(2022, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789877255195", "Español", "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704927.jpg", "La milla verde", 448, 10 },
                    { 4, "Stephen King", "Suspenso", true, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789877255089", "Español", "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704219.jpg", "Misery", 400, 10 },
                    { 5, "Stephen King", "Terror", true, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789877255218", "Español", "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/699599.jpg", "La zona muerta", 456, 10 },
                    { 6, "Stephen King", "Suspenso", true, new DateTime(2018, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789877255300", "Español", "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704323.jpg", "It", 1504, 10 },
                    { 7, "Stephen King", "Suspenso", true, new DateTime(2018, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789877255058", "Español", "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704940.jpg", "Carrie", 256, 10 },
                    { 8, "Stephen King", "Suspenso", true, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "9789877255140", "Español", "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/704925.jpg", "El resplandor", 656, 10 },
                    { 9, "Stephen King", "Suspenso", true, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "9875661244", "Español", "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/421497.jpg", "La niebla", 320, 10 },
                    { 10, "Stephen King", "Suspenso", true, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "9871138989", "Español", "https://www.tematika.com/media/catalog/Ilhsa/Imagenes/384849.jpg", "Mientras escribo", 320, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlquilerCliente_ClienteID",
                table: "AlquilerCliente",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_AlquilerLibro_LibroID",
                table: "AlquilerLibro",
                column: "LibroID");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteLibro_LibrosLibroID",
                table: "ClienteLibro",
                column: "LibrosLibroID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlquilerCliente");

            migrationBuilder.DropTable(
                name: "AlquilerLibro");

            migrationBuilder.DropTable(
                name: "ClienteLibro");

            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
