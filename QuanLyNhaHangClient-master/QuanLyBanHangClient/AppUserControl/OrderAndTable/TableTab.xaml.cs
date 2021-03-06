﻿using QuanLyBanHangAPI.model;
using QuanLyBanHangClient.AppUserControl.OrderTab.Models;
using QuanLyBanHangClient.Manager;
using QuanLyBanHangClient.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyBanHangClient.AppUserControl.OrderTab {
    /// <summary>
    /// Interaction logic for TableTab.xaml
    /// </summary>
    public partial class TableTab : UserControl {
        public OrderAndTableTab orderAndTableTab {
            get; set;
        }
        public TableTab() {
            InitializeComponent();
        }
        public void reloadLVTable() {
            LVTable.Items.Clear();
            var tableList = TableManager.getInstance().TableList;
            foreach (KeyValuePair<int, Table> entry in tableList) {
                if (entry.Value != null) {
                    var tableInfo = new TableInfo(entry.Value);
                    LVTable.Items.Add(tableInfo);
                }
            }
            BtnRemoveTable.IsEnabled = false;
            HistoryTab.reloadTable();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Table_DoubleClick(object sender, MouseButtonEventArgs e) {
            if(LVTable.SelectedIndex < 0) {
                return;
            }
            TableInfo tableInfo = (TableInfo) LVTable.SelectedItem;
            orderAndTableTab.OrderTabCustom.reloadAllUIOrderTab(tableInfo.TableData);
            orderAndTableTab.OrderTabCustom.Visibility = System.Windows.Visibility.Visible;
            orderAndTableTab.TableTabCustom.Visibility = System.Windows.Visibility.Hidden;
           
        }

        private void LVTable_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(LVTable.SelectedItem == null) {
                return;
            }
            BtnRemoveTable.IsEnabled = true;
            TextBoxCurrentTableId.Text = ((TableInfo)LVTable.SelectedItem).TableData.TableId.ToString();
            BtnMerge.IsEnabled = true;
        }

        private void BtnAdd_Click(object sender, System.Windows.RoutedEventArgs e) {
            RequestManager.getInstance().showLoading();
            Action<NetworkResponse> cbSuccessSent =
                    delegate (NetworkResponse networkResponse) {
                        if (!networkResponse.Successful) {
                            WindownsManager.getInstance().showMessageBoxSomeThingWrong();
                        } else {
                            reloadLVTable();
                        }
                        RequestManager.getInstance().hideLoading();
                    };

            Action<string> cbError =
                    delegate (string err) {
                        WindownsManager.getInstance().showMessageBoxErrorNetwork();
                        RequestManager.getInstance().hideLoading();
                    };
            var tableIdCreate = 0;
            while (true) {
                if(!TableManager.getInstance().TableList.ContainsKey(tableIdCreate)) {
                    break;
                }
                tableIdCreate++;
            }
            TableManager.getInstance().createTableFromServerAndUpdate(
                tableIdCreate,
                cbSuccessSent,
                cbError
            );
        }

        private void BtnChangeTableId_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int newTableId = 0;
            if (!int.TryParse(TextBoxCurrentTableId.Text, out newTableId))
            {
                return;
            }
            int oldTableId = ((TableInfo)LVTable.SelectedItem).TableData.TableId;
            RequestManager.getInstance().showLoading();
            Action<NetworkResponse> cbSuccessSent =
                    delegate (NetworkResponse networkResponse) {
                        if (!networkResponse.Successful)
                        {
                            WindownsManager.getInstance().showMessageBoxSomeThingWrong();
                        }
                        else
                        {

                            foreach (KeyValuePair<int, Order> entry in OrderManager.getInstance().OrderList)
                            {
                                var table = ((List<TableWithOrder>)entry.Value.TableWithOrders).Find(t => t.TableId == oldTableId);
                                if (entry.Value != null
                                    && table != null)
                                {
                                    table.TableId = newTableId;
                                }
                            }
                            reloadLVTable();
                        }
                        RequestManager.getInstance().hideLoading();
                    };

            Action<string> cbError =
                    delegate (string err) {
                        WindownsManager.getInstance().showMessageBoxErrorNetwork();
                        RequestManager.getInstance().hideLoading();
                    };
            TableManager.getInstance().updateTableFromServerAndUpdate(
                oldTableId,
                newTableId,
                cbSuccessSent,
                cbError
            );
        }

        private void TextBoxCurrentTableId_TextChanged(object sender, TextChangedEventArgs e) {
            if (LVTable.SelectedIndex < 0) {
                return;
            }
            int newTableId = 0;
            int oldTableId = ((TableInfo)LVTable.SelectedItem).TableData.TableId;
            if (!int.TryParse(TextBoxCurrentTableId.Text, out newTableId)
                || newTableId == oldTableId) {
                BtnChangeTableId.IsEnabled = false;
                return;
            }
            BtnChangeTableId.IsEnabled = true;
        }

        private void BtnRefresh_Click(object sender, System.Windows.RoutedEventArgs e) {
            if(orderAndTableTab == null) {
                return;
            }
            orderAndTableTab.reloadOrderUI(true, delegate () {
                orderAndTableTab.reloadTableUI(true);
            });
        }

        private void BtnRemoveTable_Click(object sender, System.Windows.RoutedEventArgs e) {
            int oldTableId = ((TableInfo)LVTable.SelectedItem).TableData.TableId;
            RequestManager.getInstance().showLoading();
            Action<NetworkResponse> cbSuccessSent =
                    delegate (NetworkResponse networkResponse) {
                        if (!networkResponse.Successful) {
                            WindownsManager.getInstance().showMessageBoxSomeThingWrong();
                        } else {
                            reloadLVTable();
                        }
                        RequestManager.getInstance().hideLoading();
                    };

            Action<string> cbError =
                    delegate (string err) {
                        WindownsManager.getInstance().showMessageBoxErrorNetwork();
                        RequestManager.getInstance().hideLoading();
                    };
            TableManager.getInstance().deleteTableromServerAndUpdate(
                oldTableId,
                cbSuccessSent,
                cbError
            );
        }

        private void BtnHistory_Click(object sender, System.Windows.RoutedEventArgs e) {
            HistoryTab.reloadListViewOrder(false);
            HistoryTab.Visibility = System.Windows.Visibility.Visible;
        }

        private void BtnMerge_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var addButton = sender as FrameworkElement;
            int selectedId = ((TableInfo)LVTable.SelectedItem).TableData.Id;
            if (addButton != null)
            {
                addButton.ContextMenu.Items.Clear();
                var tableList = new Dictionary<int, Table>();
                foreach (var pair in OrderManager.getInstance().OrderList)
                {
                    var order = pair.Value;
                    if (order.BillMoney > 0)
                    {
                        foreach(var tb in order.TableWithOrders)
                        {
                            if (!tableList.ContainsKey(tb.TableId))
                            {
                                var tables = TableManager.getInstance().TableList;
                                Table table = new Table();
                                foreach (var t in tables)
                                {
                                    if (t.Value.Id == tb.TableId)
                                    {
                                        table = t.Value;
                                    }
                                }
                                tableList.Add(tb.TableId, table);
                            }
                        }
                    }
                }
                foreach (var table in tableList)
                {
                    var menuItem = new MenuItem();
                    menuItem.Header = "Bàn "+ table.Value.TableId;
                    menuItem.Tag = table.Value.Id;
                    menuItem.Click += MenuItem_Click;
                    addButton.ContextMenu.Items.Add(menuItem);
                }
              
                addButton.ContextMenu.IsOpen = true;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as FrameworkElement;
            int toMergeTableId = (int)menuItem.Tag;
            int fromMergeTableId = ((TableInfo)LVTable.SelectedItem).TableData.Id;
            RequestManager.getInstance().showLoading();
            Action<NetworkResponse> cbSuccessSent =
                    delegate (NetworkResponse networkResponse)
                    {
                        if (!networkResponse.Successful)
                        {
                            WindownsManager.getInstance().showMessageBoxSomeThingWrong();
                        }
                        else
                        {
                            orderAndTableTab.reloadOrderUI(true, delegate () {
                                orderAndTableTab.reloadTableUI(true);
                            });
                        }
                        RequestManager.getInstance().hideLoading();
                    };

            Action<string> cbError =
                    delegate (string err)
                    {
                        WindownsManager.getInstance().showMessageBoxErrorNetwork();
                        RequestManager.getInstance().hideLoading();
                    };


            OrderManager.getInstance().mergeTableFromServerAndUpdate(
                fromMergeTableId,
                toMergeTableId,
                cbSuccessSent,
                cbError
            );
        }
    }
}
