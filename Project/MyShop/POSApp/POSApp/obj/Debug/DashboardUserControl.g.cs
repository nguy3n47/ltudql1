﻿#pragma checksum "..\..\DashboardUserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "418915FCE2D70E1C76A9FCC89D2EE4AAF5ADBCEBE9FE063EB25B0787B80FFD68"
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
using POSApp;
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


namespace POSApp {
    
    
    /// <summary>
    /// DashboardUserControl
    /// </summary>
    public partial class DashboardUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\DashboardUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock totalProductText;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\DashboardUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock totalOrderText;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\DashboardUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock totalSaleText;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\DashboardUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock totalCustomerText;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\DashboardUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView customerListView;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\DashboardUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid purchaseDataGrid;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\DashboardUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView soldoutProductListView;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\DashboardUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart linechartRevenue;
        
        #line default
        #line hidden
        
        
        #line 244 "..\..\DashboardUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.Axis axisLabels;
        
        #line default
        #line hidden
        
        
        #line 259 "..\..\DashboardUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView sellingProductListView;
        
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
            System.Uri resourceLocater = new System.Uri("/POSApp;component/dashboardusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DashboardUserControl.xaml"
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
            
            #line 12 "..\..\DashboardUserControl.xaml"
            ((POSApp.DashboardUserControl)(target)).Initialized += new System.EventHandler(this.UserControl_Initialized);
            
            #line default
            #line hidden
            return;
            case 2:
            this.totalProductText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.totalOrderText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.totalSaleText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.totalCustomerText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.customerListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.purchaseDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.soldoutProductListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.linechartRevenue = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 10:
            this.axisLabels = ((LiveCharts.Wpf.Axis)(target));
            return;
            case 11:
            this.sellingProductListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

