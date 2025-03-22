using EMELY_APRAEZ_CSHARP_2025;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{ 

    static List<Producto> productos = new List<Producto>
    {
        new Producto { Id = 1, Nombre = "Laptop", Precio = 1200.50m },
        new Producto { Id = 2, Nombre = "Mouse", Precio = 25.75m },
        new Producto { Id = 3, Nombre = "Teclado", Precio = 45.99m },
        new Producto { Id = 4, Nombre = "Monitor", Precio = 300.00m },
        new Producto { Id = 5, Nombre = "Impresora", Precio = 150.00m }
    };

    static int idCounter = 6;


    static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\n\nGestión de Productos");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Eliminar Producto");
                Console.WriteLine("3. Buscar Producto");
                Console.WriteLine("4. Mostrar Productos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1": AgregarProducto(); break;
                    case "2": EliminarProducto(); break;
                    case "3": BuscarProducto(); break;
                    case "4": MostrarProductos(); break;
                    case "5": return;
                    default: Console.WriteLine("\n[X] Opción no válida. Intente de nuevo."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[X] Error: {ex.Message}. Intente nuevamente.");
            }
        }
    }


    static void AgregarProducto()
    {
        try
        {

            string nombre;

            do
            {

                Console.Write("\nIngrese el nombre del producto: ");
                nombre = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(nombre) || nombre.Length < 3 || nombre.Length > 200)
                {
                    Console.WriteLine("[X] Nombre inválido. Debe tener entre 3 y 200 caracteres y no estar vacío.");
                }

            } while (string.IsNullOrEmpty(nombre) || nombre.Length < 3 || nombre.Length > 200);

            decimal precio;

            while (true)
            {

                Console.Write("\nIngrese el precio del producto: ");

                if (decimal.TryParse(Console.ReadLine(), out precio) && precio > 0)
                    break;

                Console.WriteLine("[X] Precio inválido. Debe ser un número decimal mayor a 0.");
            }

            productos.Add(new Producto { Id = idCounter++, Nombre = nombre, Precio = precio });

            Console.WriteLine("\n[✓] Producto agregado exitosamente.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[X] Error: {ex.Message}. Intente nuevamente.");
        }
    }


    static void EliminarProducto()
    {
        try
        {
            int id;

            while (true)
            {
                Console.Write("\nIngrese el ID del producto a eliminar: ");

                if (int.TryParse(Console.ReadLine(), out id))
                    break;

                Console.WriteLine("[X] ID inválido. Intente nuevamente.");
            }

            Producto? producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {
                Console.WriteLine("\n[X] Producto no encontrado.");
                return;
            }

            productos.Remove(producto);

            Console.WriteLine("\n[✓] Producto eliminado correctamente.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[X] Error: {ex.Message}. Intente nuevamente.");
        }
    }


    static void BuscarProducto()
    {
        try
        {
            string nombre;

            do
            {
                Console.Write("\nIngrese el nombre del producto a buscar: ");

                nombre = Console.ReadLine()?.Trim()?.ToLower();

                if (string.IsNullOrEmpty(nombre))
                {
                    Console.WriteLine("[X] El criterio de búsqueda no puede estar vacío.");
                }

            } while (string.IsNullOrEmpty(nombre));

            List<Producto> resultados = productos.Where(p => p.Nombre.ToLower().Contains(nombre)).ToList();

            Console.WriteLine("\n[✓] Resultados de búsqueda:");

            foreach (Producto p in resultados)
            {
                Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio:C}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[X] Error: {ex.Message}. Intente nuevamente.");
        }
    }


    static void MostrarProductos()
    {
        try
        {
            if (!productos.Any())
            {
                Console.WriteLine("\n[✓] No hay productos registrados.");
                return;
            }

            Console.WriteLine("\n[✓] Lista de Productos:");
            foreach (Producto p in productos)
            {
                Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio:C}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[X] Error: {ex.Message}. Intente nuevamente.");
        }
    }

}