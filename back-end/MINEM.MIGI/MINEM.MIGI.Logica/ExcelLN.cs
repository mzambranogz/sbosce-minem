﻿using MINEM.MIGI.Datos;
using MINEM.MIGI.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MINEM.MIGI.Logica
{
    public class ExcelLN : BaseLN
    {
        ExcelDA ExcelDA = new ExcelDA();
        public bool GuardarDatosExcel(DataTable dt)
        {
            bool esValido = false;
            try
            {
                esValido = ExcelDA.GuardarMasivo(dt, "T_GENM_MIGI", cn);
            }
            finally { if (cn.State == ConnectionState.Open) cn.Close(); }

            return esValido;
        }

        public bool GuardarDatosExcelM8U(DataTable dt)
        {
            bool esValido = false;
            try
            {
                esValido = ExcelDA.GuardarMasivo(dt, "T_GENM_MIGI_M8U", cn);
            }
            finally { if (cn.State == ConnectionState.Open) cn.Close(); }

            return esValido;
        }

        public bool VerificarOrden(OrdenCompraBE obj)
        {
            bool esValido = false;
            try
            {
                esValido = ExcelDA.VerificarOrden(obj, cn);
            }
            finally { if (cn.State == ConnectionState.Open) cn.Close(); }

            return esValido;
        }

        public bool VerificarOrdenM8U(OrdenCompraM8UBE obj)
        {
            bool esValido = false;
            try
            {
                esValido = ExcelDA.VerificarCodigoConvocatoriaMiembro(obj, cn);
            }
            finally { if (cn.State == ConnectionState.Open) cn.Close(); }

            return esValido;
        }

        public bool GuardarDatosArchivo(ExcelBE obj)
        {
            bool esValido = false;
            try
            {
                esValido = ExcelDA.GuardarDatosArchivo(obj, cn);
            }
            finally { if (cn.State == ConnectionState.Open) cn.Close(); }

            return esValido;
        }

        public List<ExcelBE> ListarExcels(int tipoexcel, int registros, int pagina, string columna, string orden)
        {
            List<ExcelBE> lista = new List<ExcelBE>();

            try
            {
                cn.Open();
                lista = ExcelDA.ListarExcels(tipoexcel, registros, pagina, columna, orden, cn);
            }
            finally { if (cn.State == ConnectionState.Open) cn.Close(); }

            return lista;
        }

        public static byte[] ObtenerPlantillaExportar(string nomArchivo)
        {
            var fileName = Path.Combine(HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data"), nomArchivo);

            var archivoBytes = System.IO.File.ReadAllBytes(fileName);
            return archivoBytes;
        }
    }
}
