using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TP_REPARA
{
    public class CSistema
    {
        private float MontoReferencia;
        private float CanonProfesional;
        private List<CEmpleado> empleados = new List<CEmpleado>();
        private List<CObra> obras = new List<CObra>();  
        
        
        private void MostrarSueldos()
        {
            Console.WriteLine("\n--- Sueldos calculados ---");

            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }
            
            foreach (CEmpleado emp in empleados)
            {
                Console.WriteLine($"Legajo: {emp.Legajo}, Nombre: {emp.Nombre}, Apellido: {emp.Apellido}");

                // Mostrar datos según tipo
                if (emp is CObrero obrero)
                {
                    obrero.LeerObrero();
                }
                else if (emp is CProfesional prof)
                {
                    prof.LeerProfesional();
                }

                
                // Calcular y mostrar el haber
                float haber = emp.CalcularHaber(MontoReferencia, CanonProfesional);
                Console.WriteLine($"Haber mensual: ${haber:F2}");
                Console.WriteLine("---------------------------");
            }
        }

        public void ListarEmpleadosOrdenados()
        {
            Console.WriteLine("\n--- Sueldos calculados ---");

            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            foreach (CEmpleado emp in empleados.OrderBy(emp => emp.Apellido))
            {
                Console.WriteLine($"Legajo: {emp.Legajo}, Nombre: {emp.Nombre}, Apellido: {emp.Apellido}");

                // Mostrar datos según tipo
                if (emp is CObrero obrero)
                {
                    obrero.LeerObrero();
                }
                else if (emp is CProfesional prof)
                {
                    prof.LeerProfesional();
                }

                // Calcular y mostrar el haber
                float haber = emp.CalcularHaber(MontoReferencia, CanonProfesional);
                Console.WriteLine($"Haber mensual: ${haber:F2}");
                Console.WriteLine("---------------------------");
            }
        }
    

        public void EstablecerVariablesSueldo()
        {
            Console.Write("\n\nIngrese el monto de referencia:");
            MontoReferencia = float.Parse(Console.ReadLine());

            Console.Write("\n\nIngrese el canon universal:");
            CanonProfesional = float.Parse(Console.ReadLine());

            Console.Write("\n\nVariables de sueldo establecidas!\n\n");

            Console.ReadKey();


            MostrarSueldos();

        }
        
        public void RegistrarEmpleado()
        {
            bool salir = false;
  
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== EMPLEADOS ===");
                Console.WriteLine("1. Obrero");
                Console.WriteLine("2. Profesional");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CRegistrarEmpleado.Obrero(empleados); //metodo static
                        break;
                    case "2":
                        CRegistrarEmpleado.Profesional(empleados);
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


        public void RegistrarObra()
        {
            
            Console.Write("Ingrese el codigo:");
            string cod = Console.ReadLine();

            Console.Write("\nIngrese la direccion:");
            string direccion = Console.ReadLine();

            Console.Write("\nIngrese el ID del Profesional a cargo:");
            uint? profesional = uint.Parse(Console.ReadLine());

            CObra obra = new CObra(cod,direccion,profesional);
            obras.Add(obra);

            Console.WriteLine("\n\nObra registrada correctamente!\n\n");
            Console.ReadKey();

            Console.Write("Quiere visualizar la base de datos de las obras?(true o false): \n\n");
            bool quiere = bool.Parse(Console.ReadLine());

            if (quiere)
            {
                obra.LeerObras(obras);
            }
        }


        public void AsignarProfesional()
        {
            Console.Write("Ingrese el ID del profesional: ");
            uint profesional = uint.Parse(Console.ReadLine());

            CProfesional existeProfesional = empleados.Find(c => c.Legajo == profesional) as CProfesional;

            Console.Write("Ingrese el ID de la obra: ");
            string obra = Console.ReadLine();

            CObra existeObra = obras.Find(c => c.Codigo == obra);

            if (existeProfesional == null || existeObra == null) 
            {
                Console.WriteLine("\nNo existe un profesional/obra con ese codigo.\n");
                Console.ReadKey();
                return;
            }
            else
            {
                existeProfesional.SetObra(obra);
                existeObra.SetProfesional(profesional);

                Console.WriteLine($"Legajo: {existeProfesional.Legajo}, Nombre: {existeProfesional.Nombre}, Apellido: {existeProfesional.Apellido}");
                existeProfesional.LeerProfesional();

                existeObra.LeerObrasPorCodigo(obras,obra);

                Console.ReadKey();
            } 
        }

        public void AginarObrero()
        {
            Console.Write("Ingrese el ID del obrero: ");
            uint obrero = uint.Parse(Console.ReadLine());

            CObrero existeObrero = empleados.Find(c => c.Legajo == obrero) as CObrero;

            Console.Write("Ingrese el ID de la obra: ");
            string obra = Console.ReadLine();

            CObra existeObra = obras.Find(c => c.Codigo == obra);

            if (existeObrero == null || existeObra == null)
            {
                Console.WriteLine("\nNo existe un obrero/obra con ese codigo.\n");
                Console.ReadKey();
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(existeObrero.Obra))
                {
                    Console.WriteLine("\nEste obrero ya está asignado a una obra.\n");
                    Console.ReadKey();
                    return;
                }


                existeObrero.SetObra(obra);

                Console.WriteLine($"Legajo: {existeObrero.Legajo}, Nombre: {existeObrero.Nombre}, Apellido: {existeObrero.Apellido}");
                existeObrero.LeerObrero();

                Console.ReadKey();

            }
        }

        public void DatosXObra()
        {
            Console.Write("Ingrese el código de obra: ");
            string obra = Console.ReadLine();

            CObra existe = obras.Find(o => o.Codigo == obra);

            if (existe == null)
            {
                Console.WriteLine("No existe ese código de obra.");
                Console.ReadKey();
                return;
            }

            List<CEmpleado> empleadosEnObra = empleados.Where(e => e.Obra == obra).ToList();


            if (empleadosEnObra == null)
            {
                Console.WriteLine("No hay empleados asignados a esa obra.");
                return;
            }

            foreach (CEmpleado empleado in empleadosEnObra)
            {
                Console.WriteLine($"Legajo: {empleado.Legajo}, Nombre: {empleado.Nombre}, Apellido: {empleado.Apellido}");

                if (empleado is CProfesional prof)
                {
                    prof.LeerProfesional();
                }
                else if (empleado is CObrero obrero)
                {
                    obrero.LeerObrero();
                }
            }
        }


        public void EliminarProfesional()
        {
            Console.Write("Ingrese el ID del profesional:");
            uint profesional = uint.Parse(Console.ReadLine());

            CProfesional existeProfesional = empleados.Find(c => c.Legajo == profesional) as CProfesional;

            if (existeProfesional == null)
            {
                Console.WriteLine("\nNo existe un obrero/obra con ese codigo.\n");
                Console.ReadKey();
                return;
            }
            else
            {
                if(!string.IsNullOrEmpty(existeProfesional.Obra))
                {
                    Console.WriteLine("\nEste profesional está supervisando una obra.\n");
                    Console.ReadKey();
                    return;
                }

                empleados.Remove(existeProfesional);
                Console.WriteLine("Profesional eliminado exitosamente");
                Console.ReadKey();
            }

        }
    }
}
