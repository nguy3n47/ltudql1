﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "87DC14FAE4EC84BE53A0D101C66CB138090C957C75E33834C260F4BA95687F1D"
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
        
        
        #line 74 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBar status;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label statusLabel;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox categoriesComboBox;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox pagesComboBox;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView productsListView;
        
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
            
            #line 21 "..\..\MainWindow.xaml"
            ((Fluent.BackstageTabItem)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.exitMenu_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 28 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.excelImportButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 35 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addCategoryButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 40 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteCategoryButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 48 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addProductButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 53 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateProductButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 58 "..\..\MainWindow.xaml"
            ((Fluent.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteProductButton_Clicked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.status = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            case 10:
            this.statusLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.categoriesComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 81 "..\..\MainWindow.xaml"
            this.categoriesComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            
            #line 99 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.previousButton_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.pagesComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 100 "..\..\MainWindow.xaml"
            this.pagesComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.pagesComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 112 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.nextButton_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.productsListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

