import { Component, OnInit, Input } from '@angular/core';
import { EncuestaService } from '../../services/encuesta.service';
import { ListaEncuesta, EdicionEncuesta, Encuesta } from '../../models/encuesta.model';
import { DxDataGridModule } from 'devextreme-angular';
import { Publicas } from 'src/models/parametricas.model';
@Component({
  selector: 'app-sabanaencuesta',
  templateUrl: './sabanaencuesta.component.html',
  styleUrls: ['./sabanaencuesta.component.css']
})
export class SabanaencuestaComponent implements OnInit {
  @Input() publicas: Publicas;
  edicion: EdicionEncuesta;
  encuesta: Encuesta;
  selectEncuestas: Array<ListaEncuesta>;

  tiposabana: Number = 0;
  fechainicial: String = '1900-01-01';
  fechafinal: String = '1900-01-01';
  todos: Number = 0;
  fecha: Number = 0;
  VisualizarFechas: Boolean = false;
  VisualizarSabana: Boolean = false;

  VisualizarEncuesta: Boolean = false; //Permite visualizar el formulario de Edición de la Encuesta

  VisualizarTituloSabana: Boolean = true;
  VisualizarEditarEncuesta: Boolean = false;


  constructor(private encuestaservice: EncuestaService) { }

  ngOnInit() {
    this.InicializarEdicion();
  }

  addZero(i) {
    if (i < 10) {
      i = '0' + i;
    }
    return i;
  }

  hoyFecha() {
    var hoy = new Date();
    var dd = hoy.getDate();
    var mm = hoy.getMonth() + 1;
    var yyyy = hoy.getFullYear();

    dd = this.addZero(dd);
    mm = this.addZero(mm);

    return dd + '/' + mm + '/' + yyyy;
  }

  AsignarFechasIniciales() {
    this.fechainicial = this.hoyFecha();
    this.fechafinal = this.hoyFecha();
  }


  Consultarsabana() {
    if (this.tiposabana == 1) {
      this.todos = 1;
      this.fecha = 0;
    }
    else if (this.tiposabana == 2) {
      this.todos = 0;
      this.fecha = 1;
    }

    if (this.tiposabana == 0) {
      alert('Debe seleccionar un criterio de consulta de la sábana');
    }

    else if (this.fecha == 1 && this.fechainicial === null && this.fechafinal === null) {
      alert('Debe indicar una fecha de inicio y una fecha final de búsqueda');

    }
    else {
      this.VisualizarSabana = true;

      //Se determina si el Usuario es SuperAdministrador o Administrador de SubRed
      if (this.publicas.rol_id === 3) //SuperAdministrador
        this.GetListaEncuestas();
      else
        if (this.publicas.rol_id === 1) //Administrador de SubRed
          this.GetListaEncuestasSubRed(this.publicas.sub_id);

    }


  }

  GetListaEncuestas() {
    this.encuestaservice.GetListEncuestas(this.todos, this.fecha, this.fechainicial, this.fechafinal).subscribe(
      result => {
        if (result != null)
          this.selectEncuestas = result.Result;
        else
          alert('No se encontraron registros asociados a la consulta');


      },
      error => {
        // this.error = error;
        console.error('Error [GetListEncuestas]');
        console.error(error);

      }
    );
  }


  GetListaEncuestasSubRed(sub_id: number) {
    this.encuestaservice.GetListEncuestasSubRed(this.todos, this.fecha, this.fechainicial, this.fechafinal, sub_id).subscribe(
      result => {
        if (result != null)
          this.selectEncuestas = result.Result;
        else
          alert('No se encontraron registros asociados a la consulta');


      },
      error => {
        // this.error = error;
        console.error('Error [GetListEncuestasSubRed]');
        console.error(error);

      }
    );
  }


