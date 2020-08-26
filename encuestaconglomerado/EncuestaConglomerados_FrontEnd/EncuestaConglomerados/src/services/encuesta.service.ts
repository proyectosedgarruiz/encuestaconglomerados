import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import {Encuesta, ListaEncuesta} from '../models/encuesta.model';
import { environment } from '../environments/environment';

import { Localidades, UPZs, Barrios, TipoDocumento, Cuadrantes, Usuarios, Roles, CriterioPriorizacionMuestra, SubRedes } from '../models/parametricas.model';

@Injectable({
  providedIn: 'root'
})
export class EncuestaService {

  private url: string;
  private token : string;
  
  constructor(
    private httpClient: HttpClient) {
    this.url = environment.apiUrl;
    this.token = environment.token;

  }
  
 


//Encuesta
addEncuesta(data: Encuesta): any {
    return this.httpClient.post<any>(this.url + '/encuesta/encuesta/addEncuesta?token='+this.token, data);
}

updEncuesta(data: Encuesta): any {
  return this.httpClient.post<any>(this.url + '/encuesta/encuesta/updEncuesta?token='+this.token, data);
}

GetEncuestaById(enc_id: number): Observable<any> {
  return this.httpClient.get(this.url + '/encuesta/encuesta/GetEncuestaById?enc_id=' + enc_id + '&token=' + this.token);
}

//Parametricas

   //Codigo Modificado
   GetUsuarioAutorizado(login :string , password: string):Observable<any>{
    return this.httpClient.get<Usuarios[]>(this.url + '/encuesta/parametricas/GetUsuarioAutorizado?login='+login+'&password='+password+'&token='+this.token);
}

GetRegistroExistente(documento :string , fecha : Date  ):Observable<any>{
  return this.httpClient.get<Encuesta[]>(this.url + '/encuesta/parametricas/GetRegistroexistente?documento='+documento+'&fecha='+fecha+'&token='+this.token);
}

GetListaLocalidades():Observable<any> {
  return this.httpClient.get<Localidades[]>(this.url  + '/encuesta/parametricas/GetListaLocalidades?token='+this.token);
}

public GetListaUPZs(localidad : number) : Observable<any>  {
  return this.httpClient.get<UPZs>(this.url + '/encuesta/parametricas/GetListaUPZs?localidad='+localidad+'&token='+this.token);
}

public GetListaBarrios(localidad : number) : Observable<any>  {
  return this.httpClient.get<Barrios>(this.url + '/encuesta/parametricas/GetListaBarrios?localidad='+localidad+'&token='+this.token);
}

GetListaCuadrantes(loc_id : number, upz_id: number):Observable<any> {
  return this.httpClient.get<Cuadrantes[]>(this.url  + '/encuesta/parametricas/GetListaCuadrantes?loc_id='+loc_id+'&upz_id='+upz_id+'&token='+this.token);
}

public GetListaTipoDocumentos() : Observable<any>  {
  return this.httpClient.get<TipoDocumento>(this.url + '/encuesta/parametricas/GetListaTipoDocumentos?token='+this.token);
}

public GetListaCriterioPriorizacionMuestra() : Observable<any>  {
  return this.httpClient.get<CriterioPriorizacionMuestra>(this.url + '/encuesta/parametricas/GetListaCriterioPriorizacionMuestra?token='+this.token);
}

public GetListaSubRedes() : Observable<any>  {
  return this.httpClient.get<SubRedes>(this.url + '/encuesta/parametricas/GetListaSubredes?token='+this.token);
}



GetListEncuestas(todos: Number, fecha: Number, fechainicial: String, fechafinal: String):Observable<any> {
  return this.httpClient.get<ListaEncuesta[]>(this.url  + '/encuesta/encuesta/GetListEncuestas?todos='+todos+'&fecha='+fecha+'&fechainicial='+fechainicial+'&fechafinal='+fechafinal+'&token='+this.token);
}


GetListEncuestasSubRed(todos: Number, fecha: Number, fechainicial: String, fechafinal: String, sub_id : number):Observable<any> {
  return this.httpClient.get<ListaEncuesta[]>(this.url  + '/encuesta/encuesta/GetListEncuestasSubRed?todos='+todos+'&fecha='+fecha+'&fechainicial='+fechainicial+'&fechafinal='+fechafinal+'&sub_id='+sub_id+'&token='+this.token);
}

public GetListaRoles() : Observable<any>  {
  return this.httpClient.get<Roles>(this.url + '/encuesta/parametricas/GetListaRoles?token='+this.token);
}

}