namespace lab2
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonCopyInThread = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonIncPath = new System.Windows.Forms.Button();
            this.buttonOutPath = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Исходный файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Файл-копия";
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(12, 99);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(122, 42);
            this.buttonCopy.TabIndex = 2;
            this.buttonCopy.Text = "Копировать";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonCopyInThread
            // 
            this.buttonCopyInThread.Location = new System.Drawing.Point(140, 99);
            this.buttonCopyInThread.Name = "buttonCopyInThread";
            this.buttonCopyInThread.Size = new System.Drawing.Size(127, 42);
            this.buttonCopyInThread.TabIndex = 3;
            this.buttonCopyInThread.Text = "Копировать в отдельном потоке";
            this.buttonCopyInThread.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(114, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 23);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(114, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(118, 23);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonIncPath
            // 
            this.buttonIncPath.Location = new System.Drawing.Point(240, 6);
            this.buttonIncPath.Name = "buttonIncPath";
            this.buttonIncPath.Size = new System.Drawing.Size(27, 23);
            this.buttonIncPath.TabIndex = 6;
            this.buttonIncPath.Text = "...";
            this.buttonIncPath.UseVisualStyleBackColor = true;
            this.buttonIncPath.Click += new System.EventHandler(this.buttonIncPath_Click);
            // 
            // buttonOutPath
            // 
            this.buttonOutPath.Location = new System.Drawing.Point(240, 52);
            this.buttonOutPath.Name = "buttonOutPath";
            this.buttonOutPath.Size = new System.Drawing.Size(27, 23);
            this.buttonOutPath.TabIndex = 7;
            this.buttonOutPath.Text = "...";
            this.buttonOutPath.UseVisualStyleBackColor = true;
            this.buttonOutPath.Click += new System.EventHandler(this.buttonOutPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 199);
            this.Controls.Add(this.buttonOutPath);
            this.Controls.Add(this.buttonIncPath);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCopyInThread);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Button buttonCopy;
        private Button buttonCopyInThread;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button buttonIncPath;
        private Button buttonOutPath;
        private System.Windows.Forms.Timer timer1;
    }
}