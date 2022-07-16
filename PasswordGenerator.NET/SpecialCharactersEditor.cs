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

        public SpecialCharactersEditor()
        {
            InitializeComponent();
        }

        private void SpecialCharactersEditor_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < specialCharacters.Count; i++)
            {
                treeView1.Nodes.Add(specialCharacters[i].ToString());
            }
        }
    }
}
