using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using WordChains;
using System.Diagnostics;

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


            var sw = new Stopwatch();
            sw.Start();

            var chains = new DepthChains()
            {
                Dictionary = GetDictionary(startWord.Length)
            };

            var chain = chains.Create(startWord, endWord);
            sw.Stop();

            this.lblAnswer.Text = "Depth :: " + chain + $" ({Math.Round(sw.Elapsed.TotalSeconds, 2)}s)";
        }

        private HashSet<string> GetDictionary(int wordLength)
        {
            return new HashSet<string>(System.IO.File.ReadAllLines(@"words.txt").Where(a => a.Length == wordLength).Select(a => a.ToUpper()));
        }

        private void cmdBreadth_Click(object sender, EventArgs e)
        {
            var startWord = this.txtFrom.Text.Trim().ToUpper();
            var endWord = this.txtTo.Text.Trim().ToUpper();


            var sw = new Stopwatch();
            sw.Start();

            var chains = new BreadthChains()
            {
                Dictionary = GetDictionary(startWord.Length)
            };

            var chain = chains.Create(startWord, endWord);
            sw.Stop();

            this.lblAnswer.Text = "Breadth :: " + chain + $" ({Math.Round(sw.Elapsed.TotalSeconds, 2)}s)";
        }
    }
}
