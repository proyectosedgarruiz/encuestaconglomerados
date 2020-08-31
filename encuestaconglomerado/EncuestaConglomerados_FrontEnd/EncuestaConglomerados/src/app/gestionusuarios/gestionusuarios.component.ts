import { Component, OnInit, Input } from '@angular/core';
import { Roles, Usuarios, SubRedes, UsuariosLista, Publicas } from 'src/models/parametricas.model';
import { UsuarioService } from 'src/services/usuarios.service';
import { EncuestaService } from 'src/services/encuesta.service';

@Component({
  selector: 'app-gestionusuarios',
  templateUrl: './gestionusuarios.component.html',
  styleUrls: ['./gestionusuarios.component.css']
})
export class GestionusuariosComponent implements OnInit {
  @Input() publicas: Publicas;

  public idUsuario: string;
  public DisplayCrearClave: boolean;
  public DisplayVisualizarClave: boolean;

  public displayListUsuarios: boolean;
  public displayCrearUsuarios: boolean;

  public error: any;


  public rolesLista: Array<Roles>;
  public usuarios: Usuarios;
  public usuariosLista: Array<UsuariosLista>;
  public operacion = 'C';
  public operacionEntidadUsuario = 'C';
  selectSubRedes : Array<SubRedes>;
  

  constructor(private encuestaservice: EncuestaService, private usuarioservice: UsuarioService
  ) {

    this.displayListUsuarios = true;
    this.displayCrearUsuarios = false;
  }

  ngOnInit() {
    this.displayListUsuarios = true;
    this.ObtenerRoles();
    this.GetListaSubRedes();
    this.MostrarListadoUsuarios();

  }

MostrarListadoUsuarios()
{
  if(this.publicas.rol_id === 3) //SuperAdministrador
    this.ObtenerUsuarios();
    else if(this.publicas.rol_id === 1) //Administrador SubRed
    this.ObtenerUsuariosSubRed(this.publicas.sub_id);
}

  GetListaSubRedes() {
    this.encuestaservice.GetListaSubRedes().subscribe(
      result => {
        this.selectSubRedes = result.Result.Lista;
        var objsubred: SubRedes = new SubRedes(0, '');
        objsubred.sub_id = -1;
        objsubred.sub_nombre = "-- Seleccione la SubRed--";
        this.selectSubRedes.push(objsubred);
        
        if(this.publicas.rol_id === 3) //Si es SuperAdministrador, se le permite asignar la SubRed SIN ASIGNAR
        {
          var objsubred2: SubRedes = new SubRedes(0, '');
          objsubred2.sub_id = 0;
          objsubred2.sub_nombre = "SIN ASIGNAR";
          this.selectSubRedes.push(objsubred2);
        }
        
        this.selectSubRedes.sort((a, b) => (a.sub_id > b.sub_id) ? 1 : ((b.sub_id > a.sub_id) ? -1 : 0));
       

      },
      error => {
        this.error = error;
        console.error('Error [GetListaSubRedes]');
        console.error(error);

      }
    );
  }

  public ObtenerRoles() {

    this.encuestaservice.GetListaRoles().subscribe(
      res => {
        this.rolesLista = res.Result.Lista;
      },
      error => {
        //this._alert.showError(error.message);
      }
    );
  }


  public ObtenerUsuarios() {

    this.usuarioservice.GetListaUsuarios().subscribe(
      res => {
        this.usuariosLista = res.Result.Lista;
      },
      error => {
        //this._alert.showError(error.message);
      }
    );
  }

  public ObtenerUsuariosSubRed(sub_id : number) {

    this.usuarioservice.GetListaUsuariosSubRed(sub_id).subscribe(
      res => {
        this.usuariosLista = res.Result.Lista;
      },
      error => {
        //this._alert.showError(error.message);
      }
    );
  }

  showPanel(sw, id) { //Eventos del CRUD

    if (sw === 'C') {//Crear Usuarios
      this.displayListUsuarios = false;
      this.displayCrearUsuarios = true;
      this.inicializarUsuario();
      this.ObtenerRoles();
    }
    else if (sw === 'V') {//Volver al listado de Usuarios
      this.displayListUsuarios = true;
      this.displayCrearUsuarios = false;
      this.MostrarListadoUsuarios();

    }

    else if (sw === 'U') {//Actualizar Usuarios

      this.inicializarUsuario();
      this.ObtenerRoles();

      this.usuarioservice.GetUsuario(id).subscribe(
        result => {

          this.operacion = 'U';
          this.displayListUsuarios = false;

          this.usuarios = <Usuarios>result;
          this.usuarios.rol_id = result.rol_id;

  
          if(this.usuarios.sub_id == null || this.usuarios.sub_id == null)
          this.usuarios.sub_id =0;

          this.displayCrearUsuarios = true;

        },
        error => {
          this.error = error;
          if (error.statusText === 'Unauthorized') {
          }
          console.log(<any>error);
        }
      );

    }

  }



  visualizarcrearclave() {
    this.DisplayCrearClave = true;
    this.DisplayVisualizarClave = false;
  }


  asignarclave() {
    var ValorOriginalClave = this.usuarios.usu_asignar_clave;

    if (ValorOriginalClave == "") {
      alert('La clave no debe estar vacia');
      return;

    }
    else {

      this.usuarioservice.AsignarClaveUsuario(ValorOriginalClave).subscribe(
        result => {
          this.usuarios.usu_password = result;
          this.DisplayCrearClave = false;
          alert('Se ha cifrado y asignado la clave al usuario');

        }
      );
    }

  }


  visualizarclave() {
    this.DisplayVisualizarClave = true;
    this.usuarioservice.VisualizarClaveUsuario(this.usuarios.usu_password).subscribe(
      result => {
        this.usuarios.usu_visualizar_clave = result;
      });
  }



  onSubmitUsuarios(isValid) {

    if (isValid) {

      if(this.publicas.rol_id === 3) //Si es SuperAdministrador, se le permite grabar la SubRed En NULL
      
      if(this.usuarios.usu_id === 1)
      this.usuarios.sub_id = null;
      

      if (this.operacion === 'C') {
        this.usuarioservice.addUsuario(this.usuarios).subscribe(
          result => {

            if (result.OperacionExitosa) {
              alert('Se ha ingresado el usuario correctamente');

              this.showPanel('V', 0);
            } else {
              alert('Error al ingresar el usuario');
            }
          },
          error => {
            this.error = error;
            if (this.error.statusText === 'Unauthorized') {
            }
            console.log(<any>error);
          })

      }
      else if (this.operacion === 'U') {

        this.usuarioservice.setUsuario(this.usuarios).subscribe(
          result => {
            if (result.OperacionExitosa) {
              alert('Se ha actualizado el usuario correctamente');
              this.operacion = 'C';
              this.showPanel('V', 0);
            } else {
              alert('Error al actualizar el usuario');
            }
          },
          error => {
            this.error = error;
            console.log(<any>error);
          })
      }
    }
    else {
      alert('Formulario Invalido');
    }
  }


  inicializarUsuario() {
    this.usuarios =
    {
      usu_id: 0,
      usu_login: "",
      usu_nombre: "",
      usu_estado: "",
      usu_password: "",
      usu_req_clave: true,
      rol_id: 0,
      usu_asignar_clave: "",
      usu_visualizar_clave: "",
      clave: "",
      sub_id: 0
    };
  }


}




