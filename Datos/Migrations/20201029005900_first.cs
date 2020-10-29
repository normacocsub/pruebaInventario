using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Numero = table.Column<string>(nullable: false),
                    Identificacion = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Sexo = table.Column<string>(nullable: true),
                    CodigoAsignatura = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Asignaturas_CodigoAsignatura",
                        column: x => x.CodigoAsignatura,
                        principalTable: "Asignaturas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    Numero = table.Column<string>(nullable: false),
                    Fecha = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    CodigoInsumo = table.Column<string>(nullable: true),
                    SolicitudNumero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_Detalle_Insumos_CodigoInsumo",
                        column: x => x.CodigoInsumo,
                        principalTable: "Insumos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detalle_Solicitudes_SolicitudNumero",
                        column: x => x.SolicitudNumero,
                        principalTable: "Solicitudes",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_CodigoInsumo",
                table: "Detalle",
                column: "CodigoInsumo");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_SolicitudNumero",
                table: "Detalle",
                column: "SolicitudNumero");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_CodigoAsignatura",
                table: "Solicitudes",
                column: "CodigoAsignatura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Asignaturas");
        }
    }
}
