using HelloWorld;
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

namespace FlashcardProgram
{
    public partial class PharmacyForm : Form
    {
        public string[] cardfiles;
    public PharmacyForm()
        {

            InitializeComponent();
            cardfiles = Deck.getCardFiles();
            this.listBox1.Items.AddRange(cardfiles);
            this.listBox1.SetSelected(0, true);
            this.radioButton1.Select();
            ChangeFilename();
        }

        

        private void ChangeFilename()
        {

            string filename = this.listBox1.SelectedItem.ToString();
            if (this.radioButton1.Checked) currentDeck = Deck.GetRandomizedDeck(filename);
            else if (this.radioButton2.Checked) currentDeck = Deck.GetRandomizedDeck(filename);
            else currentDeck = Deck.GetRandomizedDeck(filename);
            DisplayFC();
        }

        public Deck currentDeck { get;  set; }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == rightAnswer) points++;
                DisplayFC();
                richTextBox1.Text = points.ToString();
            }
        }

        private void DisplayFC()
        {
            if (this.radioButton1.Checked) currentDeck.Get1FC(this, 0);
            else if (this.radioButton2.Checked)
            {
                currentDeck.Get1FC(this, 1);
                this.label1.Text = currentDeck.Title + " Index: " + currentDeck.index;
            }
        }

        private void PharmacyForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFilename();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFilename();
        }
    }
}
