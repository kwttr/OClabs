using System;
using System.ComponentModel;
using System.Threading;
namespace lab2
{
    public partial class MainForm : Form
    {
        string SafeFileName;
        public MainForm()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += Worker_DoWork; 
            backgroundWorker1.ProgressChanged += Worker_ProgressChanged; 
            backgroundWorker1.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 100;
            ConfirmForm form = new ConfirmForm(textBox2.Text);
            form.ShowDialog();
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
            //background worker
            for (int i = 0; i < arr.Length; i++)
            {
                fRead.Read(arr, i, 1);
                backgroundWorker1.ReportProgress((int)(1.0 * i / arr.Length * 100));
            }
            if (!File.Exists(arg.Item2))
            {
            FileStream fWrite = File.OpenWrite(arg.Item2);
            fWrite.Write(arr);
            fWrite.Close();
            fRead.Close();
            }
            else
            {
                fRead.Close();
            }
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
            textBox2.Text = filePath+'\\'+SafeFileName;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            CopyFile(textBox1.Text, textBox2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCopyInThread_Click(object sender, EventArgs e) {
            if(backgroundWorker1.IsBusy == false)
                backgroundWorker1.RunWorkerAsync(Tuple.Create(textBox1.Text,textBox2.Text));
            else
            {
                MessageBox.Show("Копирование уже запущено");
            }
        }

        private void CopyFile(string outp, string dest)
        {
            FileStream fRead = File.OpenRead(outp);
            byte[] arr = new byte[fRead.Length];
            fRead.Read(arr, 0, arr.Length);
            //background worker
            for (int i = 0; i < arr.Length; i++)
            {
                fRead.Read(arr, i, 1);
                progressBar.Value=((int)(1.0 * i / arr.Length * 100));
            }
            FileStream fWrite = File.OpenWrite(dest);
            fWrite.Write(arr);
            fWrite.Close();
            fRead.Close();
        }
    }
}