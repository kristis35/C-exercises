
namespace LB3
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spausidintiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baigtiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duNaujausiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sudarytiSąrašąToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rikiuotiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sąrašasBePasikartojimųToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.užduotisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurodymaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pabaigaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issaugotiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(11, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1203, 321);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Čia bus rodomi rezultatai";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem,
            this.pabaigaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1226, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvestiToolStripMenuItem,
            this.spausidintiToolStripMenuItem,
            this.baigtiToolStripMenuItem});
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // įvestiToolStripMenuItem
            // 
            this.įvestiToolStripMenuItem.Name = "įvestiToolStripMenuItem";
            this.įvestiToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.įvestiToolStripMenuItem.Text = "Įvesti";
            this.įvestiToolStripMenuItem.Click += new System.EventHandler(this.įvestiToolStripMenuItem_Click);
            // 
            // spausidintiToolStripMenuItem
            // 
            this.spausidintiToolStripMenuItem.Name = "spausidintiToolStripMenuItem";
            this.spausidintiToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.spausidintiToolStripMenuItem.Text = "Spausidinti";
            this.spausidintiToolStripMenuItem.Click += new System.EventHandler(this.spausidintiToolStripMenuItem_Click);
            // 
            // baigtiToolStripMenuItem
            // 
            this.baigtiToolStripMenuItem.Name = "baigtiToolStripMenuItem";
            this.baigtiToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.baigtiToolStripMenuItem.Text = "Baigti";
            this.baigtiToolStripMenuItem.Click += new System.EventHandler(this.baigtiToolStripMenuItem_Click);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duNaujausiToolStripMenuItem,
            this.sudarytiSąrašąToolStripMenuItem,
            this.rikiuotiToolStripMenuItem,
            this.sąrašasBePasikartojimųToolStripMenuItem});
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(105, 26);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            // 
            // duNaujausiToolStripMenuItem
            // 
            this.duNaujausiToolStripMenuItem.Name = "duNaujausiToolStripMenuItem";
            this.duNaujausiToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.duNaujausiToolStripMenuItem.Text = "Du naujausi";
            this.duNaujausiToolStripMenuItem.Click += new System.EventHandler(this.duNaujausiToolStripMenuItem_Click);
            // 
            // sudarytiSąrašąToolStripMenuItem
            // 
            this.sudarytiSąrašąToolStripMenuItem.Name = "sudarytiSąrašąToolStripMenuItem";
            this.sudarytiSąrašąToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.sudarytiSąrašąToolStripMenuItem.Text = "Sudaryti sąrašą";
            this.sudarytiSąrašąToolStripMenuItem.Click += new System.EventHandler(this.sudarytiSąrašąToolStripMenuItem_Click);
            // 
            // rikiuotiToolStripMenuItem
            // 
            this.rikiuotiToolStripMenuItem.Name = "rikiuotiToolStripMenuItem";
            this.rikiuotiToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.rikiuotiToolStripMenuItem.Text = "Rikiuoti";
            this.rikiuotiToolStripMenuItem.Click += new System.EventHandler(this.rikiuotiToolStripMenuItem_Click);
            // 
            // sąrašasBePasikartojimųToolStripMenuItem
            // 
            this.sąrašasBePasikartojimųToolStripMenuItem.Name = "sąrašasBePasikartojimųToolStripMenuItem";
            this.sąrašasBePasikartojimųToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.sąrašasBePasikartojimųToolStripMenuItem.Text = "Sąrašas be pasikartojimų";
            this.sąrašasBePasikartojimųToolStripMenuItem.Click += new System.EventHandler(this.sąrašasBePasikartojimųToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.užduotisToolStripMenuItem,
            this.nurodymaiToolStripMenuItem});
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(76, 26);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // užduotisToolStripMenuItem
            // 
            this.užduotisToolStripMenuItem.Name = "užduotisToolStripMenuItem";
            this.užduotisToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.užduotisToolStripMenuItem.Text = "Užduotis";
            this.užduotisToolStripMenuItem.Click += new System.EventHandler(this.užduotisToolStripMenuItem_Click);
            // 
            // nurodymaiToolStripMenuItem
            // 
            this.nurodymaiToolStripMenuItem.Name = "nurodymaiToolStripMenuItem";
            this.nurodymaiToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.nurodymaiToolStripMenuItem.Text = "Nurodymai";
            this.nurodymaiToolStripMenuItem.Click += new System.EventHandler(this.nurodymaiToolStripMenuItem_Click);
            // 
            // pabaigaToolStripMenuItem
            // 
            this.pabaigaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issaugotiToolStripMenuItem});
            this.pabaigaToolStripMenuItem.Name = "pabaigaToolStripMenuItem";
            this.pabaigaToolStripMenuItem.Size = new System.Drawing.Size(72, 26);
            this.pabaigaToolStripMenuItem.Text = "Pradžia";
            // 
            // issaugotiToolStripMenuItem
            // 
            this.issaugotiToolStripMenuItem.Name = "issaugotiToolStripMenuItem";
            this.issaugotiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.issaugotiToolStripMenuItem.Text = "Pradinis žingsnis";
            this.issaugotiToolStripMenuItem.Click += new System.EventHandler(this.issaugotiToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(18, 380);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 28);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Įveskite modelį";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Auto parkai";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spausidintiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baigtiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duNaujausiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sudarytiSąrašąToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rikiuotiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sąrašasBePasikartojimųToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem užduotisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nurodymaiToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem pabaigaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issaugotiToolStripMenuItem;
    }
}

