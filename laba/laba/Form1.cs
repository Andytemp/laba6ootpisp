using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shapes;
using Drawer;
using Serializer;
using System.Reflection;
using BasePlugins;
using Adapter;
namespace laba
{
    public partial class Form1 : Form
    {
        public ShapesHistory history = new ShapesHistory();
        public Processor processor;
        public Deprocessor deprocessor;
        private bool IsPainting = false;
        public Serializer.Serializer serializer = new Serializer.Serializer();
        Dictionary<string,Type> ImportedTypes = new Dictionary<string,Type>();
        private Point LastPos = new Point(0, 0);   
        private Point StartPos = new Point(0, 0);   
        public void DrawShape(Figure shape,Graphics graph)
        {
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Pen pen = new Pen(shape.ShapeColor);
            if (shape is Polygon)
            {
                graph.DrawPolygon(pen, shape.GetBasePoints());
            }
            else
            {
                Point[] vert = shape.GetBasePoints();
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(
                vert[0].X,
                vert[0].Y,
                vert[2].X - vert[0].X,
                vert[2].Y - vert[0].Y);
                graph.DrawEllipse(pen, rect);
            }
        }
        public ShapesList list = new ShapesList();
        Figure shapetodraw = null;
        delegate Figure selectedShapeTypeDelegate(int startPointX, int startPointY, int endPointX, int endPointY);
        selectedShapeTypeDelegate currentShape= delegate(int startPointX, int startPointY, int endPointX, int endPointY) {
                return new Line(startPointX, startPointY, endPointX, endPointY); 
            };
        public Form1()
        {
            InitializeComponent();
            panel1.GetType().GetMethod("SetStyle",
              System.Reflection.BindingFlags.Instance |
              System.Reflection.BindingFlags.NonPublic).Invoke(panel1,
              new object[]{ System.Windows.Forms.ControlStyles.UserPaint | 
	          System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | 
	          System.Windows.Forms.ControlStyles.DoubleBuffer, true });
            processor = new ProcessorStub();
            deprocessor = new DeprocessorStub();
            currentProcessorToolStripMenuItem.Text = "Current processor: " + processor.GetType().Name;
            loadDeprocessorToolStripMenuItem.Text = "Current deprocessor: " + deprocessor.GetType().Name;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            foreach (Figure fig in list.list)
            {

                DrawShape(fig, e.Graphics);
            }
            if (shapetodraw != null )DrawShape(shapetodraw, e.Graphics);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsPainting)
            {
                if (shapetodraw != null)
                {
                    IsPainting = false;
                    list.list.Add(shapetodraw);
                    ListViewItem item = new ListViewItem(shapetodraw.Name);
                    item.Tag = shapetodraw;
                    listView1.Items.Add(item);
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsPainting)
            {
                if (LastPos != e.Location)
                {
                    LastPos = e.Location;
                    shapetodraw = currentShape(StartPos.X, StartPos.Y, e.Location.X, e.Location.Y); 
                }

            }
            panel1.Refresh();
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            currentShape = delegate(int startPointX, int startPointY, int endPointX, int endPointY) {
                return new Line(startPointX, startPointY, endPointX, endPointY); 
            };
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            currentShape = delegate(int startPointX, int startPointY, int endPointX, int endPointY)
            {
                return new Shapes.Rectangle(startPointX, startPointY, endPointX, endPointY);
            };
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            currentShape = delegate(int startPointX, int startPointY, int endPointX, int endPointY)
            {
                return new Shapes.Square(startPointX, startPointY, endPointX, endPointY);
            };
        }

        private void buttonRomb_Click(object sender, EventArgs e)
        {
            currentShape = delegate(int startPointX, int startPointY, int endPointX, int endPointY)
            {
                return new Shapes.Romb(startPointX, startPointY, endPointX, endPointY);
            };
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            currentShape = delegate(int startPointX, int startPointY, int endPointX, int endPointY)
            {
                return new Shapes.Triangle(startPointX, startPointY, endPointX, endPointY);
            };
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
            currentShape = delegate(int startPointX, int startPointY, int endPointX, int endPointY)
            {
                return new Shapes.Ellipse(startPointX, startPointY, endPointX, endPointY);
            };
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            currentShape = delegate(int startPointX, int startPointY, int endPointX, int endPointY)
            {
                return new Shapes.Circle(startPointX, startPointY, endPointX, endPointY);
            };
        }

