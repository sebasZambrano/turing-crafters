import { Component, NgModule, OnInit, signal, ViewChild } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GeneralModule } from 'src/app/general/general.module';
import { ActivatedRoute } from '@angular/router';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Generic } from '../../../../../generic/generic.module';
import { GenericKey } from '../../../../../generic/genericKey.modulo';
import { Salon } from '../../../parameters/salones/salones.module';
import { Mesa } from '../../../parameters/mesas/mesas.module';
import { Producto } from '../../../inventory/productos/productos-module';
import { OrdenDetalle } from '../ordenDetalle.module';
import Swal from 'sweetalert2';
import { DataSelectDto } from 'src/app/generic/dataSelectDto';
import { AutocompleteLibModule } from 'angular-ng-autocomplete';
import { DataAutoCompleteDto } from 'src/app/generic/dataAutoCompleteDto';
import { ModificacionesComponent } from '../modificaciones/modificaciones.component'
import { FacturasFormComponent } from '../../facturas/facturas-form/facturas-form.component';

@Component({
    selector: 'app-ordenes-resto-form',
    standalone: false,
    templateUrl: './ordenes-resto-form.component.html',
    styleUrl: './ordenes-resto-form.component.css',
})
export class OrdenesRestoFormComponent implements OnInit {
    @ViewChild('auto') auto: any;
    keyword = 'name';
    isLoading: boolean = false;
    listProductosAuto = signal<DataAutoCompleteDto[]>([]);
    producto: Producto = { id: 0, activo: false, codigo: "", nombre: "", descripcionCorta: "", descripcionLarga: "", precio: 0, precioCosto: 0, descuento: 0, iva: 0, categoriaId: 0, categoria: "", };

    isLoadingProduct: boolean = true;
    isLoadingCategory: boolean = true;
    isLoadingTable: boolean = true;

    frmOrdenar: FormGroup;
    statusForm: boolean = true;
    ordenar = false;

    listZonas = signal<Generic[]>([]);
    listSalones = signal<Salon[]>([]);
    listMesas = signal<Mesa[]>([]);

    listMacroCategorias = signal<Generic[]>([]);
    listCategorias = signal<GenericKey[]>([]);
    listProductos = signal<Producto[]>([]);

    selectZona = 0;
    selectSalon: Salon = { id: 0, zonaId: 0, descripcion: "", zona: "", codigo: "", nombre: "", activo: false };
    selectMesa: Mesa = { id: 0, descripcion: "", cupo: 0, salonId: 0, salon: "", estadoId: 0, estado: "", codigo: "", nombre: "", activo: false, orden: { id: 0, activo: false, codigo: "", descripcion: "", cantidadPersonas: 0, total: 0, mesaId: 0, empleadoId: 0, estadoId: 0, mesa: "", empleado: "", estado: "", createAt: undefined, } };
    selectMacro = 0;
    selectCategoria = 0;

    listEmpleados = signal<DataSelectDto[]>([]);
    ordenDetalles = signal<OrdenDetalle[]>([]);

    constructor(
        public routerActive: ActivatedRoute,
        private service: GeneralParameterService,
        public helperService: HelperService,
        private datePipe: DatePipe,
        private modalService: NgbModal,

    ) {
        this.frmOrdenar = new FormGroup({
            Codigo: new FormControl(""),
            Descripcion: new FormControl(""),
            CantidadPersonas: new FormControl(1, [Validators.required]),
            EmpleadoId: new FormControl(null, [Validators.required]),
            CreateAt: new FormControl(null, [Validators.required]),
            Total: new FormControl(0),
            MesaId: new FormControl(0),
            EstadoId: new FormControl(0),
        });
    }

    ngOnInit(): void {
        //Cargar listas
        this.cargarListas();

    }

    cargarListas() {
        this.helperService.showLoading();
        this.cargarZonas();
        this.cargarMacroCategorias();
        this.cargarEmpleados();
        this.cargarProductosAuto();
        setTimeout(() => {
            this.validarEmpleado();
        }, 1000);
    };

    cargarProductosAuto() {
        this.isLoading = true;
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
        this.service.datatable('Producto', data).subscribe((res) => {
            res.data.forEach((item: any) => {
                this.listProductosAuto.update(listProductosAuto => {
                    const DataAutoCompleteDto: DataAutoCompleteDto = {
                        id: item.id,
                        name: `${item.categoria} - ${item.nombre} - $ ${this.helperService.formaterNumber(item.precio)}`,
                    };

                    return [...listProductosAuto, DataAutoCompleteDto];
                });
            });

            this.isLoading = false;
        });
    }

