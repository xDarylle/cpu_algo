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
    public partial class FCFS_Main : Form
    {
       
       
        public FCFS_Main()
        {
            InitializeComponent();
        }


        int mov;
        int movX;
        int movY;



        private void label1_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Show();
            this.Hide();
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
          if(mov == 1)
          {
              this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
          }
        }

        private void FCFS_Main_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void FCFS_Main_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void FCFS_Main_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void FCFS_Main_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
           
            service1.ReadOnly = true;
            service2.ReadOnly = true;
            service3.ReadOnly = true;
            service4.ReadOnly = true;

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238,239,249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void process1_OnValueChanged(object sender, EventArgs e)
        {
        
        }

        public Boolean duplicating(int[] arr)
        {

            /* initialize isDuplicate equals to false
             * put each textbox in array 
             * search each element in i (j + 1) 
             * if there is duplicate compate arr[i].Equals(arr[j])
             * return isDuplicate is equals to true
             * if isDuplicate is equals to 1 print MessageBox.Show("Number Duplicate")
             */

           bool isDuplicate = false;
           for(int i = 0; i < arr.Length; i++)
           {
             for(int j = i + 1; j < arr.Length; j++)
             {
                 if(arr[i].Equals(arr[j]))
                 {
                     isDuplicate = true;
                 }
                 
             }
           }

           return isDuplicate;
        }

        public void FCFS()
        {
            String[] text = new String[] 
            {
                process1.Text,
                process2.Text,
                process3.Text,
                process4.Text,
                executionTime1.Text,
                executionTime2.Text,
                executionTime3.Text,
                executionTime4.Text
            };

            foreach (String txt in text)
            {

                if (string.IsNullOrEmpty(txt))
                {
                    MessageBox.Show("Please fill all empty fields");
                    break;
                }
                else
                {

                int[] process = new int[] 
                {
                   int.Parse(process1.Text),
                   int.Parse(process2.Text),
                   int.Parse(process3.Text),
                   int.Parse(process4.Text)
                };


                    if (duplicating(process) == true)
                    {
                        MessageBox.Show("Number Duplicate");
                        break;
                    }
                    else
                    {

                        //initializing
                        int length = 4;

                        int[] arivalTime = new int[length];
                        int[] executionTime = new int[length];
                        arivalTime[0] = int.Parse(process1.Text);
                        arivalTime[1] = int.Parse(process2.Text);
                        arivalTime[2] = int.Parse(process3.Text);
                        arivalTime[3] = int.Parse(process4.Text);

                        executionTime[0] = int.Parse(executionTime1.Text);
                        executionTime[1] = int.Parse(executionTime2.Text);
                        executionTime[2] = int.Parse(executionTime3.Text);
                        executionTime[3] = int.Parse(executionTime4.Text);

                        //int[] artime = new int[] { int.Parse(process1.Text), int.Parse(process2.Text), int.Parse(process3.Text), int.Parse(process4.Text) };
                        //int[] exetime = new int[] { int.Parse(executionTime1.Text), int.Parse(executionTime2.Text), int.Parse(executionTime3.Text), int.Parse(executionTime4.Text) };


                        //Initialize
                        int[] exetime2 = new int[length];
                        int[] wtime = new int[length];
                        int[] artime2 = new int[length];
                        int[] final = new int[length];

                        float ave = 0;

                        //For duplicating
                        for (int i = 0; i < length; i++)
                        {
                            //passing value to artim2 to duplicate
                            artime2[i] = arivalTime[i];
                        }

                        //first arrival comes with 0 waiting time
                        wtime[0] = 0;

                        //Ascending sorting value
                        Array.Sort(artime2);

                        //Sorting of execution time depending arrival time
                        for (int i = 0; i < length; i++)
                        {
                            for (int j = 0; j < length; j++)
                            {
                                if (artime2[i] == arivalTime[j])
                                {
                                    exetime2[i] = executionTime[j];
                                }
                            }
                        }

                        //Adding elements to get waiting time
                        for (int i = 0; i < length; i++)
                        {
                            if (i + 1 < length)
                            {
                                wtime[i + 1] = exetime2[i] + wtime[i];
                            }
                            ave += wtime[i];
                        }

                        //rearranging waiting time according to original arrival time
                        for (int i = 0; i < length; i++)
                        {
                            for (int j = 0; j < length; j++)
                            {
                                if (arivalTime[i] == artime2[j])
                                {
                                    final[i] = wtime[j];
                                }
                            }
                        }

                        //getting average of waiting time 
                        ave = ave / 4;

                        service1.Text = final[0].ToString();
                        service2.Text = final[1].ToString();
                        service3.Text = final[2].ToString();
                        service4.Text = final[3].ToString();

                        AveWaiting.Text = ave.ToString();

                        dataGridView1.Rows.Add(arivalTime[0].ToString(), executionTime[0].ToString(), service1.Text);
                        dataGridView1.Rows.Add(arivalTime[1].ToString(), executionTime[1].ToString(), service2.Text);
                        dataGridView1.Rows.Add(arivalTime[2].ToString(), executionTime[2].ToString(), service3.Text);
                        dataGridView1.Rows.Add(arivalTime[3].ToString(), executionTime[3].ToString(), service4.Text);
                        break;
                    }
                }
            }
        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            FCFS();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            process1.Text = " ";
            process2.Text = " ";
            process3.Text = " ";
            process4.Text = " ";

            executionTime1.Text = " ";
            executionTime2.Text = " ";
            executionTime3.Text = " ";
            executionTime4.Text = " ";

            service1.Text = " ";
            service2.Text = " ";
            service3.Text = " ";
            service4.Text = " ";

            AveWaiting.Text = " ";
        }
    }
}
