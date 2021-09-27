import { Component, OnInit, ViewEncapsulation, Input, Output, EventEmitter } from '@angular/core';
import { EncuestaService } from '../../services/encuesta.service';
import { Encuesta, EdicionEncuesta } from '../../models/encuesta.model';
import { Localidades, UPZs, Barrios, TipoDocumento, Cuadrantes, Publicas, CriterioPriorizacionMuestra, SubRedes } from '../../models/parametricas.model';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-encuesta',
  templateUrl: './encuesta.component.html',
  styleUrls: ['./encuesta.component.css'],
  encapsulation: ViewEncapsulation.None // Use to disable CSS Encapsulation for this component
})
export class EncuestaComponent implements OnInit {
  @Input() publicas: Publicas;
  @Input() edicion: EdicionEncuesta;

  @Output() public cerrar: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() public finalizoedicion: EventEmitter<boolean> = new EventEmitter<boolean>();

  encuesta: Encuesta;
  selectLocalidades: Array<Localidades>;
  selectUPZs: Array<UPZs>;
  selectBarrios: Array<Barrios>;
  selectCuadrantes: Array<Cuadrantes>;
  selectTipoDocumento: Array<TipoDocumento>;
  selectCriterioPriorizacionMuestra: Array<CriterioPriorizacionMuestra>;
  selectSubRedes: Array<SubRedes>;

  seleccionadoLocalidad: boolean;
  seleccionadoUPZ: boolean;
  formSaved: boolean;
  otromotivoseleccionado: boolean = false;
  otrasenfermedadeseleccionado: boolean = false;

  error: any;
  ValorServicio: any;

  errorLabel = false;
  successLabel = false;
  errorText: string;
  successText: string;
  public usuariodigitador: number;

  FechaHora: Date;
  FechaHoraMax: string;
  FechaEdicion: string;


  InhabilitadoUPZ: boolean = true;
  InhabilitadoBarrio: boolean = true;
  InhabilitadoCuadrante: boolean = true;

  VisualizarCerrarSesion: boolean = true;

  VisualizarBotonGuardar: boolean = true;
  VisualizarBotonActualizar: boolean = false;

  SolicitudGrabacion: boolean = false;


  constructor(private encuestaservice: EncuestaService) { }

  ngOnInit() {
    //Cargue de Datos Iniciales
    this.inicializarEncuesta();
    this.ObtenerFechaMinima();

    if (this.edicion != null || this.edicion != undefined) {
      //Se determina si proviene de consulta para edición, se Consulta los datos de la Encuesta Realizada
      if (this.edicion.editar === true && this.edicion.enc_id != 0) {
        this.VisualizarCerrarSesion = false;
        this.VisualizarBotonGuardar = false;
        this.VisualizarBotonActualizar = true;
        this.GetInformacionEncuesta(this.edicion.enc_id);
      }
    }
    else {

      this.GetListaLocalidades(null);
      this.GetListaCriterioPriorizacionMuestra(null);
      this.GetListaTipoDocumentos(null);

      if (this.publicas.sub_id != 0 && this.publicas.sub_id != null) {
        this.GetListaSubRedes(this.publicas.sub_id);
      }
      else {
        this.GetListaSubRedes(null);
      }
    }
  }


  GetInformacionEncuestaResult(enc_id: number): any {
    return this.encuestaservice.GetEncuestaById(enc_id).toPromise();
  }

  async GetInformacionEncuesta(enc_id: number) {
    try {

      if (!this.ValorServicio) {
        this.ValorServicio = await this.GetInformacionEncuestaResult(enc_id);

        this.encuesta = <Encuesta>this.ValorServicio;
        this.FechaEdicion = formatDate(this.encuesta.enc_fecha, 'yyyy-MM-dd', 'en-US');

        this.GetListaLocalidades(this.ValorServicio.loc_id);
        this.GetListaCriterioPriorizacionMuestra(this.ValorServicio.cpm_id);
        this.GetListaTipoDocumentos(this.ValorServicio.tpd_id);
        this.GetListaSubRedes(this.ValorServicio.sub_id);

        this.InhabilitadoUPZ = false;
        this.GetListaUPZs(this.encuesta.loc_id, this.ValorServicio.upz_id);

        this.InhabilitadoBarrio = false;
        this.GetListaBarrios(this.encuesta.loc_id, this.ValorServicio.bar_id);

        this.InhabilitadoCuadrante = false;
        this.GetListaCuadrantes(this.encuesta.loc_id, this.encuesta.upz_id, this.encuesta.cua_id);

      }

    }
    catch (error) {
      console.error('[error en GetListaLocalidades] : ' + error);
    }
  }


