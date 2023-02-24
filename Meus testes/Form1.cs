using System;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Collections.Generic;


namespace Meus_testes
{
    public partial class Form1 : Form
    {
        string filePath;
        string code;
        int id;
        DateTime logData;
        List<string> aplications = new List<string>();

        public Form1()
        {

            InitializeComponent();

        }

        private void ReadLog()
        {

            

            dataGridView1.Rows.Clear();
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
                        aplications.Add(lineSplited[4].Split('/')[1]);

                        id++;

                        string datetime = lineSplited[0] + " - " + lineSplited[1];

                        if (lineSplited[5].Contains("Cod="))
                        {
                            code = lineSplited[5];
                        }
                        else code = "-";

                        dataGridView1.Rows.Add(id, datetime, lineSplited[2], lineSplited[8], lineSplited[6], lineSplited[3], lineSplited[4], code, timeTakenLineSplited);

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
            else MessageBox.Show("Nenhum log encontrado!");
            
        }
        private void Form1_Load(object sender, EventArgs e)
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
                    labelFilePath.Text = "carregando...";
                    filePath = openFileDialog.FileName;

                    if (timeBox.Value > 0)
                    {
                        ReadLog();
                    }
                    else if (MessageBox.Show("Tempo '0' irá filtrar todos os logs. Continuar?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        ReadLog();
                    }

                    labelFilePath.Text = openFileDialog.FileName;
                    button_Refresh.Enabled = true;
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

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            ReadLog();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            button_Refresh.Enabled = false;
            dataGridView1.Rows.Clear();
            labelCount.Visible = false;
            labelCount.Text = "";
            labelFilePath.Text = "";         
            timeBox.Value = 0;
            id = 0;
        }
    }
}