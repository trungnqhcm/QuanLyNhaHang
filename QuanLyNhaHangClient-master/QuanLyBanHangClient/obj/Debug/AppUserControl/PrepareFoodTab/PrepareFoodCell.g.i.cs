﻿#pragma checksum "..\..\..\..\AppUserControl\PrepareFoodTab\PrepareFoodCell.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "072B3F2778247A607962670D2B49FA6F455AB714"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QuanLyBanHangClient.AppUserControl.PrepareFoodTab;
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


namespace QuanLyBanHangClient.AppUserControl.PrepareFoodTab {
    
    
    /// <summary>
    /// PrepareFoodCell
    /// </summary>
    public partial class PrepareFoodCell : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\AppUserControl\PrepareFoodTab\PrepareFoodCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridParent;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\AppUserControl\PrepareFoodTab\PrepareFoodCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageFood;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\AppUserControl\PrepareFoodTab\PrepareFoodCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockName;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\AppUserControl\PrepareFoodTab\PrepareFoodCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockTableId;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\AppUserControl\PrepareFoodTab\PrepareFoodCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageState;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\AppUserControl\PrepareFoodTab\PrepareFoodCell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxState;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyBanHangClient;component/appusercontrol/preparefoodtab/preparefoodcell.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\AppUserControl\PrepareFoodTab\PrepareFoodCell.xaml"
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
            this.GridParent = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.ImageFood = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.TextBlockName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TextBlockTableId = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.ImageState = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.ComboBoxState = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\..\AppUserControl\PrepareFoodTab\PrepareFoodCell.xaml"
            this.ComboBoxState.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxState_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

