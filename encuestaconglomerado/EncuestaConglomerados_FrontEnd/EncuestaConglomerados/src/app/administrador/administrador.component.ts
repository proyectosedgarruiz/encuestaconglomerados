import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Publicas } from '../../models/parametricas.model';

@Component({
  selector: 'app-administrador',
  templateUrl: './administrador.component.html',
  styleUrls: ['./administrador.component.css']
})
export class AdministradorComponent implements OnInit {
  @Input() publicas: Publicas;
  @Output() public cerrar: EventEmitter<boolean> = new EventEmitter<boolean>();


  VisualizarSabana: boolean = false;
  VisualizarGestionUsuarios: boolean = false;
  opcion: string;


  constructor() { }

  ngOnInit() {
  }


  EjecutarAccion() {
   
    switch (this.opcion) {
      case "1": this.DescargarSabana(); break;
      case "2": this.GestionUsuarios(); break;
    }
  }

  DescargarSabana() {
   
    this.VisualizarSabana = true;
    this.VisualizarGestionUsuarios = false;
  }

  GestionUsuarios() {
    this.VisualizarSabana = false;
    this.VisualizarGestionUsuarios = true;
  }


  cerrarsesion() {
    //Retorna a la visualización de la autenticación.
    this.cerrar.emit(true);
  }
}
