using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controller.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusTrackingRiwayatPinjam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WhenStatusChanged",
                table: "RiwayatPinjams",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 1,
                column: "WhenStatusChanged",
                value: null);

            migrationBuilder.UpdateData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 2,
                column: "WhenStatusChanged",
                value: null);

            migrationBuilder.UpdateData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 3,
                column: "WhenStatusChanged",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 11, 15, 18, 46, 27, DateTimeKind.Utc).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 11, 15, 18, 46, 27, DateTimeKind.Utc).AddTicks(3326));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 11, 15, 18, 46, 27, DateTimeKind.Utc).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 11, 15, 18, 46, 27, DateTimeKind.Utc).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 11, 15, 18, 46, 28, DateTimeKind.Utc).AddTicks(5924), "$2a$11$nKo2QWmAU87WEKdtSCFdfO8R1a1N1jjWeCJI76P4SvmKXiYwDFvXa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhenStatusChanged",
                table: "RiwayatPinjams");

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 11, 5, 26, 30, 854, DateTimeKind.Utc).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 11, 5, 26, 30, 854, DateTimeKind.Utc).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 11, 5, 26, 30, 854, DateTimeKind.Utc).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 11, 5, 26, 30, 854, DateTimeKind.Utc).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 11, 5, 26, 30, 855, DateTimeKind.Utc).AddTicks(3620), "$2a$11$mo3gmTqO1MrItcFj.DM0C.VvNy6gH4Mmq4Oh4gf3OeAaBIF2/px9y" });
        }
    }
}
