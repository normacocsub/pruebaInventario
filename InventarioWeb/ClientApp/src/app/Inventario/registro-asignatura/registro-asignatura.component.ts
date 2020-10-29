import { Component, OnInit } from '@angular/core';
import { AsignaturaService } from 'src/app/services/asignatura.service';
import { Asignatura } from '../models/asignatura';

@Component({
  selector: 'app-registro-asignatura',
  templateUrl: './registro-asignatura.component.html',
  styleUrls: ['./registro-asignatura.component.css']
})
export class RegistroAsignaturaComponent implements OnInit {

  asignatura: Asignatura;
  constructor(private asignaturaservice: AsignaturaService) { }

  ngOnInit(): void {
    this.asignatura = new Asignatura;
  }

  add()
  {
    this.asignaturaservice.post(this.asignatura).subscribe(p=>{
      if(p != null){
        alert('Asignatura # [' + p.codigo + ']');
        this.asignatura = p;
      }
    });
  }
}
