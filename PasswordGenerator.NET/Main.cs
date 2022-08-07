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
    public partial class Main : Form
    {
        List<Panel> squareImages = new List<Panel>();

        private List<char> specialCharactersList = new List<char>();

        SpecialCharactersEditor editor;

        string generatedPassword = "";

        public Main()
        {
            InitializeComponent();

            //create timer for square images to be equal
            Timer squareImagesTimer = new Timer();
            squareImagesTimer.Interval = 100;
            squareImagesTimer.Tick += new EventHandler(squareImagesTimer_Tick);
            squareImagesTimer.Start();

            //add logo to square images list to change its size activelly
            squareImages.Add(logo1);
        }

        private void generatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generatedPassword = generate();

            MessageBox.Show(generatedPassword);
        }


        private string generate()
        {
            long length = long.Parse(lengthInput.Value.ToString());
            string outputPassword  = "";

            List<int> actions = new List<int>();

            if (length <= 1000)
            {

                for (int i = 0; i < length; i++)
                {
                    if (letterRadio1.Checked) //uppercase and lowercase letters
                    {
                        actions.Add(1);
                    }
                    else if (letterRadio2.Checked) //uppercase letters only
                    {
                        actions.Add(2);
                    }
                    else if (letterRadio3.Checked) //lowercase letters only
                    {
                        actions.Add(3);
                    }
                    else if (letterRadio4.Checked) //no letters
                    {
                        actions.Add(4);
                    }
                    if (numbersCheckbox.Checked)
                    {
                        actions.Add(5);
                    }
                    if (specialCheckbox.Checked)
                    {
                        actions.Add(6);
                    }
                    

                    int randomNumbers = new Random().Next(0, actions.Count);

                    if(actions[randomNumbers] == 1)
                    {
                        if(new Random().Next(0,1) > 0)
                        {
                            outputPassword += char.ToUpper(randomAlphabet());
                        }
                        else
                        {
                            outputPassword += char.ToLower(randomAlphabet());
                        }
                    }
                    else if(actions[randomNumbers] == 2)
                    {
                        outputPassword += char.ToUpper(randomAlphabet());
                    }
                    else if(actions[randomNumbers] == 3) 
                    {
                        outputPassword += char.ToLower(randomAlphabet());
                    }
                    else if(actions[randomNumbers] == 4)
                    {
                        outputPassword += "_";
                    }
                    else if(actions[randomNumbers] == 5)
                    {
                        outputPassword += new Random().Next(0, 9).ToString();
                    }
                    else if(actions[randomNumbers] == 6)
                    {
                        outputPassword += randomSpecialCharacter();
                    }
                    
                }

                return outputPassword;

            }
            else
            {
                MessageBox.Show("sorry, maximum length is 1000", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //return "error";
        }

        private void generateMultiple()
        {

        }

        private void generateMultiplePasswordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateMultiple();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void squareImagesTimer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < squareImages.Count; i++)
            {
                squareImages[i].Size = new Size(squareImages[i].Size.Width, squareImages[i].Size.Width);
            }
        }

        private void GeneratePassword_Click(object sender, EventArgs e)
        {
            generateMultiplePasswordsToolStripMenuItem_Click((object)sender, new EventArgs());
        }

        private char randomAlphabet()
        {
            char character = '\0';

            List<char> alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' }.ToList<char>();
            
            return alphabet[new Random().Next(0,alphabet.Count)];
        }

        private char randomSpecialCharacter()
        {
            char character = '\0';

            character = specialCharactersList[new Random().Next(0, specialCharactersList.Count)];


            return character;
        }

        private void EditSpecialCharactersButton_Click(object sender, EventArgs e)
        {
            editor = new SpecialCharactersEditor();
            editor.FormClosing += new FormClosingEventHandler(SpecialCharactersEditor_formCosing);
            editor.ShowDialog();
        }

        private void SpecialCharactersEditor_formCosing(object sender, FormClosingEventArgs e) 
        {
            specialCharactersList.Clear();
            for(int i = 0; i < editor.specialCharacters.Count; i++)
            {
                specialCharactersList.Add(editor.specialCharacters[i]);
            }
        }
    }
}