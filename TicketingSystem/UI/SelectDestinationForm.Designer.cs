namespace UI
{
    partial class SelectDestinationForm
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
            this.lblSelectDestination = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnBenThanh = new System.Windows.Forms.Button();
            this.btnOperaHouse = new System.Windows.Forms.Button();
            this.btnThuDuc = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelectDestination
            // 
            this.lblSelectDestination.AutoSize = true;
            this.lblSelectDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDestination.Location = new System.Drawing.Point(395, 98);
            this.lblSelectDestination.Name = "lblSelectDestination";
            this.lblSelectDestination.Size = new System.Drawing.Size(351, 37);
            this.lblSelectDestination.TabIndex = 0;
            this.lblSelectDestination.Text = "Select Your Destination";
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbLogo.Image = global::UI.Properties.Resources.Locomotive_Train_Transportation_Logo1;
            this.pbLogo.Location = new System.Drawing.Point(59, 98);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(273, 279);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // btnBenThanh
            // 
            this.btnBenThanh.Location = new System.Drawing.Point(457, 144);
            this.btnBenThanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBenThanh.Name = "btnBenThanh";
            this.btnBenThanh.Size = new System.Drawing.Size(213, 68);
            this.btnBenThanh.TabIndex = 5;
            this.btnBenThanh.Text = "Ben Thanh Station";
            this.btnBenThanh.UseVisualStyleBackColor = true;
            this.btnBenThanh.Click += new System.EventHandler(this.btnBenThanh_Click);
            // 
            // btnOperaHouse
            // 
            this.btnOperaHouse.Location = new System.Drawing.Point(457, 221);
            this.btnOperaHouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOperaHouse.Name = "btnOperaHouse";
            this.btnOperaHouse.Size = new System.Drawing.Size(213, 68);
            this.btnOperaHouse.TabIndex = 6;
            this.btnOperaHouse.Text = "Opera House";
            this.btnOperaHouse.UseVisualStyleBackColor = true;
            this.btnOperaHouse.Click += new System.EventHandler(this.btnOperaHouse_Click);
            // 
            // btnThuDuc
            // 
            this.btnThuDuc.Location = new System.Drawing.Point(457, 294);
            this.btnThuDuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThuDuc.Name = "btnThuDuc";
            this.btnThuDuc.Size = new System.Drawing.Size(213, 68);
            this.btnThuDuc.TabIndex = 7;
            this.btnThuDuc.Text = "Thu Duc";
            this.btnThuDuc.UseVisualStyleBackColor = true;
            this.btnThuDuc.Click += new System.EventHandler(this.btnThuDuc_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(661, 395);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 42);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SelectDestinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnThuDuc);
            this.Controls.Add(this.btnOperaHouse);
            this.Controls.Add(this.btnBenThanh);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblSelectDestination);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SelectDestinationForm";
            this.Text = "Select Destination";
            this.Load += new System.EventHandler(this.SelectDestinationFormEng_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectDestination;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnBenThanh;
        private System.Windows.Forms.Button btnOperaHouse;
        private System.Windows.Forms.Button btnThuDuc;
        private System.Windows.Forms.Button btnCancel;
    }
}