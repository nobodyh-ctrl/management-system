using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_REPARA
{
    public class CObra
    {
        private Random id = new Random();
        private string codigo;
        private string direccion;
        private uint? profesional;


        public CObra(string cod, string dire, uint? prof)
        {
            this.codigo = cod;
            this.direccion = dire;
            this.profesional = prof;
        }

        public string Codigo
        {
            get 
            {
                return this.codigo;
            }
        }

        public string Direccion
        {
            get
            {
                return this.direccion;
            }
        }

        public uint? Profesional
        {
            get
            {
                return this.profesional;
            }
        }

        public void LeerObrasPorCodigo(List<CObra> obras, string obra)
        {
            if (obras.Count == 0)
            {
                Console.WriteLine("No hay obras registrados.");
                return;
            }

            CObra existeObra = obras.Find(c => c.Codigo == obra);

            if (existeObra != null)
            {
                Console.WriteLine($"Codigo: {obra}, Direccion: {existeObra.Direccion}, Responsable a cargo: {existeObra.Profesional}");
            }
            
        }
        public void LeerObras(List<CObra> obras)
        {
            if (obras.Count == 0)
            {
                Console.WriteLine("No hay obras registrados.");
                return;
            }
;

            foreach(CObra obra in obras)   
            {
                Console.WriteLine($"Codigo: {obra.Codigo}, Direccion: {obra.Direccion}, Responsable a cargo: {obra.Profesional}");
            }

        }


        public void SetProfesional(uint profesional)
        {
            this.profesional = profesional;
        }


    }
}
