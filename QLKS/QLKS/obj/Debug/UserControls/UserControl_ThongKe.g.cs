﻿#pragma checksum "..\..\..\UserControls\UserControl_ThongKe.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7F6F2A0F32A97B44B8FDCA1E9AE7AE87E7C8490A129D0A4DE159ECBEE2F5E76C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using QLKS.UserControls;
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


namespace QLKS.UserControls {
    
    
    /// <summary>
    /// UserControl_ThongKe
    /// </summary>
    public partial class UserControl_ThongKe : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\UserControls\UserControl_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbChonThang;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\UserControl_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbChonNam;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\UserControls\UserControl_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtDoanhThu;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\UserControls\UserControl_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtSoLuong;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\UserControls\UserControl_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTitle;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\UserControls\UserControl_ThongKe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvThongKe;
        
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
            System.Uri resourceLocater = new System.Uri("/QLKS;component/usercontrols/usercontrol_thongke.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\UserControl_ThongKe.xaml"
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
            
            #line 7 "..\..\..\UserControls\UserControl_ThongKe.xaml"
            ((QLKS.UserControls.UserControl_ThongKe)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbChonThang = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\UserControls\UserControl_ThongKe.xaml"
            this.cbChonThang.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbChonThang_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txbChonNam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 37 "..\..\..\UserControls\UserControl_ThongKe.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Click_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtDoanhThu = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtSoLuong = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.txtTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.lsvThongKe = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

