
namespace Lab_3
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.btnHien = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSNT = new System.Windows.Forms.Label();
            this.labelSCP = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSHH = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(80, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Số N: ";
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(214, 65);
            this.txtNhap.Multiline = true;
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(330, 30);
            this.txtNhap.TabIndex = 1;
            this.txtNhap.TextChanged += new System.EventHandler(this.txtNhap_TextChanged);
            this.txtNhap.Leave += new System.EventHandler(this.txtNhap_Leave);
            // 
            // btnHien
            // 
            this.btnHien.Location = new System.Drawing.Point(627, 55);
            this.btnHien.Name = "btnHien";
            this.btnHien.Size = new System.Drawing.Size(98, 52);
            this.btnHien.TabIndex = 2;
            this.btnHien.Text = "Hiển Thị";
            this.btnHien.UseVisualStyleBackColor = true;
            this.btnHien.Click += new System.EventHandler(this.btnHien_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(82, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Các số nguyên tố nhỏ hơn N : ";
            // 
            // labelSNT
            // 
            this.labelSNT.AutoSize = true;
            this.labelSNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSNT.Location = new System.Drawing.Point(364, 183);
            this.labelSNT.Name = "labelSNT";
            this.labelSNT.Size = new System.Drawing.Size(18, 25);
            this.labelSNT.TabIndex = 4;
            this.labelSNT.Text = ":";
            // 
            // labelSCP
            // 
            this.labelSCP.AutoSize = true;
            this.labelSCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSCP.Location = new System.Drawing.Point(401, 234);
            this.labelSCP.Name = "labelSCP";
            this.labelSCP.Size = new System.Drawing.Size(18, 25);
            this.labelSCP.TabIndex = 6;
            this.labelSCP.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(82, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Các số chính phương nhỏ hơn N : ";
            // 
            // labelSHH
            // 
            this.labelSHH.AutoSize = true;
            this.labelSHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSHH.Location = new System.Drawing.Point(375, 289);
            this.labelSHH.Name = "labelSHH";
            this.labelSHH.Size = new System.Drawing.Size(18, 25);
            this.labelSHH.TabIndex = 8;
            this.labelSHH.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(82, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(286, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Các số hoàn chỉnh nhỏ hơn N : ";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelSHH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelSCP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelSNT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHien);
            this.Controls.Add(this.txtNhap);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "chuong trinh nhap so";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNhap;
        private System.Windows.Forms.Button btnHien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSNT;
        private System.Windows.Forms.Label labelSCP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSHH;
        private System.Windows.Forms.Label label7;
    }
}