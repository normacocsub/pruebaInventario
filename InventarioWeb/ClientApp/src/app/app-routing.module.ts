import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SolicitudComponent } from './Inventario/solicitud/solicitud.component';
import { Routes, RouterModule } from '@angular/router';​
import { RegistroAsignaturaComponent } from './Inventario/registro-asignatura/registro-asignatura.component';
import { RegistroInsumosComponent } from './Inventario/registro-insumos/registro-insumos.component';

const routes: Routes = [
  { path: 'SolicitudInventario', component: SolicitudComponent },
  { path: 'RegistroAsignatura', component: RegistroAsignaturaComponent },
  { path: 'RegistroInsumo', component: RegistroInsumosComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