  ObtenerFechaMinima() {
    this.FechaHora = new Date();
    this.FechaHoraMax = formatDate(this.FechaHora, 'yyyy-MM-dd', 'en-US');

  }

  GetListaLocalidadesResult(): any {
    return this.encuestaservice.GetListaLocalidades().toPromise();
  }

  async GetListaLocalidades(loc_id: number) {
    try {
      this.ValorServicio = await this.GetListaLocalidadesResult();
      this.selectLocalidades = this.ValorServicio.Result.Lista;
      var objlocalidad: Localidades = new Localidades(0, '', 0, '');
      objlocalidad.loc_id = 0;
      objlocalidad.loc_nombre = "-- Seleccione la Localidad --";
      this.selectLocalidades.push(objlocalidad);
      this.selectLocalidades.sort((a, b) => (a.loc_nombre > b.loc_nombre) ? 1 : ((b.loc_nombre > a.loc_nombre) ? -1 : 0));
      this.encuesta.loc_id = 0;

      if (loc_id != 0 && loc_id != null)
        this.encuesta.loc_id = loc_id;
      else
        this.encuesta.loc_id = 0;

    }
    catch (error) {
      console.error('[error en GetListaLocalidades] : ' + error);
    }
  }

  GetListaUpzsResult(localidad: number): any {
    return this.encuestaservice.GetListaUPZs(localidad).toPromise();
  }

  async GetListaUPZs(localidad: number, upz_id: number) {
    this.InhabilitadoUPZ = true;
    if (this.encuesta.loc_id != 0)
      this.seleccionadoLocalidad = true;
    else
      this.seleccionadoLocalidad = false;

    try {
      this.ValorServicio = await this.GetListaUpzsResult(localidad);
      this.selectUPZs = this.ValorServicio.Result.Lista;

      var objupz: UPZs = new UPZs(0, '', 0, 0, '');
      objupz.upz_id = -1;
      objupz.upz_nombre = "-- Seleccione la UPZ --";

      var objupz2: UPZs = new UPZs(0, '', 0, 0, '');
      objupz2.upz_id = 0;
      objupz2.upz_nombre = "SIN UPZ";
      this.selectUPZs.push(objupz);
      this.selectUPZs.push(objupz2);

      this.selectUPZs.sort((a, b) => (a.upz_nombre > b.upz_nombre) ? 1 : ((b.upz_nombre > a.upz_nombre) ? -1 : 0));

      if (upz_id != 0 && upz_id != null)
        this.encuesta.upz_id = upz_id;
      else if (upz_id == 0)
        this.encuesta.upz_id = 0;
      else
        this.encuesta.upz_id = -1;

      this.InhabilitadoUPZ = false;

    }
    catch (error) {
      console.error('[error en GetListaUPZs] : ' + error);
    }

  }


  GetListaBarriosResult(localidad: number): any {
    return this.encuestaservice.GetListaBarrios(localidad).toPromise();
  }

  async GetListaBarrios(localidad: number, bar_id: number) {
    this.InhabilitadoBarrio = true;

    try {
      this.ValorServicio = await this.GetListaBarriosResult(localidad);
      this.selectBarrios = this.ValorServicio.Result.Lista;
      var objbarrio: Barrios = new Barrios(0, '', 0, 0, 0);
      objbarrio.bar_id = 0;
      objbarrio.bar_nombre = "-- Seleccione el Barrio --";
      this.selectBarrios.push(objbarrio);
      this.selectBarrios.sort((a, b) => (a.bar_nombre > b.bar_nombre) ? 1 : ((b.bar_nombre > a.bar_nombre) ? -1 : 0));

      if (bar_id != 0 && bar_id != null)
        this.encuesta.bar_id = bar_id;
      else
        this.encuesta.bar_id = 0;

      this.InhabilitadoBarrio = false;
    }
    catch (error) {
      console.error('[error en GetListaBarrios] : ' + error);
    }
  }


