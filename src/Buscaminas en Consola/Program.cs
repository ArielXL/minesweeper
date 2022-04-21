using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buscaminas_Logic;

namespace Buscaminas_en_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Game busc = new Game("Facil");
            busc.Imprimir_Board_Bool();
            string[] posicion = new string[2];

            while (true)
            {
                int TipoJugada = 1;
                Console.WriteLine("Elija una opcion:");
                Console.WriteLine("1.Jugar Click Izquierdo");
                Console.WriteLine("2.Jugar Click Derecho");
                Console.WriteLine("3.Jugar Ambos Clicks");
                switch (Console.ReadLine())
                { 
                    case "1":
                        TipoJugada = 1;
                        break;
                    case "2":
                        TipoJugada = 2;
                        break;
                    case "3":
                        TipoJugada = 3;
                        break;
                }
                posicion = Console.ReadLine().Split();
                int fila = int.Parse(posicion[0]);
                int col = int.Parse(posicion[1]);
                switch (TipoJugada)
                { 
                    case 1:
                        busc.Jugar(fila-1, col-1);
                        break;
                    case 2:
                        busc.Clic_Der(fila-1, col-1);
                        break;
                    case 3:
                        break;
                }
                
                Console.Clear();
                busc.Imprimir_Board_Bool();   
            }
        }
    }
}
