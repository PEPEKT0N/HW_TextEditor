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

namespace HW_TextEditor
{
    public partial class Form1 : Form
    {        
        Color my_color;
        public enum DateTimeFormat
        {
            ShowClock, ShowDate
        };
        DateTimeFormat format = DateTimeFormat.ShowClock;
        public Form1()
        {
            InitializeComponent();
            my_color = BackColor;
            menuStripRussia.Visible = false;            
            saveFileDialog1.Filter = "All files(*.*)|*.*| Text files(*.txt)|*.txt||";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All files(*.*)|*.*| Text files(*.txt)|*.txt||";
            open.FilterIndex = 1;
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = File.OpenText(open.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(save.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }

        private void rEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Checked == true)
            {
                this.BackColor = Color.Red;
            }
            else BackColor = my_color;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;       
            
        }       

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            string str;
            str = DateTime.Now.ToShortDateString();
            toolStripStatusLabel2.Text = str;
            str = DateTime.Now.DayOfWeek.ToString();
            toolStripStatusLabel1.Text = str;
            //if (format == DateTimeFormat.ShowClock)
            //{
            //    toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
            //    format = DateTimeFormat.ShowDate;
            //}
            //else
            //{
            //    toolStripStatusLabel2.Text = DateTime.Now.DayOfWeek.ToString();
            //    format = DateTimeFormat.ShowClock;
            //}
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            MessageBox.Show("Файл сохранен", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.SelectionFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            menuStripRussia.Visible = true;
            MainMenuStrip = menuStripRussia;            
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = true;
            menuStripRussia.Visible = false;
            MainMenuStrip = menuStrip1;
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                richTextBox1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //SaveFileDialog saveFileDialog2 = new SaveFileDialog();
            //Form2 form = new Form2(saveFileDialog2);
            //form.ShowDialog();
            //if (form.ShowDialog() == DialogResult.Yes)
            //{
            //    saveAsToolStripMenuItem_Click(sender, e);
            //    saveFileDialog1.Dispose();
            //    Application.Exit();
            //}
            //else if (form.ShowDialog() == DialogResult.No)
            //{
            //    saveFileDialog1.Dispose();
            //    Application.Exit();
            //}
            //else if (form.ShowDialog() == DialogResult.Cancel)
            //{
            //    return;
            //}
        }
    }
}
