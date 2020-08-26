using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using WSEncuestaConglomerado.Models.DTO;
using WSEncuestaConglomerado.Models.EDMX;


namespace WSEncuestaConglomerado.Services
{
    public class EncuestaService
    {
        EncuestaConglomeradosEntities db = new EncuestaConglomeradosEntities();
        SilaspReportesUnacEntities db2 = new SilaspReportesUnacEntities();

        public EncuestaRespuesta addEncuesta(EncuestaRespuesta encuesta)
        {

            EncuestaRespuesta respuesta = new EncuestaRespuesta();
            try
            {
                var accion = db.SP_ADD_ENCUESTA(
                    encuesta.enc_fecha,
                    encuesta.loc_id,
                    encuesta.upz_id,
                    encuesta.bar_id,
                    encuesta.cua_id,
                    encuesta.enc_muestreadopor,
                    encuesta.cpm_id,
                    encuesta.enc_nombreencuestado,
                    encuesta.tpd_id,
                    encuesta.enc_numerodocumento,
                    encuesta.enc_edad,
                    encuesta.enc_genero,
                    encuesta.enc_dirresidencia,
                    encuesta.enc_numcelular,
                    encuesta.enc_aseguramiento,
                    encuesta.enc_nombreEAPB,
                    encuesta.enc_ocupacion,
                    encuesta.enc_cuantaspersonashabitan,
                    encuesta.enc_cuantaspersonasmayores60,
                    encuesta.enc_cuantascondicionescronicas,
                    encuesta.enc_cuantashabitacionescuentaresidencia,
                    encuesta.enc_hapresentadosintomas_fiebre,
                    encuesta.enc_hapresentadosintomas_tos,
                    encuesta.enc_hapresentadosintomas_dolorgarganta,
                    encuesta.enc_hapresentadosintomas_fatigadebilidad,
                    encuesta.enc_hapresentadosintomas_ahogofaltaaire,
                    encuesta.enc_hapresentadosintomas_ninguno,

                    encuesta.enc_comoconsideracumplimientocuarentena,
                    encuesta.enc_contactopersonas24horas,
                    encuesta.enc_dondedesplazoustedomiembrofamilia,

                    encuesta.enc_motivosalirdecasa_noaplica,
                    encuesta.enc_motivosalirdecasa_atrabajar,
                    encuesta.enc_motivosalirdecasa_compraralimento,
                    encuesta.enc_motivosalirdecasa_ahacerdeporte,
                    encuesta.enc_motivosalirdecasa_acitamedica,
                    encuesta.enc_motivosalirdecasa_sacarmascota,
                    encuesta.enc_motivosalirdecasa_diligenciabancaria,
                    encuesta.enc_motivosalirdecasa_socializar,
                    encuesta.enc_motivosalirdecasa_otro,

                    encuesta.enc_otromotivosalirdecasa,

                    encuesta.enc_mediostransporteutilizo_noaplica,
                    encuesta.enc_mediostransporteutilizo_transmilenio,
                    encuesta.enc_mediostransporteutilizo_sitp,
                    encuesta.enc_mediostransporteutilizo_moto,
                    encuesta.enc_mediostransporteutilizo_bicicleta,
                    encuesta.enc_mediostransporteutilizo_taxi,
                    encuesta.enc_mediostransporteutilizo_carro,
                    encuesta.enc_mediostransporteutilizo_apie,
                    encuesta.enc_mediostransporteutilizo_otro,
                    encuesta.sub_id,
                    encuesta.usu_id
                    );
                respuesta.OperacionExitosa = true;

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error al Ingresar la Encuesta -" + ex.ToString() + "-";
                respuesta.OperacionExitosa = false;
            }
            return respuesta;
        }


