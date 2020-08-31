using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WSEncuestaConglomerado.Models.DTO;
using WSEncuestaConglomerado.Services;

namespace WSEncuestaConglomerado.Controllers
{
    [RoutePrefix("encuesta/encuesta")]
 
    public class EncuestaController : ApiController
    {
        private EncuestaService srvEncuesta;
        private string keyToken = "97221cdc42-8661-4ab9-a04e-51785baa88da39";

        public EncuestaController()
        {
            srvEncuesta = new EncuestaService();
        }

        [Route("addEncuesta")] //Ingresar los Datos del la encuesta
        [HttpPost]
        [ResponseType(typeof(EncuestaRespuesta))]
        public IHttpActionResult addEncuesta(string token,EncuestaRespuesta encuesta)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvEncuesta.addEncuesta(encuesta);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio addEncuesta" + e.Message;
                return Ok(error);
            }
        }

        [Route("updEncuesta")] //Actualizar los Datos del la encuesta por el Administrador
        [HttpPost]
        [ResponseType(typeof(EncuestaRespuesta))]
        public IHttpActionResult updEncuesta(string token, EncuestaRespuesta encuesta)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvEncuesta.updEncuesta(encuesta);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio updEncuesta" + e.Message;
                return Ok(error);
            }
        }


        [Route("anularEncuesta")] //Anula la encuesta por el Administrador
        [HttpPost]
        [ResponseType(typeof(EncuestaRespuesta))]
        public IHttpActionResult anularEncuesta(string token, EncuestaRespuesta encuesta)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvEncuesta.anularEncuesta(encuesta);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio anularEncuesta" + e.Message;
                return Ok(error);
            }
        }

        [HttpGet]
        [Route("GetEncuestaById")]
        [ResponseType(typeof(EncuestaRespuesta))]
        public async Task<IHttpActionResult> GetEncuestaById(int enc_id, string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    EncuestaRespuesta infoEncuesta = new EncuestaRespuesta();
                    infoEncuesta = await srvEncuesta.GetEncuestaById(enc_id);
                    return Ok(infoEncuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetEncuestaById" + e.Message;
                return Ok(error);
            }

        }



        //Obtener Lista Encuesta Administrador General (SuperAdministrador)
        [Route("GetListEncuestas")]
        [HttpGet]
        [ResponseType(typeof(List<EncuestaListaRespuesta>))]
        public async Task<IHttpActionResult> GetListEncuestas(int todos, int fecha, DateTime fechainicial, DateTime fechafinal, string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvEncuesta.GetListaEncuestas(todos, fecha, fechainicial, fechafinal);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListEncuestas" + e.Message;
                return Ok(error);
            }
        }

        //Obtener Lista Encuesta Administrador SubRed
        [Route("GetListEncuestasSubRed")]
        [HttpGet]
        [ResponseType(typeof(List<EncuestaListaRespuesta>))]
        public async Task<IHttpActionResult> GetListEncuestasSubRed(int todos, int fecha, DateTime fechainicial, DateTime fechafinal, int sub_id, string token)
        {
            try
            {
                if (token.Equals(keyToken))
                {
                    var respuesta = srvEncuesta.GetListaEncuestasSubRed(todos, fecha, fechainicial, fechafinal, sub_id);
                    return Ok(respuesta);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = "Error desde el servicio GetListEncuestasSubRed" + e.Message;
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