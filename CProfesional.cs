using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_REPARA
{
    public class CProfesional : CEmpleado
    {
        private string titulo;
        private string matricula;
        private string consejoProfesional;
        private float PorcentajeAumento;

        
        
        public CProfesional(uint legajo, string apellido, string nombre, string titulo, string matricula, string consejo, float porcentaje, string obra)
        : base(legajo, apellido, nombre,obra)
        {
            this.matricula = matricula;
            this.titulo = titulo;
            this.consejoProfesional = consejo;
            this.PorcentajeAumento = porcentaje;
            
        }


        public override float CalcularHaber(float montoRef, float canonProf)
        {
            if (this.Obra != "")
            {
                float haber = montoRef * PorcentajeAumento;
                return haber;
            }

            return 0;
        }

        public void LeerProfesional()
        {
            Console.WriteLine($"Título: {this.titulo}, Matrícula: {this.matricula}, Consejo: {this.consejoProfesional}, Obra a cargo: {this.Obra}");
        }

        

    }
}
