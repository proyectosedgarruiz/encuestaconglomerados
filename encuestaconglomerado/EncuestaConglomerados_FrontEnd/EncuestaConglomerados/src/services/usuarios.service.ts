import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { environment } from '../environments/environment';
import { Usuarios } from '../models/parametricas.model';


@Injectable({
    providedIn: 'root'
})
export class UsuarioService {


    private url: string;
    private token: string;

    constructor(
        private httpClient: HttpClient) {
        this.url = environment.apiUrl;
        this.token = environment.token;

    }


    //Usuario
    addUsuario(data: Usuarios): any {
        return this.httpClient.post<any>(this.url + '/encuesta/parametricas/addUsuario?token=' + this.token, data);
    }

    //Encuesta
    setUsuario(data: Usuarios): any {
        return this.httpClient.post<any>(this.url + '/encuesta/parametricas/setUsuario?token=' + this.token, data);
    }

    GetUsuarioAutorizado(login: string, password: string): any {
        return this.httpClient.get<Usuarios>(this.url + '/encuesta/parametricas/GetUsuarioAutorizado?login=' + login + '&password=' + password + '&token=' + this.token);
    }


    GetUsuario(usu_id: number): Observable<any> {
        return this.httpClient.get(this.url + '/encuesta/parametricas/GetUsuario?usu_id=' + usu_id + '&token=' + this.token);
    }

    GetListaUsuarios(): Observable<any> {
        return this.httpClient.get(this.url + '/encuesta/parametricas/GetListaUsuarios?token=' + this.token);
    }

    GetListaUsuariosSubRed(sub_id: number): Observable<any> {
        return this.httpClient.get(this.url + '/encuesta/parametricas/GetListaUsuariosSubRed?sub_id=' + sub_id + '&token=' + this.token);
    }

    CambiarClaveUsuario(c): Observable<any> {
        return this.httpClient.post(this.url + '/encuesta/parametricas/setClave?token=' + this.token, c);
    }

    AsignarClaveUsuario(id): Observable<any> {
        return this.httpClient.get(this.url + '/encuesta/parametricas/AsignarClaveUsuario?nuevaclave=' + id + '&token=' + this.token);
    }

    VisualizarClaveUsuario(id): Observable<any> {
        return this.httpClient.get(this.url + '/encuesta/parametricas/VisualizarClaveUsuario?clave=' + id + '&token=' + this.token);
    }





}
