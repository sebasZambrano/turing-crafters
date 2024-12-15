export interface OrdenDetalle {
    id: number;
    activo: boolean;
    cantidad: number;
    producto: string;
    observaciones: string;
    empleado: string;
    mesa: string;
    createAt: Date;
    time: string;
    minutos: number;
}