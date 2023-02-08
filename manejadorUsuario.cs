using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursoCSharp
{
    internal static class manejadorUsuario
    {
        public static string connectionString = "Data Source=DESKTOP-OQ5C61I;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Usuario> obtenerUsuario(long id)
        {
            List<Usuario> usuario = new List<Usuario>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE id=@id", conn);
                comando.Parameters.AddWithValue("@id", id);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuario usuariotem = new Usuario();
                        usuariotem.Id = reader.GetInt64(0);
                        usuariotem.Nombre = reader.GetString(1);
                        usuariotem.Apellido = reader.GetString(2);
                        usuariotem.NombreUsuario = reader.GetString(3);
                        usuariotem.Contraseña = reader.GetString(4);
                        usuariotem.Mail = reader.GetString(5);

                        usuario.Add(usuariotem);
                    }

                }
               
            }
            return usuario;
        }

        public static List<Usuario> login(string nombreUsuario, string contraseña)
        {
            List<Usuario> loguearse = new List<Usuario>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE nombreUsuario=@nombreUsuario and contraseña=@contraseña", conn);
                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@contraseña", contraseña);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuario usuariotem = new Usuario();
                        usuariotem.Id = reader.GetInt64(0);
                        usuariotem.Nombre = reader.GetString(1);
                        usuariotem.Apellido = reader.GetString(2);
                        usuariotem.NombreUsuario = reader.GetString(3);
                        usuariotem.Contraseña = reader.GetString(4);
                        usuariotem.Mail = reader.GetString(5);

                        loguearse.Add(usuariotem);
                    }

                }

            }
            return loguearse;
        }

    }
}