        public EncuestaRespuesta updEncuesta(EncuestaRespuesta encuesta)
        {

            EncuestaRespuesta respuesta = new EncuestaRespuesta();
            try
            {
                var accion = db.SP_UPD_ENCUESTA(
                    encuesta.enc_id,
                    encuesta.enc_fecha,
                    encuesta.loc_id,
                    encuesta.upz_id,
                    encuesta.bar_id,
                    encuesta.cua_id,
                    encuesta.enc_muestreadopor,
                    encuesta.cpm_id,
                    encuesta.enc_nombreencuestado,
                    encuesta.tpd_id,
                    encuesta.enc_numerodocumento,
                    encuesta.enc_edad,
                    encuesta.enc_genero,
                    encuesta.enc_dirresidencia,
                    encuesta.enc_numcelular,
                    encuesta.enc_aseguramiento,
                    encuesta.enc_nombreEAPB,
                    encuesta.enc_ocupacion,
                    encuesta.enc_cuantaspersonashabitan,
                    encuesta.enc_cuantaspersonasmayores60,
                    encuesta.enc_cuantascondicionescronicas,
                    encuesta.enc_cuantashabitacionescuentaresidencia,
                    encuesta.enc_hapresentadosintomas_fiebre,
                    encuesta.enc_hapresentadosintomas_tos,
                    encuesta.enc_hapresentadosintomas_dolorgarganta,
                    encuesta.enc_hapresentadosintomas_fatigadebilidad,
                    encuesta.enc_hapresentadosintomas_ahogofaltaaire,
                    encuesta.enc_hapresentadosintomas_ninguno,

                    encuesta.enc_comoconsideracumplimientocuarentena,
                    encuesta.enc_contactopersonas24horas,
                    encuesta.enc_dondedesplazoustedomiembrofamilia,

                    encuesta.enc_motivosalirdecasa_noaplica,
                    encuesta.enc_motivosalirdecasa_atrabajar,
                    encuesta.enc_motivosalirdecasa_compraralimento,
                    encuesta.enc_motivosalirdecasa_ahacerdeporte,
                    encuesta.enc_motivosalirdecasa_acitamedica,
                    encuesta.enc_motivosalirdecasa_sacarmascota,
                    encuesta.enc_motivosalirdecasa_diligenciabancaria,
                    encuesta.enc_motivosalirdecasa_socializar,
                    encuesta.enc_motivosalirdecasa_otro,

                    encuesta.enc_otromotivosalirdecasa,

                    encuesta.enc_mediostransporteutilizo_noaplica,
                    encuesta.enc_mediostransporteutilizo_transmilenio,
                    encuesta.enc_mediostransporteutilizo_sitp,
                    encuesta.enc_mediostransporteutilizo_moto,
                    encuesta.enc_mediostransporteutilizo_bicicleta,
                    encuesta.enc_mediostransporteutilizo_taxi,
                    encuesta.enc_mediostransporteutilizo_carro,
                    encuesta.enc_mediostransporteutilizo_apie,
                    encuesta.enc_mediostransporteutilizo_otro,
                    encuesta.sub_id,
                    encuesta.usu_id
                    );
                respuesta.OperacionExitosa = true;

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error al Actualizar la Encuesta -" + ex.ToString() + "-";
                respuesta.OperacionExitosa = false;
            }
            return respuesta;
        }

