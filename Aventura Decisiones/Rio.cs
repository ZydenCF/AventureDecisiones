using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aventura_Decisiones
{
    public class Rio : IInteractuable
    {
        public string Interactuar(Jugador jugador)
        {
            if (jugador.Puntos >= 1)
            {
                jugador.GanarPuntos(1);
                return "Usas piedras resbalosas para cruzar sin nadar. (+1 punto)";
            }
            else
            {
                return "Intentas cruzar a nado y te cansas, pero logras salir del otro lado.";
            }
        }
    }
}
