using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using WordChains;

namespace WordChainsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            var startWord = this.txtFrom.Text.Trim().ToUpper();
            var endWord = this.txtTo.Text.Trim().ToUpper();

            var chains = new Chains()
            {
                Dictionary = GetDictionary()
            };
            var chain = chains.Create(startWord, endWord);

            this.lblAnswer.Text = chain;
        }

        private HashSet<string> GetDictionary()
        {
            return new HashSet<string>(System.IO.File.ReadAllLines(@"words.txt").Select(a=>a.ToUpper()));
        }
    }
}
