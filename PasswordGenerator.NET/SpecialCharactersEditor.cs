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

        private List<int> selectedElementsList = new List<int>();

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
    }    
}
