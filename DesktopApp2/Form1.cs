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
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.Core;
using Microsoft.Msagl.GraphViewerGdi;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp2
{
    public partial class Form1 : Form
    {
        Graph graph = new Graph("grapf");
        GrafMatriks grafMatriks;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            // grafMatriks.printGraf();
            int dir = Convert.ToInt32(Direction.Text);
            int jose = Convert.ToInt32(JoseAddress.Text) - 1;
            int ferd = Convert.ToInt32(FerdiantStart.Text) - 1;
            grafMatriks.solve(dir, jose, ferd);
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
            grafMatriks = new GrafMatriks(Convert.ToInt32(filelines[0].Trim()));
            initComboBox(Convert.ToInt32(filelines[0].Trim()));
            for (int i = 1; i < filelines.Length; i++)
            {
                string a, b;
                int row, col;
                string[] splt;
                splt = filelines[i].Split(' ');
                a = splt[0];
                b = splt[1];
                row = Convert.ToInt32(a) - 1;
                col = Convert.ToInt32(b) - 1;
                graph.AddEdge(a, b);
                Console.WriteLine(Convert.ToString(row) + ' ' + Convert.ToString(col));
                grafMatriks.setGraf(row,col,true);
            }
            gViewer1.Graph = graph;
        }

        private void initComboBox(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                JoseAddress.Items.Add(i);
                FerdiantStart.Items.Add(i);
            }
        }

        private void Direction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FerdiantStart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class GrafMatriks
    {
        private bool[][] graph;
        private int size;
        
        public void solve(int dir, int jose, int ferd)
        {
            Console.Write(jose); Console.Write(' '); Console.WriteLine(ferd);
            if (dir == 1)
            {
                Console.WriteLine(Convert.ToString(solveAway(jose, ferd)));
            }
            else
            {
                Console.WriteLine(Convert.ToString(solveTowards(jose, ferd)));
            }
        }
        
        public bool solveTowards(int jose, int ferd)
        {
            if (ferd == jose)
            {
                return true;
            }
            else
            {
                if (ferd != 1)
                {
                    bool flag = false;
                    for (int i = 0; i < size; i++)
                    {
                        if (neighbor(ferd, i))
                        {
                            if (canReachThrough(ferd, i, 0))
                            {
                                setGraf(ferd, i, false);
                                flag = solveTowards(jose, i);
                                setGraf(ferd, i, true);
                                if (flag)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Tidak Bisa");
                    return flag;
                }
                else
                {
                    Console.WriteLine("Tidak Bisa");
                    return false;
                }
            }
        }

        public bool solveAway(int jose, int ferd)
        {
            if (ferd == jose)
            {
                Console.WriteLine("Bisa");
                return true;
            }
            else
            {
                if (haveNeighbor(ferd))
                {
                    bool flag = false;
                    for (int i = 0; i < size; i++)
                    {
                        if (neighbor(ferd, i))
                        {
                            if (!canReachThrough(ferd, i, 0))
                            {
                                setGraf(ferd, i, false);
                                flag = solveAway(jose, i);
                                setGraf(ferd, i, true);
                                if (flag){
                                    break;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Tidak Bisa");
                    return flag;
                }
                else
                {
                    Console.WriteLine("Tidak Bisa");
                    return false;
                }
            }
        }
        
        public bool canReachThrough(int node1, int node2, int target)
        {
            Console.Write(node1); Console.Write(" tes "); Console.Write(node2); Console.WriteLine();
            if (haveNeighbor(node2))
            {
                Console.Write("Have Neighbor");
                Console.WriteLine();
                if (neighbor(node2, target))
                {
                    return true;
                }
                else
                {
                    bool flag = false;
                    for(int i = 0; i < size; i++)
                    {
                        Console.Write(node2); Console.Write(' '); Console.Write(i); Console.Write(' '); Console.Write(target);
                        Console.WriteLine();
                        if (neighbor(node2, i) && (node1 != i))
                        {
                            if (canReachThrough(node2, i, target))
                            {
                                flag = true;
                            }
                        }
                    }
                    return flag;
                }
            }
            else
            {
                Console.Write("Don't Have Neighbor");
                return false;
            }
        }

        public bool haveNeighbor(int node)
        {
            int i = 0;
            while ((i < size) && !neighbor(node, i))
            {
                i++;
            }
            return (i < size);
        }

        public bool neighbor(int node1, int node2)
        {
            if (node1 < node2)
            {
                return graph[node2][node1];
            }
            else
            {
                if (node1 == node2)
                {
                    return false;
                }
                else
                {
                    return graph[node1][node2];
                }
            }
        }

        public GrafMatriks(int s)
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

        public void setGraf(int row, int col, bool val)
        {
            if (row < col)
            {
                graph[col][row] = val;
            }
            else
            {
                graph[row][col] = val;
            }
        }

        public void printGraf()
        {
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    Console.Write(neighbor(j,i));
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}