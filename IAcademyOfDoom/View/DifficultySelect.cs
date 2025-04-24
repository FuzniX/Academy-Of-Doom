using IAcademyOfDoom.Logic.GameSettings;
using System;
using System.Windows.Forms;

namespace IAcademyOfDoom.View
{
    public partial class DifficultySelect : Form
    {
        public Difficulty Difficulty { get { return difficultyListBox.SelectedItem is Difficulty difficulty ? difficulty : Logic.GameSettings.Difficulty.Easy; } }
        public string InputName { get { return nameTextBox.Text; } }
        public DifficultySelect()
        {
            InitializeComponent();
            foreach (Difficulty difficulty in Enum.GetValues(typeof(Difficulty)))
            {
                difficultyListBox.Items.Add(difficulty);
            }
        }
    }
}
