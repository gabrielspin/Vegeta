using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Globalization;


namespace Meus_testes
{
    public partial class Form1 : Form
    {
        string filePath;
        int id;
        DateTime logData;

        public Form1()
        {

            InitializeComponent();

        }

        private void ReadLog()
        {
            
            id = 0;
      

            foreach (string line in File.ReadLines(filePath))
            {
                string[] lineSplited = line.Split(' ');

                if (DateTime.TryParse(lineSplited[0], out logData))
                {
                    float timeTakenLineSplited = float.Parse(lineSplited[14], CultureInfo.InvariantCulture.NumberFormat);

                    timeTakenLineSplited /= 1000;

                    if ((float)timeBox.Value <= timeTakenLineSplited)
                    {
                        id++;
                                       
                            string datetime = lineSplited[0] + " - " + lineSplited[1];
                            dataGridView1.Rows.Add(id.ToString(),datetime,lineSplited[2],lineSplited[8],lineSplited[6], lineSplited[3], lineSplited[4], timeTakenLineSplited.ToString());

                            /*
                            richTextBox1.Text += "#" + count + "\n";
                            richTextBox1.Text += lineSplited[0] + " - " + lineSplited[1] + " (GWT)\n";
                            richTextBox1.Text += "server ip: " + lineSplited[2] + "\n";
                            richTextBox1.Text += "client ip: " + lineSplited[8] + "\n";
                            richTextBox1.Text += "port: " + lineSplited[6] + "\n";
                            richTextBox1.Text += lineSplited[3] + ": " + lineSplited[4] + "\n";
                            richTextBox1.Text += "time taken: " + timeTakenLineSplited + " seconds \n\n";
                            */
                        
                       
                    }
                }
            }

            if (id > 0)
            {
                labelCount.Visible = true;
                labelCount.Text = "Total: " + id.ToString() + " logs";
            }
            else MessageBox.Show("No log found!");
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAbrirArquivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"c:\";
                openFileDialog.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    labelFilePath.Visible = true;
                    labelFilePath.Text = openFileDialog.FileName;
                    filePath = openFileDialog.FileName;
                    buttonGo.Enabled = true;
                }
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
     
        }

        private void labelCount_Click(object sender, EventArgs e)
        {

        }

        private void labelTitleDoc_Click(object sender, EventArgs e)
        {

        }

        private void timeBox_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void labelTime_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonOrderByDate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonGo_Click(object sender, EventArgs e)
        {            
                if (timeBox.Value > 0) ReadLog();
                else if (MessageBox.Show("A time set 0 will show all logs. Continue?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK) ReadLog();           
        }
    }
}