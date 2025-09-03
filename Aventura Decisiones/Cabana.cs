using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aventura_Decisiones
{
    public class Cabana : IInteractuable
    {
        public string Interactuar(Jugador jugador)
        {
            if (jugador.Puntos >= 2)
            {
                jugador.GanarPuntos(1);
                return "Encuentras una linterna y mapas útiles. (+1 punto)";
            }
            else
            {
                return "Está vacía y polvorienta; pierdes tiempo valioso.";
            }
        }
    }
}
