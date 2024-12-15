using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class ClasesResto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturasConvenios_FacturasConvenios_FacturaConvenioId",
                schema: "dbo",
                table: "FacturasConvenios");

            migrationBuilder.DropIndex(
                name: "IX_FacturasConvenios_FacturaConvenioId",
                schema: "dbo",
                table: "FacturasConvenios");

            migrationBuilder.DropColumn(
                name: "FacturaConvenioId",
                schema: "dbo",
                table: "FacturasConvenios");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                schema: "dbo",
                table: "FacturasConvenios");

            migrationBuilder.AddColumn<int>(
                name: "OrdenId",
                schema: "dbo",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Impresoras",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tamaño = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impresoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModificacionesProductos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModificacionesProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propinas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Procentaje = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Liquidado = table.Column<bool>(type: "bit", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    MedioPagoId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propinas_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalSchema: "dbo",
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propinas_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalSchema: "dbo",
                        principalTable: "Facturas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Propinas_MediosPagos_MedioPagoId",
                        column: x => x.MedioPagoId,
                        principalSchema: "dbo",
                        principalTable: "MediosPagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salones",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salones_Zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalSchema: "dbo",
                        principalTable: "Zonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImpresorasCategorias",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ImpresoraId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpresorasCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImpresorasCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalSchema: "dbo",
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImpresorasCategorias_Impresoras_ImpresoraId",
                        column: x => x.ImpresoraId,
                        principalSchema: "dbo",
                        principalTable: "Impresoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImpresorasCategorias_Salones_SalonId",
                        column: x => x.SalonId,
                        principalSchema: "dbo",
                        principalTable: "Salones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesas_Salones_SalonId",
                        column: x => x.SalonId,
                        principalSchema: "dbo",
                        principalTable: "Salones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalSchema: "dbo",
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalSchema: "dbo",
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalles_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalles_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalSchema: "dbo",
                        principalTable: "Ordenes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdenesDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "dbo",
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_OrdenId",
                schema: "dbo",
                table: "Facturas",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_ImpresorasCategorias_CategoriaId",
                schema: "dbo",
                table: "ImpresorasCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ImpresorasCategorias_ImpresoraId",
                schema: "dbo",
                table: "ImpresorasCategorias",
                column: "ImpresoraId");

            migrationBuilder.CreateIndex(
                name: "IX_ImpresorasCategorias_SalonId",
                schema: "dbo",
                table: "ImpresorasCategorias",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_SalonId",
                schema: "dbo",
                table: "Mesas",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EmpleadoId",
                schema: "dbo",
                table: "Ordenes",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EstadoId",
                schema: "dbo",
                table: "Ordenes",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_MesaId",
                schema: "dbo",
                table: "Ordenes",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalles_EstadoId",
                schema: "dbo",
                table: "OrdenesDetalles",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalles_OrdenId",
                schema: "dbo",
                table: "OrdenesDetalles",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalles_ProductoId",
                schema: "dbo",
                table: "OrdenesDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Propinas_EmpleadoId",
                schema: "dbo",
                table: "Propinas",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Propinas_FacturaId",
                schema: "dbo",
                table: "Propinas",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Propinas_MedioPagoId",
                schema: "dbo",
                table: "Propinas",
                column: "MedioPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Salones_ZonaId",
                schema: "dbo",
                table: "Salones",
                column: "ZonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Ordenes_OrdenId",
                schema: "dbo",
                table: "Facturas",
                column: "OrdenId",
                principalSchema: "dbo",
                principalTable: "Ordenes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Ordenes_OrdenId",
                schema: "dbo",
                table: "Facturas");

            migrationBuilder.DropTable(
                name: "ImpresorasCategorias",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ModificacionesProductos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrdenesDetalles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Propinas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Impresoras",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ordenes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Mesas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Salones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Zonas",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_OrdenId",
                schema: "dbo",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "OrdenId",
                schema: "dbo",
                table: "Facturas");

            migrationBuilder.AddColumn<int>(
                name: "FacturaConvenioId",
                schema: "dbo",
                table: "FacturasConvenios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                schema: "dbo",
                table: "FacturasConvenios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Archivos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6671));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Bodegas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6504));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cajas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6574));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cargos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6709));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6439));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6920));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6848));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6851));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6853));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6856));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6859));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Estados",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6861));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6998));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7002));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7009));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7012));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7015));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7040));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7048));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7051));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7054));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7057));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7062));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7065));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7069));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7071));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7074));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7080));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7083));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7089));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7095));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7097));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7100));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7106));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7109));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7120));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Formularios",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7123));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7169));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7173));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7176));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7178));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7184));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7187));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7190));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7193));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7196));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7209));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7212));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7215));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7220));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7223));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7229));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7232));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7235));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7238));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7241));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7244));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7247));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7249));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7258));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7261));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7264));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7267));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7270));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7273));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7276));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7279));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7282));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7285));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "FormulariosRoles",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(7287));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Inventarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6197));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6112));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6114));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MediosPagos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6115));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6956));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6959));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6961));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Modulos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6964));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Motivos",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6075));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "NumeracionesFacturas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6012));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6377));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6382));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(5582));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(5590));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(5592));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposCostos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6892));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6810));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6812));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "TiposEstados",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6814));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6158));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6160));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UnidadesMedidas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6162));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UsuariosRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 4, 3, 18, 4, 57, 666, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.CreateIndex(
                name: "IX_FacturasConvenios_FacturaConvenioId",
                schema: "dbo",
                table: "FacturasConvenios",
                column: "FacturaConvenioId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturasConvenios_FacturasConvenios_FacturaConvenioId",
                schema: "dbo",
                table: "FacturasConvenios",
                column: "FacturaConvenioId",
                principalSchema: "dbo",
                principalTable: "FacturasConvenios",
                principalColumn: "Id");
        }
    }
}
