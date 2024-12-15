using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class ParametrosInicialesResto : Migration
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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Formularios",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "DeleteAt", "Icono", "ModuloId", "Nombre", "SuperAdmin", "UpdateAt", "Url" },
                values: new object[] { 41, true, "41", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2402), null, "fa-duotone fa-print", 2, "Impresoras", false, null, "parametros/impresoras" });

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Modulos",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "DeleteAt", "Icono", "Nombre", "UpdateAt" },
                values: new object[,]
                {
                    { 5, true, "05", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2049), null, "fa-duotone fa-store", "Distribucion", null },
                    { 6, true, "06", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2051), null, "fa-duotone fa-kitchen-set", "Resto", null },
                    { 7, true, "07", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2053), null, "fa-duotone fa-cash-register", "Pos", null },
                    { 8, true, "08", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2056), null, "fa-duotone fa-sliders", "Indicadores", null }
                });

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                columns: new[] { "Id", "Activo", "Autorizacion", "Codigo", "CreateAt", "DeleteAt", "Nombre", "NumActual", "NumFinal", "NumInicial", "Prefijo", "Resolucion", "UpdateAt" },
                values: new object[,]
                {
                    { 2, true, "Facturación POS autorizada por la DIAN desde FVP - 1 hasta FVP - 100 documento oficial autorizado por Numeración de Facturación 18764063880084 del 17 de Enero del 2024 con vigencia hasta el 17 de Julio del 2024", "POS", new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9726), null, "FVP 1 - 100", 0, 1000, 0, "FVP", "18764063880084", null },
                    { 3, true, "REMISIÓN", "RM", new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9730), null, "RM", 0, 1000, 0, "RM", "0", null }
                });

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
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(637));

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TiposEstados",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "DeleteAt", "Nombre", "UpdateAt" },
                values: new object[,]
                {
                    { 4, true, "03", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1370), null, "SALON", null },
                    { 5, true, "04", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1372), null, "MESA", null },
                    { 6, true, "05", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1374), null, "ORDEN", null },
                    { 7, true, "07", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1377), null, "ORDEN DETALLE", null }
                });

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
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(682));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UsuariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Zonas",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "DeleteAt", "Nombre", "UpdateAt" },
                values: new object[] { 1, true, "01", new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(8366), null, "PRINCIPAL", null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Estados",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "DeleteAt", "Nombre", "TipoEstadoId", "UpdateAt" },
                values: new object[,]
                {
                    { 8, true, "01", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1455), null, "DISPONIBLE", 4, null },
                    { 9, true, "02", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1460), null, "MANTENIMIENTO", 4, null },
                    { 10, true, "MESADISPONIBLE", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1757), null, "DISPONIBLE", 5, null },
                    { 11, true, "MESAOCUPADA", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1762), null, "OCUPADA", 5, null },
                    { 12, true, "MESARESERVADA", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1766), null, "RESERVADA", 5, null },
                    { 13, true, "ENPROCESO", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1772), null, "EN PROCESO", 6, null },
                    { 14, true, "ORDENFACTURADA", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1776), null, "FACTURADA", 6, null },
                    { 15, true, "07", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1780), null, "ENTREGADO", 7, null },
                    { 16, true, "08", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1784), null, "CANCELADA", 7, null },
                    { 17, true, "09", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1788), null, "FACTURADA", 7, null },
                    { 18, true, "10", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1794), null, "NO FACTURADA", 7, null },
                    { 19, true, "PREPARACION", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(1797), null, "PREPARACION", 7, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Formularios",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "DeleteAt", "Icono", "ModuloId", "Nombre", "SuperAdmin", "UpdateAt", "Url" },
                values: new object[,]
                {
                    { 38, true, "38", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2391), null, "fa-duotone fa-store", 5, "Zonas", false, null, "parametros/zonas" },
                    { 39, true, "39", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2395), null, "fa-duotone fa-person-shelter", 5, "Salones", false, null, "parametros/salones" },
                    { 40, true, "40", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2399), null, "fa-duotone fa-table-picnic", 5, "Mesas", false, null, "parametros/mesas" },
                    { 42, true, "42", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2406), null, "fa-duotone fa-dollar-sign", 6, "Propinas", false, null, "operativo/propinas" },
                    { 43, true, "43", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2409), null, "fa-duotone fa-kitchen-set", 8, "Pedidos en cocina", false, null, "operativo/cocina" },
                    { 44, true, "44", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2414), null, "fa-duotone fa-message-pen", 6, "Modificaciones Producto", false, null, "parametros/modificaciones-producto" },
                    { 45, true, "45", new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2417), null, "fa-duotone fa-cart-shopping", 6, "Ordenar", false, null, "operativo/ordenes-resto" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormulariosRoles",
                columns: new[] { "Id", "Activo", "CreateAt", "DeleteAt", "FormularioId", "RolId", "UpdateAt" },
                values: new object[] { 41, true, new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2829), null, 41, 3, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Salones",
                columns: new[] { "Id", "Activo", "Codigo", "CreateAt", "DeleteAt", "Descripcion", "Nombre", "UpdateAt", "ZonaId" },
                values: new object[] { 1, true, "01", new DateTime(2024, 4, 15, 1, 5, 30, 807, DateTimeKind.Utc).AddTicks(9115), null, "", "PRINCIPAL", null, 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "FormulariosRoles",
                columns: new[] { "Id", "Activo", "CreateAt", "DeleteAt", "FormularioId", "RolId", "UpdateAt" },
                values: new object[,]
                {
                    { 38, true, new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2817), null, 38, 3, null },
                    { 39, true, new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2822), null, 39, 3, null },
                    { 40, true, new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2826), null, 40, 3, null },
                    { 42, true, new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2833), null, 42, 3, null },
                    { 43, true, new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2836), null, 43, 3, null },
                    { 44, true, new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2840), null, 44, 3, null },
                    { 45, true, new DateTime(2024, 4, 15, 1, 5, 30, 808, DateTimeKind.Utc).AddTicks(2844), null, 45, 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Salones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Zonas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Archivos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3778));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bodegas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3613));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cajas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3677));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cargos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3824));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3288));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3469));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4224));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3208));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3937));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4020));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4026));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4030));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4155));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4158));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4162));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4165));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4326));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4330));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4338));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4343));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4348));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4354));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4357));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4360));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4363));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4366));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4369));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4372));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4375));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4431));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4434));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4438));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4442));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4453));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4461));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4464));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4467));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4469));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4479));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4602));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4605));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4656));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4719));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4725));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4741));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4758));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4763));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4766));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4827));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4830));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4833));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4848));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4856));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4859));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4865));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4873));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4930));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4934));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4939));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4943));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Inventarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3093));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2985));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2989));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2992));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4280));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4282));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4285));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4287));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2790));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2792));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2797));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2870));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2712));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3143));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3347));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3355));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2028));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(2030));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposCostos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(4196));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3970));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3973));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3974));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3049));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3051));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3053));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3413));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UsuariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 8, 14, 2, 48, 378, DateTimeKind.Utc).AddTicks(3569));
        }
    }
}