        public async Task<EncuestaRespuesta> GetEncuestaById(int enc_id)
        {
            EncuestaRespuesta respuesta = new EncuestaRespuesta();
            var info = db.SP_FIND_ENCUESTA(enc_id).FirstOrDefault();
            respuesta.enc_id = info.enc_id;
            respuesta.enc_fecha = info.enc_fecha;
            respuesta.loc_id = info.loc_id;
            respuesta.upz_id = info.upz_id;
            respuesta.bar_id = info.bar_id;
            respuesta.cua_id = info.cua_id;
            respuesta.enc_muestreadopor = info.enc_muestreadopor;
            respuesta.cpm_id = info.cpm_id;
            respuesta.enc_nombreencuestado = info.enc_nombreencuestado;
            respuesta.tpd_id = info.tpd_id;
            respuesta.enc_numerodocumento = info.enc_numerodocumento;
            respuesta.enc_edad = info.enc_edad;
            respuesta.enc_genero = info.enc_genero;
            respuesta.enc_dirresidencia = info.enc_dirresidencia;
            respuesta.enc_numcelular = info.enc_numcelular;
            respuesta.enc_aseguramiento = info.enc_aseguramiento;
            respuesta.enc_nombreEAPB = info.enc_nombreEAPB;
            respuesta.enc_ocupacion = info.enc_ocupacion;
            respuesta.enc_cuantaspersonashabitan = info.enc_cuantaspersonashabitan;
            respuesta.enc_cuantaspersonasmayores60 = info.enc_cuantaspersonasmayores60;
            respuesta.enc_cuantascondicionescronicas = info.enc_cuantascondicionescronicas;
            respuesta.enc_cuantashabitacionescuentaresidencia = info.enc_cuantashabitacionescuentaresidencia;
            respuesta.enc_hapresentadosintomas_fiebre = info.enc_hapresentadosintomas_fiebre;
            respuesta.enc_hapresentadosintomas_tos = info.enc_hapresentadosintomas_tos;
            respuesta.enc_hapresentadosintomas_dolorgarganta = info.enc_hapresentadosintomas_dolorgarganta;
            respuesta.enc_hapresentadosintomas_fatigadebilidad = info.enc_hapresentadosintomas_fatigadebilidad;
            respuesta.enc_hapresentadosintomas_ahogofaltaaire = info.enc_hapresentadosintomas_ahogofaltaaire;
            respuesta.enc_hapresentadosintomas_ninguno = info.enc_hapresentadosintomas_ninguno;
            respuesta.enc_comoconsideracumplimientocuarentena = info.enc_comoconsideracumplimientocuarentena;
            respuesta.enc_contactopersonas24horas = info.enc_contactopersonas24horas;
            respuesta.enc_dondedesplazoustedomiembrofamilia = info.enc_dondedesplazoustedomiembrofamilia;
            respuesta.enc_motivosalirdecasa_noaplica = info.enc_motivosalirdecasa_noaplica;
            respuesta.enc_motivosalirdecasa_atrabajar = info.enc_motivosalirdecasa_atrabajar;
            respuesta.enc_motivosalirdecasa_compraralimento = info.enc_motivosalirdecasa_compraralimento;
            respuesta.enc_motivosalirdecasa_ahacerdeporte = info.enc_motivosalirdecasa_ahacerdeporte;
            respuesta.enc_motivosalirdecasa_acitamedica = info.enc_motivosalirdecasa_acitamedica;
            respuesta.enc_motivosalirdecasa_sacarmascota = info.enc_motivosalirdecasa_sacarmascota;
            respuesta.enc_motivosalirdecasa_diligenciabancaria = info.enc_motivosalirdecasa_diligenciabancaria;
            respuesta.enc_motivosalirdecasa_socializar = info.enc_motivosalirdecasa_socializar;
            respuesta.enc_motivosalirdecasa_otro = info.enc_motivosalirdecasa_otro;
            respuesta.enc_otromotivosalirdecasa = info.enc_otromotivosalirdecasa;
            respuesta.enc_mediostransporteutilizo_noaplica = info.enc_mediostransporteutilizo_noaplica;
            respuesta.enc_mediostransporteutilizo_transmilenio = info.enc_mediostransporteutilizo_transmilenio;
            respuesta.enc_mediostransporteutilizo_sitp = info.enc_mediostransporteutilizo_sitp;
            respuesta.enc_mediostransporteutilizo_moto = info.enc_mediostransporteutilizo_moto;
            respuesta.enc_mediostransporteutilizo_bicicleta = info.enc_mediostransporteutilizo_bicicleta;
            respuesta.enc_mediostransporteutilizo_taxi = info.enc_mediostransporteutilizo_taxi;
            respuesta.enc_mediostransporteutilizo_carro = info.enc_mediostransporteutilizo_carro;
            respuesta.enc_mediostransporteutilizo_apie = info.enc_mediostransporteutilizo_apie;
            respuesta.enc_mediostransporteutilizo_otro = info.enc_mediostransporteutilizo_otro;
            respuesta.sub_id = info.sub_id;
           
            return respuesta;
        }



