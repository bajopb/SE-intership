﻿#pragma checksum "..\..\..\..\..\Views\FunctionsViews\ReadCoilsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31C32BB42D7359088F2D402F3504D8E90F8FE1FB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Master.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Master.Views {
    
    
    /// <summary>
    /// ReadCoilsView
    /// </summary>
    public partial class ReadCoilsView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\Views\FunctionsViews\ReadCoilsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbUnitID;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\Views\FunctionsViews\ReadCoilsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbStartAddress;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\Views\FunctionsViews\ReadCoilsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNumberOfPoints;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\Views\FunctionsViews\ReadCoilsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRead;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Master;component/views/functionsviews/readcoilsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\FunctionsViews\ReadCoilsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbUnitID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbStartAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbNumberOfPoints = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnRead = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\Views\FunctionsViews\ReadCoilsView.xaml"
            this.btnRead.Click += new System.Windows.RoutedEventHandler(this.btnRead_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

