namespace WindowsFormsTrolleybus
{
    partial class FormBusStation
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
            this.buttonAddBus = new System.Windows.Forms.Button();
            this.pictureBoxParking = new System.Windows.Forms.PictureBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonTakeBus = new System.Windows.Forms.Button();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.labelPlace = new System.Windows.Forms.Label();
            this.labelBusStation = new System.Windows.Forms.Label();
            this.textBoxNewLevelName = new System.Windows.Forms.TextBox();
            this.buttonAddBusStation = new System.Windows.Forms.Button();
            this.listBoxBusStation = new System.Windows.Forms.ListBox();
            this.buttonDelBusStation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddBus
            // 
            this.buttonAddBus.Location = new System.Drawing.Point(1126, 289);
            this.buttonAddBus.Name = "buttonAddBus";
            this.buttonAddBus.Size = new System.Drawing.Size(157, 51);
            this.buttonAddBus.TabIndex = 1;
            this.buttonAddBus.Text = "Добавить машину";
            this.buttonAddBus.UseVisualStyleBackColor = true;
            this.buttonAddBus.Click += new System.EventHandler(this.buttonAddBus_Click);
            // 
            // pictureBoxParking
            // 
            this.pictureBoxParking.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxParking.Name = "pictureBoxParking";
            this.pictureBoxParking.Size = new System.Drawing.Size(1120, 518);
            this.pictureBoxParking.TabIndex = 0;
            this.pictureBoxParking.TabStop = false;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonTakeBus);
            this.groupBox.Controls.Add(this.maskedTextBox);
            this.groupBox.Controls.Add(this.labelPlace);
            this.groupBox.Location = new System.Drawing.Point(1135, 346);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(144, 100);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Забрать машину";
            // 
            // buttonTakeBus
            // 
            this.buttonTakeBus.Location = new System.Drawing.Point(32, 58);
            this.buttonTakeBus.Name = "buttonTakeBus";
            this.buttonTakeBus.Size = new System.Drawing.Size(84, 36);
            this.buttonTakeBus.TabIndex = 2;
            this.buttonTakeBus.Text = "Забрать";
            this.buttonTakeBus.UseVisualStyleBackColor = true;
            this.buttonTakeBus.Click += new System.EventHandler(this.buttonTakeBus_Click);
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Location = new System.Drawing.Point(75, 30);
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(56, 22);
            this.maskedTextBox.TabIndex = 1;
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(16, 33);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(53, 17);
            this.labelPlace.TabIndex = 0;
            this.labelPlace.Text = "Место:";
            // 
            // labelBusStation
            // 
            this.labelBusStation.AutoSize = true;
            this.labelBusStation.Location = new System.Drawing.Point(1155, 9);
            this.labelBusStation.Name = "labelBusStation";
            this.labelBusStation.Size = new System.Drawing.Size(98, 17);
            this.labelBusStation.TabIndex = 4;
            this.labelBusStation.Text = "Автовокзалы:";
            // 
            // textBoxNewLevelName
            // 
            this.textBoxNewLevelName.Location = new System.Drawing.Point(1126, 29);
            this.textBoxNewLevelName.Name = "textBoxNewLevelName";
            this.textBoxNewLevelName.Size = new System.Drawing.Size(157, 22);
            this.textBoxNewLevelName.TabIndex = 5;
            // 
            // buttonAddBusStation
            // 
            this.buttonAddBusStation.Location = new System.Drawing.Point(1126, 57);
            this.buttonAddBusStation.Name = "buttonAddBusStation";
            this.buttonAddBusStation.Size = new System.Drawing.Size(157, 45);
            this.buttonAddBusStation.TabIndex = 6;
            this.buttonAddBusStation.Text = "Добавить автовокзал";
            this.buttonAddBusStation.UseVisualStyleBackColor = true;
            this.buttonAddBusStation.Click += new System.EventHandler(this.buttonAddBusStation_Click);
            // 
            // listBoxBusStation
            // 
            this.listBoxBusStation.FormattingEnabled = true;
            this.listBoxBusStation.ItemHeight = 16;
            this.listBoxBusStation.Location = new System.Drawing.Point(1126, 108);
            this.listBoxBusStation.Name = "listBoxBusStation";
            this.listBoxBusStation.Size = new System.Drawing.Size(153, 100);
            this.listBoxBusStation.TabIndex = 7;
            this.listBoxBusStation.SelectedIndexChanged += new System.EventHandler(this.listBoxBusStation_SelectedIndexChanged);
            // 
            // buttonDelBusStation
            // 
            this.buttonDelBusStation.Location = new System.Drawing.Point(1126, 214);
            this.buttonDelBusStation.Name = "buttonDelBusStation";
            this.buttonDelBusStation.Size = new System.Drawing.Size(153, 30);
            this.buttonDelBusStation.TabIndex = 8;
            this.buttonDelBusStation.Text = "Удалить автовокзал";
            this.buttonDelBusStation.UseVisualStyleBackColor = true;
            this.buttonDelBusStation.Click += new System.EventHandler(this.buttonDelBusStation_Click);
            // 
            // FormBusStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 596);
            this.Controls.Add(this.buttonDelBusStation);
            this.Controls.Add(this.listBoxBusStation);
            this.Controls.Add(this.buttonAddBusStation);
            this.Controls.Add(this.textBoxNewLevelName);
            this.Controls.Add(this.labelBusStation);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.buttonAddBus);
            this.Controls.Add(this.pictureBoxParking);
            this.Name = "FormBusStation";
            this.Text = "Парковка";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxParking;
        private System.Windows.Forms.Button buttonAddBus;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonTakeBus;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.Label labelBusStation;
        private System.Windows.Forms.TextBox textBoxNewLevelName;
        private System.Windows.Forms.Button buttonAddBusStation;
        private System.Windows.Forms.ListBox listBoxBusStation;
        private System.Windows.Forms.Button buttonDelBusStation;
    }
}