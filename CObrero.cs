using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_REPARA
{
    public class CObrero : CEmpleado
    {
        private string categoria;
        public CObrero(uint legajo, string apellido, string nombre, string cat,string obra)
        : base(legajo, nombre,apellido,obra) 
        {
            this.categoria = cat;
        }

        public override float CalcularHaber(float montoRef, float canonProf)
        {
            float porcentaje = 1;
            if (categoria.ToLower() == "medio-oficial") porcentaje = 0.65f;
            else if (categoria.ToLower() == "aprendiz") porcentaje = 0.25f;

            return montoRef * porcentaje;
        }

        public void LeerObrero()
        {
           Console.WriteLine($"Categoría: {this.categoria}");
        }

        
    }
}
