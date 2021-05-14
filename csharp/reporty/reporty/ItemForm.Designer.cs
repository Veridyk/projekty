namespace reporty
{
    partial class ItemForm
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
            this.polozka = new System.Windows.Forms.TextBox();
            this.popis = new System.Windows.Forms.TextBox();
            this.popis2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.vymera = new System.Windows.Forms.TextBox();
            this.mj = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cena = new System.Windows.Forms.TextBox();
            this.celkem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // polozka
            // 
            this.polozka.Location = new System.Drawing.Point(106, 33);
            this.polozka.Name = "polozka";
            this.polozka.Size = new System.Drawing.Size(321, 20);
            this.polozka.TabIndex = 0;
            // 
            // popis
            // 
            this.popis.Location = new System.Drawing.Point(106, 59);
            this.popis.Name = "popis";
            this.popis.Size = new System.Drawing.Size(321, 20);
            this.popis.TabIndex = 1;
            // 
            // popis2
            // 
            this.popis2.Location = new System.Drawing.Point(106, 85);
            this.popis2.Name = "popis2";
            this.popis2.Size = new System.Drawing.Size(321, 20);
            this.popis2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Položka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Popis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Popis 2";
            // 
            // vymera
            // 
            this.vymera.Location = new System.Drawing.Point(106, 111);
            this.vymera.Name = "vymera";
            this.vymera.Size = new System.Drawing.Size(142, 20);
            this.vymera.TabIndex = 6;
            // 
            // mj
            // 
            this.mj.Location = new System.Drawing.Point(106, 137);
            this.mj.Name = "mj";
            this.mj.Size = new System.Drawing.Size(72, 20);
            this.mj.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Výměra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "MJ";
            // 
            // cena
            // 
            this.cena.Location = new System.Drawing.Point(106, 163);
            this.cena.Name = "cena";
            this.cena.Size = new System.Drawing.Size(142, 20);
            this.cena.TabIndex = 10;
            // 
            // celkem
            // 
            this.celkem.Location = new System.Drawing.Point(106, 189);
            this.celkem.Name = "celkem";
            this.celkem.Size = new System.Drawing.Size(142, 20);
            this.celkem.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cena";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cena celkem";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.celkem);
            this.groupBox1.Controls.Add(this.cena);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.mj);
            this.groupBox1.Controls.Add(this.vymera);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.popis2);
            this.groupBox1.Controls.Add(this.popis);
            this.groupBox1.Controls.Add(this.polozka);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 241);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail položky";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(112, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(285, 31);
            this.label8.TabIndex = 15;
            this.label8.Text = "Detail položky nabídky";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 43);
            this.button1.TabIndex = 16;
            this.button1.Text = "Uložit změny";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 345);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Name = "ItemForm";
            this.Text = "Detail položky";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox polozka;
        private System.Windows.Forms.TextBox popis;
        private System.Windows.Forms.TextBox popis2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox vymera;
        private System.Windows.Forms.TextBox mj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cena;
        private System.Windows.Forms.TextBox celkem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}