    validarEmpleado() {
        var personaId = localStorage.getItem("persona_Id");
        if (personaId != null) {
            var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
            this.service.datatableKey("Empleado", data).subscribe((empleado) => {
                if (empleado.data.length == 1) {
                    localStorage.setItem("Empleado_Id", empleado.data[0].id);
                    this.frmOrdenar.controls["EmpleadoId"].setValue(empleado.data[0].id);
                    this.service.getById("Caja", empleado.data[0].cajaId).subscribe((caja) => {
                        localStorage.setItem("CajaId", caja.data.id);
                        localStorage.setItem("BodegaId", caja.data.bodegaId);
                    })
                } else {
                    Swal.fire({
                        title: '¡No existe un empleado con este usuario!',
                        icon: 'warning',
                    }).then(() => {
                        this.helperService.redirectApp("/dashboard");
                    });
                }
            })
        }
    }

    cargarEmpleados() {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";

        this.service.datatable('Empleado', data).subscribe((res) => {
            res.data.forEach((item: any) => {
                this.listEmpleados.update(listEmpleados => {
                    const DataSelectDto: DataSelectDto = {
                        id: item.id,
                        textoMostrar: `${item.persona}`,
                        activo: item.activo
                    };

                    return [...listEmpleados, DataSelectDto];
                });
            });
        });
    }

    cargarZonas() {
        this.getDataZonas().then((datos) => {
            if (datos.data.length > 0) {
                this.selectZona = datos.data[0].id;
                datos.data.forEach((item: any) => {
                    this.listZonas.update(listZonas => {
                        const Zona: Generic = {
                            id: item.id,
                            activo: item.activo,
                            codigo: item.codigo,
                            nombre: item.nombre,
                        };

                        return [...listZonas, Zona];
                    });
                });

                setTimeout(() => {
                    this.cargarSalones();
                }, 500);
            } else {
                this.isLoadingTable = true;
                this.listSalones = signal<Salon[]>([]);
                this.listMesas = signal<Mesa[]>([]);
                this.helperService.hideLoading();
            }
        }).catch((error) => {
            console.error('Error al obtener los datos:', error);
        });
    }

    cargarSalones() {
        this.getDataSalones().then((datos) => {
            if (datos.data.length > 0) {
                this.selectSalon = datos.data[0];
                datos.data.forEach((item: any) => {
                    this.listSalones.update(listSalones => {
                        const Salon: Salon = {
                            id: item.id,
                            activo: item.activo,
                            codigo: item.codigo,
                            nombre: item.nombre,
                            zonaId: item.zonaId,
                            descripcion: item.descripcion,
                            zona: item.zona,
                        };

                        return [...listSalones, Salon];
                    });
                });

                setTimeout(() => {
                    this.cargarMesas();
                }, 500);
            } else {
                this.isLoadingTable = true;
                this.listMesas = signal<Mesa[]>([]);
                this.helperService.hideLoading();
            }
        }).catch((error) => {
            console.error('Error al obtener los datos:', error);
        });
    }

    cargarMesas() {
        this.getDataMesas().then((datos) => {
            datos.data.forEach((item: any) => {
                this.listMesas.update(listMesas => {
                    const Mesa: Mesa = {
                        id: item.id,
                        activo: item.activo,
                        codigo: item.codigo,
                        nombre: item.nombre,
                        descripcion: item.descripcion,
                        salonId: item.salonId,
                        salon: item.salon,
                        cupo: item.cupo,
                        estadoId: item.estadoId,
                        estado: item.estado,
                        orden: {
                            id: 0,
                            activo: false,
                            codigo: "",
                            descripcion: "",
                            cantidadPersonas: 0,
                            total: 0,
                            mesaId: item.id,
                            empleadoId: 0,
                            estadoId: 0,
                            mesa: item.nombre,
                            empleado: "",
                            estado: "",
                            createAt: undefined,
                        }
                    };

                    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = Mesa.id; data.nameForeignKey = "MesaId";
                    this.service.datatableKey("Orden", data).subscribe((res: any) => {
                        if (res.data.length > 0) {
                            res.data.forEach((element: any) => {
                                if (element.estado == "EN PROCESO" || element.estado == "PREPARACIÓN") {
                                    Mesa.orden = element;
                                }
                            });
                        }
                    })

                    return [...listMesas, Mesa];
                });
            });
            this.isLoadingTable = false;

            setTimeout(() => {
                this.helperService.hideLoading();
            }, 200);
        }).catch((error) => {
            console.error('Error al obtener los datos:', error);
        });
    }

