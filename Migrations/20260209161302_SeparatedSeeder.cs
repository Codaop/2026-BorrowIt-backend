using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Controller.Migrations
{
    /// <inheritdoc />
    public partial class SeparatedSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ruangans",
                columns: new[] { "Id", "CreatedAt", "IsTersedia", "JenisRuangan", "Kapasitas", "NamaRuangan" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 9, 16, 13, 1, 770, DateTimeKind.Utc).AddTicks(9988), true, "Laboratorium Praktek", 30, "B302" },
                    { 2, new DateTime(2026, 2, 9, 16, 13, 1, 771, DateTimeKind.Utc).AddTicks(892), true, "Kelas Besar", 140, "SAW 10.08" },
                    { 3, new DateTime(2026, 2, 9, 16, 13, 1, 771, DateTimeKind.Utc).AddTicks(893), true, "Kelas Reguler", 40, "A302" },
                    { 4, new DateTime(2026, 2, 9, 16, 13, 1, 771, DateTimeKind.Utc).AddTicks(894), true, "Kelas Reguler", 60, "A303" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "Username" },
                values: new object[] { 1, new DateTime(2026, 2, 9, 16, 13, 1, 772, DateTimeKind.Utc).AddTicks(5081), "admin@example.com", "AdminPasswordHash", "Admin" });

            migrationBuilder.InsertData(
                table: "RiwayatPinjams",
                columns: new[] { "Id", "Email", "IdRuangan", "IsDeleted", "NamaPeminjam", "Status", "TanggalKembali", "TanggalPinjam", "TrackingToken", "TujuanPinjam" },
                values: new object[,]
                {
                    { 1, "syauqy@it.student.pens.ac.id", 4, false, "Syauqy Arrayyan", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "", "Kegiatan welcome party anggota baru ENT 2026." },
                    { 2, "nabila@it.student.pens.ac.id", 1, false, "Nabila Azzahra", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "", "Forum komunal mahasiswa teknik elektro." },
                    { 3, "yayan@it.student.pens.ac.id", 3, false, "Yayan Maulana", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "", "Rapat kerja kelompok praktikum Rangkaian Listrik." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