        private void buttonPentagon_Click(object sender, EventArgs e)
        {
            currentShape = delegate(int startPointX, int startPointY, int endPointX, int endPointY)
            {
                return new Shapes.Pentagon(startPointX, startPointY, endPointX, endPointY);
            };
        }

        private void buttonArrow_Click(object sender, EventArgs e)
        {
            currentShape = delegate(int startPointX, int startPointY, int endPointX, int endPointY)
            {
                return new Shapes.Arrow(startPointX, startPointY, endPointX, endPointY);
            };
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            IsPainting = true;
            LastPos = new Point(0, 0);
            StartPos = e.Location;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            list.list.Clear();
            listView1.Items.Clear();
            shapetodraw = null;
            panel1.Refresh();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {

                list.list.Remove(list.list.Find(x => x == eachItem.Tag));
                listView1.Items.Remove(eachItem);
            }
            shapetodraw = null;
            panel1.Refresh();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Figure item = null ;
            if (listView1.SelectedItems.Count > 0)
            {
                item = ((listView1.SelectedItems[0].Tag) as Figure);
            }
            if (item != null)
            {
                panel2.Visible = true;
                panel2.Enabled = true;
                numericUpDown1.Value = item.Startpoint.X;
                numericUpDown2.Value = item.Startpoint.Y;
                numericUpDown3.Value = item.Height;
                numericUpDown4.Value = item.Width;
            }
            else {
                panel2.Visible = false;
                panel2.Enabled = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Figure item = null;
            if (listView1.SelectedItems.Count > 0)
            {
                item = ((listView1.SelectedItems[0].Tag) as Figure);
            }
            if (item != null)
            {
                item.UpdateX(Convert.ToInt32(Math.Round((sender as NumericUpDown).Value, 0)));
                numericUpDown1.Value = item.Startpoint.X;
                numericUpDown2.Value = item.Startpoint.Y;
                numericUpDown3.Value = item.Height;
                numericUpDown4.Value = item.Width;
                panel1.Refresh();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Figure item = null;
            if (listView1.SelectedItems.Count > 0)
            {
                item = ((listView1.SelectedItems[0].Tag) as Figure);
            }
            if (item != null)
            {
                item.UpdateY(Convert.ToInt32(Math.Round((sender as NumericUpDown).Value, 0)));
                numericUpDown1.Value = item.Startpoint.X;
                numericUpDown2.Value = item.Startpoint.Y;
                numericUpDown3.Value = item.Height;
                numericUpDown4.Value = item.Width;
                panel1.Refresh();
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Figure item = null;
            if (listView1.SelectedItems.Count > 0)
            {
                item = ((listView1.SelectedItems[0].Tag) as Figure);
            }
            if (item != null)
            {
                item.UpdateHeight(Convert.ToInt32(Math.Round((sender as NumericUpDown).Value, 0)));
                numericUpDown1.Value = item.Startpoint.X;
                numericUpDown2.Value = item.Startpoint.Y;
                numericUpDown3.Value = item.Height;
                numericUpDown4.Value = item.Width;
                panel1.Refresh();
            }
        }
        //151 140
        //481 287
        //147 330
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Figure item = null;
            if (listView1.SelectedItems.Count > 0)
            {
                item = ((listView1.SelectedItems[0].Tag) as Figure);
            }
            if (item != null)
            {
                item.UpdateWidth(Convert.ToInt32(Math.Round((sender as NumericUpDown).Value, 0)));
                numericUpDown1.Value = item.Startpoint.X;
                numericUpDown2.Value = item.Startpoint.Y;
                numericUpDown3.Value = item.Height;
                numericUpDown4.Value = item.Width;
                panel1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string serialized = serializer.Serialize(list);
                processor.Process(serialized, saveFileDialog1.FileName);
                list.list.Clear();
                listView1.Items.Clear();
                shapetodraw = null;
            }
            panel1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string processed = deprocessor.Deprocess(openFileDialog1.FileName);
                list = serializer.Deserialize(processed);
                listView1.Items.Clear();
                foreach (Figure fig in list.list) {
                    ListViewItem item = new ListViewItem(fig.Name);
                    item.Tag = fig;
                    listView1.Items.Add(item);
                }
            }
            panel1.Refresh();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void LoadPlugin(string path){}
        private void LoadFigure(string path) {
            var DLL = Assembly.LoadFile(path);

            foreach (Type type in DLL.GetExportedTypes())
            {
                if (!ImportedTypes.ContainsValue(type))
                {
                    ImportedTypes.Add(type.Name, type);
                    Button b = new Button();
                    b.Text = type.Name;
                    b.Width = 99;
                    b.Height = 32;
                    flowLayoutPanel1.Controls.Add(b);
                    b.Click += new EventHandler(delegate(object sender, EventArgs e)
                    {
                        currentShape = delegate(int startPointX, int startPointY, int endPointX, int endPointY)
                        {
                            var instance = Activator.CreateInstance(ImportedTypes[b.Text], startPointX, startPointY, endPointX, endPointY);
                            return (Figure)instance;
                        };
                    });
                }
            }
        }
        private void LoadProcessor(string path) {
            var DLL = Assembly.LoadFile(path);
            foreach (Type type in DLL.GetExportedTypes())
            {
                processor = (Processor)Activator.CreateInstance(type);
            }
        }
        private void LoadDeprocessor(string path)
        {
            var DLL = Assembly.LoadFile(path);
            foreach (Type type in DLL.GetExportedTypes())
            {
                deprocessor = (Deprocessor)Activator.CreateInstance(type);
            }
        }
        private void LoadProcessorViaAdapter(string path)
        {
            var DLL = Assembly.LoadFile(path);
            object adaptee = null;
            foreach (Type type in DLL.GetExportedTypes())
            {
                adaptee = Activator.CreateInstance(type);
            }
            processor = new ProcessorAdapter(adaptee,textBox1.Text);

        }
        private void LoadDeprocessorViaAdapter(string path)
        {
            var DLL = Assembly.LoadFile(path);
            object adaptee = null;
            foreach (Type type in DLL.GetExportedTypes())
            {
                adaptee = Activator.CreateInstance(type);
            }
            deprocessor = new DeprocessorAdapter(adaptee, textBox2.Text);
        }
        private void loadPluginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadFigure(openFileDialog1.FileName);
            }
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deprocessor = new DeprocessorStub();
            loadDeprocessorToolStripMenuItem.Text = "Current deprocessor: " + deprocessor.GetType().Name;
        }

