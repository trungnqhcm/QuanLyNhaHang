﻿using QuanLyBanHangAPI.model;
using QuanLyBanHangClient.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyBanHangClient.AppUserControl.OrderTab.Models {
    /// <summary>
    /// Interaction logic for TableInfo.xaml
    /// </summary>
    public partial class TableInfo : UserControl {
        Table _table = null;
        public TableInfo(Table table) {
            InitializeComponent();
            this._table = table;
            reloadUI();
        }
        public Table TableData {
            get { return _table; }
        }
        public void reloadUI() {
            if(_table == null) {
                return;
            }
            double currentMoneyOfTable = 0;
            foreach(KeyValuePair<int, Order> entry in OrderManager.getInstance().OrderList) {
                if (entry.Value != null)
                {
                    var included = entry.Value.TableWithOrders.Any(t => t.TableId == TableData.Id);
                    if (included
                       && (entry.Value.MoneyReceive < entry.Value.BillMoney || entry.Value.BillMoney == 0))
                        {
                            currentMoneyOfTable += (double)(entry.Value.BillMoney - entry.Value.MoneyReceive);
                        }
                }
            }
            TextBlockTableId.Text = "Bàn số " + _table.TableId.ToString();
            if (currentMoneyOfTable > 0) {
                //ImageState.Source = (ImageSource)GridParent.FindResource("ImageGreenDot");
                GridParent.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4FB99F"));

                TextBlockState.Text = "Đang sử dụng";
                //TextBlockState.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF18FA00"));


                TextBlockMoney.Text = UtilFuction.formatMoney((decimal)currentMoneyOfTable) + " VND";
            } else {
                //ImageState.Source = (ImageSource)GridParent.FindResource("ImageGrayDot");

                TextBlockState.Text = "Chưa sử dụng";
                TextBlockState.Foreground = new SolidColorBrush(Colors.White);

                TextBlockMoney.Text = "Mở bàn";
            }
        }
    }
}
