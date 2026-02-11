using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Controller.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeederAndMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ruangans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NamaRuangan = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kapasitas = table.Column<int>(type: "int", nullable: false),
                    JenisRuangan = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsTersedia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruangans", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RiwayatPinjams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdRuangan = table.Column<int>(type: "int", nullable: false),
                    TrackingToken = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NamaPeminjam = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TanggalPinjam = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TanggalKembali = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TujuanPinjam = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiwayatPinjams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiwayatPinjams_Ruangans_IdRuangan",
                        column: x => x.IdRuangan,
                        principalTable: "Ruangans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Ruangans",
                columns: new[] { "Id", "CreatedAt", "IsTersedia", "JenisRuangan", "Kapasitas", "NamaRuangan" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 11, 5, 26, 30, 854, DateTimeKind.Utc).AddTicks(358), true, "Laboratorium Praktek", 30, "B302" },
                    { 2, new DateTime(2026, 2, 11, 5, 26, 30, 854, DateTimeKind.Utc).AddTicks(1481), true, "Kelas Besar", 140, "SAW 10.08" },
                    { 3, new DateTime(2026, 2, 11, 5, 26, 30, 854, DateTimeKind.Utc).AddTicks(1483), true, "Kelas Reguler", 40, "A302" },
                    { 4, new DateTime(2026, 2, 11, 5, 26, 30, 854, DateTimeKind.Utc).AddTicks(1484), true, "Kelas Reguler", 60, "A303" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "Username" },
                values: new object[] { 1, new DateTime(2026, 2, 11, 5, 26, 30, 855, DateTimeKind.Utc).AddTicks(3620), "admin@example.com", "$2a$11$mo3gmTqO1MrItcFj.DM0C.VvNy6gH4Mmq4Oh4gf3OeAaBIF2/px9y", "Admin" });

            migrationBuilder.InsertData(
                table: "RiwayatPinjams",
                columns: new[] { "Id", "Email", "IdRuangan", "IsDeleted", "NamaPeminjam", "Status", "TanggalKembali", "TanggalPinjam", "TrackingToken", "TujuanPinjam" },
                values: new object[,]
                {
                    { 1, "syauqy@it.student.pens.ac.id", 2, false, "Syauqy Arrayyan", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "", "Kegiatan welcome party anggota baru ENT 2026." },
                    { 2, "nabila@it.student.pens.ac.id", 3, false, "Nabila Azzahra", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "", "Forum komunal mahasiswa teknik elektro." },
                    { 3, "yayan@it.student.pens.ac.id", 4, false, "Yayan Maulana", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "", "Rapat kerja kelompok praktikum Rangkaian Listrik." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiwayatPinjams_IdRuangan",
                table: "RiwayatPinjams",
                column: "IdRuangan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiwayatPinjams");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ruangans");
        }
    }
}
