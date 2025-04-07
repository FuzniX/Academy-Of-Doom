using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAcademyOfDoom.View
{
    public partial class ResultPhase : Form
    {
        private int successCount;
        private int failureCount;
        private int deathsCount;
        public ResultPhase((int successes, int failures, int deaths) results)
        {
            InitializeComponent();
            this.successCount = results.successes;
            this.failureCount = results.failures;
            this.deathsCount = results.deaths;
        }

        private void ResultPhase_Paint(object sender, PaintEventArgs e)
        {
            this.successCountLabel.Text = ""+successCount;
            this.failuresCountLabel.Text = ""+failureCount;
            this.deathsCountLabel.Text = ""+deathsCount;
        }

        private void resultOkBtn_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