        public async Task<List<EncuestaListaRespuesta>> GetListaEncuestas(int todos, int fecha, DateTime fechainicial, DateTime fechafinal)
        {
            List<EncuestaListaRespuesta> respuesta = new List<EncuestaListaRespuesta>();
            int IdDatoReferenciado = 0;

            var listapreliminar = (from l in db.SP_LIST_ENCUESTAS(todos, fecha, fechainicial, fechafinal).ToList()

                                   select new EncuestaListaRespuesta
                                   {
                                       enc_id = l.enc_id,
                                       enc_fecha = l.enc_fecha,
                                       loc_nombre = l.loc_nombre,
                                       upz_nombre = l.upz_nombre,
                                       bar_nombre = l.bar_nombre,
                                       cua_nombre = l.cua_nombre,
                                       enc_muestreadopor = l.enc_muestreadopor,
                                       cpm_nombre = l.cpm_nombre,
                                       enc_nombreencuestado = l.enc_nombreencuestado,
                                       tpd_nombre = l.tpd_nombre,
                                       enc_numerodocumento = l.enc_numerodocumento,
                                       enc_edad = l.enc_edad.ToString(),
                                       enc_genero = l.enc_genero,
                                       enc_dirresidencia = l.enc_dirresidencia,
                                       enc_numcelular = l.enc_numcelular,
                                       enc_aseguramiento = l.enc_aseguramiento,
                                       enc_nombreEAPB = l.enc_nombreEAPB,
                                       enc_ocupacion = l.enc_ocupacion,
                                       enc_cuantaspersonashabitan = l.enc_cuantaspersonashabitan,
                                       enc_cuantaspersonasmayores60 = l.enc_cuantaspersonasmayores60,
                                       enc_cuantascondicionescronicas = l.enc_cuantascondicionescronicas,
                                       enc_cuantashabitacionescuentaresidencia = l.enc_cuantashabitacionescuentaresidencia,
                                       enc_hapresentadosintomas_fiebre = l.enc_hapresentadosintomas_fiebre,
                                       enc_hapresentadosintomas_tos = l.enc_hapresentadosintomas_tos,
                                       enc_hapresentadosintomas_dolorgarganta = l.enc_hapresentadosintomas_dolorgarganta,
                                       enc_hapresentadosintomas_fatigadebilidad = l.enc_hapresentadosintomas_fatigadebilidad,
                                       enc_hapresentadosintomas_ahogofaltaaire = l.enc_hapresentadosintomas_ahogofaltaaire,
                                       enc_hapresentadosintomas_ninguno = l.enc_hapresentadosintomas_ninguno,
                                       enc_comoconsideracumplimientocuarentena = l.enc_comoconsideracumplimientocuarentena,
                                       enc_contactopersonas24horas = l.enc_contactopersonas24horas,
                                       enc_dondedesplazoustedomiembrofamilia = l.enc_dondedesplazoustedomiembrofamilia,
                                       enc_motivosalirdecasa_noaplica = l.enc_motivosalirdecasa_noaplica,
                                       enc_motivosalirdecasa_atrabajar = l.enc_motivosalirdecasa_atrabajar,
                                       enc_motivosalirdecasa_compraralimento = l.enc_motivosalirdecasa_compraralimento,
                                       enc_motivosalirdecasa_ahacerdeporte = l.enc_motivosalirdecasa_ahacerdeporte,
                                       enc_motivosalirdecasa_acitamedica = l.enc_motivosalirdecasa_acitamedica,
                                       enc_motivosalirdecasa_sacarmascota = l.enc_motivosalirdecasa_sacarmascota,
                                       enc_motivosalirdecasa_diligenciabancaria = l.enc_motivosalirdecasa_diligenciabancaria,
                                       enc_motivosalirdecasa_socializar = l.enc_motivosalirdecasa_socializar,
                                       enc_motivosalirdecasa_otro = l.enc_motivosalirdecasa_otro,
                                       enc_otromotivosalirdecasa = l.enc_otromotivosalirdecasa,
                                       enc_mediostransporteutilizo_noaplica = l.enc_mediostransporteutilizo_noaplica,
                                       enc_mediostransporteutilizo_transmilenio = l.enc_mediostransporteutilizo_transmilenio,
                                       enc_mediostransporteutilizo_sitp = l.enc_mediostransporteutilizo_sitp,
                                       enc_mediostransporteutilizo_moto = l.enc_mediostransporteutilizo_moto,
                                       enc_mediostransporteutilizo_bicicleta = l.enc_mediostransporteutilizo_bicicleta,
                                       enc_mediostransporteutilizo_taxi = l.enc_mediostransporteutilizo_taxi,
                                       enc_mediostransporteutilizo_carro = l.enc_mediostransporteutilizo_carro,
                                       enc_mediostransporteutilizo_apie = l.enc_mediostransporteutilizo_apie,
                                       enc_mediostransporteutilizo_otro = l.enc_mediostransporteutilizo_otro,
                                       sub_nombre = l.sub_nombre,
                                       usu_nombre = l.usu_nombre,
                                       enc_datetimecreated = l.enc_datetimecreated,
                                       usu_nombre_modificacion = l.usu_nombre_modificacion,
                                       enc_datetimeupdated = l.enc_datetimeupdated

                                   }
                                   ).ToList();

            if (listapreliminar.Count > 0)
            {
                //Se consulta la información adicional desde Silaps

                foreach (EncuestaListaRespuesta item in listapreliminar)
                {
                    IdDatoReferenciado = 0;
                    //Se consulta la información faltante en Silaps y se actualiza
                    //Se consulta por el numero de documento del encuestado
                    var ListaporDocumento = (from r in db2.DatosRecepcion
                                             where r.Idrvp_dyr == 152 && r.Texto_dyr == item.enc_numerodocumento
                                             orderby r.Fecha_dyr descending
                                             select new DatosRecepciondto
                                             {
                                                 Ideyr_dyr = r.Ideyr_dyr,
                                                 Idrvp_dyr = r.Idrvp_dyr,
                                                 dato_dyr = r.dato_dyr,
                                                 Texto_dyr = r.Texto_dyr,

                                             }
                    ).ToList();


                    if (ListaporDocumento.Count > 0)
                    {
                        //Se verifica si el item corresponde a Virus Respiratorios 237

                        foreach (DatosRecepciondto i in ListaporDocumento)
                        {

                            var ListaporId = (from r in db2.DatosRecepcion
                                              where r.Ideyr_dyr == i.Ideyr_dyr && r.Idrvp_dyr == 191 && r.dato_dyr == "237" //VIRUS RESPIRATORIOS
                                              orderby r.Fecha_dyr descending
                                              select new DatosRecepciondto
                                              {
                                                  Ideyr_dyr = r.Ideyr_dyr,
                                                  Idrvp_dyr = r.Idrvp_dyr,
                                                  dato_dyr = r.dato_dyr,
                                                  Texto_dyr = r.Texto_dyr,

                                              }
                        ).FirstOrDefault();

                            if (ListaporId != null)
                            {
                                if (ListaporId.Ideyr_dyr != 0) //Tiene Datos asociados 
                                {
                                    IdDatoReferenciado = ListaporId.Ideyr_dyr;
                                    break;
                                }
                            }




                        }

                        if (IdDatoReferenciado != 0)
                        {

                            //Se consultan los datos faltantes de la encuesta y se hace su correspondiente reemplazamiento
                            var Edad = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(155)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();
                            var Anios = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(329)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();
                            var Genero = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(156)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();
                            var Direccion = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(161)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();
                            var Telefono = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(162)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();
                            var EAPB = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(324)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();

                            item.enc_edad = Edad.Texto_dyr + " " + Anios.Texto_dyr;
                            item.enc_genero = Genero.Texto_dyr;
                            item.enc_dirresidencia = Direccion.Texto_dyr;
                            item.enc_numcelular = Telefono.Texto_dyr;
                            item.enc_nombreEAPB = EAPB.Texto_dyr;



                        }

                    }
                    else
                    {

                        item.enc_edad = "No Reportado";
                        item.enc_genero = "No Reportado";
                        item.enc_dirresidencia = "No Reportado";
                        item.enc_numcelular = "No Reportado";
                        item.enc_nombreEAPB = "No Reportado";



                    }

                }


            }
            else
            {
                respuesta = null;
                return respuesta;

            }




            respuesta = listapreliminar;
            return respuesta;
        }

