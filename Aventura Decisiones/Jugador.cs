using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aventura_Decisiones
{
    public class Jugador : Personaje
    {
        public int Puntos;


        public Jugador(string nombre, int puntosIniciales) : base(nombre)
        {
            this.Puntos = puntosIniciales;
        }


        public void GanarPuntos(int cantidad)
        {
            this.Puntos = this.Puntos + cantidad;
        }


        public override string Hablar()
        {
            return "Hola " + this.Nombre + " debes ir al bosque.";
        }
    }
}
