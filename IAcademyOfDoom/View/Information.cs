using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IAcademyOfDoom.Logic.Skills;

namespace IAcademyOfDoom.View
{
    public partial class Information: Form
    {
        public Information()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Information_Paint(object sender, PaintEventArgs e)
        {
            int y = 20;
            foreach (SkillType skill in SkillTypeUtils.AllCombinatedSkills())
            {
                DrawSkill(e.Graphics, skill, y);
                y += Settings.SkillOffset.Height * 3;
            }
            foreach (SkillType skill in SkillTypeUtils.AllBaseSkills())
            {
                DrawSkill(e.Graphics, skill, y);
                y += Settings.SkillOffset.Height * 3;
            }
        }

        private void DrawSkill(Graphics g, SkillType skill, int y)
        {
            int x = 390;
            Point p = new Point(x + Settings.SkillOffset.Width * 2, y);
            Rectangle r = new Rectangle(x, y, Settings.SkillSide, Settings.SkillSide);
            g.FillRectangle(Settings.GetSkillColourFor(skill), r);
            g.DrawString(skill.ToString(), Settings.RoomFont, Settings.TextBrush, p);
        }
    }
}
