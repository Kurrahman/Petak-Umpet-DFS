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
        Graph graph;
        GrafMatriks grafMatriks;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int dir = Convert.ToInt32(Direction.Text);
            int jose = Convert.ToInt32(JoseAddress.Text) - 1;
            int ferd = Convert.ToInt32(FerdiantStart.Text) - 1;
            string a = Convert.ToString(dir);
            string b = Convert.ToString(jose+1);
            string c = Convert.ToString(ferd+1);
            Ways tmp = grafMatriks.solve(dir, jose, ferd);
            if (tmp.getPass())
            {
                ListBox.Items.Add(a + ' ' + b + ' ' + c + " YA " + tmp.getJalur());
            }
            else
            {
                ListBox.Items.Add(a + ' ' + b + ' ' + c + " TIDAK");
            }
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
            //gViewer1.CurrentLayoutMethod = LayoutMethod.MDS;
            graph = new Graph("graph");
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
                grafMatriks.setGraf(row,col,true);
            }
            gViewer1.Graph = graph;
            grafMatriks.initDistance(0, 0);
        }

        private void inputClick(object sender, EventArgs e)
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
            InputDir.Text = filename;
            string[] filelines = File.ReadAllLines(filename);
            ListBox.Items.Clear();
            // Queries
            for (int i = 1; i < filelines.Length; i++)
            {
                string[] tmps = filelines[i].Split(' ');
                int dir = Convert.ToInt32(tmps[0]);
                int jose = Convert.ToInt32(tmps[1]) - 1;
                int ferd = Convert.ToInt32(tmps[2]) - 1;
                Ways tmp = grafMatriks.solve(dir, jose, ferd);
                if (tmp.getPass())
                {
                    ListBox.Items.Add(tmps[0] + ' ' + tmps[1] + ' ' + tmps[2] + " YA " + tmp.getJalur());
                }
                else
                {
                    ListBox.Items.Add(tmps[0] + ' ' + tmps[1] + ' ' + tmps[2] + ' ' + " TIDAK");
                }
            }
        }

        private void initComboBox(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                JoseAddress.Items.Add(i);
                FerdiantStart.Items.Add(i);
                graph.AddNode(Convert.ToString(i));
                graph.FindNode(Convert.ToString(i)).Attr.Shape = Shape.Circle;
            }
        }

        private void Direction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FerdiantStart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateGraph(object sender, EventArgs e)
        {
            gViewer1.Graph = graph;
            string[] nodes = ListBox.GetItemText(ListBox.SelectedItem).Trim().Split(' ');
            for (int i = 0; i < graph.NodeCount; i++)
            {
                Node tmp = gViewer1.Graph.FindNode(Convert.ToString(i+1));
                tmp.Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
                gViewer1.Graph.AddNode(tmp);
            }
            for (int i = 4; i < nodes.Length; i++)
            {
                Node tmp = gViewer1.Graph.FindNode(nodes[i]);
                if (tmp == null)
                {
                    return;
                }
                tmp.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
                gViewer1.Graph.AddNode(tmp);
            }
        }

        private void Export(object sender, EventArgs e)
        {
            string[] path = InputDir.Text.Split('\\');
            string filename = path[0];
            for (int i = 1; i < path.Length-1; i++)
            {
                filename += '\\' + path[i];
            }
            filename += '\\' + "Output.txt";

            string[] lines = new string[ListBox.Items.Count];
            for (int i = 0; i < ListBox.Items.Count; i++)
            {
                lines[i] = ListBox.Items[i].ToString();
            }
            File.WriteAllLines(filename, lines);
        }
    }
    public class GrafMatriks
    {
        private bool[][] graph;
        private int size;
        private int[] distance;

        public Ways solve(int dir, int jose, int ferd)
        {
            Ways inpw = new Ways();
            if (dir == 1)
            {
                inpw = solveAway(jose, ferd);
                inpw.addToJalur(ferd);
                return inpw;
            }
            else
            {
                inpw = solveTowards(jose, ferd);
                inpw.addToJalur(ferd);
                return inpw;
            }
        }

        public Ways solveTowards(int jose, int ferd)
        {
            Ways inpw = new Ways();
            if (ferd == jose)
            {
                inpw.setPass(true);
                return inpw;
            }
            else
            {
                if (ferd != 0)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (neighbor(ferd, i))
                        {
                            setGraf(ferd, i, false);
                            if (distance[ferd] > distance[i])
                            {
                                inpw = solveTowards(jose, i);
                                inpw.removeJalur();
                                if (inpw.getPass())
                                {
                                    inpw.addToJalur(i);
                                    setGraf(ferd, i, true);
                                    break;
                                }
                            }
                            setGraf(ferd, i, true);
                        }
                    }
                    return inpw;
                }
                else
                {
                    return inpw;
                }
            }
        }

        public Ways solveAway(int jose, int ferd)
        {

            Ways inpw = new Ways();
            if (ferd == jose)
            {
                inpw.setPass(true);
                return inpw;
            }
            else
            {
                if (haveNeighbor(ferd))
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (neighbor(ferd, i))
                        {
                            setGraf(ferd, i, false);
                            if (distance[ferd] < distance[i])
                            {
                                inpw = solveAway(jose, i);
                                inpw.removeJalur();
                                if (inpw.getPass())
                                {
                                    inpw.addToJalur(i);
                                    setGraf(ferd, i, true);
                                    break;
                                }
                            }
                            setGraf(ferd, i, true);
                        }
                    }
                    return inpw;
                }
                else
                {
                    return inpw;
                }
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
            distance = new int[size];
        }

        public void initDistance(int node, int depth)
        {
            distance[node] = depth;
            if (haveNeighbor(node))
            {
                for (int i = 0; i < distance.Length; i++)
                {
                    if (neighbor(node, i))
                    {
                        setGraf(node, i, false);
                        initDistance(i, depth + 1);
                        setGraf(node, i, true);
                    }
                }
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
    public class Quest
    {
        private int dir;
        private int jose;
        private int ferd;

        public Quest(int di, int jos, int fer)
        {
            dir = di;
            jose = jos;
            ferd = fer;
        }

        public int getDir() { return dir; }
        public int getJose() { return jose; }
        public int getFerd() { return ferd; }
    }
    public class Ways
    {
        private string jalur;
        private bool pass;
        public Ways()
        {
            pass = false;
            jalur = "";
        }
        public bool getPass()
        {
            return pass;
        }
        public string getJalur()
        {
            return jalur;
        }
        public void setPass(bool _b)
        {
            pass = _b;
        }
        public void addToJalur(int _s)
        {
            jalur =  Convert.ToString(_s+1) +' '+jalur;
        }
        public void addListJalur(string _jalur)
        {
            jalur = jalur + ' ' + _jalur;
        }
        public void removeJalur()
        {
            string[] tmp = jalur.Split(' ');
            string stmp = "";
            for (int i = 0; i < tmp.Length; i++)
            {
                stmp +=tmp[i] +' ';
            }
            jalur = stmp;
        }
    }
}