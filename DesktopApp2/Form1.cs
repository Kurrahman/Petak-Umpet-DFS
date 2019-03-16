using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp2
{
    public partial class Form1 : Form
    {
        private Graph graf;
        private int[] node;
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileDir.Text = openFileDialog1.FileName;
            }
            // Menyiapkan file untuk dibaca
            string filename = openFileDialog1.FileName;
            string[] filelines = File.ReadAllLines(filename);
            // Inisialisasi Graph
            graf = new Graph(Convert.ToInt32(filelines[0].Trim()));
            node = new int[Convert.ToInt32(filelines[0].Trim())];
            initNode(node, Convert.ToInt32(filelines[0].Trim()));
            JoseAddress.DataSource = node;
            FerdiantStart.DataSource = node;
            for (int i = 1; i < filelines.Length; i++)
            {
                string[] spltmp = filelines[i].Split(' ');
                int row = Convert.ToInt32(spltmp[1]) - 1;
                int col = Convert.ToInt32(spltmp[0]) - 1;
                if (row < col)
                {
                    row = row + col;
                    col = row - col;
                    row = row - col;
                }
                Console.WriteLine(Convert.ToString(row) + ' ' + Convert.ToString(col));
                graf.setGraf(row, col);
            }
        }
        
        private void initNode(int[] node, int size)
        {
            for(int i = 1; i <= size; i++)
            {
                node[i - 1] = i;
            }
        }

        private void Direction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class Graph
    {
        private bool[][] graph;
        private int size;

        public bool solve(int direction)
        {
            return true;
        }

        public Graph(int s)
        {
            size = s;
            graph = new bool[size][];
            for (int i = 0; i < size; i++)
            {
                graph[i] = new bool[i];
            }
        }

        public int getSize()
        {
            return size;
        }

        public void setGraf(int row, int col)
        {
            graph[row][col] = true;
        }
    }
}
