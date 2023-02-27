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
        // global variables
        string filePath;        
        List<string> aplicationsList = new List<string>();
        bool loadAplicationComboBox = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadLog()
        {
            int id = 0;

            dataGridView1.Rows.Clear();

            foreach (string line in File.ReadLines(filePath))
            {
                string[] lineSplited = line.Split(' ');
                DateTime logData;

                if (DateTime.TryParse(lineSplited[0], out logData))
                {
                    string aplicationSplited = lineSplited[4].Split('/')[1].ToUpper();

                    if (comboBox1.SelectedItem == null
                    || comboBox1.SelectedItem.ToString() == ""
                    || comboBox1.SelectedItem.ToString() == aplicationSplited)
                    {
                        float timeTakenLineSplited = float.Parse(lineSplited[14], CultureInfo.InvariantCulture.NumberFormat);

                        timeTakenLineSplited /= 1000;

                        if ((float)timeBox.Value <= timeTakenLineSplited)
                        {
                            id++;
                            bool aplicationRepeated = false;

                            foreach (string _aplication in aplicationsList)
                            {
                                if (aplicationSplited == _aplication)
                                {
                                    aplicationRepeated = true;
                                }
                            }

                            if (aplicationRepeated == false)
                            {
                                aplicationsList.Add(aplicationSplited);
                            }

                            string datetime = lineSplited[0] + " - " + lineSplited[1];
                            string code;

                            if (lineSplited[5].Contains("Cod="))
                            {
                                code = lineSplited[5];
                            }
                            else
                            {
                                code = "-";
                            }

                            dataGridView1.Rows.Add(id, datetime, lineSplited[2], lineSplited[8], lineSplited[6], lineSplited[3], lineSplited[4], code, timeTakenLineSplited);
                        }
                    }
                }
            }

            if (loadAplicationComboBox == true)
            {
                aplicationsList.Sort();
                comboBox1.Items.Clear();
                comboBox1.Items.Add("");

                foreach (string _aplication in aplicationsList)
                {
                    comboBox1.Items.Add(_aplication);
                }

                comboBox1.Enabled = true;
                comboBox1.Enabled = true;
                loadAplicationComboBox = false;
            }

            if (id > 0)
            {
                labelCount.Visible = true;
                labelCount.Text = "Total: " + id.ToString() + " logs";
            }
            else
            {
                MessageBox.Show("Nenhum log encontrado!");
            }
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
                    loadAplicationComboBox = true;

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
        
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            ReadLog();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox1.Text = "";
            comboBox1.Items.Clear();

            button_Refresh.Enabled = false;
            
            dataGridView1.Rows.Clear();
            
            labelCount.Visible = false;
            labelCount.Text = "";
            labelFilePath.Text = "";         
            
            timeBox.Value = 0;
            
            buttonReset.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadLog();
        }

    }
}