namespace Buscaminas_Visual
{
    partial class Board_Visual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board_Visual));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labeltime = new System.Windows.Forms.Label();
            this.labelCont = new System.Windows.Forms.Label();
            this.labelminas = new System.Windows.Forms.Label();
            this.pbxTablero = new System.Windows.Forms.PictureBox();
            this.nuevoJuegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoJuegoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reiniciarJuegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dificilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTablero)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoJuegoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(518, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labeltime
            // 
            this.labeltime.AutoSize = true;
            this.labeltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltime.Location = new System.Drawing.Point(450, 8);
            this.labeltime.Name = "labeltime";
            this.labeltime.Size = new System.Drawing.Size(63, 16);
            this.labeltime.TabIndex = 3;
            this.labeltime.Text = "Contador";
            // 
            // labelCont
            // 
            this.labelCont.AutoSize = true;
            this.labelCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCont.Location = new System.Drawing.Point(385, 8);
            this.labelCont.Name = "labelCont";
            this.labelCont.Size = new System.Drawing.Size(67, 17);
            this.labelCont.TabIndex = 4;
            this.labelCont.Text = "Tiempo : ";
            // 
            // labelminas
            // 
            this.labelminas.AutoSize = true;
            this.labelminas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelminas.Location = new System.Drawing.Point(193, 7);
            this.labelminas.Name = "labelminas";
            this.labelminas.Size = new System.Drawing.Size(45, 17);
            this.labelminas.TabIndex = 5;
            this.labelminas.Text = "Minas";
            // 
            // pbxTablero
            // 
            this.pbxTablero.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pbxTablero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxTablero.Image = ((System.Drawing.Image)(resources.GetObject("pbxTablero.Image")));
            this.pbxTablero.Location = new System.Drawing.Point(1, 28);
            this.pbxTablero.Name = "pbxTablero";
            this.pbxTablero.Size = new System.Drawing.Size(512, 485);
            this.pbxTablero.TabIndex = 1;
            this.pbxTablero.TabStop = false;
            this.pbxTablero.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxTablero_Paint_1);
            this.pbxTablero.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxTablero_MouseClick);
            // 
            // nuevoJuegoToolStripMenuItem
            // 
            this.nuevoJuegoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoJuegoToolStripMenuItem1,
            this.reiniciarJuegoToolStripMenuItem,
            this.toolStripSeparator1,
            this.opcionesToolStripMenuItem,
            this.toolStripSeparator2,
            this.salirToolStripMenuItem});
            this.nuevoJuegoToolStripMenuItem.Image = global::Buscaminas_Visual.Properties.Resources.home;
            this.nuevoJuegoToolStripMenuItem.Name = "nuevoJuegoToolStripMenuItem";
            this.nuevoJuegoToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.nuevoJuegoToolStripMenuItem.Text = "Juego";
            // 
            // nuevoJuegoToolStripMenuItem1
            // 
            this.nuevoJuegoToolStripMenuItem1.Image = global::Buscaminas_Visual.Properties.Resources.arrow_curve;
            this.nuevoJuegoToolStripMenuItem1.Name = "nuevoJuegoToolStripMenuItem1";
            this.nuevoJuegoToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.nuevoJuegoToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.nuevoJuegoToolStripMenuItem1.Text = "Nuevo juego";
            this.nuevoJuegoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoJuegoToolStripMenuItem1_Click);
            // 
            // reiniciarJuegoToolStripMenuItem
            // 
            this.reiniciarJuegoToolStripMenuItem.Image = global::Buscaminas_Visual.Properties.Resources.arrow_circle_315;
            this.reiniciarJuegoToolStripMenuItem.Name = "reiniciarJuegoToolStripMenuItem";
            this.reiniciarJuegoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.reiniciarJuegoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.reiniciarJuegoToolStripMenuItem.Text = "Reiniciar juego";
            this.reiniciarJuegoToolStripMenuItem.Click += new System.EventHandler(this.reiniciarJuegoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facilToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.dificilToolStripMenuItem});
            this.opcionesToolStripMenuItem.Image = global::Buscaminas_Visual.Properties.Resources.icon_diagram;
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // facilToolStripMenuItem
            // 
            this.facilToolStripMenuItem.Image = global::Buscaminas_Visual.Properties.Resources.control;
            this.facilToolStripMenuItem.Name = "facilToolStripMenuItem";
            this.facilToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.facilToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.facilToolStripMenuItem.Text = "Fácil";
            this.facilToolStripMenuItem.Click += new System.EventHandler(this.facilToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Image = global::Buscaminas_Visual.Properties.Resources.controlx2;
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // dificilToolStripMenuItem
            // 
            this.dificilToolStripMenuItem.Image = global::Buscaminas_Visual.Properties.Resources.control_skip;
            this.dificilToolStripMenuItem.Name = "dificilToolStripMenuItem";
            this.dificilToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.dificilToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.dificilToolStripMenuItem.Text = "Difícil";
            this.dificilToolStripMenuItem.Click += new System.EventHandler(this.dificilToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::Buscaminas_Visual.Properties.Resources.cross_circle;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click_1);
            // 
            // Board_Visual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(518, 518);
            this.Controls.Add(this.labelminas);
            this.Controls.Add(this.labelCont);
            this.Controls.Add(this.labeltime);
            this.Controls.Add(this.pbxTablero);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Board_Visual";
            this.Text = "Buscaminas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTablero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxTablero;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoJuegoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoJuegoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reiniciarJuegoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dificilToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labeltime;
        private System.Windows.Forms.Label labelCont;
        private System.Windows.Forms.Label labelminas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

