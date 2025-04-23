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
        private Controller controller;
        public Shop(Controller c)
        {
            InitializeComponent();
            controller = c;
            

        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            Buyable selectedBuyable = GetSelectedBuyable();
            if(selectedBuyable != null)
            {
                int price = selectedBuyable.getPrice();
                if (controller.GetAvailableMoney() >= price && selectedBuyable.getQuantity() > 0)
                {
                    controller.UpdateAvailableMoney(price);
                    if(!selectedBuyable.isAction)
                    {
                        controller.AddPlaceable(selectedBuyable.MakePlaceable());
                    }
                    if (selectedBuyable.isAction)
                    {
                        controller.AddAction(new PlaceableAction(selectedBuyable.actionType, selectedBuyable.getName(), selectedBuyable.Skill));
                    }

                    selectedBuyable.decrementQuantity();
                    controller.RefreshMainWindow();
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Cannot buy this item");
                }
            } else
            {
                MessageBox.Show("Select item first");
            }
            
        }

        private Buyable GetSelectedBuyable()
        {
            if(this.buyablesList.SelectedItem != null)
            {
                string name = this.buyablesList.SelectedItem.ToString().Split('-')[0];
                foreach (Buyable buyable in controller.Buyables())
                {
                    if (buyable.getName() == name)
                    {
                        return buyable;
                    }
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
            this.buyablesList.Items.Clear();
            this.buyablesList.Items.AddRange(controller.Buyables().ToArray());
        }
    }
}
