using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buscaminas_Logic;
using Buscaminas_en_Consola;
using System.Diagnostics;

namespace Buscaminas_Visual
{
    public partial class Board_Visual : Form
    {
        private Game juego;
        private int dimen_fila;
        private int dimen_col;
        private string dificultad = "Facil";
        Stopwatch crono;
       
        public Board_Visual()
        {
            InitializeComponent();
            juego = new Game(dificultad);
            dimen_fila = juego.Board.GetLength(0);
            dimen_col = juego.Board.GetLength(1);
            crono = new Stopwatch();
            dificultad = juego.Dificultad;
            labeltime.Text = "0";
            labelminas.Text = "Minas: " + juego.Minas;
        }

        private void pbxTablero_Paint_1(object sender, PaintEventArgs e)
        {
            System.Drawing.Bitmap casilla = new Bitmap(@"Figuritas\celda_vacia.bmp",true);
            System.Drawing.Bitmap pregunta = new Bitmap(@"Figuritas\signo.bmp", true);
            System.Drawing.Bitmap bandera = new Bitmap(@"Figuritas\fig_bandera.bmp", true);
            System.Drawing.Bitmap mina = new Bitmap(@"Figuritas\bombabmp.bmp",true);
            int[,] matriz = juego.Board;
            Game.Propiedad_Celda[,] marc = juego.Board_Juego;
            Graphics g = e.Graphics;
            SolidBrush b = new SolidBrush(Color.White);
            g.FillRectangle(b, e.ClipRectangle);
            Pen p = new Pen(Color.Black);
            int width = pbxTablero.Width / dimen_col;
            int altura = pbxTablero.Height / dimen_fila;
            pbxTablero.Width = width * dimen_col;
            pbxTablero.Height = altura * dimen_fila;
            for (int i = 0; i < dimen_fila; i++)
                for (int j = 0; j < dimen_col; j++)
                {
                    PointF punto = new PointF(j * width, i * altura);
                    var tamaño = new SizeF(width, altura);
                    var rectangulo = new RectangleF(punto, tamaño);
                    switch (juego.Board_Juego[i, j])
                    {
                        case Game.Propiedad_Celda.Tapado:
                           
                            g.DrawImage(casilla, rectangulo);
                            break;
                        case Game.Propiedad_Celda.Descubierto:
                           
                            if (juego.Board[i,j]==0)
                            g.FillRectangle(b, rectangulo);
                            else if(juego.Board[i,j] == -1)                         
                            {
                                g.DrawImage(mina, rectangulo);
                            }
                            else
                            {
                                var format = new StringFormat();
                                format.Alignment=StringAlignment.Center;
                                format.LineAlignment = StringAlignment.Center;
                                var bn = new SolidBrush(Color.Black);
                                var font  = new Font (Font.FontFamily, Math.Min(width/2,altura/2));
                                g.DrawString(juego.Board[i,j].ToString(),font,bn,rectangulo,format);
                            }
                            break;
                        case Game.Propiedad_Celda.Bandera:
                            g.DrawImage(bandera, rectangulo);
                            break;
                        case Game.Propiedad_Celda.Pregunta:
                            g.DrawImage(pregunta, rectangulo);
                            break;
                    }
                }
            for (int i = 0; i <= dimen_fila; i++)
            {
                g.DrawLine(p, 0, i * altura - 1, pbxTablero.Width, i * altura - 1);
            }
            for (int i = 0; i <= dimen_col; i++)
            {
                g.DrawLine(p, i * width - 1, 0, i * width - 1, pbxTablero.Height);
            }
        }

        private void pbxTablero_MouseClick(object sender, MouseEventArgs e)
        {
            int i = e.Y / (pbxTablero.Height / dimen_fila);
            int j = e.X / (pbxTablero.Width / dimen_col);
            crono.Start();

            switch (e.Button)
            { 
                case MouseButtons.Left:
                    if (juego.Board_Juego[i, j] != Game.Propiedad_Celda.Bandera)
                    {
                        juego.Clic_Izq(i, j);
                        if (juego.Jugar(i, j) == Game.Estado_Juego.Ganado)
                        {
                            crono.Stop();
                            pbxTablero.Refresh();
                            if (MessageBox.Show("Juego terminado, haz ganado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                pbxTablero.Enabled = false;
                                pbxTablero.Invalidate();

                            }
                        }
                        if (juego.Jugar(i, j) == Game.Estado_Juego.Perdido)
                        {
                            crono.Stop();
                            pbxTablero.Refresh();
                            if (MessageBox.Show("Juego terminado, haz perdido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                            {
                                pbxTablero.Invalidate();
                                pbxTablero.Enabled = false;
                                dimen_fila = juego.Board.GetLength(0);
                                dimen_col = juego.Board.GetLength(1);
                            }
                        }
                    }
                    pbxTablero.Refresh();
                    break;
                case MouseButtons.Right:
                    juego.Clic_Der(i, j);
                    labelminas.Text = "Minas: " + juego.Minas;
                    pbxTablero.Refresh();
                    break;
            }
        }

        private void nuevoJuegoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quieres empezar un nuevo juego?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                juego = new Game(dificultad);
                crono.Restart();
                crono.Stop();
                labelminas.Text = "Minas: " + juego.Minas;
                pbxTablero.Invalidate();
                pbxTablero.Enabled = true;
                dimen_fila = juego.Board.GetLength(0);
                dimen_col = juego.Board.GetLength(1);
            }
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quieres salir del juego?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Close();
        }

        private void reiniciarJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quieres reiniciar este juego?", "Confimación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                juego.Reiniciar_Juego();
                crono.Restart();
                crono.Stop();
                labelminas.Text = "Minas: " + juego.Minas;
                pbxTablero.Enabled = true;
                pbxTablero.Invalidate();
            }
        }

        private void facilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            juego = new Game("Facil");
            dificultad = "Facil";
            dimen_fila = juego.Board.GetLength(0);
            dimen_col = juego.Board.GetLength(1);
            pbxTablero.Invalidate();
            pbxTablero.Enabled = true;
            pbxTablero.Height = 458;
            pbxTablero.Width = 512;
            labelminas.Location = new Point(231, 7);
            labelCont.Location = new Point(387, 7);
            labeltime.Location = new Point(462, 7);            
            crono.Restart();
            crono.Stop();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            juego = new Game("Normal");
            dificultad = "Normal";
            dimen_fila = juego.Board.GetLength(0);
            dimen_col = juego.Board.GetLength(1);
            pbxTablero.Invalidate();
            pbxTablero.Enabled = true;
            pbxTablero.Height = 512;
            pbxTablero.Width = 600;
            labelminas.Location = new Point(275, 7);
            labelCont.Location = new Point(475, 7);
            labeltime.Location = new Point(550, 7);
            crono.Restart();
            crono.Stop();
        }

        private void dificilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            juego = new Game("Dificil");
            dificultad = "Dificil";
            dimen_fila = juego.Board.GetLength(0);
            dimen_col = juego.Board.GetLength(1);
            pbxTablero.Invalidate();
            pbxTablero.Enabled = true;
            pbxTablero.Height = 600;
            pbxTablero.Width = 1250;
            labelminas.Location = new Point(600, 7);
            labelCont.Location = new Point(1125, 7);
            labeltime.Location = new Point(1200, 7);
            crono.Restart();
            crono.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            long tiempo = crono.ElapsedMilliseconds / 1000;
            labeltime.Text = tiempo.ToString();
        }
        
    }
}
