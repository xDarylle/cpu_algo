using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCFS
{
    public partial class SJF : Form
    {

        int mov;
        int movX;
        int movY;

        List<int> _exetime = new List<int>();
        List<int> _waittime = new List<int>();
        List<TextBox> _txtbox = new List<TextBox>();
        List<TextBox> _waitbox = new List<TextBox>();
        List<Label> _labels = new List<Label>();
        List<string> _process = new List<string>();

        int process;
        int numTxtBox = 4;

        int x;
        int y;

        public SJF()
        {
            InitializeComponent();
        }

        public void addBox() {

            TextBox txtburstTime = new TextBox();
            txtburstTime.Width = 230;
            txtburstTime.Font = new Font(txtburstTime.Font.FontFamily, 16);
            txtburstTime.Location = new Point(100, y);
            _txtbox.Add(txtburstTime);
            processPanel.Controls.Add(txtburstTime);
            processPanel.AutoScroll = true;


            TextBox txtwatingTime = new TextBox();
            txtwatingTime.Width = 250;
            txtwatingTime.Font = new Font(txtwatingTime.Font.FontFamily, 16);
            txtwatingTime.Location = new Point(360, y);
            txtwatingTime.ReadOnly = true;
            _waitbox.Add(txtwatingTime);
            processPanel.Controls.Add(txtwatingTime);
            processPanel.AutoScroll = true;

            Label processlbl = new Label();
            processlbl.Font = new Font(processlbl.Font.FontFamily, 16);
            processlbl.Location = new Point(30, y);
            _labels.Add(processlbl);
            processlbl.Text = "P" + process;
            processPanel.Controls.Add(processlbl);

            y += 40;
            process++;
        }

        private void initialize() {
            for (int i = 0; i < numTxtBox; i++) {
                addBox();
            }
            count.Text = numTxtBox.ToString();
        }

        private void setDefaultVal() {
            x = 40;
            y = 0;
            process = 0;
        }

        private void clearListBox() {
            _txtbox.Clear();
            _waitbox.Clear();
            _labels.Clear();
        }

        private void clearList() {
            _exetime.Clear();
            _waittime.Clear();
            _process.Clear();
        }

        private void clearPanel() {
            processPanel.Controls.Clear();
            processPanel.Controls.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SJF_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 118, 190);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            processPanel.AutoScroll = false;
            processPanel.HorizontalScroll.Enabled = false;
            processPanel.HorizontalScroll.Visible = false;
            processPanel.HorizontalScroll.Maximum = 0;
            processPanel.AutoScroll = false;

            setDefaultVal();
            initialize();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            addBox();
            numTxtBox++;
            count.Text = numTxtBox.ToString();

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            processPanel.Controls.RemoveAt(processPanel.Controls.Count - 1);
            processPanel.Controls.RemoveAt(processPanel.Controls.Count - 1);
            processPanel.Controls.RemoveAt(processPanel.Controls.Count - 1);
           
            _txtbox.RemoveAt(_txtbox.Count - 1);
            _labels.RemoveAt(_labels.Count - 1);
           
            process--;
            y -= 40;

            numTxtBox--;
            count.Text = numTxtBox.ToString();
        }

        private void processPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Startbtn_Click(object sender, EventArgs e)
        {

            foreach (var txt in _txtbox)
            {
                _exetime.Add(int.Parse(txt.Text));
            }


            int[] _copy = new int[_exetime.Count];

            float ave = 0;

            _waittime.Add(0);

            _exetime.CopyTo(_copy);

           Array.Sort(_copy);
            
           for (int i = 0; i < _exetime.Count; i++ ) {
               if(i + 1 < _exetime.Count) {
                   _waittime.Add(_waittime[i] + _copy[i]);
               }
           }

           for (int i = 0; i < _exetime.Count; i++ ) {
               for (int j = 0; j < _exetime.Count; j++ ) {
                   if(_exetime[i] == _copy[j]) {
                       _process.Add(_labels[j].Text);
                   }
               }
               ave += _waittime[i];
           }

           ave = ave / 4;

           AverageWaitingTIme.Text = ave.ToString();

           for (int i = 0; i < _waittime.Count; i++)
           {
               _waitbox[i].Text = _waittime[i].ToString();
               _txtbox[i].Text = _copy[i].ToString();
               _labels[i].Text = _process[i];
           }

           clearList();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            clearList();
            clearListBox();
            clearPanel();
            setDefaultVal();
            initialize();
        }

        private void count_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                clearListBox();
                clearPanel();
                setDefaultVal();

                numTxtBox = int.Parse(count.Text);

                initialize();

            }
        }
    }
  }

    

