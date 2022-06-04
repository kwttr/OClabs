using System;
using System.ComponentModel;
using System.Threading;
namespace lab2
{
    public partial class Form1 : Form
    {
        delegate void ProgressBarHandler(int count);
        event ProgressBarHandler OnStep;
        string SafeFileName;
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += Worker_DoWork; 
            backgroundWorker1.ProgressChanged += Worker_ProgressChanged; 
            backgroundWorker1.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 100;
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            var arg = e.Argument as Tuple<string, string>;
            
            FileStream fRead = File.OpenRead(arg.Item1);
            byte[] arr = new byte[fRead.Length];
            fRead.Read(arr, 0, arr.Length);
            double steps = arr.Length / 100000;
            int percentFinishedcur = 0;
            int percentFinishedprev = percentFinishedcur;
            //background worker
            for (int i = 0; i < arr.Length; i++)
            {
                fRead.Read(arr, i, 1);
                    backgroundWorker1.ReportProgress(percentFinishedcur);
                    percentFinishedprev = percentFinishedcur;
                }
                if (i % steps == 0)
                {
                    Thread.Sleep(1);
                }
            }
            FileStream fWrite = File.OpenWrite(arg.Item2);
            fWrite.Write(arr);
            fWrite.Close();
            fRead.Close();
            progressBar.Value = 0;

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
            backgroundWorker1.RunWorkerAsync(Tuple.Create(textBox1.Text, textBox2.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void buttonCopyInThread_Click(object sender, EventArgs e) {
            backgroundWorker1.RunWorkerAsync(Tuple.Create(textBox1.Text,textBox2.Text));
        }
    }
}