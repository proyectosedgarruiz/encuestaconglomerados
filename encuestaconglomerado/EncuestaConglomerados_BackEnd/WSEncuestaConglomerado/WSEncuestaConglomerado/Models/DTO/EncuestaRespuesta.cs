using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSEncuestaConglomerado.Models.EDMX;

namespace WSEncuestaConglomerado.Models.DTO
{
    public class EncuestaRespuesta : RespuestaBase
    {
        public Int64 enc_id;
        public DateTime enc_fecha;
        public int loc_id;
        public int upz_id;
        public int bar_id;
        public int cua_id;
        public string enc_muestreadopor;
        public int? cpm_id;
        public string enc_nombreencuestado;
        public int tpd_id;
        public string enc_numerodocumento;
        public int enc_edad;
        public string enc_genero;
        public string enc_dirresidencia;
        public string enc_numcelular;
        public string enc_aseguramiento;
        public string enc_nombreEAPB;
        public string enc_ocupacion;
        public int enc_cuantaspersonashabitan;
        public int enc_cuantaspersonasmayores60;
        public int enc_cuantascondicionescronicas;
        public int enc_cuantashabitacionescuentaresidencia;
        public bool? enc_hapresentadosintomas_fiebre;
        public bool? enc_hapresentadosintomas_tos;
        public bool? enc_hapresentadosintomas_dolorgarganta;
        public bool? enc_hapresentadosintomas_fatigadebilidad;
        public bool? enc_hapresentadosintomas_ahogofaltaaire;
        public bool? enc_hapresentadosintomas_ninguno;
        public string enc_comoconsideracumplimientocuarentena;
        public string enc_contactopersonas24horas;
        public string enc_dondedesplazoustedomiembrofamilia;
        public bool? enc_motivosalirdecasa_noaplica;
        public bool? enc_motivosalirdecasa_atrabajar;
        public bool? enc_motivosalirdecasa_compraralimento;
        public bool? enc_motivosalirdecasa_ahacerdeporte;
        public bool? enc_motivosalirdecasa_acitamedica;
        public bool? enc_motivosalirdecasa_sacarmascota;
        public bool? enc_motivosalirdecasa_diligenciabancaria;
        public bool? enc_motivosalirdecasa_socializar;
        public bool? enc_motivosalirdecasa_otro;
        public string enc_otromotivosalirdecasa;
        public bool? enc_mediostransporteutilizo_noaplica;
        public bool? enc_mediostransporteutilizo_transmilenio;
        public bool? enc_mediostransporteutilizo_sitp;
        public bool? enc_mediostransporteutilizo_moto;
        public bool? enc_mediostransporteutilizo_bicicleta;
        public bool? enc_mediostransporteutilizo_taxi;
        public bool? enc_mediostransporteutilizo_carro;
        public bool? enc_mediostransporteutilizo_apie;
        public bool? enc_mediostransporteutilizo_otro;
        public int? sub_id;
        public int? usu_id;
        public int? enc_usu_modificacion;
        //Nuevos atributos
        public string enc_estadoembarazo;
        public string enc_etnia;
        public string enc_condiciondiscapacidad;
        public bool? enc_presentaenfermedad_hipertension;
        public bool? enc_presentaenfermedad_diabetesmellitus;
        public bool? enc_presentaenfermedad_obesidad;
        public bool? enc_presentaenfermedad_epoc;
        public bool? enc_presentaenfermedad_asma;
        public bool? enc_presentaenfermedad_otro;
        public string enc_presentaenfermedad_otrocuales;
        public bool? enc_hapresentadosintomas_diarrea;
        public bool? enc_hapresentadosintomas_perdidaolfato;
        public string enc_contactopersonascuantas;
        public string enc_dispuestoaislamiento;
        public string enc_vacunadocovid;
        public string enc_accedetomamuestra;
        public bool? enc_convivepresentadosintomas_fiebre;
        public bool? enc_convivepresentadosintomas_tos;
        public bool? enc_convivepresentadosintomas_dolorgarganta;
        public bool? enc_convivepresentadosintomas_fatigadebilidad;
        public bool? enc_convivepresentadosintomas_ahogofaltaaire;
        public bool? enc_convivepresentadosintomas_ninguno;
        public bool? enc_convivehapresentadosintomas_diarrea;
        public bool? enc_convivehapresentadosintomas_perdidaolfato;
        public bool? enc_presentaenfermedad_ninguno;
        public string enc_compartehabitacion;
        public bool? enc_hapresentadosintomas_dolorestomago;
        public bool? enc_convivepresentadosintomas_dolorestomago;
        public string enc_frecuenciadesplazamiento;
        public string enc_esquemavacunacioncompleto;

    }


    public class DatosRecepciondto
    {
        public int Ideyr_dyr;
        public int Idrvp_dyr;
        public string dato_dyr;
        public string Texto_dyr;
        public int Codigousu_dyr;
        public int Periodoeyr_dyr;

    }

