namespace Master
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnReadDI = new Button();
            btnReadCoils = new Button();
            btnWriteSingleHR = new Button();
            btnWriteMultiCoils = new Button();
            btnWriteSingleCoils = new Button();
            btnReadMultiHR = new Button();
            btnReadIR = new Button();
            rtbResponse = new RichTextBox();
            SuspendLayout();
            // 
            // btnReadDI
            // 
            btnReadDI.Location = new Point(157, 12);
            btnReadDI.Name = "btnReadDI";
            btnReadDI.Size = new Size(139, 55);
            btnReadDI.TabIndex = 2;
            btnReadDI.Text = "Read Discrete Inputs";
            btnReadDI.UseVisualStyleBackColor = true;
            btnReadDI.Click += btnReadDI_Click;
            // 
            // btnReadCoils
            // 
            btnReadCoils.Location = new Point(12, 12);
            btnReadCoils.Name = "btnReadCoils";
            btnReadCoils.Size = new Size(139, 55);
            btnReadCoils.TabIndex = 3;
            btnReadCoils.Text = "Read Coils";
            btnReadCoils.UseVisualStyleBackColor = true;
            btnReadCoils.Click += btnReadCoils_Click;
            // 
            // btnWriteSingleHR
            // 
            btnWriteSingleHR.Location = new Point(649, 272);
            btnWriteSingleHR.Name = "btnWriteSingleHR";
            btnWriteSingleHR.Size = new Size(139, 55);
            btnWriteSingleHR.TabIndex = 4;
            btnWriteSingleHR.Text = "Write Single Holding Register";
            btnWriteSingleHR.UseVisualStyleBackColor = true;
            btnWriteSingleHR.Click += btnWriteSingleHR_Click;
            // 
            // btnWriteMultiCoils
            // 
            btnWriteMultiCoils.Location = new Point(649, 172);
            btnWriteMultiCoils.Name = "btnWriteMultiCoils";
            btnWriteMultiCoils.Size = new Size(139, 55);
            btnWriteMultiCoils.TabIndex = 5;
            btnWriteMultiCoils.Text = "Write Multi Coils";
            btnWriteMultiCoils.UseVisualStyleBackColor = true;
            btnWriteMultiCoils.Click += btnWriteMultiCoils_Click;
            // 
            // btnWriteSingleCoils
            // 
            btnWriteSingleCoils.Location = new Point(649, 73);
            btnWriteSingleCoils.Name = "btnWriteSingleCoils";
            btnWriteSingleCoils.Size = new Size(139, 55);
            btnWriteSingleCoils.TabIndex = 6;
            btnWriteSingleCoils.Text = "Write Single Coils";
            btnWriteSingleCoils.UseVisualStyleBackColor = true;
            btnWriteSingleCoils.Click += btnWriteSingleCoils_Click;
            // 
            // btnReadMultiHR
            // 
            btnReadMultiHR.Location = new Point(447, 12);
            btnReadMultiHR.Name = "btnReadMultiHR";
            btnReadMultiHR.Size = new Size(139, 55);
            btnReadMultiHR.TabIndex = 7;
            btnReadMultiHR.Text = "Read Multi Holding Registers";
            btnReadMultiHR.UseVisualStyleBackColor = true;
            btnReadMultiHR.Click += btnReadMultiHR_Click;
            // 
            // btnReadIR
            // 
            btnReadIR.Location = new Point(302, 12);
            btnReadIR.Name = "btnReadIR";
            btnReadIR.Size = new Size(139, 55);
            btnReadIR.TabIndex = 8;
            btnReadIR.Text = "Read Input Registers";
            btnReadIR.UseVisualStyleBackColor = true;
            btnReadIR.Click += btnReadIR_Click;
            // 
            // rtbResponse
            // 
            rtbResponse.Location = new Point(12, 73);
            rtbResponse.Name = "rtbResponse";
            rtbResponse.Size = new Size(576, 365);
            rtbResponse.TabIndex = 9;
            rtbResponse.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbResponse);
            Controls.Add(btnReadIR);
            Controls.Add(btnReadMultiHR);
            Controls.Add(btnWriteSingleCoils);
            Controls.Add(btnWriteMultiCoils);
            Controls.Add(btnWriteSingleHR);
            Controls.Add(btnReadCoils);
            Controls.Add(btnReadDI);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnReadDI;
        private Button btnReadCoils;
        private Button btnWriteSingleHR;
        private Button btnWriteMultiCoils;
        private Button btnWriteSingleCoils;
        private Button btnReadMultiHR;
        private Button btnReadIR;
        private RichTextBox rtbResponse;
    }
}