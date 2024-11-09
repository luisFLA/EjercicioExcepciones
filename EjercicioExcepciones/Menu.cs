using System;

namespace EjercicioExcepciones
{
    public class Menu
    {
        private Operaciones operaciones;

        public Menu()
        {
            operaciones = new Operaciones();
        }

        public void MostrarMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Menú de Operaciones:");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    continue;
                }

                if (opcion == 5)
                {
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                }

                EjecutarOperacion(opcion);
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void EjecutarOperacion(int opcion)
        {
            try
            {
                Console.Write("Ingrese el primer número: ");
                double num1 = double.Parse(Console.ReadLine());

                Console.Write("Ingrese el segundo número: ");
                double num2 = double.Parse(Console.ReadLine());

                double resultado = 0;

                switch (opcion)
                {
                    case 1:
                        resultado = operaciones.Sumar(num1, num2);
                        Console.WriteLine($"Resultado: {resultado}");
                        break;
                    case 2:
                        resultado = operaciones.Restar(num1, num2);
                        Console.WriteLine($"Resultado: {resultado}");
                        break;
                    case 3:
                        resultado = operaciones.Multiplicar(num1, num2);
                        Console.WriteLine($"Resultado: {resultado}");
                        break;
                    case 4:
                        resultado = operaciones.Dividir(num1, num2);
                        Console.WriteLine($"Resultado: {resultado}");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese un número válido.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}
