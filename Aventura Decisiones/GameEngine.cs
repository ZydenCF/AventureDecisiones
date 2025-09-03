using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aventura_Decisiones
{
    public class GameEngine
    {
        private Jugador jugador;
        private Anciano anciano;


        private List<string> eventos;
        private int[] decisiones; 
        private int totalDecisiones;


        private Dictionary<string, string> finales;


        private bool terminado;
        private string claveFinal;


        public GameEngine()
        {
            this.eventos = new List<string>();
            this.decisiones = new int[5];
            this.totalDecisiones = 0;
            this.finales = new Dictionary<string, string>();
            this.finales.Add("bueno", "Logras salir del bosque guiado por luciérnagas y consejos sabios.");
            this.finales.Add("malo", "Te pierdes en un ciclo sin fin dentro del bosque embrujado.");
            this.terminado = false;
            this.claveFinal = "";
        }
        public void Iniciar(string nombreJugador)
        {
            this.jugador = new Jugador(nombreJugador, 0);
            this.anciano = new Anciano("Anciano");
            this.eventos.Add("El jugador despierta en un bosque misterioso.");
        }


        public string ObtenerPromptDecision(int numero)
        {
            switch (numero) 
            {
                case 1:
                    return "Decisión 1: Encuentras dos senderos.\n1) Camino iluminado por luciérnagas.\n2) Camino oscuro con ramas secas.";
                case 2:
                    return "Decisión 2: Escuchas un ruido entre los arbustos.\n1) Acercarte a investigar.\n2) Seguir sin mirar.";
                case 3:
                    return "Decisión 3: Llegas a un río caudaloso.\n1) Cruzar nadando.\n2) Buscar un puente.";
                case 4:
                    return "Decisión 4: Encuentras a un anciano misterioso.\n1) Pedirle ayuda.\n2) Ignorarlo.";
                case 5:
                    return "Decisión 5: Ves una cabaña abandonada.\n1) Entrar a buscar provisiones.\n2) Rodearla y seguir.";
                default:
                    return "Decisión no encontrada";
            }
        }

        public string ProcesarDecision(int numeroDecision, int opcion)
        {
            this.decisiones[numeroDecision - 1] = opcion;
            this.totalDecisiones = this.totalDecisiones + 1;


            string texto = "";


            switch (numeroDecision)
            {
                case 1:
                    if (opcion == 1) 
                    {
                        this.jugador.GanarPuntos(1);
                        this.eventos.Add("Tomas el sendero iluminado.");
                        texto = "Sigues las luciérnagas; el ambiente se siente seguro.";
                    }
                    else
                    {
                        this.eventos.Add("Tomas el camino oscuro.");
                        texto = "Avanzas entre ramas crujientes; sientes miradas a tu alrededor.";
                    }
                    break;


                case 2:
                    if (opcion == 1)
                    {
                        this.eventos.Add("Te acercas al ruido y encuentras un amuleto.");
                        this.jugador.GanarPuntos(1);
                        texto = "Hallaste un amuleto protector. (+1 punto)";
                    }
                    else
                    {
                        this.eventos.Add("Ignoras el ruido y avanzas con cautela.");
                        texto = "Decides no arriesgarte.";
                    }
                    break;
                case 3:
                    Rio rio = new Rio();
                    texto = rio.Interactuar(this.jugador);
                    this.eventos.Add("Encuentro con un río: " + texto);
                    break;


                case 4:
                    Personaje p = this.anciano; 
                    string mensaje = p.Hablar();
                    if (opcion == 1)
                    {
                        this.jugador.GanarPuntos(2);
                        this.eventos.Add("Pides ayuda al anciano: " + mensaje);
                        texto = "El anciano te señala constelaciones para guiarte. (+2 puntos)";
                    }
                    else
                    {
                        this.eventos.Add("Ignoras al anciano: " + mensaje);
                        texto = "Pasas de largo sin escuchar sus consejos.";
                    }
                    break;

                case 5:
                    Cabana cabana = new Cabana();
                    texto = cabana.Interactuar(this.jugador);
                    this.eventos.Add("Encuentro con la cabaña: " + texto);


                    this.terminado = true;
                    if (this.jugador.Puntos >= 3)
                    {
                        this.claveFinal = "bueno";
                    }
                    else
                    {
                        this.claveFinal = "malo";
                    }
                    break;
            }

            return texto;
        }

        public bool EstaTerminado()
        {
            return this.terminado;
        }


        public List<string> ObtenerResumen()
        {
            List<string> salida = new List<string>();
            salida.Add("Jugador: " + this.jugador.Nombre + " | Puntos: " + this.jugador.Puntos);
            salida.Add("Decisiones tomadas (1=opción1, 2=opción2):");


            for (int i = 0; i < this.decisiones.Length; i++) 
            {
                int n = i + 1;
                salida.Add(" Decisión " + n + ": " + this.decisiones[i]);
            }

            salida.Add("Eventos:");
            for (int j = 0; j < this.eventos.Count; j++)
            {
                salida.Add(" - " + this.eventos[j]);
            }


            string textoFinal;
            if (this.finales.TryGetValue(this.claveFinal, out textoFinal))
            {
                salida.Add("Final: " + textoFinal);
            }
            else
            {
                salida.Add("Indefinido");
            }


            return salida;
        }
    }
}


