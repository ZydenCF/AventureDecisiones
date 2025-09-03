using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aventura_Decisiones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a El Bosque Misterioso");
            Console.Write("Ingresa tu nombre: ");
            string nombre = Console.ReadLine();
            if (nombre == null || nombre.Trim().Length == 0)
            {
                nombre = "Aventurero";
            }


            GameEngine motor = new GameEngine();
            motor.Iniciar(nombre);


            int decisionActual = 1;
            while (!motor.EstaTerminado()) 
            {
                string prompt = motor.ObtenerPromptDecision(decisionActual);
                Console.WriteLine();
                Console.WriteLine(prompt);
                Console.Write("Elige opción (1/2): ");


                string entrada = Console.ReadLine();
                int opcion;
                bool ok = int.TryParse(entrada, out opcion);
                if (!ok || (opcion != 1 && opcion != 2))
                {
                    Console.WriteLine("Opción inválida. Intenta nuevamente.");
                    continue;
                }


                string resultado = motor.ProcesarDecision(decisionActual, opcion);
                Console.WriteLine(resultado);
                decisionActual = decisionActual + 1;
            }

            Console.WriteLine();
            Console.WriteLine(" FIN DE LA AVENTURA");

            List<string> resumen = motor.ObtenerResumen();
            for (int i = 0; i < resumen.Count; i++)
            {
                Console.WriteLine(resumen[i]);
            }

        }
    }
}
