using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication.Repositorio
{
    public class ChartsConcrete:ICharts
    {

        public void ListaTecnicos(out string Tecnicos, out string Cantidad)
        {
           
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString()))  
            {
                using (MySqlDataAdapter da = new MySqlDataAdapter())
                {
                    StringBuilder command = new StringBuilder();
                    command.Append("select tabla1.Com_Nombre as nombre, tabla1.Comp_estado as estado from ");
                    command.Append("(SELECT com_usuarios.idCom_Usuarios, com_usuarios.Com_Nombre ,  count(comp_ruta.Comp_estado) Comp_estado ");
                    command.Append("FROM comp_ruta ");
                    command.Append("right join com_usuarios ");
                    command.Append("on comp_ruta.Com_Usuarios_idCom_Usuarios = com_usuarios.idCom_Usuarios ");
                    command.Append(" where YEAR(comp_ruta.Comp_Fecha) = YEAR(CURRENT_DATE()) AND ");
                    command.Append(" MONTH(comp_ruta.Comp_Fecha) = MONTH(CURRENT_DATE()) ");
                    command.Append("group by com_usuarios.idCom_Usuarios) as tabla1;");
                   

                    da.SelectCommand = new MySqlCommand(command.ToString(), con);
                    con.Open();
                    

                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    var MobileSalesCounts = (from DataRow myRow in tabla.Rows
                                             select myRow.Field<string>("nombre")).ToList();

                  

                    var ProductNames = (from DataRow myRow in tabla.Rows
                                        select myRow.Field<Int64>("estado")).ToList();

                    Tecnicos = string.Join(",", MobileSalesCounts);

                    Cantidad = string.Join(",", ProductNames); 
                }

                
            }  
        
        }
    }
}