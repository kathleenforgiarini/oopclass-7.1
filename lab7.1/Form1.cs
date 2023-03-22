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

// CODED BY KATHLEEN FORGIARINI DA SILVA
// 2023-03-21
// LAB 7.1 - WORKING WITH TEXT FILES

namespace lab7._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string path = @".\files\Names.txt";
        private void write_Click(object sender, EventArgs e)
        {
            string dir = @".\files\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fileStream);

                writer.Write(fName.Text + ";" + lName.Text + ";" + DateTime.Now.ToString() + "\n");

                writer.Close();
                fileStream.Close();

                MessageBox.Show("Data was written to the file successfully.");
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured, try again. \n" + ex.Message);
            }
        }


        private void read_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fileStream);

                string textToPrint = "";
                int counter = 0;
                while (reader.Peek() != -1)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(';');
                    textToPrint += data[0] + " " + data[1] + "\n";
                    counter++;

                    if (counter == 3)
                    {
                        MessageBox.Show(textToPrint);
                        textToPrint = "";
                        counter = 0;
                    }
                }

                if (counter != 0)
                {
                    MessageBox.Show(textToPrint);
                }

                reader.Close();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading from the file: " + ex.Message);
            }
        }
    }
}
