using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controller.Migrations
{
    /// <inheritdoc />
    public partial class EnableGlobalQueryFilters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrackingToken",
                value: "def71be7-afa9-4f2b-b2e9-ea30e827d5a5");

            migrationBuilder.UpdateData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrackingToken",
                value: "e20cdc80-b45c-4431-8d63-88457c1edb06");

            migrationBuilder.UpdateData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 3,
                column: "TrackingToken",
                value: "296deb35-8d51-4021-8ee5-f1f59d6da558");

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 12, 0, 58, 246, DateTimeKind.Utc).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 12, 0, 58, 246, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 12, 0, 58, 246, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 12, 0, 58, 246, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 13, 12, 0, 57, 966, DateTimeKind.Utc).AddTicks(1662), "$2a$11$iHdjFkq8T3WHM.qZtvO9ZOFqtYRNlzMZ9XA4bDQ0qlsLw/NWvaMPK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrackingToken",
                value: "49911852-590d-420d-a2c7-27c8b5c8d125");

            migrationBuilder.UpdateData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrackingToken",
                value: "a9b5eca9-e39f-420c-8b0f-0a192a693d1d");

            migrationBuilder.UpdateData(
                table: "RiwayatPinjams",
                keyColumn: "Id",
                keyValue: 3,
                column: "TrackingToken",
                value: "b91a2859-6cc2-4d91-8611-3dc9b26b78cb");

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 20, 21, 13, 869, DateTimeKind.Utc).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 20, 21, 13, 869, DateTimeKind.Utc).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 20, 21, 13, 869, DateTimeKind.Utc).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "Ruangans",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 12, 20, 21, 13, 869, DateTimeKind.Utc).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 12, 20, 21, 13, 868, DateTimeKind.Utc).AddTicks(7819), "AdminPasswordHash" });
        }
    }
}
