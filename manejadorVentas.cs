using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cursoCSharp
{
    internal class manejadorVentas
    {
        public static string connectionString = "Data Source=DESKTOP-OQ5C61I;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Venta> obtenerVentas(long IdUsuario)
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario=@idUsuario", conn);
                comando.Parameters.AddWithValue("@idUsuario", IdUsuario);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta sale= new Venta();
                        sale.Id = reader.GetInt64(0);
                        sale.Comentarios = reader.GetString(1);
                        sale.IdUsuario = reader.GetInt64(2);

                        ventas.Add(sale);
                    }

                }

            }
            return ventas;
        }
    }
}
