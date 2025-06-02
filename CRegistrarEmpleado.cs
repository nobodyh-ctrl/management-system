using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_REPARA
{
    public static class CRegistrarEmpleado
    {
        public static void Obrero(List<CEmpleado> empleados)
        {
            Console.WriteLine("Ingrese el legajo: ");
            uint leg = uint.Parse(Console.ReadLine());

            // Buscar si ya existe un empleado con ese legajo
            CEmpleado existente = empleados.Find(c => c.Legajo == leg);

            if (existente != null)
            {
                Console.WriteLine("\nYa existe un empleado con ese legajo. No se puede repetir.\n");
                Console.ReadKey();
                return; // Salir del método
            }

            Console.WriteLine("\nIngrese el Nombre: ");
            string nom = Console.ReadLine();

            Console.WriteLine("\nIngrese el Apellido: ");
            string ape = Console.ReadLine();

            Console.WriteLine("\nIngrese la Categoria: ");
            string cat = Console.ReadLine();

            Console.WriteLine("\nIngrese la Obra en la que trabaja: ");
            string obra = Console.ReadLine();


            CObrero obrero = new CObrero(leg,ape,nom,cat,obra);

            empleados.Add(obrero);
        }


        public static void Profesional(List<CEmpleado> empleados) 
        {
            Console.WriteLine("Ingrese el legajo: ");
            uint leg = uint.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el Nombre: ");
            string nom = Console.ReadLine();

            Console.WriteLine("\nIngrese el Apellido: ");
            string ape = Console.ReadLine();

            Console.WriteLine("\nIngrese el Titulo: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("\nIngrese la Matricula: ");
            string matricula = Console.ReadLine();

            Console.WriteLine("\nIngrese el consejo: ");
            string consejo = Console.ReadLine();

            Console.WriteLine("\nIngrese el porcentaje: ");
            float porcentaje = float.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el codigo de la obra que supervisa: ");
            string obra = Console.ReadLine();


            CProfesional profesional = new CProfesional(leg,ape,nom,titulo,matricula,consejo,porcentaje,obra);

            empleados.Add(profesional);
        }
    }
}