  GetListaCuadrantesResult(loc_id: number, upz_id: number): any {
    return this.encuestaservice.GetListaCuadrantes(loc_id, upz_id).toPromise();
  }

  async GetListaCuadrantes(loc_id: number, upz_id: number, cua_id: number) {
    this.InhabilitadoCuadrante = true;
    try {
      this.ValorServicio = await this.GetListaCuadrantesResult(loc_id, upz_id);
      this.selectCuadrantes = this.ValorServicio.Result.Lista;
      var objcuadrante: Cuadrantes = new Cuadrantes(0, '');
      objcuadrante.cua_id = 0;
      objcuadrante.cua_nombre = "-- Seleccione el Cuadrante --";
      this.selectCuadrantes.push(objcuadrante);
      this.selectCuadrantes.sort((a, b) => (a.cua_id > b.cua_id) ? 1 : ((b.cua_id > a.cua_id) ? -1 : 0));

      if (cua_id != 0 && cua_id != null)
        this.encuesta.cua_id = cua_id;
      else
        this.encuesta.cua_id = 0;

      this.InhabilitadoCuadrante = false;
    }
    catch (error) {
      console.error('[error en GetListaCuadrantes] : ' + error);
    }

  }


  GetListaTipoDocumentosResult(): any {
    return this.encuestaservice.GetListaTipoDocumentos().toPromise();
  }

  async GetListaTipoDocumentos(tpd_id: number) {
    try {
      this.ValorServicio = await this.GetListaTipoDocumentosResult();
      this.selectTipoDocumento = this.ValorServicio.Result.Lista;
      var objtipodocumento: TipoDocumento = new TipoDocumento(0, '');
      objtipodocumento.tpd_id = 0;
      objtipodocumento.tpd_nombre = "-- Seleccione el Tipo de Documento --";
      this.selectTipoDocumento.push(objtipodocumento);
      this.selectTipoDocumento.sort((a, b) => (a.tpd_id > b.tpd_id) ? 1 : ((b.tpd_id > a.tpd_id) ? -1 : 0));
      this.encuesta.tpd_id = 0;

      if (tpd_id != 0 && tpd_id != null)
        this.encuesta.tpd_id = tpd_id;
      else
        this.encuesta.tpd_id = 0;
    }
    catch (error) {
      console.error('[error en GetListaTipoDocumentos] : ' + error);
    }
  }



  GetListaCriterioPriorizacionMuestraResult(): any {
    return this.encuestaservice.GetListaCriterioPriorizacionMuestra().toPromise();
  }

  async GetListaCriterioPriorizacionMuestra(cpm_id: number) {
    try {
      this.ValorServicio = await this.GetListaCriterioPriorizacionMuestraResult();
      this.selectCriterioPriorizacionMuestra = this.ValorServicio.Result.Lista;
      var objcriterio: CriterioPriorizacionMuestra = new CriterioPriorizacionMuestra(0, '');
      objcriterio.cpm_id = 0;
      objcriterio.cpm_nombre = "-- Seleccione el Criterio Priorización Muestra--";
      this.selectCriterioPriorizacionMuestra.push(objcriterio);
      this.selectCriterioPriorizacionMuestra.sort((a, b) => (a.cpm_id > b.cpm_id) ? 1 : ((b.cpm_id > a.cpm_id) ? -1 : 0));
      this.encuesta.cpm_id = 0;

      if (cpm_id != 0 && cpm_id != null)
        this.encuesta.cpm_id = cpm_id;
      else
        this.encuesta.cpm_id = 0;
    }
    catch (error) {
      console.error('[error en GetListaCriterioPriorizacionMuestra] : ' + error);
    }
  }



  GetListaSubRedesResult(): any {
    return this.encuestaservice.GetListaSubRedes().toPromise();
  }

