using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WSEncuestaConglomerado.Models.DTO;
using WSEncuestaConglomerado.Services;
using static WSEncuestaConglomerado.Models.DTO.ParametricasRespuesta;

namespace WSEncuestaConglomerado.Controllers
{
    [RoutePrefix("encuesta/parametricas")]
    public class ParametricasController : ApiController
    {
        private ParametricasService srvParametricas;
        private string keyToken = "97221cdc42-8661-4ab9-a04e-51785baa88da39";
        public ParametricasController()
        {
            srvParametricas = new ParametricasService();
        }

        //Obtener Lista Localidades
        [Route("GetListaLocalidades")]
        [HttpGet]
        [ResponseType(typeof(ListaLocalidades))]
        public async Task<IHttpActionResult> GetListaLocalidades(string token)
        {


            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetListaLocalidades();
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListaLocalidades" + e.Message;
                return Ok(error);
            }

          
        }

        //Obtener Lista UPZs
        [Route("GetListaUPZs")]
        [HttpGet]
        [ResponseType(typeof(ListaUPZs))]
        public async Task<IHttpActionResult> GetListaUPZs(int localidad, string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetListaUPZs(localidad);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListaUPZs" + e.Message;
                return Ok(error);
            }
        }

        //Obtener Lista Barrios
        [Route("GetListaBarrios")]
        [HttpGet]
        [ResponseType(typeof(ListaBarrios))]
        public async Task<IHttpActionResult> GetListaBarrios(int localidad, string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetListaBarrios(localidad);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListaBarrios" + e.Message;
                return Ok(error);
            }
        }


        //Obtener Lista Cuadrantes
        [Route("GetListaCuadrantes")]
        [HttpGet]
        [ResponseType(typeof(ListaCuadrantes))]
        public async Task<IHttpActionResult> GetListaCuadrantes(int loc_id, int upz_id, string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetListaCuadrantes(loc_id, upz_id);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListaCuadrantes" + e.Message;
                return Ok(error);
            }
        }

        //Obtener Lista Tipo Documentos
        [Route("GetListaTipoDocumentos")]
        [HttpGet]
        [ResponseType(typeof(ListaTipoDocumentos))]
        public async Task<IHttpActionResult> GetListaTipoDocumentos(string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetListaTipoDocumentos();
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListaTipoDocumentos" + e.Message;
                return Ok(error);
            }
        }


        //Obtener Lista Criterio Priorizacion Muestreo
        [Route("GetListaCriterioPriorizacionMuestra")]
        [HttpGet]
        [ResponseType(typeof(ListaCriterioPriorizacionMuestra))]
        public async Task<IHttpActionResult> GetListaCriterioPriorizacionMuestra( string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetListaCriterioPriorizacionMuestra();
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListaCriterioPriorizacionMuestra" + e.Message;
                return Ok(error);
            }
        }


        //Obtener Lista Subredes
        [Route("GetListaSubRedes")]
        [HttpGet]
        [ResponseType(typeof(ListaSubRedes))]
        public async Task<IHttpActionResult> GetListaSubRedes(string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetListaSubRedes();
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListaSubRedes" + e.Message;
                return Ok(error);
            }
        }



        //Obtener Lista Roles
        [Route("GetListaRoles")]
        [HttpGet]
        [ResponseType(typeof(ListaRoles))]
        public async Task<IHttpActionResult> GetListaRoles(string token)
        {
            try
            {

                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetListaRoles();
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListaRoles" + e.Message;
                return Ok(error);
            }
        }



        //Obtener Lista Usuarios (SuperAdministrador)
        [Route("GetListaUsuarios")]
        [HttpGet]
        [ResponseType(typeof(ListaUsuarios))]
        public async Task<IHttpActionResult> GetListaUsuarios(string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetListaUsuarios();
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListaUsuarios" + e.Message;
                return Ok(error);
            }
        }



        //Obtener Lista Usuarios (Administrador SubRed)
        [Route("GetListaUsuariosSubRed")]
        [HttpGet]
        [ResponseType(typeof(ListaUsuariosSubRed))]
        public async Task<IHttpActionResult> GetListaUsuariosSubRed(int sub_id,string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetListaUsuariosSubRed(sub_id);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListaUsuariosSubRed" + e.Message;
                return Ok(error);
            }
        }


        [HttpGet]
        [Route("GetUsuario")]
        [ResponseType(typeof(UsuariosRespuesta))]
        public async Task<IHttpActionResult> GetUsuario(int usu_id, string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    UsuariosRespuesta infoUsuario = new UsuariosRespuesta();
                    infoUsuario = await srvParametricas.GetUsuario(usu_id);
                    return Ok(infoUsuario);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetUsuario" + e.Message;
                return Ok(error);
            }

        }




        //Obtener Lista UsuarioAutorizado
        [Route("GetUsuarioAutorizado")]
        [HttpGet]
        
        [ResponseType(typeof(ListaUsuariosAutorizado))]
        public async Task<IHttpActionResult> GetUsuarioAutorizado(string login, string password, string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetUsuarioAutorizado(login, password);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetUsuarioAutorizado" + e.Message;
                return Ok(error);
            }
        }

    

        [Route("setClave")] //Actualizar los Datos del Usuario
        [HttpPost]
        [ResponseType(typeof(ClavesRespuesta))]
        public IHttpActionResult setClave(ClavesRespuesta clave, string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.setClave(clave);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio setClave" + e.Message;
                return Ok(error);
            }

        }



        [Route("AsignarClaveUsuario")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult AsignarClaveUsuario(string nuevaclave)
        {
            try
            {
                var respuesta = srvParametricas.AsignarClaveUsuario(nuevaclave);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio AsignarClaveUsuario" + e.Message;
                return Ok(error);
            }
        }

        [Route("VisualizarClaveUsuario")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult VisualizarClaveUsuario(string clave)
        {
            try
            {
                clave = clave.Replace(" ", "+");

                var respuesta = srvParametricas.VisualizarClaveUsuario(clave);
                return Ok(respuesta);
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio VisualizarClaveUsuario" + e.Message;
                return Ok(error);
            }
        }



        [Route("addUsuario")] 
        [HttpPost]
        [ResponseType(typeof(UsuariosRespuesta))]
        public IHttpActionResult addUsuario(string token, UsuariosRespuesta usuario)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.addUsuario(usuario);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio addUsuario" + e.Message;
                return Ok(error);
            }
        }


        [Route("setUsuario")]
        [HttpPost]
        [ResponseType(typeof(UsuariosRespuesta))]
        public IHttpActionResult setUsuario(string token, UsuariosRespuesta usuario)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.setUsuario(usuario);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio setUsuario" + e.Message;
                return Ok(error);
            }
        }



        [Route("GetRegistroExistente")]
        [HttpGet]
        [ResponseType(typeof(ListaRegistroExistente))]
        public async Task<IHttpActionResult> GetRegistroExistente(string documento, DateTime fecha, string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvParametricas.GetRegistroExistente(documento, fecha);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetRegistroExistente" + e.Message;
                return Ok(error);
            }
        }


        // GET: api/[controller]/getTree
        [Route("test")]
        [HttpGet]
        public string test()
        {
            return "Servidor responde";
        }


    }


}
