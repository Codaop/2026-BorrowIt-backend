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
                    Roles = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    WhenStatusChanged = table.Column<DateTime>(type: "datetime(6)", nullable: true),
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
                    { 1, new DateTime(2026, 2, 12, 20, 14, 42, 707, DateTimeKind.Utc).AddTicks(3438), true, "Laboratorium Praktek", 30, "B302" },
                    { 2, new DateTime(2026, 2, 12, 20, 14, 42, 707, DateTimeKind.Utc).AddTicks(4365), true, "Kelas Besar", 140, "SAW 10.08" },
                    { 3, new DateTime(2026, 2, 12, 20, 14, 42, 707, DateTimeKind.Utc).AddTicks(4366), true, "Kelas Reguler", 40, "A302" },
                    { 4, new DateTime(2026, 2, 12, 20, 14, 42, 707, DateTimeKind.Utc).AddTicks(4367), true, "Kelas Reguler", 60, "A303" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "Roles", "Username" },
                values: new object[] { 1, new DateTime(2026, 2, 12, 20, 14, 42, 706, DateTimeKind.Utc).AddTicks(3255), "admin@example.com", "AdminPasswordHash", "User", "Admin" });

            migrationBuilder.InsertData(
                table: "RiwayatPinjams",
                columns: new[] { "Id", "Email", "IdRuangan", "IsDeleted", "NamaPeminjam", "Status", "TanggalKembali", "TanggalPinjam", "TrackingToken", "TujuanPinjam", "WhenStatusChanged" },
                values: new object[,]
                {
                    { 1, "syauqy@it.student.pens.ac.id", 2, false, "Syauqy Arrayyan", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "5e00bf45-0ca6-4438-bd37-ea4f7392afcb", "Kegiatan welcome party anggota baru ENT 2026.", null },
                    { 2, "nabila@it.student.pens.ac.id", 3, false, "Nabila Azzahra", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "023c6597-8ca0-4bc2-899d-265c378848c9", "Forum komunal mahasiswa teknik elektro.", null },
                    { 3, "yayan@it.student.pens.ac.id", 4, false, "Yayan Maulana", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "a95af082-2927-4806-947a-98d773d676c1", "Rapat kerja kelompok praktikum Rangkaian Listrik.", null }
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