  async GetListaSubRedes(sub_id: number) {
    try {
      this.ValorServicio = await this.GetListaSubRedesResult();
      this.selectSubRedes = this.ValorServicio.Result.Lista;
      var objsubred: SubRedes = new SubRedes(0, '');
      objsubred.sub_id = 0;
      objsubred.sub_nombre = "-- Seleccione la SubRed--";
      this.selectSubRedes.push(objsubred);
      this.selectSubRedes.sort((a, b) => (a.sub_id > b.sub_id) ? 1 : ((b.sub_id > a.sub_id) ? -1 : 0));
      this.encuesta.sub_id = 0;

      if (sub_id != 0 && sub_id != null)
        this.encuesta.sub_id = sub_id;
      else
        this.encuesta.sub_id = 0;


      const selectsub_id = document.getElementById('sub_id') as HTMLSelectElement;
      if (selectsub_id != undefined) {
        selectsub_id.disabled = true;
      }

    }
    catch (error) {
      console.error('[error en GetListaSubRedes] : ' + error);
    }
  }




  soloNumeros(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if ((charCode < 46) || (charCode > 57))
      return false;
    else
      return true;

  }

  deshabilitarnoaplicasintomas() {
    this.encuesta.enc_hapresentadosintomas_ninguno = false;
  }

  deshabilitarsintomas() {
    this.encuesta.enc_hapresentadosintomas_fiebre = false;
    this.encuesta.enc_hapresentadosintomas_tos = false;
    this.encuesta.enc_hapresentadosintomas_dolorgarganta = false;
    this.encuesta.enc_hapresentadosintomas_fatigadebilidad = false;
    this.encuesta.enc_hapresentadosintomas_ahogofaltaaire = false;
    this.encuesta.enc_hapresentadosintomas_diarrea = false;
    this.encuesta.enc_hapresentadosintomas_perdidaolfato = false;
  }

  deshabilitarnoaplicasintomasconvive() {
    this.encuesta.enc_convivepresentadosintomas_ninguno = false;
  }

  deshabilitarsintomasconvive() {
    this.encuesta.enc_convivepresentadosintomas_fiebre = false;
    this.encuesta.enc_convivepresentadosintomas_tos = false;
    this.encuesta.enc_convivepresentadosintomas_dolorgarganta = false;
    this.encuesta.enc_convivepresentadosintomas_fatigadebilidad = false;
    this.encuesta.enc_convivepresentadosintomas_ahogofaltaaire = false;
    this.encuesta.enc_convivehapresentadosintomas_diarrea = false;
    this.encuesta.enc_convivehapresentadosintomas_perdidaolfato = false;
  }


  deshabilitarmotivosalirdecasanoaplica() {
    this.encuesta.enc_motivosalirdecasa_noaplica = false;
  }

  deshabilitarmotivosalirdecasa() {
    this.encuesta.enc_motivosalirdecasa_atrabajar = false;
    this.encuesta.enc_motivosalirdecasa_compraralimento = false;
    this.encuesta.enc_motivosalirdecasa_ahacerdeporte = false;
    this.encuesta.enc_motivosalirdecasa_acitamedica = false;
    this.encuesta.enc_motivosalirdecasa_sacarmascota = false;
    this.encuesta.enc_motivosalirdecasa_diligenciabancaria = false;
    this.encuesta.enc_motivosalirdecasa_socializar = false;
    this.encuesta.enc_motivosalirdecasa_otro = false;
    this.otromotivoseleccionado = false;
  }

  deshabilitarmediotransportenoaplica() {
    this.encuesta.enc_mediostransporteutilizo_noaplica = false;
  }


  deshabilitarmediotransporte() {
    this.encuesta.enc_mediostransporteutilizo_transmilenio = false;
    this.encuesta.enc_mediostransporteutilizo_sitp = false;
    this.encuesta.enc_mediostransporteutilizo_moto = false;
    this.encuesta.enc_mediostransporteutilizo_bicicleta = false;
    this.encuesta.enc_mediostransporteutilizo_taxi = false;
    this.encuesta.enc_mediostransporteutilizo_carro = false;
    this.encuesta.enc_mediostransporteutilizo_apie = false;
    this.encuesta.enc_mediostransporteutilizo_otro = false;
  }


  ShowAlertsValidations() {
    this.errorLabel = true;
    setTimeout(() => {
      this.errorLabel = false;
    }, 2500);
  }

