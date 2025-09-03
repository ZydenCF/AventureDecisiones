using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aventura_Decisiones
{
    public class Anciano : Personaje
    {
        public string Mensaje;
        public Anciano(string nombre) : base(nombre)
        {
            this.Mensaje = "La naturaleza siempre responde a quien escucha.";
        }

        public override string Hablar()
        {
            return this.Nombre + this.Mensaje;
        }
    }
}
