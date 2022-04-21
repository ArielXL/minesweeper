using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas_Logic
{
    public class Game
    {
        private int[,] board;
        private Propiedad_Celda[,] board_juego;
        private int minas;
        private int minas_clone;
        private int[] dir_fila = { -1, 1, 0, 0, -1, 1, 1, -1};
        private int[] dir_col = { 0, 0, 1, -1, 1, 1, -1, -1};
        private Estado_Juego estado_act;
        private string dificultad;

        public enum Propiedad_Celda { Tapado, Descubierto, Bandera, Pregunta };
        public enum Estado_Juego {Ganado, Perdido, SeguirJuego }
        
        #region Propiedades
        public int[,] Board
        {
            get
            {
                return (int[,])board.Clone();
            }
        }
        public Propiedad_Celda[,] Board_Juego
        {
            get
            {
                return (Propiedad_Celda[,])board_juego.Clone();
            }
        }
        public string Dificultad
        {
            get
            {
                return (string)dificultad.Clone();
            }
        }
        public int Minas
        {
            get 
            {
                return minas;
            }
        }
        #endregion

        #region Metodos de la Clase
        public Game(string dificultad_juego)
        {
            if (dificultad_juego == "Facil")
            {
                minas = 10;
                minas_clone = minas;
                this.board = new int[9, 9];
                this.board_juego = new Propiedad_Celda[9, 9];
                dificultad = "Facil";
                Generar_Board(minas);
            }
            else if (dificultad_juego == "Normal")
            {
                minas = 40;
                minas_clone = minas;
                this.board = new int[16, 16];
                this.board_juego = new Propiedad_Celda[16, 16];
                dificultad = "Normal";
                Generar_Board(minas);
            }
            else if (dificultad_juego == "Dificil")
            {
                minas = 99;
                minas_clone = minas;
                this.board = new int[16, 30];
                this.board_juego = new Propiedad_Celda[16, 30];
                dificultad = "Dificil";
                Generar_Board(minas);
            }
        }
        public Estado_Juego Jugar(int fila, int columna)
        {
            if (board[fila, columna] == -1 )
            {
                Impr_Minas();
                estado_act= Estado_Juego.Perdido;
                return estado_act;
            }
            else 
            {
                BFS(fila, columna);
                if (Juego_Ganado())
                {
                    estado_act = Estado_Juego.Ganado;
                    return estado_act;
                }
                else
                {
                    estado_act = Estado_Juego.SeguirJuego;
                    return estado_act;
                }
            }
        }
        private bool Pertenece(int fila, int columna)
        {
            if (fila >= 0 && columna >= 0 && fila < board.GetLength(0) && columna < board.GetLength(1))
                return true;
            else
                return false;
        }
        private void Generar_Board(int minas)
        {
            while (minas > 0)
            {
                Random rand = new Random();
                int pos_fila = rand.Next(board.GetLength(0));
                int pos_columna = rand.Next(board.GetLength(1));
                if (board[pos_fila, pos_columna] == 0)
                {
                    board[pos_fila, pos_columna] = -1;
                    minas--;
                }
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == -1)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            int nueva_i = i + dir_fila[k];
                            int nueva_j = j + dir_col[k];
                            if (Pertenece(nueva_i, nueva_j) && board[nueva_i,nueva_j]!=-1)
                            {
                                board[nueva_i, nueva_j] += 1;
                            }
                        }
                    }
                }
            }

            //for (int i = 0 ; i < board_juego.GetLength(0);i++)
            //    for (int j = 0; j < board_juego.GetLength(1); j++)
            //    {
            //        board_juego[i, j] = Propiedad_Celda.Tapado;
            //    }
        }
        public void Imprimir_Board()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("{0}"+" ", board[i,j]);
                }
                Console.WriteLine();
            }
        }
        public void Imprimir_Board_Bool()
        {
            for (int i = 0; i < board_juego.GetLength(0); i++)
            {
                for (int j = 0; j < board_juego.GetLength(1); j++)
                {
                    switch (board_juego[i, j])
                    {
                        case Propiedad_Celda.Tapado:
                            Console.Write("- ");
                            break;
                        case Propiedad_Celda.Pregunta:
                            Console.Write("? ");
                            break;
                        case Propiedad_Celda.Descubierto:
                            Console.Write(board[i, j] + " ");

                            break;
                        case Propiedad_Celda.Bandera:
                            Console.Write("B ");
                            break;

                    }
                }
                Console.WriteLine();
            }
        }
        #endregion
         
        private void BFS(int fila, int columna)
        {
            bool[,] he_pasado = new bool[board.GetLength(0), board.GetLength(1)];
            Queue<Tuple<int, int>> cola = new Queue<Tuple<int, int>>();
            cola.Enqueue(new Tuple<int,int>(fila,columna));
            int nueva_i; int nueva_j;

            while (cola.Count > 0)
            {
                fila = cola.Peek().Item1;
                columna = cola.Peek().Item2;
                cola.Dequeue();
                if (board_juego[fila, columna] == Propiedad_Celda.Descubierto)
                {
                    continue;
                }
                Destapar(fila,columna);

                if(board[fila, columna] == 0)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        nueva_i = fila + dir_fila[k];
                        nueva_j = columna + dir_col[k];
                        if (Pertenece(nueva_i, nueva_j) && board_juego[nueva_i, nueva_j] == Propiedad_Celda.Tapado)
                        {
                            cola.Enqueue(new Tuple<int, int>(nueva_i, nueva_j));
                        }
                    }
                }
            }
        }

        private void Destapar(int fila, int columna)
        {
            board_juego[fila, columna] = Propiedad_Celda.Descubierto;
        }

        public void Clic_Izq(int fila, int col)
        {
            if (board_juego[fila, col] == Propiedad_Celda.Pregunta)
                Destapar(fila, col);
            if (board_juego[fila, col] == Propiedad_Celda.Tapado)
            {
                if (board[fila, col] == 0)
                {
                    BFS(fila, col);
                }
                else
                    Destapar(fila, col);
            }
        }

        public void Clic_Der(int fila, int col)
        {
            if (board_juego[fila, col] == Propiedad_Celda.Tapado)
            {
                board_juego[fila, col] = Propiedad_Celda.Bandera;
                minas--;
            }
            else if (board_juego[fila, col] == Propiedad_Celda.Bandera)
            {
                board_juego[fila, col] = Propiedad_Celda.Pregunta;
                minas++;
            }
            else if(board_juego[fila,col] == Propiedad_Celda.Pregunta)
            {
                board_juego[fila, col] = Propiedad_Celda.Tapado;
            }
        }

        public void Ambos_Clic(int fila, int col)
        {
            int cont = 0;
            if (board_juego[fila, col] == Propiedad_Celda.Descubierto)
            {
                for (int i = 0; i < 8; i++)
                {
                    int nueva_fila = fila + dir_fila[i];
                    int nueva_col = col + dir_col[i];
                    if (Pertenece(nueva_fila, nueva_col) && board_juego[nueva_fila, nueva_col] == Propiedad_Celda.Bandera)
                    {
                        cont++;
                    }
                }
                if (cont == board[fila, col])
                {
                    BFS(fila, col);
                }
            }
        }

        public bool Juego_Ganado()
        {
            for (int i = 0; i < board_juego.GetLength(0); i++)
            {
                for (int j = 0; j < board_juego.GetLength(1); j++)
                {
                    if (board[i, j] != -1 && board_juego[i, j] == Propiedad_Celda.Tapado)
                    {
                        return false; 
                    }
                }
            }
            return true;
        }

        public void Reiniciar_Juego()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board_juego[i, j] = Propiedad_Celda.Tapado; 
                }
            }
            minas = minas_clone;
        }

        private void Impr_Minas()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == -1)
                    {
                        Destapar(i, j);
                    }
                }   
            }
        }
    }
}
