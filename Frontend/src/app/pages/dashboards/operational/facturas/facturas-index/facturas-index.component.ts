import { Component, OnInit, NgModule, ViewChild } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GeneralModule } from 'src/app/general/general.module';
import { HelperService, MessageType, Messages } from 'src/app/admin/helper.service';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { DataTableDirective } from 'angular-datatables';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { FacturasService } from '../facturas.service';
import Swal from 'sweetalert2';
import { FacturasDetallesComponent } from '../../facturas-detalles/facturas-detalles.component';
import { BitacorasInventariosComponent } from '../../../inventory/bitacoras-inventarios/bitacoras-inventarios.component';

@Component({
  selector: 'app-facturas-index',
  standalone: false,
  templateUrl: './facturas-index.component.html',
  styleUrl: './facturas-index.component.css',
})

export class FacturasIndexComponent implements OnInit {
  title = 'Listado de Facturas';
  breadcrumb!: any[];
  botones: String[] = ['btn-nuevo'];
  public dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective) dtElement!: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  manejaClave = false;
  empleadoId = 0;
  frmFacturas: FormGroup;
  statusForm: boolean = true;

  constructor(
    private service: GeneralParameterService,
    private facturasService: FacturasService,
    public helperService: HelperService,
    private modalService: NgbModal,
    private datePipe: DatePipe

  ) {
    this.breadcrumb = [
      { name: `Inicio`, icon: `fa-duotone fa-house` },
      { name: 'Operativo', icon: 'fa-duotone fa-shop' },
      { name: 'Facturas de venta', icon: 'fa-duotone fa-file-invoice' },
    ];

    this.frmFacturas = new FormGroup({
      FechaInicio: new FormControl(null, [Validators.required]),
      FechaFin: new FormControl(null, [Validators.required]),
    });
  }

  ngOnInit(): void {
    this.validarEmpleado();
    this.cargarLista();
    this.ManejaClave();
  }

  validarEmpleado() {
    var personaId = localStorage.getItem("persona_Id");
    if (personaId != null) {
      var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = personaId; data.nameForeignKey = "PersonaId";
      this.service.datatableKey("Empleado", data).subscribe((empleado) => {
        if (empleado.data.length == 1) {
          this.empleadoId = empleado.data[0].id;
        } else {
          Swal.fire({
            title: '¡No existe un empleado con este usuario!',
            icon: 'warning',
          }).then(() => {
            this.helperService.redirectApp("/login");
          });
        }
      })
    }
  }

  ngAfterViewInit() {
    this.dtTrigger.next(this.dtOptions);
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  cargarLista() {
    const that = this;
    this.dtOptions = {
      dom: 'Blfrtip',
      processing: true,
      ordering: true,
      responsive: true,
      paging: true,
      order: [0, 'desc'],
      language: LANGUAGE_DATATABLE,
      ajax: (dataTablesParameters: any, callback: any) => {
        const data = new DatatableParameter(); data.pageNumber = ''; data.pageSize = ''; data.filter = ''; data.columnOrder = ''; data.directionOrder = '';
        this.service.datatable('Factura', data).subscribe((res) => {
          callback({
            recordsTotal: res.data.length,
            recordsFiltered: res.data.length,
            draw: dataTablesParameters.draw,
            data: res.data,
          });
        });
      },
      columns: [
        {
          title: 'ID',
          data: 'id',
          className: 'd-none',
        },
        {
          title: 'FECHA',
          data: 'createAt',
          className: 'text-center',
          render: (item: any) => {
            return this.helperService.convertDateTime(item);
          },
        },
        {
          title: 'CLIENTE',
          data: 'cliente',
          className: 'text-center',
        },
        {
          title: '# FACTURA',
          data: 'numeroFactura',
          className: 'text-center',
        },
        {
          title: 'SUBTOTAL',
          data: 'subTotal',
          className: 'text-center',
          render: function (data: any) {
            return '$ ' + that.helperService.formaterNumber(data);
          },
        },
        {
          title: 'DESCUENTO',
          data: 'descuento',
          className: 'text-center',
          render: function (data: any) {
            return '$ ' + that.helperService.formaterNumber(data);
          },
        },
        {
          title: 'IVA',
          data: 'iva',
          className: 'text-center',
          render: function (data: any) {
            return data + ' %';
          },
        },
        {
          title: 'TOTAL',
          data: 'total',
          className: 'text-center',
          render: function (data: any) {
            return '$ ' + that.helperService.formaterNumber(data);
          },
        },
        {
          title: 'EMPLEADO',
          data: 'empleado',
          className: 'text-center',
        },
        {
          title: 'CAJA',
          data: 'caja',
          className: 'text-center',
        },
        {
          title: 'TIPO',
          data: 'remision',
          className: 'text-center',
          render: function (item: any) {
            if (item) {
              return "<label class='text-center text-primary'>Remisión</label>";
            } else {
              return "<label class='text-center text-success'>Factura</label>";
            }
          },
        },
        {
          title: 'ESTADO',
          data: 'estado',
          className: 'text-center',
          render: function (item: any) {
            if (item == "FACTURADA") {
              return "<label class='text-center text-success'>FACTURADA</label>";
            } else {
              return "<label class='text-center text-warning'>ANULADA</label>";
            }
          },
        },
        {
          title: 'PAGOS',
          data: 'pagos',
          className: 'text-center w-100',
        },
        {
          title: 'ACCIONES',
          orderable: false,
          data: 'id',
          className: 'text-center',
          render: function (id: any) {
            // <button type="button" title="Anular" class="btn btn-sm text-secondary btn-dropdown-anular" data-id="${id}"><i class="fa-duotone fa-ban"></i> Anular</button>
            return `<div class="d-flex justify-content-center align-items-center">
                      <button type="button" title="Detalles" class="btn btn-sm text-secondary btn-dropdown-detalles" data-id="${id}"><i class="fa-duotone fa-info"></i></button>
                      <button type="button" title="Imprimir" class="btn btn-sm text-secondary btn-dropdown-imprimir" data-id="${id}"><i class="fa-duotone fa-print"></i></button>
                      <button type="button" title="Nota Crédito" class="btn btn-sm text-secondary btn-dropdown-nota-credito" data-id="${id}"><i class="fa-duotone fa-file-circle-exclamation"></i></button>
                      <button type="button" title="Bitácora" class="btn btn-sm text-secondary btn-dropdown-bitacora" data-id="${id}"><i class="fa-duotone fa-people-carry-box"></i></button>
                    </div>`;
          },
        },
      ],
      drawCallback: () => {
        $('.btn-dropdown-imprimir')
          .off()
          .on('click', (event: any) => {
            this.imprimir(event.currentTarget.dataset.id);
          });
        $('.btn-dropdown-detalles')
          .off()
          .on('click', (event: any) => {
            this.detalles(event.currentTarget.dataset.id);
          });
        $('.btn-dropdown-nota-credito')
          .off()
          .on('click', (event: any) => {
            this.notaCredito(event.currentTarget.dataset.id);
          });
        $('.btn-dropdown-bitacora')
          .off()
          .on('click', (event: any) => {
            this.bitacora(event.currentTarget.dataset.id);
          });

        $('.btn-dropdown-anular')
          .off()
          .on('click', (event: any) => {
            if (this.manejaClave) {
              Swal.fire({
                title: "Clave de supervisor",
                input: "number",
                inputAttributes: {
                  autocapitalize: "off"
                },
                showCancelButton: true,
                confirmButtonText: "Validar",
                cancelButtonText: "Cancelar",
                showLoaderOnConfirm: true,
                preConfirm: async (clave) => {
                  this.ValidarClaveSupervisor(clave, event.currentTarget.dataset.id);
                },
                allowOutsideClick: () => !Swal.isLoading()
              });
            } else {
              this.anular(event.currentTarget.dataset.id, this.empleadoId);
            }
          });
      },
    };
  }

  notaCredito(id: number) {
    var data = new DatatableParameter(); data.pageNumber = ""; data.pageSize = ""; data.filter = ""; data.columnOrder = ""; data.directionOrder = ""; data.foreignKey = id; data.nameForeignKey = "FacturaId";
    this.service.datatableKey("NotaCredito", data).subscribe((res: any) => {
      if (res.data.length == 0) {
        this.helperService.redirectApp(`/dashboard/operativo/notas-credito/editar/${id}`);
      } else {
        var generada = false;
        res.data.forEach((element: any) => {
          if (element.estado == "GENERADA") {
            generada = true;
          }
        });
        if (!generada) {
          this.helperService.redirectApp(`/dashboard/operativo/notas-credito/editar/${id}`);
        } else {
          Swal.fire({
            title: '¡La factura tiene una nota de crédito pendiente por aprobar!',
            icon: 'warning',
          });
        }
      }
    });
  }

  ManejaClave() {
    this.getConfiguration().then((res) => {
      if (res.status) {
        if (res.data[0].manejaClaveSupervisor) {
          this.manejaClave = true;
        }
      } else {
        this.helperService.showMessage(MessageType.WARNING, "¡No hay una clave de supervisor configurada!");
      }
    }).catch((error) => {
      console.error('Error al obtener los datos:', error);
    });
  }

  ValidarClaveSupervisor(clave: number, id: number) {
    this.getConfiguration().then((res) => {
      if (res.status) {
        if (clave == Number(res.data[0].claveSupervisor)) {
          this.anular(id, this.empleadoId);
        } else {
          this.helperService.showMessage(MessageType.WARNING, "¡Clave de supervisor incorrecta!");
        }
      } else {
        this.helperService.showMessage(MessageType.WARNING, "¡No hay una clave de supervisor configurada!");
      }
    });
  }

  getConfiguration(): Promise<any> {
    return new Promise((resolve, reject) => {
      this.service.getAll("Configuracion").subscribe(
        (datos) => {
          resolve(datos);
        },
        (error) => {
          reject(error);
        }
      );
    });
  }

  imprimir(id: number) {
    this.helperService.showLoading();
    this.facturasService.GetArchivoById(id).subscribe((res) => {
      this.openPdfInNewTab(res.data.content);
    });
  }

  openPdfInNewTab(pdfContent: string) {
    const byteCharacters = atob(pdfContent);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'application/pdf' });
    const objectUrl = URL.createObjectURL(blob);

    setTimeout(() => {
      this.helperService.hideLoading();
    }, 200);

    const newWindow = window.open(objectUrl, '_blank');

    if (newWindow) {
      newWindow.document.title = 'Factura';
      newWindow.print();
    }
  }

  anular(id: number, empleadoId: number) {
    this.helperService.showLoading();
    this.facturasService.anular(id, empleadoId).subscribe(
      (response) => {
        if (response.status) {
          setTimeout(() => {
            this.helperService.hideLoading();
          }, 200);
          this.helperService.showMessage(MessageType.SUCCESS, "Factura Anulada");
          this.refrescarTabla();
        }
      },
      (error) => {
        setTimeout(() => {
          this.helperService.hideLoading();
        }, 200);
        this.helperService.showMessage(MessageType.WARNING, error.error.message);
      }
    );
  }

  refrescarTabla() {
    if (typeof this.dtElement.dtInstance != 'undefined') {
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.ajax.reload();
      });
    }

    setTimeout(() => {
      this.helperService.hideLoading();
    }, 200);
  }

  nuevo() {
    this.helperService.redirectApp('/dashboard/operativo/ordenes');
  }

  detalles(facturaId: any) {
    const modal = this.modalService.open(FacturasDetallesComponent, { size: 'xl', keyboard: false, backdrop: false, centered: true });
    modal.componentInstance.FacturaId = facturaId;
  }

  bitacora(facturaId: any) {
    const modal = this.modalService.open(BitacorasInventariosComponent, { size: 'xl', keyboard: false, backdrop: false, centered: true });
    modal.componentInstance.facturas = true;
    modal.componentInstance.InsumoId = facturaId;
  }

  buscar() {
    if (this.frmFacturas.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }

    this.helperService.showLoading();
    this.cargarListaFilter();
  }

  cargarListaFilter() {
    var data = new DatatableParameter(); data.pageNumber = ''; data.pageSize = ''; data.filter = ''; data.columnOrder = ''; data.directionOrder = ''; data.fechaInicio = this.formatDate(this.frmFacturas.controls["FechaInicio"].value); data.fechaFin = this.formatDate(this.frmFacturas.controls["FechaFin"].value);
    this.service.datatableDate('Factura', data).subscribe((res) => {
      // Actualiza los datos de la tabla
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.clear().rows.add(res.data).draw();
      });
    });

    setTimeout(() => {
      this.helperService.hideLoading();
    }, 500);
  }

  formatDate(inputDate: string): string {
    // Convert input string to Date object
    let dateObject = new Date(inputDate);

    // Format the date using DatePipe
    return this.datePipe.transform(dateObject, 'yyyy-MM-dd HH:mm:ss') || "Invalid Date";
  }

  limpiar() {
    this.helperService.showLoading();
    this.frmFacturas.controls["FechaInicio"].setValue(null);
    this.frmFacturas.controls["FechaFin"].setValue(null);
    this.statusForm = true;
    this.refrescarTabla();
  }
}

@NgModule({
  declarations: [FacturasIndexComponent],
  imports: [CommonModule, GeneralModule],
})
export class FacturasIndexModule { }