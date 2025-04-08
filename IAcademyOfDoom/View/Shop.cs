using IAcademyOfDoom.App;
using IAcademyOfDoom.Logic.Places;
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
    public partial class Shop : Form
    {
        private List<Buyable> buyables;
        private Controller controller;
        public Shop(Controller c)
        {
            InitializeComponent();
            controller = c;
            this.buyablesList.Items.AddRange(controller.Buyables().ToArray());

        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            Buyable selectedBuyable = GetSelectedBuyable();
            int price = selectedBuyable.getPrice();
            if (controller.GetAvailableMoney() >= price)
            {
                controller.UpdateAvailableMoney(price);
                controller.AddPlaceable(selectedBuyable.MakePlaceable());
                Refresh();
            } else
            {
                MessageBox.Show("Not enough money on account");
            }
        }

        private Buyable GetSelectedBuyable()
        {
            foreach(Buyable buyable in controller.Buyables())
            {
                string name = this.buyablesList.SelectedItem.ToString();
                if (buyable.getName().Equals(name))
                {
                    return buyable;
                    
                }
            }
            return null;
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void closeButton_Paint(object sender, PaintEventArgs e)
        {
           
            this.moneyAmountLabel.Text = "" + controller.GetAvailableMoney();
        }
    }
}
