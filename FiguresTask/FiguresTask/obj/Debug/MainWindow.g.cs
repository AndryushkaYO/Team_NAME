﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C4710F032F8AB3B440EEE54A08D54CD6C51311CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Figures;
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


namespace Figures {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem polygonesList;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas MainCanvas;
        
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
            System.Uri resourceLocater = new System.Uri("/FiguresTask;component/mainwindow.xaml", System.UriKind.Relative);
            
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
            ((Figures.MainWindow)(target)).PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.KeyboardDragging);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 11 "..\..\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.NewCanvas);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 12 "..\..\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.OpenCanvas);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 13 "..\..\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SaveCanvas);
            
            #line default
            #line hidden
            return;
            case 5:
            this.polygonesList = ((System.Windows.Controls.MenuItem)(target));
            
            #line 45 "..\..\MainWindow.xaml"
            this.polygonesList.Click += new System.Windows.RoutedEventHandler(this.SelectPolygon);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MainCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 51 "..\..\MainWindow.xaml"
            this.MainCanvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.AddPoint);
            
            #line default
            #line hidden
            
            #line 52 "..\..\MainWindow.xaml"
            this.MainCanvas.MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SelectPolygon);
            
            #line default
            #line hidden
            
            #line 53 "..\..\MainWindow.xaml"
            this.MainCanvas.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.KeyboardDragging);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 59 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DrawPolygon);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

