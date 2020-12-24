using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23122020form
{
    public partial class Form1 : Form
    {
        Timer timerAnim = new Timer();
        public Form1()
        {
            InitializeComponent();
            timerAnim.Interval = 10;
            timerAnim.Tick += TimerAnim_Tick;
        }

        int CountAnim = 0;
        bool OnButton = false;
        private void TimerAnim_Tick(object sender, EventArgs e)
        {
            int k = OnButton ? 1 : -1;
            CountAnim += k;
            if (OnButton)
            {
                if (CountAnim > 5)
                    timerAnim.Stop();
            }
            else
            {
                if (CountAnim < 1)
                    timerAnim.Stop();
            }
            button4.Size = new Size(button4.Size.Width + k, button4.Size.Height + k);
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ImageIndex = 5;
            OnButton = true;
            timerAnim.Start();
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ImageIndex = 4;
            OnButton = false;
            timerAnim.Start();
        }

        int k = 0;
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            // string text = "123";
            string text = (sender as ListBox)?.Items[e.Index].ToString();

            Brush brush = e.Index % 2 == 0 ? Brushes.Red : Brushes.Blue;
            e.Graphics.DrawString(text,
                e.Font,
                brush,
                e.Bounds,
                StringFormat.GenericDefault);
            e.DrawFocusRectangle();

            Text = "" + ++k;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(11345);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                listBox2.Items.Add(random.Next(-10, 11));
            }
        }
        private void DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            // string text = "123";
            if (sender is ListBox LB && LB.Items.Count > 0)
            {
                if (LB.Items[e.Index] is Int32 n)
                {
                    Brush brush = (n > 0 ? Brushes.Green : (n < 0 ? Brushes.Red : Brushes.Black));
                    e.Graphics.DrawString(
                        "" + n,
                        e.Font,
                        brush,
                        e.Bounds,
                        StringFormat.GenericDefault);
                }
            }
            e.DrawFocusRectangle();
            Text = "" + ++k;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                    listBox1.Items.Add(checkedListBox1.Items[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < checkedListBox1.Items.Count; i++)            
            //    checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));

            checkedListBox1.SetItemCheckState(1, CheckState.Checked);
            checkedListBox1.SetItemCheckState(2, CheckState.Unchecked);
            checkedListBox1.SetItemCheckState(3, CheckState.Indeterminate);

        }




        private void button4_Click(object sender, EventArgs e)
        {
            checkBox1.ImageIndex++;
        }
    }
}
