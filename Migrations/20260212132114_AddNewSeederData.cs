using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Controller.Migrations
{
    /// <inheritdoc />
    public partial class AddNewSeederData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ruangans",
                columns: new[] { "Id", "CreatedAt", "IsTersedia", "JenisRuangan", "Kapasitas", "NamaRuangan" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 12, 20, 21, 13, 869, DateTimeKind.Utc).AddTicks(8499), true, "Laboratorium Praktek", 30, "B302" },
                    { 2, new DateTime(2026, 2, 12, 20, 21, 13, 869, DateTimeKind.Utc).AddTicks(9514), true, "Kelas Besar", 140, "SAW 10.08" },
                    { 3, new DateTime(2026, 2, 12, 20, 21, 13, 869, DateTimeKind.Utc).AddTicks(9516), true, "Kelas Reguler", 40, "A302" },
                    { 4, new DateTime(2026, 2, 12, 20, 21, 13, 869, DateTimeKind.Utc).AddTicks(9517), true, "Kelas Reguler", 60, "A303" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "Roles", "Username" },
                values: new object[] { 1, new DateTime(2026, 2, 12, 20, 21, 13, 868, DateTimeKind.Utc).AddTicks(7819), "admin@example.com", "AdminPasswordHash", "User", "Admin" });

            migrationBuilder.InsertData(
                table: "RiwayatPinjams",
                columns: new[] { "Id", "Email", "IdRuangan", "IsDeleted", "NamaPeminjam", "Status", "TanggalKembali", "TanggalPinjam", "TrackingToken", "TujuanPinjam", "WhenStatusChanged" },
                values: new object[,]
                {
                    { 1, "syauqy@it.student.pens.ac.id", 2, false, "Syauqy Arrayyan", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "49911852-590d-420d-a2c7-27c8b5c8d125", "Kegiatan welcome party anggota baru ENT 2026.", null },
                    { 2, "nabila@it.student.pens.ac.id", 3, false, "Nabila Azzahra", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "a9b5eca9-e39f-420c-8b0f-0a192a693d1d", "Forum komunal mahasiswa teknik elektro.", null },
                    { 3, "yayan@it.student.pens.ac.id", 4, false, "Yayan Maulana", "Pending", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "b91a2859-6cc2-4d91-8611-3dc9b26b78cb", "Rapat kerja kelompok praktikum Rangkaian Listrik.", null }
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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 2);

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
