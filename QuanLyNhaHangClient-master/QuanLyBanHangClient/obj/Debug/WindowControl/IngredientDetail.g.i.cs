﻿#pragma checksum "..\..\..\WindowControl\IngredientDetail.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1DC4C06D67655CC5738EA6ABF837C18330CC896D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LoadingPanelSample.Controls;
using QuanLyBanHangClient.WindowControl;
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


namespace QuanLyBanHangClient.WindowControl {
    
    
    /// <summary>
    /// IngredientDetail
    /// </summary>
    public partial class IngredientDetail : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\WindowControl\IngredientDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockNameWindow;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\WindowControl\IngredientDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxId;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\WindowControl\IngredientDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxName;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\WindowControl\IngredientDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxUnit;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\WindowControl\IngredientDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnConfirm;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\WindowControl\IngredientDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid loadingAnim;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\WindowControl\IngredientDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LoadingPanelSample.Controls.CircularProgressBar progressBar;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyBanHangClient;component/windowcontrol/ingredientdetail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowControl\IngredientDetail.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.TextBlockNameWindow = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TextBoxId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ComboBoxUnit = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.BtnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\WindowControl\IngredientDetail.xaml"
            this.BtnConfirm.Click += new System.Windows.RoutedEventHandler(this.BtnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.loadingAnim = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.progressBar = ((LoadingPanelSample.Controls.CircularProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

