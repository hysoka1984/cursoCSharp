namespace cursoCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*traer usuario (recibe un int)*/
            List<Usuario> usuario = manejadorUsuario.obtenerUsuario(1);
            foreach (var item in usuario)
            {
                Console.WriteLine(item.Nombre);
            }

            /*traer Productos (recibe un id de usuario y devuelve una lista con los productos cargados por ese usuario)*/
            List<Producto> producto = ProductoManejador.obtenerProductos(1);
            foreach (var item in producto)
            {
                Console.WriteLine(item.Descripciones);
            }

            /*Traer ProductosVendidos (recibe el id del usuario y devuelve una lista de productos vendidos por ese usuario)*/
            List<Producto> productos = ProductoManejador.obtenerProductosVendidos(1);
            foreach (var item in productos)
            {
                Console.WriteLine(item.Descripciones);
            }

            /*Traer Ventas(recibe el id del usuario y devuelve una lista de ventas realizadas por ese usuario)*/
            List<Venta> ventas = manejadorVentas.obtenerVentas(1);
            foreach (var item in ventas)
            {
                Console.WriteLine(item.Id);
            }

            /*Inicio de session(recibe un usuario y contraseña, devuelve un objeto usuario)*/
            List<Usuario> usuariologuead = manejadorUsuario.login("tcasazza", "SoyTobiasCasazza");

            foreach (var item in usuariologuead)
            {
                if (item.NombreUsuario = "tcasazza")
                {
                    Console.WriteLine("usuario correcto")
                }
            }
        }
    }
}