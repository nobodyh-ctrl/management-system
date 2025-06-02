using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_REPARA
{
    public class CPrincipal
    {
        static void Main(string[] args)
        {
            CSistema sistema = new CSistema();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Establecer variables de sueldo");
                Console.WriteLine("2. Registrar empleado");
                Console.WriteLine("3. Mostar empleados ordenandos");
                Console.WriteLine("4. Registrar una Obra");
                Console.WriteLine("5. Asignar profesional a una obra");
                Console.WriteLine("6. Asignar obrero a una obra");
                Console.WriteLine("7. Listar datos X obra");
                Console.WriteLine("8. Eliminar profesional");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        sistema.EstablecerVariablesSueldo();
                        break;
                    case "2":
                        sistema.RegistrarEmpleado();
                        break;
                    case "3":
                        sistema.ListarEmpleadosOrdenados();
                        break;
                    case "4":
                        sistema.RegistrarObra();
                        break;
                    case "5":
                        sistema.AsignarProfesional();
                        break;
                    case "6":
                        sistema.AginarObrero();
                        break;
                    case "7":
                        sistema.DatosXObra();
                        break;
                    case "8":
                        sistema.EliminarProfesional();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
