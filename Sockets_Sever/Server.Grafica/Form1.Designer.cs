
namespace Server.Grafica
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.graficoRendimiento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.Lb_estado = new System.Windows.Forms.Label();
            this.btnEncender = new System.Windows.Forms.Button();
            this.iniciarTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.graficoRendimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(306, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grafica de Rendimiento";
            // 
            // graficoRendimiento
            // 
            chartArea6.Name = "ChartArea1";
            this.graficoRendimiento.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.graficoRendimiento.Legends.Add(legend6);
            this.graficoRendimiento.Location = new System.Drawing.Point(30, 135);
            this.graficoRendimiento.Name = "graficoRendimiento";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "WIFI";
            this.graficoRendimiento.Series.Add(series6);
            this.graficoRendimiento.Size = new System.Drawing.Size(943, 274);
            this.graficoRendimiento.TabIndex = 1;
            this.graficoRendimiento.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(215, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estado:";
            // 
            // Lb_estado
            // 
            this.Lb_estado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lb_estado.AutoSize = true;
            this.Lb_estado.BackColor = System.Drawing.SystemColors.Control;
            this.Lb_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_estado.Location = new System.Drawing.Point(335, 73);
            this.Lb_estado.Name = "Lb_estado";
            this.Lb_estado.Size = new System.Drawing.Size(137, 29);
            this.Lb_estado.TabIndex = 3;
            this.Lb_estado.Text = "Sin estado";
            // 
            // btnEncender
            // 
            this.btnEncender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEncender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncender.Location = new System.Drawing.Point(391, 433);
            this.btnEncender.Name = "btnEncender";
            this.btnEncender.Size = new System.Drawing.Size(184, 41);
            this.btnEncender.TabIndex = 4;
            this.btnEncender.Text = "Recibir Data";
            this.btnEncender.UseVisualStyleBackColor = true;
            this.btnEncender.Click += new System.EventHandler(this.btnEncender_Click);
            // 
            // iniciarTimer
            // 
            this.iniciarTimer.Interval = 1000;
            this.iniciarTimer.Tick += new System.EventHandler(this.iniciarTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 530);
            this.Controls.Add(this.btnEncender);
            this.Controls.Add(this.Lb_estado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.graficoRendimiento);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Rendimiento ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graficoRendimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoRendimiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lb_estado;
        private System.Windows.Forms.Button btnEncender;
        private System.Windows.Forms.Timer iniciarTimer;
    }
}

