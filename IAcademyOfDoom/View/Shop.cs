﻿using IAcademyOfDoom.App;
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
            

        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            Buyable selectedBuyable = GetSelectedBuyable();
            int price = selectedBuyable.getPrice();
            if (controller.GetAvailableMoney() >= price && selectedBuyable.getQuantity() > 0)
            {
                controller.UpdateAvailableMoney(price);
                controller.AddPlaceable(selectedBuyable.MakePlaceable());
                selectedBuyable.decrementQuantity();
                Refresh();
            } else
            {
                MessageBox.Show("Cannot buy this room");
            }
        }

        private Buyable GetSelectedBuyable()
        {
            string name = this.buyablesList.SelectedItem.ToString().Split('-')[0];
            foreach (Buyable buyable in controller.Buyables())
            {
                if(buyable.getName() == name)
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
            this.buyablesList.Items.Clear();
            this.buyablesList.Items.AddRange(controller.Buyables().ToArray());
        }
    }
}