  validateForm() {

    let FechaSeleccionada = new Date(this.encuesta.enc_fecha);
    let FechaActual = new Date(this.FechaHoraMax);

    if (this.encuesta.enc_fecha === null || this.encuesta.enc_fecha === undefined) {
      this.errorText = 'Por favor seleccione la fecha';
      this.ShowAlertsValidations();
      return false;
    }
    else if (FechaSeleccionada > FechaActual) {
      this.errorText = 'Por favor la Fecha Seleccionada no puede ser superior a la Fecha Actual';
      this.ShowAlertsValidations();
    }
    else if (this.encuesta.loc_id === 0 || this.encuesta.loc_id === undefined) {
      this.errorText = 'Por favor seleccione la localidad';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.upz_id === -1 || this.encuesta.upz_id === undefined) {
      this.errorText = 'Por favor seleccione la UPZ';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.bar_id === 0 || this.encuesta.bar_id === undefined) {
      this.errorText = 'Por favor seleccione el barrio';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.cua_id === 0 || this.encuesta.cua_id === undefined) {
      this.errorText = 'Por favor seleccione el cuadrante';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_muestreadopor === '' || this.encuesta.enc_muestreadopor === undefined) {
      this.errorText = 'Por favor seleccione una opción en la casilla muestrado por';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.cpm_id === 0 || this.encuesta.cpm_id === undefined) {
      this.errorText = 'Por favor seleccione el criterio de priorización para muestra';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_nombreencuestado === '' || this.encuesta.enc_nombreencuestado === undefined) {
      this.errorText = 'Por favor ingrese el nombre del encuestado';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.tpd_id === 0 || this.encuesta.tpd_id === undefined) {
      this.errorText = 'Por favor seleccione el tipo de documento';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_numerodocumento === '' || this.encuesta.enc_numerodocumento === undefined) {
      this.errorText = 'Por favor ingrese el número de documento';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_aseguramiento === '' || this.encuesta.enc_aseguramiento === undefined) {
      this.errorText = 'Por favor seleccione una opción en la casilla aseguramiento';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_ocupacion === '' || this.encuesta.enc_ocupacion === undefined) {
      this.errorText = 'Por favor ingrese el nombre de la ocupación';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_cuantaspersonashabitan === null || this.encuesta.enc_cuantaspersonashabitan === undefined) {
      this.errorText = 'Por favor ingrese un valor en la casilla cuantas personas habitan en su residencia';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_cuantaspersonasmayores60 === null || this.encuesta.enc_cuantaspersonasmayores60 === undefined) {
      this.errorText = 'Por favor ingrese un valor en la casilla cuantas personas son mayores de 60 años';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_cuantascondicionescronicas === null || this.encuesta.enc_cuantascondicionescronicas === undefined) {
      this.errorText = 'Por favor ingrese un valor en la casilla cuantas con condiciones crónicas';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_cuantashabitacionescuentaresidencia === null || this.encuesta.enc_cuantashabitacionescuentaresidencia === undefined) {
      this.errorText = 'Por favor ingrese un valor en la casilla con cuantas habitaciones cuenta la residencia';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_hapresentadosintomas_fiebre === false &&
      this.encuesta.enc_hapresentadosintomas_tos === false &&
      this.encuesta.enc_hapresentadosintomas_dolorgarganta === false &&
      this.encuesta.enc_hapresentadosintomas_fatigadebilidad === false &&
      this.encuesta.enc_hapresentadosintomas_ahogofaltaaire === false &&
      this.encuesta.enc_hapresentadosintomas_dolorestomago === false &&
      this.encuesta.enc_hapresentadosintomas_diarrea === false &&
      this.encuesta.enc_hapresentadosintomas_perdidaolfato === false &&
      this.encuesta.enc_hapresentadosintomas_ninguno === false) {
      this.errorText = 'Por favor seleccione mínimo una opción en la casilla ha presentado sintomas';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_convivepresentadosintomas_fiebre === false &&
      this.encuesta.enc_convivepresentadosintomas_tos === false &&
      this.encuesta.enc_convivepresentadosintomas_dolorgarganta === false &&
      this.encuesta.enc_convivepresentadosintomas_fatigadebilidad === false &&
      this.encuesta.enc_convivepresentadosintomas_ahogofaltaaire === false &&
      this.encuesta.enc_convivepresentadosintomas_dolorestomago === false &&
      this.encuesta.enc_convivehapresentadosintomas_diarrea === false &&
      this.encuesta.enc_convivehapresentadosintomas_perdidaolfato === false &&
      this.encuesta.enc_convivepresentadosintomas_ninguno === false) {
      this.errorText = 'Por favor seleccione mínimo una opción en la casilla persona con la que convive ha presentado sintomas';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_comoconsideracumplimientocuarentena === '' || this.encuesta.enc_comoconsideracumplimientocuarentena === undefined) {
      this.errorText = 'Por favor seleccione una opción en la casilla como considera o evalúa el cumplimiento o acatamiento del confinamiento o la cuarentena en el barrio';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_contactopersonas24horas === '' || this.encuesta.enc_contactopersonas24horas === undefined) {
      this.errorText = 'Por favor seleccione una opción en la casilla en las últimas 24 horas ha estado en contacto con otras personas fuera de su casa';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_dondedesplazoustedomiembrofamilia === '' || this.encuesta.enc_dondedesplazoustedomiembrofamilia === undefined) {
      this.errorText = 'Por favor seleccione una opción en la casilla hasta dónde se desplazó fuera de la vivienda';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_motivosalirdecasa_noaplica === false &&
      this.encuesta.enc_motivosalirdecasa_atrabajar === false &&
      this.encuesta.enc_motivosalirdecasa_compraralimento === false &&
      this.encuesta.enc_motivosalirdecasa_ahacerdeporte === false &&
      this.encuesta.enc_motivosalirdecasa_acitamedica === false &&
      this.encuesta.enc_motivosalirdecasa_sacarmascota === false &&
      this.encuesta.enc_motivosalirdecasa_diligenciabancaria === false &&
      this.encuesta.enc_motivosalirdecasa_socializar === false &&
      this.encuesta.enc_motivosalirdecasa_otro === false) {
      this.errorText = 'Por favor seleccione mínimo una opción en la casilla motivo salir a la calle';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.enc_mediostransporteutilizo_noaplica === false &&
      this.encuesta.enc_mediostransporteutilizo_transmilenio === false &&
      this.encuesta.enc_mediostransporteutilizo_sitp === false &&
      this.encuesta.enc_mediostransporteutilizo_moto === false &&
      this.encuesta.enc_mediostransporteutilizo_bicicleta === false &&
      this.encuesta.enc_mediostransporteutilizo_taxi === false &&
      this.encuesta.enc_mediostransporteutilizo_carro === false &&
      this.encuesta.enc_mediostransporteutilizo_apie === false &&
      this.encuesta.enc_mediostransporteutilizo_otro === false) {
      this.errorText = 'Por favor seleccione mínimo una opción en la casilla medios de transporte utilizados';
      this.ShowAlertsValidations();
      return false;
    }
    else if (this.encuesta.sub_id === 0 || this.encuesta.sub_id === undefined) {
      this.errorText = 'Por favor seleccione una SubRed';
      this.ShowAlertsValidations();
      return false;
    }
    else
      return true;
  }


