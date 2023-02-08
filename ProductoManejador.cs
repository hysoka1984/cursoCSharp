using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursoCSharp
{
    internal static class ProductoManejador
    {
        public static string connectionString = "Data Source=DESKTOP-OQ5C61I;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Producto obtener1Producto(long Id)
        {
            Producto productoUnico = new Producto();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE Id=@id", conn);
                comando.Parameters.AddWithValue("@id", Id);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productoUnico.Id = reader.GetInt64(0);
                        productoUnico.Descripciones = reader.GetString(1);
                        productoUnico.Costo = reader.GetDecimal(2);
                        productoUnico.PrecioVenta = reader.GetDecimal(3);
                        productoUnico.Stock = reader.GetInt32(4);
                        productoUnico.IdUsuario = reader.GetInt64(5);
                    }

                }

            }
            return productoUnico;
        }

        public static List<Producto> obtenerProductos(long IdUsuario)
        {
            List<Producto> Producto = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario=@idUsuario", conn);
                comando.Parameters.AddWithValue("@idUsuario", IdUsuario);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto Prod = new Producto();

                        Prod.Id = reader.GetInt64(0);
                        Prod.Descripciones = reader.GetString(1);
                        Prod.Costo = reader.GetDecimal(2);
                        Prod.PrecioVenta = reader.GetDecimal(3);
                        Prod.Stock = reader.GetInt32(4);
                        Prod.IdUsuario = reader.GetInt64(5);

                        Producto.Add(Prod);
                    }

                }

            }
            return Producto;
        }

        public static List<Producto> obtenerProductosVendidos(long IdUsuario)
        {
            List<long> idProductos = new List<long>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando1 = new SqlCommand("SELECT pv.idProducto FROM Venta v" + " INNER JOIN ProductoVendido pv" + " ON v.Id = pv.idVenta" + " WHERE idUsuario=@idUsuario", conn);
                comando1.Parameters.AddWithValue("@idUsuario", IdUsuario);
                conn.Open();

                SqlDataReader reader = comando1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idProductos.Add(reader.GetInt64(0));
                    }

                }

            }
            List<Producto> productos = new List<Producto>();
            foreach (var id in idProductos)
            {
                Producto temp = obtener1Producto(id);
                productos.Add(temp);
            }

            return productos;
        }

    }
}
