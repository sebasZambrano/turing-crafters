using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMesas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                schema: "dbo",
                table: "Mesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_EstadoId",
                schema: "dbo",
                table: "Mesas",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesas_Estados_EstadoId",
                schema: "dbo",
                table: "Mesas",
                column: "EstadoId",
                principalSchema: "dbo",
                principalTable: "Estados",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesas_Estados_EstadoId",
                schema: "dbo",
                table: "Mesas");

            migrationBuilder.DropIndex(
                name: "IX_Mesas_EstadoId",
                schema: "dbo",
                table: "Mesas");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                schema: "dbo",
                table: "Mesas");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Archivos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3887));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bodegas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3704));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cajas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cargos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3941));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3473));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3621));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4179));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3404));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4035));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3855));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4104));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4109));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4113));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4119));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4121));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4124));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4321));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4324));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4328));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4330));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4333));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4337));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4343));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4349));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4352));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4358));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4361));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4365));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4371));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4378));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4387));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4390));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4394));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4451));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4453));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4456));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4462));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4466));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4469));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4527));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4531));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4536));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4539));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4541));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4544));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4617));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4620));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4623));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4626));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4633));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4638));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4644));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4647));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4651));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4705));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4724));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4731));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4734));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4736));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Inventarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3295));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3147));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3151));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4272));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4275));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4277));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4280));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3032));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3034));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3037));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3040));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3042));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3044));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3047));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(2977));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3348));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3515));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3522));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(2533));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposCostos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4150));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4060));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4062));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3202));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3205));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3208));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3561));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UsuariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 5, 12, 21, 5, 85, DateTimeKind.Utc).AddTicks(3661));
        }
    }
}