    public class EncuestaListaRespuesta : RespuestaBase
    {
        public Int64 enc_id;
        public string enc_fecha;
        public string loc_nombre;
        public string upz_nombre;
        public string bar_nombre;
        public string cua_nombre;
        public string enc_muestreadopor;
        public string cpm_nombre;
        public string enc_nombreencuestado;
        public string tpd_nombre;
        public string enc_numerodocumento;
        public string enc_edad;
        public string enc_genero;
        public string enc_dirresidencia;
        public string enc_numcelular;
        public string enc_aseguramiento;
        public string enc_nombreEAPB;
        public string enc_ocupacion;
        public int enc_cuantaspersonashabitan;
        public int enc_cuantaspersonasmayores60;
        public int enc_cuantascondicionescronicas;
        public int enc_cuantashabitacionescuentaresidencia;
        public bool? enc_hapresentadosintomas_fiebre;
        public bool? enc_hapresentadosintomas_tos;
        public bool? enc_hapresentadosintomas_dolorgarganta;
        public bool? enc_hapresentadosintomas_fatigadebilidad;
        public bool? enc_hapresentadosintomas_ahogofaltaaire;
        public bool? enc_hapresentadosintomas_ninguno;
        public string enc_comoconsideracumplimientocuarentena;
        public string enc_contactopersonas24horas;
        public string enc_dondedesplazoustedomiembrofamilia;
        public bool? enc_motivosalirdecasa_noaplica;
        public bool? enc_motivosalirdecasa_atrabajar;
        public bool? enc_motivosalirdecasa_compraralimento;
        public bool? enc_motivosalirdecasa_ahacerdeporte;
        public bool? enc_motivosalirdecasa_acitamedica;
        public bool? enc_motivosalirdecasa_sacarmascota;
        public bool? enc_motivosalirdecasa_diligenciabancaria;
        public bool? enc_motivosalirdecasa_socializar;
        public bool? enc_motivosalirdecasa_otro;
        public string enc_otromotivosalirdecasa;
        public bool? enc_mediostransporteutilizo_noaplica;
        public bool? enc_mediostransporteutilizo_transmilenio;
        public bool? enc_mediostransporteutilizo_sitp;
        public bool? enc_mediostransporteutilizo_moto;
        public bool? enc_mediostransporteutilizo_bicicleta;
        public bool? enc_mediostransporteutilizo_taxi;
        public bool? enc_mediostransporteutilizo_carro;
        public bool? enc_mediostransporteutilizo_apie;
        public bool? enc_mediostransporteutilizo_otro;
        public string sub_nombre;
        public string usu_nombre;
        public DateTime enc_datetimecreated;
        public string usu_nombre_modificacion;
        public DateTime? enc_datetimeupdated;

        //Nuevos atributos
        public string enc_estadoembarazo;
        public string enc_etnia;
        public string enc_condiciondiscapacidad;
        public bool? enc_presentaenfermedad_hipertension;
        public bool? enc_presentaenfermedad_diabetesmellitus;
        public bool? enc_presentaenfermedad_obesidad;
        public bool? enc_presentaenfermedad_epoc;
        public bool? enc_presentaenfermedad_asma;
        public bool? enc_presentaenfermedad_otro;
        public string enc_presentaenfermedad_otrocuales;
        public bool? enc_hapresentadosintomas_diarrea;
        public bool? enc_hapresentadosintomas_perdidaolfato;
        public string enc_contactopersonascuantas;
        public string enc_dispuestoaislamiento;
        public string enc_vacunadocovid;
        public string enc_accedetomamuestra;
        public bool? enc_convivepresentadosintomas_fiebre;
        public bool? enc_convivepresentadosintomas_tos;
        public bool? enc_convivepresentadosintomas_dolorgarganta;
        public bool? enc_convivepresentadosintomas_fatigadebilidad;
        public bool? enc_convivepresentadosintomas_ahogofaltaaire;
        public bool? enc_convivepresentadosintomas_ninguno;
        public bool? enc_convivehapresentadosintomas_diarrea;
        public bool? enc_convivehapresentadosintomas_perdidaolfato;
        public bool? enc_presentaenfermedad_ninguno;
        public string enc_compartehabitacion;
        public bool? enc_hapresentadosintomas_dolorestomago;
        public bool? enc_convivepresentadosintomas_dolorestomago;
        public string enc_frecuenciadesplazamiento;
        public string enc_esquemavacunacioncompleto;



    }

    #region RespuestaBase
    public abstract class RespuestaBase
    {

        public bool OperacionExitosa { get; set; }
        public string Mensaje { get; set; }


    }

    #endregion


    public class ListaEncuesta
    {
        public virtual ICollection<SP_LIST_ENCUESTAS_Result> Lista { get; set; }

        public ListaEncuesta()
        {
            Lista = new HashSet<SP_LIST_ENCUESTAS_Result>();
        }
    }

    public class ListaEncuestaSubRed
    {
        public virtual ICollection<SP_LIST_ENCUESTAS_SUBRED_Result> Lista { get; set; }

        public ListaEncuestaSubRed()
        {
            Lista = new HashSet<SP_LIST_ENCUESTAS_SUBRED_Result>();
        }
    }
}