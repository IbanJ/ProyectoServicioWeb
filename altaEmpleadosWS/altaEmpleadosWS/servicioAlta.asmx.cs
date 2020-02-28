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
        public void altaEmpleado()
        {
            List<empleado> listaEmpleados = new List<empleado>();
            string cs = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

            using (SqlConnection conex = new SqlConnection(cs))
            {
                string strConsulta = "SELECT employeeID,firstname,lastname,country FROM employees";
                SqlCommand cmdRecEmplePorCod = new SqlCommand(strConsulta, conex);
                cmdRecEmplePorCod.CommandType = CommandType.Text;

                conex.Open();
                SqlDataReader lector = cmdRecEmplePorCod.ExecuteReader();
                while (lector.Read())
                {
                    empleado objEmpleado = new empleado();

                    objEmpleado.Codigo = Convert.ToInt32(lector["employeeId"]);
                    objEmpleado.Nombre = lector["FirstName"].ToString();
                    objEmpleado.LastName = lector["LastName"].ToString();
                    objEmpleado.Country = lector["Country"].ToString();

                    listaEmpleados.Add(objEmpleado);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listaEmpleados));
        }
    }
}
