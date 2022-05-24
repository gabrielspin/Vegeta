using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;

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
        List<string> a = new List<string>();
        //string[] a;
        IDictionary<int, List<string>> dictLog = new Dictionary<int, List<string>>();
        //IDictionary<int, Tuple<string, string, string, string, string, string, string, float>> dictLog = new Dictionary<int, Tuple<string, string, string, string, string, string, string, float>>();

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

                        if (radioButtonOrderByDate.Checked == true)
                        {
                            richTextBox1.Text += "#" + count + "\n";
                            richTextBox1.Text += lineSplited[0] + " - " + lineSplited[1] + " (GWT)\n";
                            richTextBox1.Text += "server ip: " + lineSplited[2] + "\n";
                            richTextBox1.Text += "client ip: " + lineSplited[8] + "\n";
                            richTextBox1.Text += "port: " + lineSplited[6] + "\n";
                            richTextBox1.Text += lineSplited[3] + ": " + lineSplited[4] + "\n";
                            richTextBox1.Text += "time taken: " + timeTakenLineSplited + " seconds \n\n";
                        }
                        else if (radioButtonOrderByTimeTaken.Checked == true)
                        {
                            a.Clear();
                            a.Add(lineSplited[0]);
                            a.Add(lineSplited[1]);
                            a.Add(lineSplited[2]);
                            a.Add(lineSplited[8]);
                            a.Add(lineSplited[6]);
                            a.Add(lineSplited[3]);
                            a.Add(lineSplited[4]);
                            a.Add(lineSplited[14]);

                            dictLog.Add(count, a);

                            //dictLog.Add(count, new Tuple<string, string, string, string, string, string, string, float>(lineSplited[0], lineSplited[1], lineSplited[2], lineSplited[8], lineSplited[6], lineSplited[3], lineSplited[4], timeTakenLineSplited));
                        }
                    }
                }
            }

            if (count > 0)
            {
                if (radioButtonOrderByTimeTaken.Checked == true)
                {
                    var sortedDict = from entry in dictLog orderby entry.Value ascending select entry;
                    foreach (var value in sortedDict) richTextBox1.Text += value + "\n";
                
                }

                labelCount.Visible = true;
                labelCount.Text = "Total: " + count.ToString() + " logs";
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