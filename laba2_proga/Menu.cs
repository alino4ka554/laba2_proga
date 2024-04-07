using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laba2_proga
{
    public class Menu: Form3
    {
        public Menu(string user, string filename = "menu.txt")
        {
            if(!File.Exists(filename))
            {
                throw new Exception("Файл не найден!");
            }
            Form3 Form3 = new Form3();
            string[] str = File.ReadAllLines(filename);
            ToolStripMenuItem menuItem = null;
            ToolStripMenuItem parentItem = new ToolStripMenuItem();
            ToolStripMenuItem tmp = new ToolStripMenuItem();
            for(int i = 0; i < str.Length; i++)
            {
                string[] subs = str[i].Split();
                
                int level = int.Parse(subs[0]);
                string name = subs[1];
                menuItem = new ToolStripMenuItem(name);
                if (subs.Length == 4)
                    menuItem.Click += (sender, e) => menuItem_Click(sender, e, subs[3]);
                if (subs[2] == "1")
                {
                    menuItem.Enabled = false;
                }
                else if (subs[2] == "2")
                {
                    menuItem.Visible = false;
                }
                if (level == 0)
                {
                    Form3.menuStrip1.Items.Add(menuItem);
                    parentItem = menuItem;
                    tmp = menuItem;
                }
                else
                {
                    parentItem.DropDownItems.Add(menuItem);
                    if (i < str.Length - 1 && str[i + 1].Split()[0] != str[i].Split()[0])
                    {
                        parentItem = menuItem;
                    }
                    if(i < str.Length - 1 && int.Parse(str[i].Split()[0]) > int.Parse(str[i + 1].Split()[0]))
                    {
                        parentItem = tmp;
                    }
                }
            }
            Form3.menuStrip1 = ShowMenu(Form3.menuStrip1, user, "USERS.txt");
            Form3.Show();
            
        }

        public MenuStrip ShowMenu(MenuStrip menu, string user, string filename = "USERS.txt")
        {
            if (!File.Exists(filename))
            {
                throw new Exception("Файл не найден!");
            }
            string[] fileLines = File.ReadAllLines(filename);
            for (int i = 0; i < fileLines.Length; i++)
            {
                string[] users = fileLines[i].Split();
                if (users[0] == "#" + user)
                {

                    for (int j = i; j < fileLines.Length; j++)
                    {
                        foreach (ToolStripMenuItem item in menu.Items)
                        {

                            if (fileLines[j].Split()[0] == item.Text)
                            {
                                if (fileLines[j].Split()[1] == "1")
                                {
                                    item.Enabled = false;
                                }
                                else if (fileLines[j].Split()[1] == "2")
                                {
                                    item.Visible = false;
                                }
                            } 
                        }
                        if (j != fileLines.Length - 1 && fileLines[j + 1].Split()[0].ToCharArray()[0] == '#') { break; }
                    }
                }
            }
            return menu;
        }

        public void menuItem_Click(object sender, EventArgs e, string method)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            if (clickedItem != null)
            {
                MessageBox.Show(method);
            }
        }
    }
}
