import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { AsignaturaService } from 'src/app/services/asignatura.service';
import { InsumoService } from 'src/app/services/insumo.service';
import { SolicitudService } from 'src/app/services/solicitud.service';
import { Asignatura } from '../models/asignatura';
import { Detalles } from '../models/detalles';
import { Insumo } from '../models/insumo';
import { Solicitud } from '../models/solicitud';

@Component({
  selector: 'app-solicitud',
  templateUrl: './solicitud.component.html',
  styleUrls: ['./solicitud.component.css']
})
export class SolicitudComponent implements OnInit {
  solicitud: Solicitud;
  detalle: Detalles;
  detalles: Detalles[];
  option: boolean = false;
  asignatura: Asignatura;
  stringAsignaturaa: string;
  asignaturas: Asignatura[];
  stringasi: string[];
  insumo: Insumo;
  insumos: Insumo[];
  stringInsumo: string;
  arrayinsumo: string[];
  constructor(private solicitudService: SolicitudService, private asignaturaService: AsignaturaService, private insumoService: InsumoService) { }

  ngOnInit(): void {
    this.llenarasignaturas();
    this.llenarInsumos();
    this.solicitud = new Solicitud;
    this.detalles = [];
    this.detalle = new Detalles;
    this.asignatura = new Asignatura;
    this.insumo = new Insumo;
  }

  add() {
    this.stringasi = this.stringAsignaturaa.split(';');
    this.asignatura = this.asignaturas.find(a => a.codigo == this.stringasi[1]);
    this.solicitud.asignatura = this.asignatura;
    this.solicitudService.post(this.solicitud).subscribe(p => {
      if (p != null) {
        alert('Solicitud # [' + p.numero + ']');
        this.solicitud = p;
      }
    });
  }

  anadirDetalles() {
    var fecha = new Date();
    this.arrayinsumo = this.stringInsumo.split(';');
    this.insumo = this.insumos.find(I => I.codigo == this.arrayinsumo[1]);
    this.detalle.insumo = this.insumo;
    this.detalle.fecha = fecha.getDate() + "/" + (fecha.getMonth() + 1) + "/" + fecha.getFullYear();
    this.detalle.numero = (this.detalles.length + 1).toString();
    var detallerespuesta = this.detalles.find(d => d.insumo.codigo == this.insumo.codigo);
    if (detallerespuesta != null) {
      var numero = this.detalles.findIndex(d => d.insumo.codigo == this.insumo.codigo)
          this.detalles[numero].cantidad += this.detalle.cantidad;
          this.detalles[numero].fecha = this.detalle.fecha;
    }
    else {
      this.detalles.push(this.detalle);
      this.solicitud.detalles = this.detalles;
      this.detalle = new Detalles;
      this.option = true;
    }
  }

  llenarasignaturas() {
    this.asignaturaService.get().subscribe(result => {
      this.asignaturas = result;
    })
  }

  llenarInsumos() {
    this.insumoService.get().subscribe(result => {
      this.insumos = result;
    })
  }

  eliminarDetalles(code: string) {
    var detallerespues = this.detalles.find(d => d.insumo.codigo == code);
    var detallesaux = [];
    if(detallerespues!=null)
    {
      for (let index = 0; index < this.detalles.length; index++) {
        var numero = this.detalles.findIndex(d => d.insumo.codigo == detallerespues.insumo.codigo);
        if(index!=numero)
        {
          detallesaux.push(this.detalles[index]);
        }
      }

      this.detalles = detallesaux;
    }
  }

  resete() {
    this.llenarasignaturas();
    this.llenarInsumos();
    this.solicitud = new Solicitud;
    this.detalles = [];
    this.detalle = new Detalles;
    this.asignatura = new Asignatura;
    this.insumo = new Insumo;
    this.option = false;
  }

}
