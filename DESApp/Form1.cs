using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.FileName = "in.txt";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";

            openFileDialog2.FileName = "in2.dat";
            openFileDialog2.Filter = "Data files(*.dat)|*.dat";

            saveFileDialog1.FileName = "in.dat";
            saveFileDialog1.Filter = "Text files(*.dat)|*.dat";
        }


        private byte[] ReadByteFile(string fileName)
        {
            return File.ReadAllBytes(fileName);
        }
        private string ReadFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string text = "";

            while (!sr.EndOfStream)
            {
                text += sr.ReadLine();
            }

            sr.Close();
            return text;
        }

        private void WriteByteFile(string fileName, byte[] bytes)
        {
            BinaryWriter Writer = null;
            try
            {
                // Create a new stream to write to the file
                Writer = new BinaryWriter(File.OpenWrite(fileName));

                // Writer raw data                
                Writer.Write(bytes);
                Writer.Flush();
                Writer.Close();
            }
            catch
            {
                MessageBox.Show("Exception WriteByteFile");
            }
        }
        private void WriteFile(string fileName, string text)
        {
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(text);
            sw.Close();
        }

        private void encodeBtn_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string plainText = ReadFile(filename);
            string text = "";

            DESApp.DES.DES des = new DESApp.DES.DES();
            byte[] encoded = des.Encode(plainText, tBKey.Text, out text);
            rTBInput.Text = plainText;
            rTBOutput.Text = text;

            WriteFile("in2.txt", text);
            WriteByteFile("in2.dat", encoded);
        }

        private void decodeBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog2.FileName;
            byte[] encoded = ReadByteFile(filename);

            string text = Encoding.Unicode.GetString(encoded);
            DESApp.DES.DES des = new DESApp.DES.DES();
            string plainText = des.Decode(encoded, tBKey.Text);

            rTBInput.Text = text;
            rTBOutput.Text = plainText;

            WriteFile("out.txt", plainText);
        }
    }
}
