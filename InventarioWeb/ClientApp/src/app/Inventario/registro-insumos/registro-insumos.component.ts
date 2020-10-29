import { Component, OnInit } from '@angular/core';
import { InsumoService } from 'src/app/services/insumo.service';
import { Insumo } from '../models/insumo';

@Component({
  selector: 'app-registro-insumos',
  templateUrl: './registro-insumos.component.html',
  styleUrls: ['./registro-insumos.component.css']
})
export class RegistroInsumosComponent implements OnInit {
  insumo: Insumo;
  constructor(private insumoService: InsumoService) { }

  ngOnInit(): void {
    this.insumo = new Insumo;
  }

  add()
  {
    this.insumoService.post(this.insumo).subscribe(p=>{
      if(p != null){
        alert('Insumo # [' + p.codigo + ']');
        this.insumo = p;
      }
    });
  }

}
