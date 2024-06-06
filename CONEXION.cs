using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BASE_DE_DATOS_ALUMNOS_UNI_3
{
    internal class CONEXION
    {
        public static SqlConnection connectar ()
        {
            SqlConnection cn = new SqlConnection("Server=" +
                "BRENDA\\SQLEXPRESS;Database=REGISTRO;Integrated Security=True;");
        cn.Open();
            return cn;

    }
}
}
