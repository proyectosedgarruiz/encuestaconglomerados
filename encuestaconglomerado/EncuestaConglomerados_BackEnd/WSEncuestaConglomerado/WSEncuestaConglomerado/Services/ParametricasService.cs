using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WSEncuestaConglomerado.Models.DTO;
using WSEncuestaConglomerado.Models.EDMX;
using static WSEncuestaConglomerado.Models.DTO.ParametricasRespuesta;

namespace WSEncuestaConglomerado.Services
{
    public class ParametricasService
    {
        EncuestaConglomeradosEntities db = new EncuestaConglomeradosEntities();
        public async Task<ListaLocalidades> GetListaLocalidades()
        {
            ListaLocalidades respuesta = new ListaLocalidades();
            var lista = db.SP_LIST_LOCALIDADES().ToList();
            respuesta.Lista = lista;
            return respuesta;
        }

        public async Task<ListaCuadrantes> GetListaCuadrantes(int loc_id, int upz_id)
        {
            ListaCuadrantes respuesta = new ListaCuadrantes();
            var lista = db.SP_LIST_CUADRANTES(loc_id, upz_id).ToList();
            respuesta.Lista = lista;
            return respuesta;
        }
        public async Task<ListaUPZs> GetListaUPZs(int localidad)
        {
            ListaUPZs respuesta = new ListaUPZs();
            var lista = db.SP_LIST_UPZ(localidad).ToList();
            respuesta.Lista = lista;
            return respuesta;
        }

        public async Task<ListaBarrios> GetListaBarrios(int localidad)
        {
            ListaBarrios respuesta = new ListaBarrios();
            var lista = db.SP_LIST_BARRIOS(localidad).ToList();
            respuesta.Lista = lista;
            return respuesta;
        }

        public async Task<ListaTipoDocumentos> GetListaTipoDocumentos()
        {
            ListaTipoDocumentos respuesta = new ListaTipoDocumentos();
            var lista = db.SP_LIST_TIPODOCUMENTO().ToList();
            respuesta.Lista = lista;
            return respuesta;
        }


        public async Task<ListaCriterioPriorizacionMuestra> GetListaCriterioPriorizacionMuestra()
        {
            ListaCriterioPriorizacionMuestra respuesta = new ListaCriterioPriorizacionMuestra();
            var lista = db.SP_LIST_CRITERIO_PRIORIZACION_MUESTRA().ToList();
            respuesta.Lista = lista;
            return respuesta;
        }

        public async Task<ListaSubRedes> GetListaSubRedes()
        {
            ListaSubRedes respuesta = new ListaSubRedes();
            var lista = db.SP_LIST_SUBREDES().ToList();
            respuesta.Lista = lista;
            return respuesta;
        }
        public async Task<ListaRoles> GetListaRoles()
        {
            ListaRoles respuesta = new ListaRoles();
            var lista = db.SP_LIST_ROLES().ToList();
            respuesta.Lista = lista;
            return respuesta;
        }

        public async Task<ListaUsuarios> GetListaUsuarios()
        {
            ListaUsuarios respuesta = new ListaUsuarios();
            var lista = db.SP_LIST_USUARIOS().ToList();
            respuesta.Lista = lista;
            return respuesta;
        }

        public async Task<ListaUsuariosSubRed> GetListaUsuariosSubRed(int sub_id)
        {
            ListaUsuariosSubRed respuesta = new ListaUsuariosSubRed();
            var lista = db.SP_LIST_USUARIOS_SUBRED(sub_id).ToList();
            respuesta.Lista = lista;
            return respuesta;
        }

        public async Task<UsuariosRespuesta> GetUsuario(int usu_id)
        {
            UsuariosRespuesta respuesta = new UsuariosRespuesta();
            var info = db.SP_FIND_USUARIO(usu_id).FirstOrDefault();
            respuesta.usu_id = info.usu_id;
            respuesta.usu_login = info.usu_login;
            respuesta.usu_nombre = info.usu_nombre;
            respuesta.usu_req_clave = info.usu_req_clave;
            respuesta.usu_password = info.usu_password;
            respuesta.usu_estado = info.usu_estado;
            respuesta.rol_id = info.rol_id;
            respuesta.sub_id = info.sub_id;
            return respuesta;
        }