        public async Task<List<EncuestaListaRespuesta>> GetListaEncuestasSubRed(int todos, int fecha, DateTime fechainicial, DateTime fechafinal , int sub_id)
        {
            List<EncuestaListaRespuesta> respuesta = new List<EncuestaListaRespuesta>();
            int IdDatoReferenciado = 0;

            var listapreliminar = (from l in db.SP_LIST_ENCUESTAS_SUBRED(todos, fecha, fechainicial, fechafinal, sub_id).ToList()

                                   select new EncuestaListaRespuesta
                                   {
                                       enc_id = l.enc_id,
                                       enc_fecha = l.enc_fecha,
                                       loc_nombre = l.loc_nombre,
                                       upz_nombre = l.upz_nombre,
                                       bar_nombre = l.bar_nombre,
                                       cua_nombre = l.cua_nombre,
                                       enc_muestreadopor = l.enc_muestreadopor,
                                       cpm_nombre = l.cpm_nombre,
                                       enc_nombreencuestado = l.enc_nombreencuestado,
                                       tpd_nombre = l.tpd_nombre,
                                       enc_numerodocumento = l.enc_numerodocumento,
                                       enc_edad = l.enc_edad.ToString(),
                                       enc_genero = l.enc_genero,
                                       enc_dirresidencia = l.enc_dirresidencia,
                                       enc_numcelular = l.enc_numcelular,
                                       enc_aseguramiento = l.enc_aseguramiento,
                                       enc_nombreEAPB = l.enc_nombreEAPB,
                                       enc_ocupacion = l.enc_ocupacion,
                                       enc_cuantaspersonashabitan = l.enc_cuantaspersonashabitan,
                                       enc_cuantaspersonasmayores60 = l.enc_cuantaspersonasmayores60,
                                       enc_cuantascondicionescronicas = l.enc_cuantascondicionescronicas,
                                       enc_cuantashabitacionescuentaresidencia = l.enc_cuantashabitacionescuentaresidencia,
                                       enc_hapresentadosintomas_fiebre = l.enc_hapresentadosintomas_fiebre,
                                       enc_hapresentadosintomas_tos = l.enc_hapresentadosintomas_tos,
                                       enc_hapresentadosintomas_dolorgarganta = l.enc_hapresentadosintomas_dolorgarganta,
                                       enc_hapresentadosintomas_fatigadebilidad = l.enc_hapresentadosintomas_fatigadebilidad,
                                       enc_hapresentadosintomas_ahogofaltaaire = l.enc_hapresentadosintomas_ahogofaltaaire,
                                       enc_hapresentadosintomas_ninguno = l.enc_hapresentadosintomas_ninguno,
                                       enc_comoconsideracumplimientocuarentena = l.enc_comoconsideracumplimientocuarentena,
                                       enc_contactopersonas24horas = l.enc_contactopersonas24horas,
                                       enc_dondedesplazoustedomiembrofamilia = l.enc_dondedesplazoustedomiembrofamilia,
                                       enc_motivosalirdecasa_noaplica = l.enc_motivosalirdecasa_noaplica,
                                       enc_motivosalirdecasa_atrabajar = l.enc_motivosalirdecasa_atrabajar,
                                       enc_motivosalirdecasa_compraralimento = l.enc_motivosalirdecasa_compraralimento,
                                       enc_motivosalirdecasa_ahacerdeporte = l.enc_motivosalirdecasa_ahacerdeporte,
                                       enc_motivosalirdecasa_acitamedica = l.enc_motivosalirdecasa_acitamedica,
                                       enc_motivosalirdecasa_sacarmascota = l.enc_motivosalirdecasa_sacarmascota,
                                       enc_motivosalirdecasa_diligenciabancaria = l.enc_motivosalirdecasa_diligenciabancaria,
                                       enc_motivosalirdecasa_socializar = l.enc_motivosalirdecasa_socializar,
                                       enc_motivosalirdecasa_otro = l.enc_motivosalirdecasa_otro,
                                       enc_otromotivosalirdecasa = l.enc_otromotivosalirdecasa,
                                       enc_mediostransporteutilizo_noaplica = l.enc_mediostransporteutilizo_noaplica,
                                       enc_mediostransporteutilizo_transmilenio = l.enc_mediostransporteutilizo_transmilenio,
                                       enc_mediostransporteutilizo_sitp = l.enc_mediostransporteutilizo_sitp,
                                       enc_mediostransporteutilizo_moto = l.enc_mediostransporteutilizo_moto,
                                       enc_mediostransporteutilizo_bicicleta = l.enc_mediostransporteutilizo_bicicleta,
                                       enc_mediostransporteutilizo_taxi = l.enc_mediostransporteutilizo_taxi,
                                       enc_mediostransporteutilizo_carro = l.enc_mediostransporteutilizo_carro,
                                       enc_mediostransporteutilizo_apie = l.enc_mediostransporteutilizo_apie,
                                       enc_mediostransporteutilizo_otro = l.enc_mediostransporteutilizo_otro,
                                       sub_nombre = l.sub_nombre,
                                       usu_nombre = l.usu_nombre,
                                       enc_datetimecreated = l.enc_datetimecreated,
                                       usu_nombre_modificacion = l.usu_nombre_modificacion,
                                       enc_datetimeupdated = l.enc_datetimeupdated


                                   }
                                   ).ToList();

            if (listapreliminar.Count > 0)
            {
                //Se consulta la información adicional desde Silaps

                foreach (EncuestaListaRespuesta item in listapreliminar)
                {
                    IdDatoReferenciado = 0;
                    //Se consulta la información faltante en Silaps y se actualiza
                    //Se consulta por el numero de documento del encuestado
                    var ListaporDocumento = (from r in db2.DatosRecepcion
                                             where r.Idrvp_dyr == 152 && r.Texto_dyr == item.enc_numerodocumento
                                             orderby r.Fecha_dyr descending
                                             select new DatosRecepciondto
                                             {
                                                 Ideyr_dyr = r.Ideyr_dyr,
                                                 Idrvp_dyr = r.Idrvp_dyr,
                                                 dato_dyr = r.dato_dyr,
                                                 Texto_dyr = r.Texto_dyr,

                                             }
                    ).ToList();


                    if (ListaporDocumento.Count > 0)
                    {
                        //Se verifica si el item corresponde a Virus Respiratorios 237

                        foreach (DatosRecepciondto i in ListaporDocumento)
                        {

                            var ListaporId = (from r in db2.DatosRecepcion
                                              where r.Ideyr_dyr == i.Ideyr_dyr && r.Idrvp_dyr == 191 && r.dato_dyr == "237" //VIRUS RESPIRATORIOS
                                              orderby r.Fecha_dyr descending
                                              select new DatosRecepciondto
                                              {
                                                  Ideyr_dyr = r.Ideyr_dyr,
                                                  Idrvp_dyr = r.Idrvp_dyr,
                                                  dato_dyr = r.dato_dyr,
                                                  Texto_dyr = r.Texto_dyr,

                                              }
                        ).FirstOrDefault();

                            if (ListaporId != null)
                            {
                                if (ListaporId.Ideyr_dyr != 0) //Tiene Datos asociados 
                                {
                                    IdDatoReferenciado = ListaporId.Ideyr_dyr;
                                    break;
                                }
                            }




                        }

                        if (IdDatoReferenciado != 0)
                        {

                            //Se consultan los datos faltantes de la encuesta y se hace su correspondiente reemplazamiento
                            var Edad = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(155)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();
                            var Anios = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(329)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();
                            var Genero = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(156)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();
                            var Direccion = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(161)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();
                            var Telefono = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(162)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();
                            var EAPB = db2.DatosRecepcion.Where(p => p.Ideyr_dyr.Equals(IdDatoReferenciado) && p.Idrvp_dyr.Equals(324)).OrderByDescending(p => p.Fecha_dyr).FirstOrDefault();

                            item.enc_edad = Edad.Texto_dyr + " " + Anios.Texto_dyr;
                            item.enc_genero = Genero.Texto_dyr;
                            item.enc_dirresidencia = Direccion.Texto_dyr;
                            item.enc_numcelular = Telefono.Texto_dyr;
                            item.enc_nombreEAPB = EAPB.Texto_dyr;



                        }

                    }
                    else
                    {

                        item.enc_edad = "No Reportado";
                        item.enc_genero = "No Reportado";
                        item.enc_dirresidencia = "No Reportado";
                        item.enc_numcelular = "No Reportado";
                        item.enc_nombreEAPB = "No Reportado";



                    }

                }


            }
            else
            {
                respuesta = null;
                return respuesta;

            }




            respuesta = listapreliminar;
            return respuesta;
        }

    }
}