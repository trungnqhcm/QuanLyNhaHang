﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

namespace QuanLyBanHangClient.AppUserControl.Custom {
    /// <summary>
    /// Interaction logic for ComboBoxRoundedImage.xaml
    /// </summary>
    public partial class ComboBoxRoundedImage : UserControl {
        Action<int> _selectedCB = null;
        bool _isChangeTextFromCode = false;
        public Size ImageSize { get; set; }
        public ComboBoxRoundedImage() {
            InitializeComponent();
            ImageSize = new Size(15, 15);
            //((ContentPresenter) ComboBoxData.FindName("ContentSite")).Visibility = Visibility.Hidden;
        }

        public void setSelectedCB(Action<int> selectedCB) {
            _selectedCB = selectedCB;
        }

        public ComboBoxItem addItem(string txt, ImageSource imgSrc) {
            var item = createItem(txt, imgSrc);
            item.Tag = ComboBoxData.Items.Count;
            ComboBoxData.Items.Add(item);
            return item;
        }
        public void clear() {
            ComboBoxData.Items.Clear();
            clearSearch();
        }

        private void clearSearch() {
            _isChangeTextFromCode = true;
            TextBoxSearch.Text = "";
            ImageSearch.Source = null;
        }
        private ComboBoxItem createItem(string txt, ImageSource imgSrc) {
            var item = new ComboBoxItem();
            item.Style = (Style) Application.Current.FindResource("ComboBoxItemRoundedStyle");

            var dock = new DockPanel();

            var txtBlock = new TextBlock();
            txtBlock.Name = "TextBlockData";
            txtBlock.HorizontalAlignment = HorizontalAlignment.Center;
            txtBlock.VerticalAlignment = VerticalAlignment.Center;
            txtBlock.TextWrapping = TextWrapping.Wrap;
            txtBlock.Text = txt;
            dock.Children.Add(txtBlock);

            item.Content = dock;
            return item;
        }
        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e) {
            TextBox textBoxName = (TextBox)sender;
            string filterText = textBoxName.Text;

            ICollectionView cv = CollectionViewSource.GetDefaultView(ComboBoxData.Items);
            cv.Filter = o => {
                /* change to get data row value */
                ComboBoxItem p = o as ComboBoxItem;
                var txt = ((TextBlock)((DockPanel)p.Content).Children[0]).Text;

                if (!string.IsNullOrEmpty(filterText)
                && !_isChangeTextFromCode) {
                    return (txt.ToUpper().Contains(filterText.ToUpper()));
                } else {
                    return true;
                }
                /* end change to get data row value */
            };
            _isChangeTextFromCode = false;
        }

        private void ComboBoxData_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ComboBoxData.SelectedIndex < 0) {
                clearSearch();
                return;
            }

            var itemSelected = ((ComboBoxItem)ComboBoxData.SelectedItem);
            var txt = ((TextBlock)((DockPanel)itemSelected.Content).Children[0]).Text;

            _isChangeTextFromCode = true;
            TextBoxSearch.Text = txt;

            _selectedCB?.Invoke(ComboBoxData.SelectedIndex);
        }


        private void ComboBoxData_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key >= Key.Space && e.Key <= Key.Z) {

                var ch = (char)KeyInterop.VirtualKeyFromKey(e.Key);
                var caret = TextBoxSearch.CaretIndex;
                //TextBoxSearch.Text.Insert(caret, ch.ToString());
                //TextBoxSearch.Text += e.Key.ToString();

                TextBoxSearch.AppendText(ch.ToString());

                //var val = Encoding.Default.GetString(Encoding.Convert(Encoding.Unicode, Encoding.Default, unicode.GetBytes(TextBoxSearch.Text)));

                //byte[] bytes = Encoding.UTF8.GetBytes(UniCodeFeld1.Text);
                //Encoding enc = Encoding.GetEncoding("Windows-1252");
                //string asd = enc.GetString();
            } else if(e.Key == Key.Back
                && !TextBoxSearch.Text.Equals("")) {
                TextBoxSearch.Text = TextBoxSearch.Text.Substring(0, TextBoxSearch.Text.Length - 1);
            }

            //var ch = (char)KeyInterop.VirtualKeyFromKey(e.Key);
            //if (!char.IsLetter(ch)) { return; }

            //bool upper = false;
            //if (Keyboard.IsKeyToggled(Key.Capital) || Keyboard.IsKeyToggled(Key.CapsLock)) {
            //    upper = !upper;
            //}
            //if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) {
            //    upper = !upper;
            //}
            //if (!upper) {
            //    ch = char.ToLower(ch);
            //}

            //var box = TextBoxSearch;
            //var text = box.Text;
            //var caret = box.CaretIndex;

            ////string urdu = AsciiToUrdu(e.Key);
            //byte[] bytes = Encoding.UTF8.GetBytes(ch);
            //Encoding enc = Encoding.GetEncoding("Windows-1258");
            //string asd = enc.GetString();

            ////string urdu = ASCIIEncoding.  (ch);

            ////Update the TextBox' text..
            //box.Text = text.Insert(caret, urdu);
            ////..move the caret accordingly..
            //box.CaretIndex = caret + urdu.Length;
            ////..and make sure the keystroke isn't handled again by the TextBox itself:
            //e.Handled = true;
        }
    }
}
