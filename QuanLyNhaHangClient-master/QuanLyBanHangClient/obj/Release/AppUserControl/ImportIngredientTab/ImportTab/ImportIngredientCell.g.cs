﻿#pragma checksum "..\..\..\..\..\AppUserControl\ImportIngredientTab\ImportTab\ImportIngredientCell.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5D0912AE6AA6CBD1024651DC0E74EAC5D16AE88F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QuanLyBanHangClient.AppUserControl.ImportIngredientTab.ImportTab;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
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


namespace QuanLyBanHangClient.AppUserControl.ImportIngredientTab.ImportTab {
    
    
    /// <summary>
    /// ImportIngredientCell
    /// </summary>
    public partial class ImportIngredientCell : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\AppUserControl\ImportIngredientTab\ImportTab\ImportIngredientCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockIngredient;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\AppUserControl\ImportIngredientTab\ImportTab\ImportIngredientCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockPrice;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\AppUserControl\ImportIngredientTab\ImportTab\ImportIngredientCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockQuantity;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\AppUserControl\ImportIngredientTab\ImportTab\ImportIngredientCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockTotal;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\AppUserControl\ImportIngredientTab\ImportTab\ImportIngredientCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRemove;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyBanHangClient;component/appusercontrol/importingredienttab/importtab/impor" +
                    "tingredientcell.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\AppUserControl\ImportIngredientTab\ImportTab\ImportIngredientCell.xaml"
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
            
            #line 8 "..\..\..\..\..\AppUserControl\ImportIngredientTab\ImportTab\ImportIngredientCell.xaml"
            ((QuanLyBanHangClient.AppUserControl.ImportIngredientTab.ImportTab.ImportIngredientCell)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.UserControl_MouseEnter);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\..\..\AppUserControl\ImportIngredientTab\ImportTab\ImportIngredientCell.xaml"
            ((QuanLyBanHangClient.AppUserControl.ImportIngredientTab.ImportTab.ImportIngredientCell)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.UserControl_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBlockIngredient = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TextBlockPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TextBlockQuantity = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TextBlockTotal = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.BtnRemove = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\..\AppUserControl\ImportIngredientTab\ImportTab\ImportIngredientCell.xaml"
            this.BtnRemove.Click += new System.Windows.RoutedEventHandler(this.BtnRemove_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

