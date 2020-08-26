export class Localidades {
    constructor(
        public loc_id: number,
        public loc_nombre: string,
        public loc_codigo: number,
        public loc_estado: string
    ) { }
}

export class UPZs {
    constructor(
        public upz_id: number,
        public upz_nombre: string,
        public loc_id: number,
        public loc_codigo: number,
        public upz_estado: string
    ) { }
}


export class Barrios {
    constructor(
        public bar_id: number,
        public bar_nombre: string,
        public upz_id: number,
        public bar_codigo: number,
        public upz_codigo: number
    ) { }
}

export class Cuadrantes {
    constructor(
        public cua_id: number,
        public cua_nombre: string
       
    ) { }
}

export class TipoDocumento {
    constructor(
        public tpd_id: number,
        public tpd_nombre: string,
    ) { }
}

export class CriterioPriorizacionMuestra {
    constructor(
        public cpm_id: number,
        public cpm_nombre: string,
    ) { }
}


export class SubRedes {
    constructor(
        public sub_id: number,
        public sub_nombre: string,
    ) { }
}


export class Roles {
    constructor(
        public rol_id: number,
        public rol_nombre: string
       
    ) { }
}

export class Usuarios {
    constructor(
        public usu_id: number,
        public usu_nombre: string,
        public usu_login: string,
        public usu_password: string,
        public usu_estado: string,
        public rol_id: number,
        public usu_req_clave: boolean,
        public usu_asignar_clave: string,
        public clave : string,
        public usu_visualizar_clave: string,
        public sub_id : number

    ) { }
}

export class UsuariosLista {
    constructor(
        public usu_id: number,
        public usu_nombre: string,
        public usu_login: string,
        public usu_password: string,
        public usu_estado: string,
        public rol_id: number,
        public usu_req_clave: boolean,
        public usu_asignar_clave: string,
        public clave : string,
        public usu_visualizar_clave: string,
        public sub_nombre : string

    ) { }
}
export class CambioClave {

    constructor(

        public clave_anterior: string,
        public clave_nueva: string,
        public clave_confirmada: string,
        public id_usuario: number
        
    ) { }
}


export class Publicas {

    constructor(

        public autorized : boolean,
        public usu_id: number,
        public rol_id: number,
        public sub_id: number
        
        
    ) { }
}