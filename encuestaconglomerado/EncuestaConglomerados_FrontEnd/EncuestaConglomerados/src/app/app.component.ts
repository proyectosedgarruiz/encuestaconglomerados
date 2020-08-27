import { Component, ViewChild } from '@angular/core';
import { Publicas } from '../models/parametricas.model';
import { EdicionEncuesta } from 'src/models/encuesta.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @ViewChild('encuesta',null) encuesta;
  title = 'EncuestaConglomerados';
  VisualizarLogin: boolean = true;
  VisualizarFormulario : boolean =false;
  VisualizarAdministrador : boolean =false;
  pub: Publicas;
  publicas : Publicas;
  edicion : EdicionEncuesta;
  
  ngOnInit() {
   
  }


  usuarioAutorizado($event) {

    this.pub = $event;

    if (this.pub.autorized === true) //Esta autorizado
    {
      if (this.pub.rol_id === 1 || this.pub.rol_id === 3) //Administrador o SuperAdministrador
      {
        this.VisualizarLogin = false;
        this.VisualizarFormulario = false;
        this.VisualizarAdministrador =true;
        this.publicas = this.pub;
        
      }
      else
        if (this.pub.rol_id === 2) //Digitador
        {
          this.VisualizarLogin = false;
          this.VisualizarFormulario = true;
          this.VisualizarAdministrador =false;
          this.publicas = this.pub;
        }

    }
  }
  
  cerrarsesion($event)
  {
    if($event === true) //Se cierra sesión
    {
      this.pub.autorized=false;
      this.pub.usu_id=0;
      this.pub.rol_id=0;

      this.VisualizarLogin = true;
      this.VisualizarFormulario = false;
      this.VisualizarAdministrador =false;

    }
  }

}
