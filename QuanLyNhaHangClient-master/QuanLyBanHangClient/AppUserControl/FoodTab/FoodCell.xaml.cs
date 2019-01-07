﻿using QuanLyBanHangAPI.model;
using QuanLyBanHangClient.Manager;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyBanHangClient.AppUserControl.FoodTab
{
    /// <summary>
    /// Interaction logic for FoodCell.xaml
    /// </summary>
    public partial class FoodCell : UserControl
    {
        public Food FoodData { get; set; }
        FoodTab _foodTab;
        public FoodCell()
        {
            InitializeComponent();
        }
        public FoodCell(
            Food food,
            FoodTab foodTab
            ) {
            InitializeComponent();
            FoodData = food;
            _foodTab = foodTab;
            setupUI();
        }

        private void setupUI() {
            if(FoodData == null) {
                return;
            }
            TextBlockName.Text = FoodData.FoodId + " - " + FoodData.Name;
            TextBlockPrice.Text = UtilFuction.formatMoney(FoodData.Price) + " vnđ";
            TextBlockCategory.Text = FoodCategorizeManager.getInstance().FoodCategorizeList[FoodData.FoodCategorizeId].Name;
        }


        private void TextBlockName_MouseUp(object sender, MouseButtonEventArgs e) {

            if (_foodTab != null
                && FoodData != null) {
                _foodTab.showEditFoodView(FoodData.FoodId);
            }
        }
    }
}
