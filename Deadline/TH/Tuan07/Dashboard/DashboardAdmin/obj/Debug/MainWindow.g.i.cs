﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A06DC96B250B5BEF01CC9F56A398622411DF377F976E18AB6DD9F3C6CE9E806A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DashboardAdmin;
using Fluent;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace DashboardAdmin {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Fluent.Ribbon ribbon;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabsContent;
        
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
            System.Uri resourceLocater = new System.Uri("/DashboardAdmin;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 9 "..\..\MainWindow.xaml"
            ((DashboardAdmin.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.RibbonWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ribbon = ((Fluent.Ribbon)(target));
            return;
            case 3:
            
            #line 22 "..\..\MainWindow.xaml"
            ((Fluent.BackstageTabItem)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.exitMenu_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 29 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.excelImportButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 36 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addCategoryButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 41 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateCategoryButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 46 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteCategoryButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 54 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addProductButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 59 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateProductButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 64 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteProductButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 11:
            this.tabsContent = ((System.Windows.Controls.TabControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
