namespace Master
{
    partial class FormInput
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
            label1 = new Label();
            label2 = new Label();
            tbStartAddress = new TextBox();
            tbNumOfPoints = new TextBox();
            btnFormInputRead = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 0;
            label1.Text = "Start Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(156, 31);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 1;
            label2.Text = "Number of Points";
            // 
            // tbStartAddress
            // 
            tbStartAddress.Location = new Point(12, 54);
            tbStartAddress.Name = "tbStartAddress";
            tbStartAddress.Size = new Size(125, 27);
            tbStartAddress.TabIndex = 2;
            // 
            // tbNumOfPoints
            // 
            tbNumOfPoints.Location = new Point(156, 54);
            tbNumOfPoints.Name = "tbNumOfPoints";
            tbNumOfPoints.Size = new Size(125, 27);
            tbNumOfPoints.TabIndex = 3;
            // 
            // btnFormInputRead
            // 
            btnFormInputRead.Location = new Point(12, 98);
            btnFormInputRead.Name = "btnFormInputRead";
            btnFormInputRead.Size = new Size(272, 29);
            btnFormInputRead.TabIndex = 4;
            btnFormInputRead.Text = "Read";
            btnFormInputRead.UseVisualStyleBackColor = true;
            btnFormInputRead.Click += btnFormInputRead_Click;
            // 
            // FormInput
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(296, 139);
            Controls.Add(btnFormInputRead);
            Controls.Add(tbNumOfPoints);
            Controls.Add(tbStartAddress);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormInput";
            Text = "FormInput";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbStartAddress;
        private TextBox tbNumOfPoints;
        private Button btnFormInputRead;
    }
}