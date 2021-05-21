using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMatic.Migrations
{
    public partial class AgregamosCambiosNuevosBDMODEL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AM_BLOQUE",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BLOQUE = table.Column<long>(type: "bigint", nullable: true),
                    HORA = table.Column<TimeSpan>(type: "time", nullable: true),
                    ESTADO = table.Column<bool>(type: "bit", nullable: true),
                    LIMITE = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_BLOQUE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AM_USUARIO",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    APELLIDO = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CORREO = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CONTRASENA = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ESTADO = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AM_CITA",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DESCRIPCION = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ID_BLOQUE = table.Column<long>(type: "bigint", nullable: true),
                    ID_USUARIO = table.Column<long>(type: "bigint", nullable: true),
                    FECHA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ESTADO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_CITA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AM_CITA_AM_BLOQUE",
                        column: x => x.ID_BLOQUE,
                        principalTable: "AM_BLOQUE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AM_CITA_AM_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "AM_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AM_LOG",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MENSAJE = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    FECHA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ID_USUARIO = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_LOG", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AM_LOG_AM_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "AM_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AmParticipantes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAmCita = table.Column<long>(type: "bigint", nullable: true),
                    IdAmUsuario = table.Column<long>(type: "bigint", nullable: true),
                    IdAmCitaNavigationId = table.Column<long>(type: "bigint", nullable: true),
                    IdAmUsuarioNavigationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmParticipantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmParticipantes_AM_CITA_IdAmCitaNavigationId",
                        column: x => x.IdAmCitaNavigationId,
                        principalTable: "AM_CITA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AmParticipantes_AM_USUARIO_IdAmUsuarioNavigationId",
                        column: x => x.IdAmUsuarioNavigationId,
                        principalTable: "AM_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AM_CITA_ID_BLOQUE",
                table: "AM_CITA",
                column: "ID_BLOQUE");

            migrationBuilder.CreateIndex(
                name: "IX_AM_CITA_ID_USUARIO",
                table: "AM_CITA",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_AM_LOG_ID_USUARIO",
                table: "AM_LOG",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_AmParticipantes_IdAmCitaNavigationId",
                table: "AmParticipantes",
                column: "IdAmCitaNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_AmParticipantes_IdAmUsuarioNavigationId",
                table: "AmParticipantes",
                column: "IdAmUsuarioNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AM_LOG");

            migrationBuilder.DropTable(
                name: "AmParticipantes");

            migrationBuilder.DropTable(
                name: "AM_CITA");

            migrationBuilder.DropTable(
                name: "AM_BLOQUE");

            migrationBuilder.DropTable(
                name: "AM_USUARIO");
        }
    }
}