  EditarEncuesta(id) {//Editar Encuesta
    this.edicion.editar = true;
    this.edicion.enc_id = id;
    this.VisualizarEncuesta = true;
    this.VisualizarSabana = false;
    this.VisualizarTituloSabana = false;
    this.VisualizarEditarEncuesta = true;

  }


  AnularEncuesta(id) {//Anular Encuesta
    this.inicializarEncuesta();
    this.encuesta.enc_id = id;
    this.encuestaservice.anularEncuesta(this.encuesta).subscribe(
      result => {
        if (result.OperacionExitosa) {
          this.VisualizarSabana = true;
          this.VisualizarTituloSabana = true;
          this.VisualizarEditarEncuesta = false;
          this.Consultarsabana();

        } else {
          alert('Error al Anular la Encuesta ');
        }

      }
    );

  }

  confirmarAnular(id) {
    var r = confirm("¿Confirma que anular esta encuesta ?");
    if (r == true) {
      this.AnularEncuesta(id);
    }
  }



  finalizoedicion($event) {
    if ($event === true) //Se cierra la ventana de Formulario
    {
      this.edicion.editar = false;
      this.VisualizarEncuesta = false;
      this.VisualizarSabana = true;
      this.VisualizarTituloSabana = true;
      this.VisualizarEditarEncuesta = false;

      this.Consultarsabana();
    }
  }


  InicializarEdicion() {
    this.edicion =
    {
      editar: false,
      enc_id: 0
    };
  }



  inicializarEncuesta() {
    this.encuesta =
    {
      enc_id: 0,
      enc_fecha: null,
      enc_dia: '',
      enc_mes: '',
      enc_ano: '',
      loc_id: 0,
      upz_id: -1,
      bar_id: 0,
      cua_id: 0,
      enc_muestreadopor: '',
      cpm_id: 0,
      enc_nombreencuestado: '',
      tpd_id: 0,
      enc_numerodocumento: '',
      enc_edad: 0,
      enc_genero: '',
      enc_dirresidencia: '',
      enc_numcelular: '',
      enc_aseguramiento: '',
      enc_nombreEAPB: '',
      enc_ocupacion: '',
      enc_cuantaspersonashabitan: 0,
      enc_cuantaspersonasmayores60: 0,
      enc_cuantascondicionescronicas: 0,
      enc_cuantashabitacionescuentaresidencia: 0,
      enc_hapresentadosintomas_fiebre: false,
      enc_hapresentadosintomas_tos: false,
      enc_hapresentadosintomas_dolorgarganta: false,
      enc_hapresentadosintomas_fatigadebilidad: false,
      enc_hapresentadosintomas_ahogofaltaaire: false,
      enc_hapresentadosintomas_ninguno: false,
      enc_comoconsideracumplimientocuarentena: '',
      enc_contactopersonas24horas: '',
      enc_dondedesplazoustedomiembrofamilia: '',
      enc_motivosalirdecasa_noaplica: false,
      enc_motivosalirdecasa_atrabajar: false,
      enc_motivosalirdecasa_compraralimento: false,
      enc_motivosalirdecasa_ahacerdeporte: false,
      enc_motivosalirdecasa_acitamedica: false,
      enc_motivosalirdecasa_sacarmascota: false,
      enc_motivosalirdecasa_diligenciabancaria: false,
      enc_motivosalirdecasa_socializar: false,
      enc_motivosalirdecasa_otro: false,
      enc_otromotivosalirdecasa: '',
      enc_mediostransporteutilizo_noaplica: false,
      enc_mediostransporteutilizo_transmilenio: false,
      enc_mediostransporteutilizo_sitp: false,
      enc_mediostransporteutilizo_moto: false,
      enc_mediostransporteutilizo_bicicleta: false,
      enc_mediostransporteutilizo_taxi: false,
      enc_mediostransporteutilizo_carro: false,
      enc_mediostransporteutilizo_apie: false,
      enc_mediostransporteutilizo_otro: false,
      sub_id: 0,
      usu_id: 0

    };
  }
}