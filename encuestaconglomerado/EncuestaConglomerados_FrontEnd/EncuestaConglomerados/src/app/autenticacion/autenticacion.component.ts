import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Usuarios, CambioClave, Publicas, Localidades } from '../../models/parametricas.model';
import { UsuarioService } from '../../services/usuarios.service';
import { EncuestaService } from '../../services/encuesta.service';


@Component({
  selector: 'app-autenticacion',
  templateUrl: './autenticacion.component.html',
  styleUrls: ['./autenticacion.component.css']
})
export class AutenticacionComponent implements OnInit {

  @Output() public usuarioAutorizado: EventEmitter<Publicas> = new EventEmitter<Publicas>();
  public usuario: Usuarios;
  public cambioclave: CambioClave;
  public pub: Publicas;

  //EMRO: Se adicionan dos nuevos atributos para el manejo de usuarios
  public loginUser: string;
  public passwordUser: string;

  public error: any;

  public StartedProcess: boolean = false;
  public AlertaClaveAnterior: boolean;
  public AlertaClaveErrada: boolean;
  public AlertaClaveNueva: boolean;
  public AlertaClaveConfirmada: boolean;
  public AlertaClaveDesiguales: boolean;
  public AlertaSistema: boolean;
  //EMRO: Se adiciona objeto para redireccionar al Login

  public VisualizarContenido: boolean;
  public VisualizarLogin: boolean = true;
  public VisualizaAdministrador: boolean;
  public VisualizarCambioClave: boolean;
  public displayVisualizarSistema: boolean;
  public VisualizarSistema: boolean;

  selectLocalidades: Array<Localidades>;
  selectUsuarios: Array<Usuarios>;

  public _loginForm: LoginObject;
  constructor(private usuarioservice: UsuarioService, private encuestaservice: EncuestaService
  ) {
    this.usuario = new Usuarios(0, '', '', '', '', 0, false, '', '', '', 0);

    this._loginForm = new LoginObject("", "", false);
  }

  ngOnInit() {
    this.inicializarPublicas();
  }



  //EMRO: Nuevo Metodo para obtener los datos de autenticación del usuario
  onLogin() {

    this.loginUser = this._loginForm.username;
    this.passwordUser = this._loginForm.password;
    this.getUsuario(this.loginUser, this.passwordUser);

  }


  onSubmitCambioClave(isValid) {

    if (isValid) {
      var ValorClaveAnterior = this.cambioclave.clave_anterior;
      var ValorClaveNueva = this.cambioclave.clave_nueva;
      var ValorClaveConfirmada = this.cambioclave.clave_confirmada;
      this.loginUser = this._loginForm.username;
      this.passwordUser = this._loginForm.password;

      if (ValorClaveAnterior == "") {

        alert('La clave anterior no debe estar vacia');
        this.AlertaClaveAnterior = true;
        return;
      } else {
        this.AlertaClaveAnterior = false;
        //return;
      }
      if (ValorClaveAnterior != this.passwordUser) {
        alert('La clave anterior no es correcta');
        this.AlertaClaveErrada = true;
        return;
      } else {
        this.AlertaClaveErrada = false;
      }
      if (ValorClaveNueva == "") {
        alert('La clave nueva no debe estar vacia');
        this.AlertaClaveNueva = true;
        return;
      } else {
        this.AlertaClaveNueva = false;
      }
      if (ValorClaveConfirmada == "") {
        alert('La clave confirmada no debe estar vacia');
        this.AlertaClaveConfirmada = true;
        return;
      } else {
        this.AlertaClaveConfirmada = false;
      }
      if (ValorClaveNueva != ValorClaveConfirmada) {
        alert('La clave nueva y la clave confirmada no son iguales');
        this.AlertaClaveDesiguales = true;
        return;
      } else {
        this.AlertaClaveDesiguales = false;

        this.cambioclave.id_usuario = this.pub.usu_id;


        this.usuarioservice.CambiarClaveUsuario(this.cambioclave).subscribe(
          result => {

            if (result.OperacionExitosa) {
              alert('Se ha cambiado la clave del usuario correctamente');
              this.VisualizarCambioClave = false;
              this.VisualizarContenido = false;
              this.VisualizarLogin = true;

            } else {
              alert('Error al Actualizar la clave');
            }
          },
          error => {
            this.error = error;
            if (this.error.statusText === 'Unauthorized') {
              // this.authenticationService.logout().subscribe(response => { });
              // this.storageService.logout();
            }
            console.log(<any>error);
          })
      }
    }
    else {
      //this._alert.showError('Formulario no válido, recargue la página e intentetelo nuevamente');
    }
  }


  public getUsuario(login, password) {
    this.encuestaservice.GetUsuarioAutorizado(login, password).subscribe(
      result => {
        this.selectUsuarios = result.Result.Lista;

        if (this.selectUsuarios.length > 0) {

          if (this.selectUsuarios[0].usu_req_clave == true) {

            this.inicializarCambioClave();
            this.VisualizarCambioClave = true;
            this.VisualizarLogin = false;
            this.pub.usu_id = this.selectUsuarios[0].usu_id;
            this.pub.sub_id = this.selectUsuarios[0].sub_id;

          }
          else {

            this.pub.autorized = true;
            this.pub.usu_id = this.selectUsuarios[0].usu_id;
            this.pub.rol_id = this.selectUsuarios[0].rol_id;
            this.pub.sub_id = this.selectUsuarios[0].sub_id;

            this.usuarioAutorizado.emit(this.pub);

          }
        }
        else {
          alert('Usuario No Valido. Intente nuevamente');
          //Usuario no Valido

        }

      },
      error => {
        this.error = error;
        console.error('Error [GetUsuarioAutorizado]');
        console.error(error);

      }
    );
  }
  inicializarCambioClave() {
    this.cambioclave =
    {
      clave_anterior: "",
      clave_nueva: "",
      clave_confirmada: "",
      id_usuario: 0

    };
  }


  inicializarPublicas() {
    this.pub =
    {
      autorized: false,
      usu_id: 0,
      rol_id: 0,
      sub_id: 0

    };
  }

}




export class LoginObject {

  constructor(public username: string,
    public password: string, public recordar: boolean
  ) { }
}