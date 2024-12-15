import { Component, OnInit, NgModule, signal, ViewChild } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { GeneralModule } from 'src/app/general/general.module';
import { GeneralParameterService } from '../../../../../generic/general.service';
import { DatatableParameter } from '../../../../../admin/datatable.parameters';
import { LANGUAGE_DATATABLE } from 'src/app/admin/datatable.language';
import { HelperService, Messages, MessageType } from 'src/app/admin/helper.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-facturas-detalles-index',
  standalone: false,
  templateUrl: './facturas-detalles-index.component.html',
  styleUrl: './facturas-detalles-index.component.css'
})
export class FacturasDetallesIndexComponent implements OnInit {
  title = 'Listado detalles de facturas';
  breadcrumb!: any[];
  public dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective) dtElement!: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  frmFacturaDetalles: FormGroup;
  statusForm: boolean = true;

  constructor(
    private service: GeneralParameterService,
    public helperService: HelperService,
    private datePipe: DatePipe
  ) {
    this.breadcrumb = [
      { name: `Inicio`, icon: `fa-duotone fa-house` },
      { name: 'Operativo', icon: 'fa-duotone fa-shop' },
      { name: 'Facturas Detalles', icon: 'fa-duotone fa-file-invoice' },
    ];

    this.frmFacturaDetalles = new FormGroup({
      FechaInicio: new FormControl(null, [Validators.required]),
      FechaFin: new FormControl(null, [Validators.required]),
    });
  }

  ngOnInit(): void {
    this.cargarLista();
  }

  ngAfterViewInit() {
    this.dtTrigger.next(this.dtOptions);
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  cargarLista() {
    var that = this;
    this.dtOptions = {
      dom: 'Blfrtip',
      processing: true,
      ordering: true,
      responsive: true,
      paging: true,
      order: [0, 'desc'],
      language: LANGUAGE_DATATABLE,
      ajax: (dataTablesParameters: any, callback: any) => {
        var data = new DatatableParameter(); data.pageNumber = ''; data.pageSize = ''; data.filter = ''; data.columnOrder = ''; data.directionOrder = '';
        this.service.datatable('FacturaDetalle', data).subscribe((res) => {
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
          title: 'FECHA',
          data: 'createAt',
          className: 'text-center',
          render: function (item: any) {
            return that.helperService.convertDateTime(item);
          }
        },
        {
          title: 'N° FACTURA',
          data: 'factura',
          className: 'text-center',
        },
        {
          title: 'CÓDIGO',
          data: 'codigo',
          className: 'text-center',
        },
        {
          title: 'NOMBRE',
          data: 'producto',
          className: 'text-center',
        },
        {
          title: 'CANTIDAD',
          data: 'cantidad',
          className: 'text-center',
        },
        {
          title: 'PRECIO',
          data: 'precioProducto',
          className: 'text-center',
          render: function (item: any) {
            return "$ " + that.helperService.formaterNumber(item);
          },
        },
        {
          title: 'SUBTOTAL',
          data: 'subTotal',
          className: 'text-center',
          render: function (item: any) {
            return "$ " + that.helperService.formaterNumber(item);
          },
        },
        {
          title: 'DESCUENTO',
          data: 'descuento',
          className: 'text-center',
          render: function (item: any) {
            return "$ " + that.helperService.formaterNumber(item);
          },
        },
        {
          title: 'IVA',
          data: 'iva',
          className: 'text-center',
          render: function (item: any) {
            return that.helperService.formaterNumber(item) + " %";
          },
        },
      ],
      drawCallback: () => {

      },
    };
  }

  refrescarTabla() {
    if (typeof this.dtElement.dtInstance != 'undefined') {
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.ajax.reload();
      });
    }
  }

  buscar() {
    if (this.frmFacturaDetalles.invalid) {
      this.statusForm = false;
      this.helperService.showMessage(MessageType.WARNING, Messages.EMPTYFIELD);
      return;
    }

    this.helperService.showLoading();
    this.cargarListaFilter();
  }

  cargarListaFilter() {
    var data = new DatatableParameter(); data.pageNumber = ''; data.pageSize = ''; data.filter = ''; data.columnOrder = ''; data.directionOrder = ''; data.fechaInicio = this.formatDate(this.frmFacturaDetalles.controls["FechaInicio"].value); data.fechaFin = this.formatDate(this.frmFacturaDetalles.controls["FechaFin"].value);
    this.service.datatableDate('FacturaDetalle', data).subscribe((res) => {
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
}
@NgModule({
  declarations: [
    FacturasDetallesIndexComponent,
  ],
  imports: [
    CommonModule,
    GeneralModule,
  ]
})
export class FacturasDetallesIndexModule { }