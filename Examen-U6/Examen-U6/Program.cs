using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examen_U6
{
    public class Amazon
    {
        //Campos
        public string Nombre, Descripcion;
        public int CantStock;
        public float Precio;

        //Constructor
        public Amazon(string Nombre, string Descripcion, int CantStock, float Precio)
        {
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.CantStock = CantStock;
            this.Precio = Precio;
        }

        //Constructor para poder llamar sin tener que enviar algun dato
        public Amazon()
        {

        }

        //Metodos
        public void EscribirArchivo()
        {
            Console.WriteLine("|----------------|Registro de Productos|----------------|");
            StreamWriter sw = new StreamWriter("Productos.txt", true); //Texto de registro de clientes
            //Se escribe en el archivo
            sw.WriteLine("Nombre: " + this.Nombre);
            sw.WriteLine("Descripcion: " + this.Descripcion);
            sw.WriteLine("Cantidad en el Almacen: " + this.CantStock.ToString());
            sw.WriteLine("Precio por unidad: $"+ this.Precio.ToString());
            sw.WriteLine("");
            sw.Close();//se debe cerrare el archivo
        }

        public void LeerArchivo()
        {
            Console.WriteLine("|----------------|Productos registrados|----------------|");
            //Uso de streamreader
            StreamReader sr = new StreamReader("Productos.txt");
            string Line;

            while ((Line = sr.ReadLine()) != null)
            {
                Console.WriteLine(Line);//Pintar en consola el texto

            }
            sr.Close();
            Console.WriteLine("|----------------|Fin de los registros|-----------------|");
        }

        //Destructor
        ~Amazon()
        {
            Console.WriteLine("Clase Amazon destruida");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Variable para el ciclo do-while
            int opcion;

            //Variables auxiliares para enviar a constructor
            string Nombre, Descripcion;
            int CantStock;
            float Precio;
            //Menú de Opciones
            do
            {
                Console.Clear();
                Console.WriteLine("\n ARCHIVO  EMPLEADOS ");
                Console.WriteLine("1.- Registro de elementos en el Archivo.");
                Console.WriteLine("2.- Lectura de un Archivo");
                Console.WriteLine("3.- Salida del Programa");
                Console.Write("\nQué opción deseas: ");
                opcion = Int16.Parse(Console.ReadLine());
                switch (opcion)

                {
                    case 1:
                        try
                        {
                            //Limpia la pantalla
                            Console.Clear();

                            //Valores que enviaremos a la clase
                            Console.Write("Inserte el nombre del Producto: ");
                            Nombre = Convert.ToString(Console.ReadLine());
                            Console.Write("Descripcion breve del producto: ");
                            Descripcion = Convert.ToString(Console.ReadLine());
                            Console.Write("Dame el Precio del Producto por Unidad: ");
                            Precio = float.Parse(Console.ReadLine());
                            Console.Write("Dame la cantidad en el Almacen: ");
                            CantStock = int.Parse(Console.ReadLine());

                            //Creacion de un objeto
                            Amazon Productos = new Amazon(Nombre, Descripcion, CantStock, Precio);

                            Productos.EscribirArchivo();
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError: " + e.Message);
                            Console.WriteLine("\nRuta: " + e.StackTrace);
                        }
                        break;
                    case 2:
                        //bloque de lectura
                        try
                        {
                            //Limpia la pantalla
                            Console.Clear();

                            Amazon LeerProductos = new Amazon();

                            LeerProductos.LeerArchivo();
                            Console.ReadKey();
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError: " + e.Message);
                            Console.WriteLine("\nRuta: " + e.StackTrace);
                        }
                        break;
                    case 3:
                        Console.Write("\nPresione <ENTER> para Salir del Programa...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nEsta opcion no existe intente de nuevo por favor");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 3);

        }
    }
}