  async saveForm() {
    this.encuesta.usu_id = this.publicas.usu_id;
    if (this.validateForm()) {


      const btnsave = document.getElementById('saveenc') as HTMLButtonElement;
      if (btnsave != undefined) {
        btnsave.disabled = true;
      }

      //Se ingresan los datos del formulario y se envian al Web Service
      await this.encuestaservice.addEncuesta(this.encuesta).subscribe(result => {
        if (result.OperacionExitosa == true) {
          this.SolicitudGrabacion = true;
          this.formSaved = true;
        }
        else {
          this.errorText = 'Error en en el registro de la encuesta';
          this.ShowAlertsValidations();
          console.log(result.Mensaje);
          this.SolicitudGrabacion = true;
        }
      },
        error => {
          this.error = error;
          console.log(this.error.statusText);
          console.error('Error [encuesta]');
          console.error(error);

        }
      );
    }
  }



  async ActualizarEncuesta() {
    this.encuesta.usu_id = this.publicas.usu_id;
    this.encuesta.enc_fecha = new Date(this.FechaEdicion);
    if (this.validateForm()) {
      //Se ingresan los datos del formulario y se envian al Web Service

      await this.encuestaservice.updEncuesta(this.encuesta).subscribe(result => {
        if (result.OperacionExitosa == true) {
          //Debe informar al componente padre que ya guardo y cerrar la ventana
          this.finalizoedicion.emit(true);
        }
        else {
          this.errorText = 'Error en la actualización de la encuesta';
          this.ShowAlertsValidations();
          console.log(result.Mensaje);
        }
      },
        error => {
          this.error = error;
          console.log(this.error.statusText);
          console.error('Error [encuesta]');
          console.error(error);

        }
      );
    }
  }