    cargarMacroCategorias() {
        this.getDataMacroCategorias().then((datos) => {
            if (datos.data.length > 0) {
                this.selectMacro = datos.data[0].id;
                datos.data.forEach((item: any) => {
                    this.listMacroCategorias.update(listMacroCategorias => {
                        const MacroCategoria: Generic = {
                            id: item.id,
                            activo: item.activo,
                            codigo: item.codigo,
                            nombre: item.nombre,
                        };

                        return [...listMacroCategorias, MacroCategoria];
                    });
                });

                setTimeout(() => {
                    this.cargarCategorias();
                }, 500);
            } else {
                this.isLoadingCategory = true;
                this.listCategorias = signal<GenericKey[]>([]);
                this.isLoadingProduct = true;
                this.listProductos = signal<Producto[]>([]);
                this.helperService.hideLoading();
            }
        }).catch((error) => {
            console.error('Error al obtener los datos:', error);
        });
    }

    cargarCategorias() {
        this.getDataCategorias().then((datos) => {
            if (datos.data.length > 0) {
                this.selectCategoria = datos.data[0].id;
                datos.data.forEach((item: any) => {
                    this.listCategorias.update(listCategorias => {
                        const Categoria: GenericKey = {
                            id: item.id,
                            activo: item.activo,
                            codigo: item.codigo,
                            nombre: item.nombre,
                            key: item.macroCategoriaId,
                        };

                        return [...listCategorias, Categoria];
                    });
                });

                this.isLoadingCategory = false;

                setTimeout(() => {
                    this.cargarProductos();
                }, 500);
            } else {
                this.isLoadingProduct = true;
                this.listProductos = signal<Producto[]>([]);
                this.helperService.hideLoading();
            }
        }).catch((error) => {
            console.error('Error al obtener los datos:', error);
        });
    }

    cargarProductos() {
        this.getDataProductos().then((datos) => {
            datos.data.forEach((item: any) => {
                this.listProductos.update(listProductos => {
                    const Producto: Producto = {
                        id: item.id,
                        activo: item.activo,
                        codigo: item.codigo,
                        nombre: item.nombre,
                        descripcionCorta: item.descripcionCorta,
                        descripcionLarga: item.descripcionLarga,
                        precio: item.precio,
                        precioCosto: item.precioCosto,
                        descuento: item.descuento,
                        iva: item.iva,
                        categoriaId: item.categoriaId,
                        categoria: item.categoria,
                    };

                    //Consulto el archivo
                    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = Producto.id; data.nameForeignKey = "TablaId";
                    this.service.datatableKey("Archivo", data).subscribe((response) => {
                        if (response.data.length > 0) {
                            response.data.forEach((item: any) => {
                                if (item.tabla == "Producto") {
                                    Producto.imagen = item.content;
                                }
                            });
                        }
                    });

                    return [...listProductos, Producto];
                });
            });
            this.isLoadingProduct = false;

            setTimeout(() => {
                this.helperService.hideLoading();
            }, 200);
        }).catch((error) => {
            console.error('Error al obtener los datos:', error);
        });
    }

    getDataSalones(): Promise<any> {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.selectZona; data.nameForeignKey = "ZonaId";
        return new Promise((resolve, reject) => {
            this.service.datatableKey("Salon", data).subscribe(
                (datos) => {
                    resolve(datos);
                },
                (error) => {
                    reject(error);
                }
            )
        });
    }

    getDataZonas(): Promise<any> {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
        return new Promise((resolve, reject) => {
            this.service.datatable("Zona", data).subscribe(
                (datos) => {
                    resolve(datos);
                },
                (error) => {
                    reject(error);
                }
            )
        });
    }

    getDataMacroCategorias(): Promise<any> {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = "";
        return new Promise((resolve, reject) => {
            this.service.datatable("MacroCategoria", data).subscribe(
                (datos) => {
                    resolve(datos);
                },
                (error) => {
                    reject(error);
                }
            )
        });
    }

    getDataCategorias(): Promise<any> {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.selectMacro; data.nameForeignKey = "MacroCategoriaId";
        return new Promise((resolve, reject) => {
            this.service.datatableKey("Categoria", data).subscribe(
                (datos) => {
                    resolve(datos);
                },
                (error) => {
                    reject(error);
                }
            )
        });
    }

