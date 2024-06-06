namespace Master
{
    partial class FormSingleHRWrite
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            tbAddress = new TextBox();
            tbValue = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 77);
            button1.Name = "button1";
            button1.Size = new Size(294, 29);
            button1.TabIndex = 0;
            button1.Text = "Write";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 1;
            label1.Text = "Address";
            //label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 21);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 2;
            label2.Text = "Value";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(12, 44);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(125, 27);
            tbAddress.TabIndex = 3;
            // 
            // tbValue
            // 
            tbValue.Location = new Point(181, 44);
            tbValue.Name = "tbValue";
            tbValue.Size = new Size(125, 27);
            tbValue.TabIndex = 4;
            // 
            // FormSingleHRWrite
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 123);
            Controls.Add(tbValue);
            Controls.Add(tbAddress);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "FormSingleHRWrite";
            Text = "FormSingleHRWrite";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox tbAddress;
        private TextBox tbValue;
    }
}