﻿#pragma checksum "..\..\Regestration.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DAB3C109C4181924A53FBD6FCABE3050"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GUI;
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


namespace GUI {
    
    
    /// <summary>
    /// Regestration
    /// </summary>
    public partial class Regestration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\Regestration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbLogin;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Regestration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PbPassword;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Regestration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CbShow;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Regestration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbPassword;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Regestration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButOk;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Regestration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButCancel;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Regestration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButRegistr;
        
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
            System.Uri resourceLocater = new System.Uri("/GUI;component/regestration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Regestration.xaml"
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
            this.TbLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.PbPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 24 "..\..\Regestration.xaml"
            this.PbPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.PbPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CbShow = ((System.Windows.Controls.CheckBox)(target));
            
            #line 25 "..\..\Regestration.xaml"
            this.CbShow.Checked += new System.Windows.RoutedEventHandler(this.CbShow_Checked);
            
            #line default
            #line hidden
            
            #line 25 "..\..\Regestration.xaml"
            this.CbShow.Unchecked += new System.Windows.RoutedEventHandler(this.CbShow_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TbPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\Regestration.xaml"
            this.TbPassword.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TbPassword_TextChanged_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButOk = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Regestration.xaml"
            this.ButOk.Click += new System.Windows.RoutedEventHandler(this.ButOk_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButCancel = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.ButRegistr = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Regestration.xaml"
            this.ButRegistr.Click += new System.Windows.RoutedEventHandler(this.ButRegistr_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
