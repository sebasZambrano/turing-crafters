﻿namespace Entity.Dtos.Parameter
{
    public class ConfiguracionDto : BaseDto
    {
        public bool ImprimeFactura { get; set; }
        public int CantidadFactura { get; set; }
        public string TamañoImpresion { get; set; } = null!;
        public bool ManejaInventario { get; set; }
        public bool ManejaClaveSupervisor { get; set; }
        public string ClaveSupervisor { get; set; } = null!;
        public bool ManejaRemision { get; set; }
    }
}