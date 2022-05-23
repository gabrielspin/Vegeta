using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;


namespace Meus_testes
{

    public partial class Form1 : Form
    {
        string filePath;
        int count;
        DateTime logData;

        public Form1()
        {

            InitializeComponent();

        }

        private void ReadLog()
        {
            
            count = 0;
            richTextBox1.Text = "";

            foreach (string line in File.ReadLines(filePath))
            {
                string[] lineSplited = line.Split(' ');

                if (DateTime.TryParse(lineSplited[0], out logData))
                {
                    float timeTakenLineSplited = float.Parse(lineSplited[14], CultureInfo.InvariantCulture.NumberFormat);

                    timeTakenLineSplited /= 1000;

                    if ((float)timeBox.Value <= timeTakenLineSplited)
                    {
                        
                        
                        count++;

                        richTextBox1.Text += "#" + count + "\n";
                        richTextBox1.Text += lineSplited[0] + " - " + lineSplited[1] + " (GWT)\n";
                        richTextBox1.Text += "server ip: " + lineSplited[2] + "\n";
                        richTextBox1.Text += "client ip: " + lineSplited[8] + "\n";
                        richTextBox1.Text += "port: " + lineSplited[6] + "\n";
                        richTextBox1.Text += lineSplited[3] + ": " + lineSplited[4] + "\n";
                        richTextBox1.Text += "time taken: " + timeTakenLineSplited + " seconds \n\n";
                    }
                }
            }

            labelCount.Visible = true;
            labelCount.Text = "Total: " + count.ToString() + " logs";

            if (count == 0) MessageBox.Show("No log found!");
            
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
                    richTextBox1.Text = "";
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

/*
 * 
 * using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;


namespace Meus_testes
{

    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }

        private void ReadLog()
        {                    
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"c:\";
                openFileDialog.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = "";              
                    labelFilePath.Visible = true;
                    labelFilePath.Text = openFileDialog.FileName;
 
                    var readedLines = File.ReadAllLines(openFileDialog.FileName);

                    int count = 0;

                    foreach (var line in readedLines)
                    {   
                        string[] lineSplited = line.Split(' ');   
                        DateTime logData;

                        if (DateTime.TryParse(lineSplited[0], out logData))
                        {
                            float timeTakenLineSplited = float.Parse(lineSplited[14], CultureInfo.InvariantCulture.NumberFormat);
                            
                            timeTakenLineSplited /= 1000;
                     
                            if((float)timeBox.Value <= timeTakenLineSplited)
                            {
                                count++;

                                richTextBox1.Text += "#" + count + "\n";
                                richTextBox1.Text += lineSplited[0] + " - " + lineSplited[1] + " (GWT)\n";
                                richTextBox1.Text += "server ip: " + lineSplited[2] + "\n";
                                richTextBox1.Text += "client ip: " + lineSplited[8] + "\n";
                                richTextBox1.Text += "port: " + lineSplited[6] + "\n";
                                richTextBox1.Text += lineSplited[3] + ": " + lineSplited[4] + "\n";
                                richTextBox1.Text += "time taken: " + timeTakenLineSplited + " seconds \n\n";
                            }                       
                        }
                    }

                    labelCount.Visible = true;
                    labelCount.Text = "Total: " + count.ToString() + " logs";

                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAbrirArquivo_Click(object sender, EventArgs e)
        {
            if (timeBox.Value != 0) ReadLog();
            else {
                if (MessageBox.Show("A time set 0 will show all logs. Continue?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK) ReadLog();
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
    }
}

 * 
 * 
 */