  volver() {
    this.finalizoedicion.emit(true);
  }


  confirmar2() {
    var r = confirm("¿Confirma que la información registrada es correcta ?");
    if (r == true) {
      this.ActualizarEncuesta();
    }
  }

  confirmar() {

    if (this.SolicitudGrabacion === false) {
      var r = confirm("¿Confirma que la información registrada es correcta ?");
      if (r == true) {

        this.saveForm();
      }
    }
  }


  validateRegistroExistente() {
    if (this.encuesta.enc_fecha === null || this.encuesta.enc_fecha === undefined) {
      this.errorText = 'Por favor seleccione la fecha';
      this.ShowAlertsValidations();
      return false;
    }
    else {
      this.encuestaservice.GetRegistroExistente(this.encuesta.enc_numerodocumento, this.encuesta.enc_fecha).subscribe(result => {
        if (result != null) {
          if (result.Result.Lista.length > 0) {
            alert('Ya había sido realizado un registro para el número de documento :' + this.encuesta.enc_numerodocumento + ' para la fecha : ' + this.encuesta.enc_fecha);
            return;
          }
          else {
            if (this.validateForm())
              this.confirmar();
          }
        }
        else {
          this.errorText = 'Error en en la consulta de numero de cédula';
          this.ShowAlertsValidations();
          console.log(result.Mensaje);
        }
      },
        error => {
          this.error = error;
          console.log(this.error.statusText);
          console.error('Error [formulario]');
          console.error(error);


        }
      );
    }

  }

  soloLetras(event): boolean {
    if ((event.keyCode == 241) || (event.keyCode == 209) || (event.keyCode == 243) || (event.keyCode == 233) || (event.keyCode == 237) || (event.keyCode == 225) || (event.keyCode == 250) || (event.keyCode == 193) || (event.keyCode == 201) || (event.keyCode == 205) || (event.keyCode == 211) || (event.keyCode == 218))
      return true;
    else
      if ((event.keyCode != 32) && (event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122))
        return false;
      else
        return true;
  }


  cerrarsesion() {
    //Retorna a la visualización de la autenticación.
    this.cerrar.emit(true);
  }


  inicializar() {
    this.formSaved = false;
    this.otromotivoseleccionado = false;
    this.seleccionadoLocalidad = false;
    this.seleccionadoUPZ = false;
    this.SolicitudGrabacion = false;
    this.ngOnInit();
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
      usu_id: 0,
      enc_estadoembarazo: '',
      enc_etnia: '',
      enc_condiciondiscapacidad: '',
      enc_presentaenfermedad_hipertension: false,
      enc_presentaenfermedad_diabetesmellitus: false,
      enc_presentaenfermedad_obesidad: false,
      enc_presentaenfermedad_epoc: false,
      enc_presentaenfermedad_asma: false,
      enc_presentaenfermedad_otro: false,
      enc_presentaenfermead_otrocuales: '',
      enc_hapresentadosintomas_diarrea: false,
      enc_hapresentadosintomas_perdidaolfato: false,
      enc_contactopersonascuantas: '',
      enc_dispuestoaislamiento: '',
      enc_vacunadocovid: '',
      enc_accedetomamuestra: '',
      enc_convivepresentadosintomas_fiebre: false,
      enc_convivepresentadosintomas_tos: false,
      enc_convivepresentadosintomas_dolorgarganta: false,
      enc_convivepresentadosintomas_fatigadebilidad: false,
      enc_convivepresentadosintomas_ahogofaltaaire: false,
      enc_convivepresentadosintomas_ninguno: false,
      enc_convivehapresentadosintomas_diarrea: false,
      enc_convivehapresentadosintomas_perdidaolfato: false,
      enc_presentaenfermedad_ninguno: false,
      enc_compartehabitacion: '',
      enc_hapresentadosintomas_dolorestomago: false,
      enc_convivepresentadosintomas_dolorestomago: false,
      enc_frecuenciadesplazamiento: '',
      enc_esquemavacunacioncompleto: ''

    };
  }
}
