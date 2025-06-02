using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_REPARA
{
    public abstract class CEmpleado : ICalculaHaber, IAsignableAObra
    {
        protected uint legajo;
        protected string nombre;
        protected string apellido;
        protected string obra;


        public CEmpleado(uint legajo, string nombre, string apellido,string obra)
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.obra = obra;
        }

        public uint Legajo
        {
            get
            { 
                return legajo;
            }
        }

        public string Nombre
        {
            get 
            { 
                return nombre; 
            }
        }

        public string Obra
        {
            get
            {
                return this.obra;
            }
        }

        public string Apellido
        {
            get 
            { 
                return apellido; 
            }
        }

        public abstract float CalcularHaber(float montoRef, float canonProf);
        public void SetObra(string obra)
        { 
            this.obra = obra; 
        }
       

    }
}
