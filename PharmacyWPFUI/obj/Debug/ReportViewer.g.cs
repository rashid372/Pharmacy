﻿#pragma checksum "..\..\ReportViewer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EDC98D023DFE9E90D84D264476EB900B468CAA2A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PharmacyWPFUI;
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
using Telerik.ReportViewer.Wpf;
using Telerik.Windows.Controls;


namespace PharmacyWPFUI {
    
    
    /// <summary>
    /// ReportViewer
    /// </summary>
    public partial class ReportViewer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 191 "..\..\ReportViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border WindowButtonsPlaceholder;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\ReportViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblUser;
        
        #line default
        #line hidden
        
        
        #line 212 "..\..\ReportViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\ReportViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadComboBox DDLReportType;
        
        #line default
        #line hidden
        
        
        #line 254 "..\..\ReportViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.ReportViewer.Wpf.ReportViewer reportViewer1;
        
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
            System.Uri resourceLocater = new System.Uri("/PharmacyWPFUI;component/reportviewer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReportViewer.xaml"
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
            this.WindowButtonsPlaceholder = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.lblUser = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.DDLReportType = ((Telerik.Windows.Controls.RadComboBox)(target));
            
            #line 251 "..\..\ReportViewer.xaml"
            this.DDLReportType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DDLReportType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.reportViewer1 = ((Telerik.ReportViewer.Wpf.ReportViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

