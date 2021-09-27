namespace WindowsFormsTrolleybus
{
    partial class FormTrolleybus
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxTrolleybus = new System.Windows.Forms.PictureBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTrolleybus)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTrolleybus
            // 
            this.pictureBoxTrolleybus.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxTrolleybus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTrolleybus.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTrolleybus.Name = "pictureBoxTrolleybus";
            this.pictureBoxTrolleybus.Size = new System.Drawing.Size(882, 453);
            this.pictureBoxTrolleybus.TabIndex = 0;
            this.pictureBoxTrolleybus.TabStop = false;
            this.pictureBoxTrolleybus.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(12, 12);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(153, 30);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "Создать автобус";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreateBus_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.BackgroundImage = global::WindowsFormsTrolleybus.Properties.Resources.Up;
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUp.Location = new System.Drawing.Point(804, 375);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(30, 30);
            this.buttonUp.TabIndex = 2;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeft.BackgroundImage = global::WindowsFormsTrolleybus.Properties.Resources.Left;
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLeft.Location = new System.Drawing.Point(768, 411);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(30, 30);
            this.buttonLeft.TabIndex = 3;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.BackgroundImage = global::WindowsFormsTrolleybus.Properties.Resources.Down;
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDown.Location = new System.Drawing.Point(804, 411);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(30, 30);
            this.buttonDown.TabIndex = 4;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.BackgroundImage = global::WindowsFormsTrolleybus.Properties.Resources.Right;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRight.Location = new System.Drawing.Point(840, 411);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(30, 30);
            this.buttonRight.TabIndex = 5;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Создать троллейбус";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonCreateTrolleybus_Click);
            // 
            // FormTrolleybus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.pictureBoxTrolleybus);
            this.Name = "FormTrolleybus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trolleybus";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTrolleybus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTrolleybus;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button button1;
    }
}

