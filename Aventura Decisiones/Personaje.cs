using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aventura_Decisiones
{
    public abstract class Personaje
    {
        public string Nombre;


        public Personaje(string nombre)
        {
            this.Nombre = nombre;
        }

        public abstract string Hablar();
    }
}
