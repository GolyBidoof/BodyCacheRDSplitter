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

namespace IDKwhyamidoingthisbutifeellikeit
{
    public partial class Form1 : Form
    {
        byte[] bytes;
        int size = -1;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    bytes = File.ReadAllBytes(file);
                    size = bytes.Length;
                }
                catch (IOException)
                {
                    MessageBox.Show("You didn't import any file.");
                }

            }
            if (size % 1376256 == 0)
            {
                AmountBox.Text = (size / 1376256).ToString();
            }
            else
            {
                MessageBox.Show("You didn't import a valid BodyCache_rd.bin file.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (size != -1)
            {
                for (int i = 0; i < int.Parse(AmountBox.Text); i++)
                {
                    byte[] save = new byte[1376256];
                    Array.Copy(bytes, 1376256 * i, save, 0, 1376256);
                    saveFileDialog1.FileName = i+1 + ".bin";
                    DialogResult resultsave = saveFileDialog1.ShowDialog(); // Show the dialog.
                    if (resultsave == DialogResult.OK) // Test result.
                    {
                        string file = saveFileDialog1.FileName;
                        try
                        {
                            File.WriteAllBytes(file, save);
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("You didn't save any file.");
                        }

                    }
                }
            }
        }
    }
}
