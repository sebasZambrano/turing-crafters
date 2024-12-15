export interface DetalleFactura {
    id: number;
    activo: boolean;
    codigo: string;
    cantidad: number;
    subTotal: number;
    precio: number;
    descuento: number;
    iva: number;
    facturaId: number;
    productoId: number;
    producto: string;
    cantidadBodega: number;
    detallesInventariosBodegas: any[];
    alerta: boolean;
}