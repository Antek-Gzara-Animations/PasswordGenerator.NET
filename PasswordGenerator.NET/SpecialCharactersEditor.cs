using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator.NET
{
    public partial class SpecialCharactersEditor : Form
    {
        public List<char> specialCharacters = new char[]
        {
            '~',
            '`',
            '!',
            '@',
            '#',
            '$',
            '%',
            '^',
            '&',
            '*',
            '(',
            ')',
            '-',
            '_',
            '+',
            '=',
            '{',
            '}',
            '[',
            ']',
            '|',
            '\\',
            '/',
            ':',
            ';',
            '\"',
            '\'',
            '<',
            '>',
            ',',
            '.',
            '?'
        }.ToList();

        public bool done = false;

        private List<int> selectedElementsList = new List<int>();

        private char newItemCharacter = '\0';
        AddNewItem addNewItem;

        public SpecialCharactersEditor()
        {
            InitializeComponent();
        }

        private void SpecialCharactersEditor_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < specialCharacters.Count; i++)
            {
                listView1.Items.Add(specialCharacters[i].ToString());
            }
        }

        private void getSelectedItems()
        {
            selectedElementsList.Clear();

            for(int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected)
                {
                    selectedElementsList.Add(i);
                }
            }
        }
        
        private void changeBackgroundColorOfAllElements(Color color)
        {
            for(int i = 0; i < listView1.Items.Count; i++ ){
                listView1.Items[i].BackColor = color;
            }
        }

        private void changeBackgroundColorOfSelectedElements(Color color)
        {
            getSelectedItems();

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                for (int j = 0; j < selectedElementsList.Count; j++)
                {
                    if (i == selectedElementsList[j])
                    {
                        listView1.Items[i].BackColor = color;
                    }
                }
            }
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            changeBackgroundColorOfAllElements(Color.White);
            changeBackgroundColorOfSelectedElements(Color.LightBlue);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            getSelectedItems();
                for (int j = 0; j < selectedElementsList.Count; j++)
                { 
                        listView1.Items[selectedElementsList[j]].Remove();
                }
            
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SpecialCharactersEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                specialCharacters.Add(char.Parse(listView1.Items[i].Text));
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            addNewItem = new AddNewItem();
            addNewItem.FormClosing += new FormClosingEventHandler(AddNewItem_FormClosing);
            addNewItem.ShowDialog();
        }

        private void AddNewItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            newItemCharacter = addNewItem.character;

            bool charactersOverlap = false;

            for(int i = 0; i < listView1.Items.Count; i++) 
            {
                if (char.Parse(listView1.Items[i].Text) == newItemCharacter)  //comment in memory of my very dumb idea:  if (char.Parse(new string(listView1.Items[i].ToString().ToArray<char>()).Substring(0,0)) == newItemCharacter)
                {
                    MessageBox.Show("this item already exists!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    charactersOverlap = true;
                    break;
                }
            }

            if (charactersOverlap == false)
            {
                listView1.Items.Add(newItemCharacter.ToString());
            }
        }
    }    
}
