using System;
using System.Collections.Generic;

class Producto
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public Producto(int codigo, string nombre, int cantidad, decimal precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Cantidad = cantidad;
        Precio = precio;
    }

    public override string ToString()
    {
        return $"Código: {Codigo}, Nombre: {Nombre}, Cantidad: {Cantidad}, Precio: {Precio:C2}";
    }
}

class Program
{
    static List<Producto> inventario = new List<Producto>();

    static void Main()
    {
        int opcion;
        do
        {
            MostrarMenu();
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProducto();
                    break;
                case 2:
                    EliminarProducto();
                    break;
                case 3:
                    ModificarProducto();
                    break;
                case 4:
                    ConsultarProducto();
                    break;
                case 5:
                    MostrarTodosLosProductos();
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        } while (opcion != 6);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n--- Menú de Inventario ---");
        Console.WriteLine("1. Agregar producto");
        Console.WriteLine("2. Eliminar producto");
        Console.WriteLine("3. Modificar producto");
        Console.WriteLine("4. Consultar producto");
        Console.WriteLine("5. Mostrar todos los productos");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void AgregarProducto()
    {
        Console.Write("Ingrese el código del producto: ");
        int codigo = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la cantidad del producto: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el precio del producto: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        inventario.Add(new Producto(codigo, nombre, cantidad, precio));
        Console.WriteLine("Producto agregado con éxito.");
    }

    static void EliminarProducto()
    {
        Console.Write("Ingrese el código del producto que desea eliminar: ");
        int codigo = int.Parse(Console.ReadLine());

        Producto producto = inventario.Find(p => p.Codigo == codigo);

        if (producto != null)
        {
            inventario.Remove(producto);
            Console.WriteLine("Producto eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ModificarProducto()
    {
        Console.Write("Ingrese el código del producto que desea modificar: ");
        int codigo = int.Parse(Console.ReadLine());

        Producto producto = inventario.Find(p => p.Codigo == codigo);

        if (producto != null)
        {
            Console.Write("Ingrese el nuevo nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.Write("Ingrese la nueva cantidad del producto: ");
            producto.Cantidad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nuevo precio del producto: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Producto modificado con éxito.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ConsultarProducto()
    {
        Console.Write("Ingrese el código del producto que desea consultar: ");
        int codigo = int.Parse(Console.ReadLine());

        Producto producto = inventario.Find(p => p.Codigo == codigo);

        if (producto != null)
        {
            Console.WriteLine(producto);
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void MostrarTodosLosProductos()
    {
        if (inventario.Count == 0)
        {
            Console.WriteLine("No hay productos en el inventario.");
        }
        else
        {
            Console.WriteLine("\n--- Productos en Inventario ---");
            foreach (Producto producto in inventario)
            {
                Console.WriteLine(producto);
            }
        }
    }
}
