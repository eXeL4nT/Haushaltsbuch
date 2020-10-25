﻿#pragma checksum "..\..\..\..\Views\AddBookingWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56379F8FBD5BD1D4E435B356AB00A62A44525781"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using HouseholdBook.Models;
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


namespace HouseholdBook {
    
    
    /// <summary>
    /// AddBookingWindow
    /// </summary>
    public partial class AddBookingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Views\AddBookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cBoxAddBookingRecurring;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Views\AddBookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rButtonAddBookingIn;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Views\AddBookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rButtonAddBookingOut;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Views\AddBookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddBooking;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Views\AddBookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tBoxAddBookingTitle;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Views\AddBookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tBoxAddBookingAmount;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Views\AddBookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dPickerAddBooking;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Views\AddBookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cBoxAddBookingBankAccount;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Views\AddBookingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cBoxAddBookingCategory;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HouseholdBook;V1.0.0.0;component/views/addbookingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\AddBookingWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cBoxAddBookingRecurring = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 2:
            this.rButtonAddBookingIn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.rButtonAddBookingOut = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.btnAddBooking = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\Views\AddBookingWindow.xaml"
            this.btnAddBooking.Click += new System.Windows.RoutedEventHandler(this.btnAddBooking_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tBoxAddBookingTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tBoxAddBookingAmount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.dPickerAddBooking = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.cBoxAddBookingBankAccount = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.cBoxAddBookingCategory = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

