﻿#pragma checksum "..\..\..\UserControls\UserControl_QLLoaiPhong.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "04AB1C9C58EB1042D0CCD7430F184BE0F9DB153114C985A2D6D88AFFE5FE8BAB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// UserControl_QLLoaiPhong
    /// </summary>
    public partial class UserControl_QLLoaiPhong : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 34 "..\..\..\UserControls\UserControl_QLLoaiPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFilter;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\UserControls\UserControl_QLLoaiPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThemLoaiPhong;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\UserControls\UserControl_QLLoaiPhong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvLoaiPhong;
        
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
            System.Uri resourceLocater = new System.Uri("/QLKS;component/usercontrols/usercontrol_qlloaiphong.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\UserControl_QLLoaiPhong.xaml"
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
            this.txtFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\UserControls\UserControl_QLLoaiPhong.xaml"
            this.txtFilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtFilter_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnThemLoaiPhong = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\UserControls\UserControl_QLLoaiPhong.xaml"
            this.btnThemLoaiPhong.Click += new System.Windows.RoutedEventHandler(this.btnThemLoaiPhong_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lsvLoaiPhong = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 102 "..\..\..\UserControls\UserControl_QLLoaiPhong.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSuaLoaiPhong_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 117 "..\..\..\UserControls\UserControl_QLLoaiPhong.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnXoaLoaiPhong_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