    getDataProductos(): Promise<any> {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.selectCategoria; data.nameForeignKey = "CategoriaId";
        return new Promise((resolve, reject) => {
            this.service.datatableKey("Producto", data).subscribe(
                (datos) => {
                    resolve(datos);
                },
                (error) => {
                    reject(error);
                }
            )
        });
    }

    getDataMesas(): Promise<any> {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.selectSalon.id; data.nameForeignKey = "SalonId"
        return new Promise((resolve, reject) => {
            this.service.datatableKey("Mesa", data).subscribe(
                (datos) => {
                    resolve(datos);
                },
                (error) => {
                    reject(error);
                }
            )
        });
    }

    onClick(id: number, service: string) {
        // this.helperService.showLoading();
        switch (service) {
            case "Zona":
                this.selectZona = id;
                this.listSalones = signal<Salon[]>([]);
                this.isLoadingTable = true;
                this.listMesas = signal<Mesa[]>([]);
                this.cargarSalones();
                break;
            case "Salon":
                var salon = this.listSalones().find(salon => salon.id === id);
                if (salon != null) {
                    this.selectSalon = salon;
                }
                this.isLoadingTable = true;
                this.listMesas = signal<Mesa[]>([]);
                this.cargarMesas();
                break;
            case "MacroCategoria":
                this.selectMacro = id;
                this.isLoadingCategory = true;
                this.listCategorias = signal<GenericKey[]>([]);
                this.cargarCategorias();
                this.isLoadingProduct = true;
                this.listProductos = signal<Producto[]>([]);
                break;
            case "Categoria":
                this.selectCategoria = id;
                this.isLoadingProduct = true;
                this.listProductos = signal<Producto[]>([]);
                this.cargarProductos();
                break;
        }
    }

    cargarDetallesOrden() {
        var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = this.selectMesa.id; data.nameForeignKey = "MesaId";
        this.service.datatableKey("Orden", data).subscribe((res: any) => {
            if (res.data.length > 0) {
                res.data.forEach((item: any) => {
                    if (item.estado == "EN PROCESO" || item.estado == "PREPARACIÓN") {
                        data.foreignKey = item.id;
                        data.nameForeignKey = "OrdenId";
                        this.service.datatableKey("OrdenDetalle", data).subscribe((detalles: any) => {
                            console.log(detalles.data);
                        });
                    }
                });
            }
        })
    }

