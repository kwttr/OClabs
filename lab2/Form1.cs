using System;
namespace lab2
{
    public partial class Form1 : Form
    {
        string SafeFileName;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonIncPath_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.PNG; *.JPEG)| *.BMP; *.JPG; *.PNG ; *.JPEG";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    SafeFileName = openFileDialog.SafeFileName;
                }
                textBox1.Text = filePath;
            }
        }

        private void buttonOutPath_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                filePath = fbd.SelectedPath;
            }
            textBox2.Text = filePath+'/'+SafeFileName;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Thread copyThread = new Thread(CopyFile);
            copyThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void IncreasingProgressBar(ProgressBar progressBar)
        {
            progressBar.Value = progressBar.Value + 1;
        }
        public void CopyFile()
        {
            FileStream fstream = File.OpenRead(textBox1.Text);
            byte[] arr = new byte[fstream.Length];
            fstream.Read(arr, 0, arr.Length);
            using (ProgressBar progressBar = new ProgressBar())
            {
                progressBar.Location = new Point(12, 164);
                progressBar.Width = 255;
                progressBar.Height = 23;
                progressBar.Maximum = arr.Length;
                for (int i = 0; i < arr.Length; i++)
                {
                    fstream.Read(arr, i, 1);
                    IncreasingProgressBar(progressBar);
                    Thread.Sleep(2);
                }
            }
            FileStream fWrite = File.OpenWrite(textBox2.Text);
            fWrite.Write(arr);
            fWrite.Close();
            fstream.Close();
        }
    }
}