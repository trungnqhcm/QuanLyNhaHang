﻿#pragma checksum "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DBAE082C935B722389AF38827829381537B4C7E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QuanLyBanHangClient.AppUserControl.OrderAndTable;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Custom;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace QuanLyBanHangClient.AppUserControl.OrderAndTable {
    
    
    /// <summary>
    /// OrderHistoryTab
    /// </summary>
    public partial class OrderHistoryTab : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnFilterOrder;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRemoveOrder;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxSelectTables;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVFilterTable;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxFilterDate;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel FilterDateGroup;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePickerFrom;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePickerTo;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVOrderInfo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuanLyBanHangClient;component/appusercontrol/orderandtable/orderhistorytab.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnFilterOrder = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
            this.BtnFilterOrder.Click += new System.Windows.RoutedEventHandler(this.BtnFilterOrder_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnRemoveOrder = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
            this.BtnRemoveOrder.Click += new System.Windows.RoutedEventHandler(this.BtnRemoveOrder_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CheckBoxSelectTables = ((System.Windows.Controls.CheckBox)(target));
            
            #line 59 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
            this.CheckBoxSelectTables.Checked += new System.Windows.RoutedEventHandler(this.CheckBoxSelectTables_Checked);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
            this.CheckBoxSelectTables.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBoxSelectTables_Unchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LVFilterTable = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.CheckBoxFilterDate = ((System.Windows.Controls.CheckBox)(target));
            
            #line 63 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
            this.CheckBoxFilterDate.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBoxFilterDate_Unchecked);
            
            #line default
            #line hidden
            
            #line 63 "..\..\..\..\AppUserControl\OrderAndTable\OrderHistoryTab.xaml"
            this.CheckBoxFilterDate.Checked += new System.Windows.RoutedEventHandler(this.CheckBoxFilterDate_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FilterDateGroup = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.DatePickerFrom = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.DatePickerTo = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.LVOrderInfo = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

