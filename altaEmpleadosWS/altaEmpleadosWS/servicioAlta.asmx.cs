using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace altaEmpleadosWS
{
    /// <summary>
    /// Descripción breve de servicioAlta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class servicioAlta : System.Web.Services.WebService
    {

        [WebMethod]
        public void altaEmpleado(int codEmpleado,string firstname, string lastname, string country)
        {
            alta alta = new alta();
            string cs = ConfigurationManager.ConnectionStrings["AVAN_iban"].ConnectionString;

            using (SqlConnection conex = new SqlConnection(cs))
            {
                SqlCommand cmdAltaEmpleado = new SqlCommand("pr_altaEmpleado", conex);
                cmdAltaEmpleado.CommandType = CommandType.StoredProcedure;
                SqlParameter prmCodigo = new SqlParameter();
                SqlParameter prmFirstname = new SqlParameter();
                SqlParameter prmLastname = new SqlParameter();
                SqlParameter prmCountry = new SqlParameter();
                SqlParameter prmSalida = new SqlParameter();

                prmCodigo.ParameterName = "@p_employeeID"; 
                prmCodigo.SqlDbType = SqlDbType.Int;
                prmCodigo.Value = codEmpleado;
                prmCodigo.Direction = ParameterDirection.Input;
                cmdAltaEmpleado.Parameters.Add(prmCodigo);

                prmFirstname.ParameterName = "@p_firstname";
                prmFirstname.SqlDbType = SqlDbType.NVarChar;
                prmFirstname.Size = 10;
                prmFirstname.Value = firstname;
                prmFirstname.Direction = ParameterDirection.Input;
                cmdAltaEmpleado.Parameters.Add(prmFirstname);

                prmLastname.ParameterName = "@p_lastname"; 
                prmLastname.SqlDbType = SqlDbType.NVarChar;
                prmFirstname.Size = 20;
                prmLastname.Value = lastname;
                prmLastname.Direction = ParameterDirection.Input;
                cmdAltaEmpleado.Parameters.Add(prmLastname);

                prmCountry.ParameterName = "@p_country"; 
                prmCountry.SqlDbType = SqlDbType.NVarChar;
                prmFirstname.Size = 15;
                prmCountry.Value = country;
                prmCountry.Direction = ParameterDirection.Input;
                cmdAltaEmpleado.Parameters.Add(prmCountry);

                prmSalida.ParameterName = "@p_salida"; 
                prmSalida.SqlDbType = SqlDbType.SmallInt;
                // value a 0 igual mejor
                prmSalida.Direction = ParameterDirection.Output;
                cmdAltaEmpleado.Parameters.Add(prmSalida);


                //try
                conex.Open();

                SqlDataReader lector = cmdAltaEmpleado.ExecuteReader();
                //catch
                alta.Salida = Convert.ToInt32(prmSalida.Value);
                
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(alta));
        }

    }
}