        public async Task<ListaUsuariosAutorizado> GetUsuarioAutorizado(string usu_login, string usu_password)
        {
            string strLlave = "098#7UI#OPPDFG";

            Symmetric objSymetric = new Symmetric();
            string strClaveEncriptada = objSymetric.EncryptData(strLlave, usu_password);

            ListaUsuariosAutorizado respuesta = new ListaUsuariosAutorizado();
            var lista = db.SP_FIND_USUARIO_AUTORIZADO(usu_login, strClaveEncriptada).ToList();
            respuesta.Lista = lista;
            return respuesta;
        }




        public ClavesRespuesta setClave(ClavesRespuesta clave)
        {
            string strLlave = "098#7UI#OPPDFG";

            Symmetric objSymetric = new Symmetric();
            string strClaveEncriptada = objSymetric.EncryptData(strLlave, clave.clave_nueva);

            ClavesRespuesta respuesta = new ClavesRespuesta();
            try
            {
                var accion = db.SP_UPD_CLAVE_USUARIO(clave.id_usuario, strClaveEncriptada);
                respuesta.OperacionExitosa = true;

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error al Actualizar la clave de usuario -" + ex.ToString() + "-";
                respuesta.OperacionExitosa = false;
            }
            return respuesta;
        }


        public string AsignarClaveUsuario(string nuevaclave)
        {

            string strClaveEncriptada, strLlave;
            strLlave = "098#7UI#OPPDFG";

            Symmetric objSymetric = new Symmetric();
            strClaveEncriptada = objSymetric.EncryptData(strLlave, nuevaclave);

            return strClaveEncriptada;

        }


        public string VisualizarClaveUsuario(string clave)
        {
            string strClaveDesencriptada, strLlave;
            strLlave = "098#7UI#OPPDFG";

            Symmetric objSymetric = new Symmetric();
            strClaveDesencriptada = objSymetric.DecryptData(strLlave, clave);

            return strClaveDesencriptada;
        }

        public UsuariosRespuesta addUsuario(UsuariosRespuesta usuario)
        {

            UsuariosRespuesta respuesta = new UsuariosRespuesta();
            try
            {
                var accion = db.SP_ADD_USUARIO(
                    usuario.usu_nombre,
                    usuario.usu_login,
                    usuario.usu_password,
                    usuario.usu_estado,
                   usuario.rol_id,
                    usuario.usu_req_clave,
                    usuario.sub_id

                    );
                respuesta.OperacionExitosa = true;

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error al Ingresar el Usuario -" + ex.ToString() + "-";
                respuesta.OperacionExitosa = false;
            }
            return respuesta;
        }


        public UsuariosRespuesta setUsuario(UsuariosRespuesta usuario)
        {

            UsuariosRespuesta respuesta = new UsuariosRespuesta();
            try
            {
                var accion = db.SP_UPD_USUARIO(
                    usuario.usu_id,
                    usuario.usu_nombre,
                    usuario.usu_login,
                    usuario.usu_password,
                    usuario.usu_estado,
                    usuario.rol_id,
                    usuario.usu_req_clave,
                    usuario.sub_id

                    );
                respuesta.OperacionExitosa = true;

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error al Actualizar el Usuario -" + ex.ToString() + "-";
                respuesta.OperacionExitosa = false;
            }
            return respuesta;
        }



        public async Task<ListaRegistroExistente> GetRegistroExistente(string documento, DateTime fecha)
        {

            ListaRegistroExistente respuesta = new ListaRegistroExistente();
            var lista = db.SP_CONSULTAR_REGISTRO_EXISTENTE(documento, fecha).ToList();
            respuesta.Lista = lista;
            return respuesta;
        }

    }
}