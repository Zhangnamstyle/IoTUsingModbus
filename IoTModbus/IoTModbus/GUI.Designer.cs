namespace IoTModbus
{
    partial class GUI
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSendOn = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.txtTransactions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(29, 34);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(157, 34);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(29, 83);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(124, 21);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send Off";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSendOn
            // 
            this.btnSendOn.Location = new System.Drawing.Point(174, 80);
            this.btnSendOn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendOn.Name = "btnSendOn";
            this.btnSendOn.Size = new System.Drawing.Size(117, 27);
            this.btnSendOn.TabIndex = 3;
            this.btnSendOn.Text = "Send On";
            this.btnSendOn.UseVisualStyleBackColor = true;
            this.btnSendOn.Click += new System.EventHandler(this.btnSendOn_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(29, 137);
            this.btnRead.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(112, 21);
            this.btnRead.TabIndex = 4;
            this.btnRead.Text = "Send Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // txtTransactions
            // 
            this.txtTransactions.Location = new System.Drawing.Point(29, 201);
            this.txtTransactions.Multiline = true;
            this.txtTransactions.Name = "txtTransactions";
            this.txtTransactions.Size = new System.Drawing.Size(344, 166);
            this.txtTransactions.TabIndex = 5;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 379);
            this.Controls.Add(this.txtTransactions);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnSendOn);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "GUI";
            this.Text = "Modbus Client For IoT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSendOn;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox txtTransactions;
    }
}

