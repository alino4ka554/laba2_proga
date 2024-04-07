using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2_proga
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string[] fileLines = File.ReadAllLines("USERS.txt");
            Menu menu = null;
            for (int i = 0; i < fileLines.Length; i++)
            {
                string[] users = fileLines[i].Split();
                if (users[0] == "#" + login)
                {
                    if (password == users[1])
                    {
                        menu = new Menu(login, "menu.txt");
                    }

                }
            }
            if(menu == null) MessageBox.Show("Неправильное имя пользователя или пароль");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
