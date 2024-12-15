using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParametrosResto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Archivos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4873));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bodegas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cajas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cargos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4887));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4630));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4920));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5258));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5261));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5263));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5265));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5267));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5269));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5271));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5329));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5332));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5334));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5336));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5338));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5339));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5341));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5343));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5347));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5349));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5351));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5456));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5515));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5517));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5519));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5521));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5523));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5525));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5527));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5534));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5536));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5538));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5540));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5542));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5544));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5546));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5548));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5550));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5552));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5554));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5556));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5562));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5563));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5565));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5567));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5569));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5571));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5573));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5575));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5635));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5645));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5647));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5649));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5651));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5653));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5655));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5657));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5658));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5660));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5662));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5706));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5710));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5712));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5764));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5766));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5768));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5770));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5773));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5775));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5777));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5778));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5781));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5783));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5785));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5787));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5791));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5793));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5843));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5845));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5847));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5849));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5851));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5853));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5855));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5857));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5859));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5862));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5864));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5866));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5868));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5870));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5871));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5873));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5931));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5943));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5947));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Insumos",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "DeleteAt", "Descripcion", "Nombre", "UnidadMedidaId", "UpdateAt" },
                values: new object[] { 1, true, "01", new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4414), null, "HAMBURGUESA SENCILLA", "SENCILLA", 1, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Inventarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4273));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MacroCategorias",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "DeleteAt", "Nombre", "UpdateAt" },
                values: new object[,]
                {
                    { 1, true, "01", new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4301), null, "COMIDA", null },
                    { 2, true, "02", new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4302), null, "BEBIDA", null }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4224));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Mesas",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "Cupo", "DeleteAt", "Descripcion", "EstadoId", "Nombre", "SalonId", "UpdateAt" },
                values: new object[,]
                {
                    { 1, true, "01", new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(3974), 4, null, "", 1, "MESA 1", 1, null },
                    { 2, true, "02", new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(3981), 4, null, "", 1, "MESA 2", 1, null },
                    { 3, true, "03", new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(3985), 4, null, "", 1, "MESA 3", 1, null },
                    { 4, true, "04", new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(3989), 4, null, "", 1, "MESA 4", 1, null },
                    { 5, true, "05", new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(3992), 4, null, "", 1, "MESA 5", 1, null }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5422));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5424));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5425));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5426));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5428));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5429));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5431));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5432));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4092));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4093));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4094));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4096));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4160));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4162));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4067));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Direccion", "Documento", "Email", "PrimerApellido", "PrimerNombre", "Telefono" },
                values: new object[] { new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4686), "calle 48 # 24 - 93", "1003828711", "josepoza125@gmail.com", "Zambrano", "Johan", "3124888633" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4025));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4027));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4029));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Salones",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(3915));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposCostos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(5376));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4936));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4938));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4939));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4941));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4942));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4943));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4252));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4254));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UserName" },
                values: new object[] { new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4710), "sebas" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UsuariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zonas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(3665));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Categorias",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "DeleteAt", "MacroCategoriaId", "Nombre", "UpdateAt" },
                values: new object[] { 1, true, "01", new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4333), null, 1, "HAMBURGUESAS", null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "InventariosDetalles",
                columns: new[] { "Id", "Activo", "CantidadIngresada", "CantidadTotal", "CantidadUsada", "CreateAt", "DeleteAt", "InsumoId", "InventarioId", "PrecioCosto", "UpdateAt" },
                values: new object[] { 1, true, 10m, 10m, 0m, new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4452), null, 1, 1, 0m, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "DetallesInventariosBodegas",
                columns: new[] { "Id", "Activo", "BodegaId", "Cantidad", "CreateAt", "DeleteAt", "InventarioDetalleId", "UpdateAt" },
                values: new object[] { 1, true, 1, 10m, new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4572), null, 1, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Productos",
                columns: new[] { "Id", "Activo", "CategoriaId", "Codigo", "CreateAt", "DeleteAt", "DescripcionCorta", "DescripcionLarga", "Descuento", "Iva", "Nombre", "Precio", "PrecioCosto", "UpdateAt" },
                values: new object[] { 1, true, 1, "01", new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4388), null, "HAMBURGUESA SENCILLA", "HAMBURGUESA SENCILLA", 0m, 0m, "SENCILLA", 14000m, 0m, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "InsumosProductos",
                columns: new[] { "Id", "Activo", "Adicional", "Cantidad", "CreateAt", "DeleteAt", "InsumoId", "ProductoId", "UnidadMedidaId", "UpdateAt" },
                values: new object[] { 1, true, false, 1m, new DateTime(2024, 4, 15, 1, 54, 55, 381, DateTimeKind.Utc).AddTicks(4431), null, 1, 1, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "DetallesInventariosBodegas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "InsumosProductos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MacroCategorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "InventariosDetalles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Insumos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MacroCategorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Archivos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1194));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bodegas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(840));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cajas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(955));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cargos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1235));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(538));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(723));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(444));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1329));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1147));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1421));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1427));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1434));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1439));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1442));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1447));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1451));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1460));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1762));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1766));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1772));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1776));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1780));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1784));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1788));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1794));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1797));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2107));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2112));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2115));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2119));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2209));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2212));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2216));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2222));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2226));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2243));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2247));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2254));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2259));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2266));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2270));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2274));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2278));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2282));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2292));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2296));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2299));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2302));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2306));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2375));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2384));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2388));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2391));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2399));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2402));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2406));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2414));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2476));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2484));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2488));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2495));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2498));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2562));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2566));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2569));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2573));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2577));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2581));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2585));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2589));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2593));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2598));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2601));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2605));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2609));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2616));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2692));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2698));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2702));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2705));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2708));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2712));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2715));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2719));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2722));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2726));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2731));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2734));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2739));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2742));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2747));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2817));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2822));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2826));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2829));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2833));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2836));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2840));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2844));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Inventarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9933));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9944));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9947));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2034));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2039));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2042));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2044));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2049));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2051));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2053));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2056));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9771));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9780));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9783));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9786));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9726));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(344));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Direccion", "Documento", "Email", "PrimerApellido", "PrimerNombre", "Telefono" },
                values: new object[] { new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(637), "calle", "105154151", "jwca19@gmail.com", "Corredor", "Jhon", "3112136100" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(644));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9539));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9542));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9545));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Salones",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9115));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposCostos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1867));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1363));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1370));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1372));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1377));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(26));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(31));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "UserName" },
                values: new object[] { new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(682), "jwca" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UsuariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Zonas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(8366));
        }
    }
}
