﻿using QuanLyBanHangAPI.model;
using QuanLyBanHangClient.AppUserControl.OrderAndTable;
using QuanLyBanHangClient.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyBanHangClient.AppUserControl.OrderTab.Models
{
    /// <summary>
    /// Interaction logic for OrderInfo.xaml
    /// </summary>
    public partial class OrderInfo : UserControl
    {
        public OrderTab orderTab { get; set; }
        public OrderHistoryTab orderHistoryTab { get; set; }
        public int OrderId { get; set; }
        public OrderInfo(int orderId, OrderTab _orderTab, OrderHistoryTab _orderHistoryTab = null)
        {
            InitializeComponent();
            OrderId = orderId;
            orderTab = _orderTab;
            orderHistoryTab = _orderHistoryTab;
            ComboBoxSelectFood.TextBoxSearch.FontSize = 11;
            reloadAllUI();
        }
        public decimal billMoney = 0;

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void updateFoodWithOrderAndReloadUI() {
            RequestManager.getInstance().showLoading();
            Action<NetworkResponse> cbSuccessSent =
                    delegate (NetworkResponse networkResponse) {
                        if (!networkResponse.Successful) {
                            WindownsManager.getInstance().showMessageBoxSomeThingWrong();
                        } else {
                            reloadAllUI();
                        }
                        RequestManager.getInstance().hideLoading();
                    };

            Action<string> cbError =
                    delegate (string err) {
                        WindownsManager.getInstance().showMessageBoxErrorNetwork();
                        RequestManager.getInstance().hideLoading();
                    };
            var listFoodWithOrders = new List<FoodWithOrder>();
            foreach (OrderWithFood orderWithFood in listViewOrderWithFood.Items.OfType<OrderWithFood>()) {
                var newQuantity = orderWithFood._foodWithOrder.Quantities;
                int.TryParse(orderWithFood.TextBoxQuantity.Text, out newQuantity);
                listFoodWithOrders.Add(new FoodWithOrder() {
                    FoodId = orderWithFood._foodWithOrder.FoodId,
                    Quantities = newQuantity
                });

            }
            OrderManager.getInstance().updateOrderWithFoodsFromServerAndUpdate(
                OrderId,
                listFoodWithOrders,
                cbSuccessSent,
                cbError
                );
        }
        public void reloadLVOrderWithFood() {
            listViewOrderWithFood.Items.Clear();
            var order = OrderManager.getInstance().OrderList[OrderId];
            foreach (FoodWithOrder foodWithOrder in order.FoodWithOrders) {
                var newItem = new OrderWithFood(foodWithOrder, this);
                listViewOrderWithFood.Items.Add(newItem);
                if(orderHistoryTab != null) {
                    newItem.BtnRemove.Visibility = Visibility.Hidden;
                    newItem.TextBoxQuantity.IsReadOnly = true;
                }
            }
        }
        public void reloadAllUI() {
            reloadLVOrderWithFood();
            var order = OrderManager.getInstance().OrderList[OrderId];
            TextBlockHeader.Text = "Order " + OrderId;
            billMoney = order.BillMoney;

            BtnAccept.Visibility = Visibility.Hidden;
            BtnCancel.Visibility = Visibility.Hidden;

            foreach (KeyValuePair<int, Food> entry in FoodManager.getInstance().FoodList) {
                if (entry.Value != null) {
                    bool isContinue = false;
                    foreach(FoodWithOrder foodWithOrder in order.FoodWithOrders) {
                        if(foodWithOrder.FoodId == entry.Value.FoodId) {
                            isContinue = true;
                        }
                    }
                    if(isContinue) {
                        continue;
                    }


                    string txt = entry.Value.FoodId + " - " + entry.Value.Name;
                    var imgSrc = (ImageSource)Application.Current.FindResource("ImageDefaultFood");
                    if (entry.Value.ImageId != null) {
                        byte[] imgData = null;
                        ImageManager.getInstance().loadImageFromLocal(entry.Value.ImageId ?? default(int), out imgData);
                        if (imgData != null) {
                            var img = UtilFuction.ByteToImage(imgData);
                            imgSrc = UtilFuction.imageToBitmapSource(img);
                        }
                    }
                    var item = ComboBoxSelectFood.addItem(txt, imgSrc);
                    item.Tag = entry.Value.FoodId;
                }
            }
            onChangeMoney();


            if (orderHistoryTab != null) {
                BtnAddFood.Visibility = Visibility.Hidden;
                TextBlockHeader.Text += ("  -  " + order.CreatedDate.ToShortDateString()) + "  -  " + UtilFuction.formatMoney(billMoney) + " VND";
            }
        }
        public void checkAndAddFoodIdToComboBox(int foodId) {
            foreach(ComboBoxItem comboData in ComboBoxSelectFood.ComboBoxData.Items) {
                if((int)comboData.Tag == foodId) {
                    return;
                }
            }
            var foodData = FoodManager.getInstance().FoodList[foodId];
            string txt = foodData.FoodId + " - " + foodData.Name;
            var imgSrc = (ImageSource)Application.Current.FindResource("ImageDefaultFood");
            if (foodData.ImageId != null) {
                byte[] imgData = null;
                ImageManager.getInstance().loadImageFromLocal(foodData.ImageId ?? default(int), out imgData);
                if (imgData != null) {
                    var img = UtilFuction.ByteToImage(imgData);
                    imgSrc = UtilFuction.imageToBitmapSource(img);
                }
            }
            var item = ComboBoxSelectFood.addItem(txt, imgSrc);
            item.Tag = foodData.FoodId;
        }
        public void checkAndRemoveFoodIdToComboBox(int foodId) {
            foreach (ComboBoxItem comboData in ComboBoxSelectFood.ComboBoxData.Items) {
                if ((int)comboData.Tag == foodId) {
                    ComboBoxSelectFood.ComboBoxData.Items.Remove(comboData);
                    return;
                }
            }
        }
        public void onEditOrderWithFood(
            OrderWithFood orderWithFood
            ) {
            BtnAccept.Visibility = Visibility.Visible;
            BtnCancel.Visibility = Visibility.Visible;
        }
        public void onRemoveOrderWithFood(
            OrderWithFood orderWithFood
            ) {
            BtnAccept.Visibility = Visibility.Visible;
            BtnCancel.Visibility = Visibility.Visible;

            listViewOrderWithFood.Items.Remove(orderWithFood);
            checkAndAddFoodIdToComboBox(orderWithFood._foodWithOrder.FoodId);
        }
        public void onChangeMoney() {
            decimal totalBill = 0;
            foreach(OrderWithFood orderWithFood in listViewOrderWithFood.Items.OfType<OrderWithFood>()) {
                decimal money = 0;
                decimal.TryParse(orderWithFood.textBlockTotal.Text, out money);
                totalBill += money;
            }
            TextBlockTotalOrder.Text = "Tổng cộng " + UtilFuction.formatMoney(totalBill);
            billMoney = totalBill;
            if(orderTab != null) {
                orderTab.onChangeMoney();
            }
        }

        private void BtnAddFood_Click(object sender, RoutedEventArgs e) {
            AddFoodGroup.Visibility = Visibility.Visible;
            BtnAccept.Opacity = 0;
            BtnCancel.Opacity = 0;
        }
        private void BtnAccept_Click(object sender, RoutedEventArgs e) {
            updateFoodWithOrderAndReloadUI();
        }

        private void BtnConfirmAdd_Click(object sender, RoutedEventArgs e) {
            var quantity = 0;
            if(ComboBoxSelectFood.ComboBoxData.SelectedIndex < 0
                || !int.TryParse(TextBoxQuantity.Text, out quantity)) {
                return;
            }
            var foodId = (int)((ComboBoxItem)ComboBoxSelectFood.ComboBoxData.SelectedItem).Tag;
            listViewOrderWithFood.Items.Add(new OrderWithFood(new FoodWithOrder {
                Food = FoodManager.getInstance().FoodList[foodId],
                FoodId = foodId,
                Quantities = quantity
            }, this));
            checkAndRemoveFoodIdToComboBox(foodId);
            BtnAccept.Visibility = Visibility.Visible;
            BtnCancel.Visibility = Visibility.Visible;
            onChangeMoney();
        }

        private void BtnConfirmExit_Click(object sender, RoutedEventArgs e) {
            AddFoodGroup.Visibility = Visibility.Hidden;
            BtnAccept.Opacity = 1;
            BtnCancel.Opacity = 1;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) {
            reloadAllUI();
            BtnAccept.Visibility = Visibility.Hidden;
            BtnCancel.Visibility = Visibility.Hidden;
        }
    }
}
