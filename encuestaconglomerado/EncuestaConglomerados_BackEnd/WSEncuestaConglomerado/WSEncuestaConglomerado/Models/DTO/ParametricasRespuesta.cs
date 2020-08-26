using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSEncuestaConglomerado.Models.EDMX;

namespace WSEncuestaConglomerado.Models.DTO
{
    public class ParametricasRespuesta
    {


        public class UsuariosRespuesta  : RespuestaBase
        {
            public int usu_id;
            public string usu_nombre;
            public string usu_login;
            public string usu_password;
            public string usu_estado;
            public int rol_id;
            public bool usu_req_clave;
            public int? sub_id;


        }

        public class ClavesRespuesta : RespuestaBase
        {
            public int id_usuario;
            public string clave_nueva;
            public string clave_anterior;
            public string clave_confirmada;


        }

        public abstract class RespuestaBase
        {

            public bool OperacionExitosa { get; set; }
            public string Mensaje { get; set; }


        }




        public class ListaLocalidades
        {
            public virtual ICollection<SP_LIST_LOCALIDADES_Result> Lista { get; set; }

            public ListaLocalidades()
            {
                Lista = new HashSet<SP_LIST_LOCALIDADES_Result>();
            }
        }


        public class ListaUPZs
        {
            public virtual ICollection<SP_LIST_UPZ_Result> Lista { get; set; }

            public ListaUPZs()
            {
                Lista = new HashSet<SP_LIST_UPZ_Result>();
            }
        }

        public class ListaBarrios
        {
            public virtual ICollection<SP_LIST_BARRIOS_Result> Lista { get; set; }

            public ListaBarrios()
            {
                Lista = new HashSet<SP_LIST_BARRIOS_Result>();
            }
        }

        public class ListaCuadrantes
        {
            public virtual ICollection<SP_LIST_CUADRANTES_Result> Lista { get; set; }

            public ListaCuadrantes()
            {
                Lista = new HashSet<SP_LIST_CUADRANTES_Result>();
            }
        }

        public class ListaTipoDocumentos
        {
            public virtual ICollection<SP_LIST_TIPODOCUMENTO_Result> Lista { get; set; }

            public ListaTipoDocumentos()
            {
                Lista = new HashSet<SP_LIST_TIPODOCUMENTO_Result>();
            }
        }



        public class ListaCriterioPriorizacionMuestra
        {
            public virtual ICollection<SP_LIST_CRITERIO_PRIORIZACION_MUESTRA_Result> Lista { get; set; }

            public ListaCriterioPriorizacionMuestra()
            {
                Lista = new HashSet<SP_LIST_CRITERIO_PRIORIZACION_MUESTRA_Result>();
            }
        }

        public class ListaSubRedes
        {
            public virtual ICollection<SP_LIST_SUBREDES_Result> Lista { get; set; }

            public ListaSubRedes()
            {
                Lista = new HashSet<SP_LIST_SUBREDES_Result>();
            }
        }
        public class ListaRoles
        {
            public virtual ICollection<SP_LIST_ROLES_Result> Lista { get; set; }

            public ListaRoles()
            {
                Lista = new HashSet<SP_LIST_ROLES_Result>();
            }
        }

        public class ListaUsuarios
        {
            public virtual ICollection<SP_LIST_USUARIOS_Result> Lista { get; set; }

            public ListaUsuarios()
            {
                Lista = new HashSet<SP_LIST_USUARIOS_Result>();
            }
        }


        public class ListaUsuariosSubRed
        {
            public virtual ICollection<SP_LIST_USUARIOS_SUBRED_Result> Lista { get; set; }

            public ListaUsuariosSubRed()
            {
                Lista = new HashSet<SP_LIST_USUARIOS_SUBRED_Result>();
            }
        }


        public class ListaUsuariosAutorizado
        {
            public virtual ICollection<SP_FIND_USUARIO_AUTORIZADO_Result> Lista { get; set; }

            public ListaUsuariosAutorizado()
            {
                Lista = new HashSet<SP_FIND_USUARIO_AUTORIZADO_Result>();
            }
        }


        public class ListaRegistroExistente
        {
            public virtual ICollection<SP_CONSULTAR_REGISTRO_EXISTENTE_Result> Lista { get; set; }

            public ListaRegistroExistente()
            {
                Lista = new HashSet<SP_CONSULTAR_REGISTRO_EXISTENTE_Result>();
            }
        }
    }
}