    agregar() {
        if (this.producto.id != 0) {
            var productoValidado = this.validarProducto(this.producto.id);
            if (productoValidado.length == 0) {
                const detalle = {
                    id: 0,
                    activo: true,
                    codigo: "",
                    cantidad: 1,
                    precio: this.producto.precio,
                    observaciones: "",
                    ordenId: 0,
                    productoId: this.producto.id,
                    estadoId: 0,
                    orden: "",
                    producto: this.producto.nombre,
                    estado: "",
                    subTotal: this.producto.precio,
                }
                this.ordenDetalles.update((ordenDetalles) => [...ordenDetalles, detalle]);
                this.frmOrdenar.controls["Total"].setValue(this.ordenDetalles().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0));
            } else {
                //Sumar la cantidad
                var productoId = productoValidado[0].productoId;
                for (let i = 0; i < this.ordenDetalles().length; i++) {
                    if (this.ordenDetalles()[i].productoId == productoId) {

                        var nuevaCantidad = this.ordenDetalles()[i].cantidad + 1;

                        this.ordenDetalles.update((ordenDetalles) => {
                            return ordenDetalles.map((ordenDetalles, position) => {
                                if (position === i) {
                                    var subtotal = ordenDetalles.precio * nuevaCantidad;
                                    return {
                                        ...ordenDetalles,
                                        cantidad: nuevaCantidad,
                                        subTotal: subtotal
                                    }
                                }
                                return ordenDetalles;
                            })
                        });
                    }
                }
                this.frmOrdenar.controls["Total"].setValue(this.ordenDetalles().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0));
            }
        } else {
            this.helperService.showMessage(MessageType.WARNING, "Selecciona un producto");
        }
    }

    validarProducto(id: number) {
        var detalle: any[] = [];
        if (this.ordenDetalles().length > 0) {
            this.ordenDetalles().forEach((item: any) => {
                if (item.productoId == id) {
                    detalle.push(item);
                }
            });
        }
        return detalle;
    }

    // Events Table
    delete(index: number) {
        this.ordenDetalles.update((ordenDetalles) => ordenDetalles.filter((detalle, position) => position !== index));
        this.frmOrdenar.controls["Total"].setValue(this.ordenDetalles().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0));
    }

    changeCantidad(event: any, index: number) {
        var inputCantidad = event.target as HTMLInputElement;
        if (inputCantidad.value != '') {
            var nuevaCantidad = Number(inputCantidad.value);
            if (nuevaCantidad == 0) {
                nuevaCantidad = 1;
            }

            this.ordenDetalles.update((ordenDetalles) => {
                return ordenDetalles.map((ordenDetalles, position) => {
                    if (position === index) {
                        var subtotal = ordenDetalles.precio * nuevaCantidad;
                        return {
                            ...ordenDetalles,
                            cantidad: nuevaCantidad,
                            subTotal: subtotal
                        }
                    }
                    return ordenDetalles;
                })
            });
        }

        this.frmOrdenar.controls["Total"].setValue(this.ordenDetalles().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0));

    }

    modificaciones(index: number) {
        let modal = this.modalService.open(ModificacionesComponent, { size: 'md', keyboard: false, backdrop: false, centered: true });
        modal.componentInstance.observaciones = this.ordenDetalles()[index].observaciones;
        modal.result.then(res => {
            this.ordenDetalles.update((ordenDetalles) => {
                return ordenDetalles.map((ordenDetalles, position) => {
                    if (position === index) {

                        return {
                            ...ordenDetalles,
                            observaciones: res,
                        }
                    }
                    return ordenDetalles;
                })
            });
        })
    }

    // Events Autocomplete
    selectEvent(item: any) {
        this.service.getById('Producto', item.id).subscribe((res) => {
            this.producto = res.data;
        })
    }

    onFocused() {
        this.auto.close();
    }

    inputCleared() {
        this.auto.close();
        this.listProductosAuto = signal<DataAutoCompleteDto[]>([]);
        this.cargarProductosAuto();
    }

    inputClear() {
        this.auto.clear();
    }

    // Events Buttons Products

    onclickAgregar(item: any) {
        var productoValidado = this.validarProducto(item.id);
        if (productoValidado.length == 0) {
            const detalle = {
                id: 0,
                activo: true,
                codigo: "",
                cantidad: 1,
                precio: item.precio,
                observaciones: "",
                ordenId: 0,
                productoId: item.id,
                estadoId: 0,
                orden: "",
                producto: item.nombre,
                estado: "",
                subTotal: item.precio,
            }

            this.ordenDetalles.update((ordenDetalles) => [...ordenDetalles, detalle]);
            this.frmOrdenar.controls["Total"].setValue(this.ordenDetalles().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0));

            this.helperService.hideLoading();
        } else {
            //Sumar la cantidad
            var productoId = productoValidado[0].productoId;
            for (let i = 0; i < this.ordenDetalles().length; i++) {
                if (this.ordenDetalles()[i].productoId == productoId) {

                    var nuevaCantidad = this.ordenDetalles()[i].cantidad + 1;

                    this.ordenDetalles.update((ordenDetalles) => {
                        return ordenDetalles.map((ordenDetalles, position) => {
                            if (position === i) {
                                var subtotal = ordenDetalles.precio * nuevaCantidad;
                                return {
                                    ...ordenDetalles,
                                    cantidad: nuevaCantidad,
                                    subTotal: subtotal
                                }
                            }
                            return ordenDetalles;
                        })
                    });
                }
            }
            this.frmOrdenar.controls["Total"].setValue(this.ordenDetalles().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0));
            this.helperService.hideLoading();
        }
    }

    onclickRestar(item: any) {
        var productoValidado = this.validarProducto(item.id);
        if (productoValidado.length > 0) {
            //Restar la cantidad
            var productoId = productoValidado[0].productoId;
            for (let i = 0; i < this.ordenDetalles().length; i++) {
                if (this.ordenDetalles()[i].productoId == productoId) {

                    var nuevaCantidad = this.ordenDetalles()[i].cantidad - 1;

                    if (nuevaCantidad > 0) {
                        this.ordenDetalles.update((ordenDetalles) => {
                            return ordenDetalles.map((ordenDetalles, position) => {
                                if (position === i) {
                                    var subtotal = ordenDetalles.precio * nuevaCantidad;
                                    return {
                                        ...ordenDetalles,
                                        cantidad: nuevaCantidad,
                                        subTotal: subtotal
                                    }
                                }
                                return ordenDetalles;
                            })
                        });
                    } else if (nuevaCantidad == 0) {
                        this.ordenDetalles.update((ordenDetalles) => ordenDetalles.filter((detalle, position) => position !== i));
                        this.frmOrdenar.controls["Total"].setValue(this.ordenDetalles().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0));
                    }
                }
            }
            this.frmOrdenar.controls["Total"].setValue(this.ordenDetalles().reduce((acumulador, detalle) => acumulador + detalle.subTotal, 0));
        }
    }

    //Events Buttons Mesas
    onClickMesa(Mesa: Mesa) {
        var formattedFecha = this.datePipe.transform(Date(), 'yyyy-MM-ddTHH:mm:ss', 'America/Bogota');
        this.frmOrdenar.controls["CreateAt"].setValue(formattedFecha);

        this.selectMesa = Mesa;
        this.frmOrdenar.controls["MesaId"].setValue(Mesa.id);
        this.ordenar = true;
        if (Mesa.orden.id != 0) {
            this.cargarDetallesOrden();
        }
    }

    onClickFacturar(Mesa: Mesa) {
        let modal = this.modalService.open(FacturasFormComponent, { size: 'lg', keyboard: false, backdrop: false, centered: true });
        modal.componentInstance.subTotal = Mesa.orden.total;
        modal.componentInstance.total = Mesa.orden.total;
        modal.componentInstance.saldo = Mesa.orden.total;
        modal.componentInstance.ordenId = Mesa.orden.id;

        modal.result.finally(() => {
            this.isLoadingTable = true;
            this.listMesas = signal<Mesa[]>([]);
            this.cargarMesas();
        })
    }

    onClickPasaMesa() {

    }

    onClickLimpiar(Mesa: Mesa) {
        this.helperService.confirmDelete(() => {
            this.helperService.showLoading();
            this.service.limpiar("Orden", Mesa.orden.id).subscribe(
                (response) => {
                    if (response.status) {
                        this.isLoadingTable = true;
                        this.listMesas = signal<Mesa[]>([]);
                        this.cargarMesas();
                        this.helperService.hideLoading();
                        this.helperService.showMessage(MessageType.SUCCESS, Messages.DELETESUCCESS);
                    }
                },
                (error) => {
                    this.helperService.hideLoading();
                    this.helperService.showMessage(MessageType.WARNING, error);
                }
            )
        });
    }

    //Guardar Orden

    onClickOrdenar() {
        this.helperService.showLoading();
        if (this.frmOrdenar.invalid) {
            this.statusForm = false
            this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
            return;
        }
        let data = {
            id: 0,
            ...this.frmOrdenar.value
        };

        this.service.save("Orden", data.id, data).subscribe(
            (response) => {
                if (response.status) {
                    this.guardarDetallesOrden(response.data.id);
                } else {
                    this.helperService.hideLoading();
                }
            },
            (error) => {
                this.helperService.hideLoading();
                this.helperService.showMessage(MessageType.WARNING, error.error.message);
            }
        );
    }

    guardarDetallesOrden(ordenId: number) {
        let detalles: any[] = [];

        this.ordenDetalles().forEach((element: any) => {
            var detalle = {
                Id: 0,
                Activo: true,
                CreateAt: new Date(),
                Codigo: element.codigo,
                Cantidad: element.cantidad,
                Precio: element.precio,
                Observaciones: element.observaciones,
                OrdenId: ordenId,
                ProductoId: element.productoId,
                EstadoId: 0,
            };

            detalles.push(detalle);
        });

        this.service.saveDetalles('OrdenDetalle', detalles).subscribe(
            (response) => {
                if (response.status) {
                    setTimeout(() => {
                        this.isLoadingTable = true;
                        this.listMesas = signal<Mesa[]>([]);
                        this.cargarMesas();
                        this.ordenar = false;
                        this.helperService.hideLoading();
                        this.limpiar();
                    }, 200);
                } else {
                    this.helperService.hideLoading();
                }
            },
            (error) => {
                this.helperService.hideLoading();
                this.helperService.showMessage(MessageType.ERROR, error.error.message);
            }
        );
    }

    limpiar() {
        this.ordenDetalles = signal<OrdenDetalle[]>([]);
        this.frmOrdenar.controls["CantidadPersonas"].setValue(1);
        this.frmOrdenar.controls["CreateAt"].setValue(null);
        this.frmOrdenar.controls["Total"].setValue(0);
        this.frmOrdenar.controls["MesaId"].setValue(0);
    }
}
@NgModule({
    declarations: [OrdenesRestoFormComponent],
    imports: [CommonModule, GeneralModule, AutocompleteLibModule],
})
export class OrdenesRestoFormModule { }