        private void pluginsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void externalDeprocessorsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void loadProcessorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadProcessor(openFileDialog1.FileName);
                currentProcessorToolStripMenuItem.Text = "Current processor: "+processor.GetType().Name;
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadDeprocessor(openFileDialog1.FileName);
                loadDeprocessorToolStripMenuItem.Text = "Current deprocessor: "+deprocessor.GetType().Name;
            }
        }

        private void resetProcessorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processor = new ProcessorStub();
            currentProcessorToolStripMenuItem.Text = "Current processor: " + processor.GetType().Name;
        }

        private void currentProcessorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LoadProcessorViaAdapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadProcessorViaAdapter(openFileDialog1.FileName);
                currentProcessorToolStripMenuItem.Text = "Current processor: " + processor.GetType().Name;
            }
        }

        private void LoadDeprocessorViaAdapterToolstripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadDeprocessorViaAdapter(openFileDialog1.FileName);
                loadDeprocessorToolStripMenuItem.Text = "Current deprocessor: " + deprocessor.GetType().Name;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (shapetodraw != null)
            {
                Figure clonedshape = shapetodraw.Clone();
                list.list.Add(clonedshape);
                ListViewItem item = new ListViewItem(clonedshape.Name);
                item.Tag = clonedshape;
                listView1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            list.RestoreState(history.History.Pop());
            listView1.Items.Clear();
            shapetodraw = null;
            foreach (Figure fig in list.list)
            {
                ListViewItem item = new ListViewItem(fig.Name);
                item.Tag = fig;
                listView1.Items.Add(item);
            }
            panel1.Refresh();
            if (history.History.Count == 0)
            {
                button4.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            history.History.Push(list.SaveState());
            button4.Enabled = true;
        }
    }
}
