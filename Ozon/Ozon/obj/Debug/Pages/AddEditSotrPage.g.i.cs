﻿#pragma checksum "..\..\..\Pages\AddEditSotrPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D10C764E62745FAFC494D2D6074FAEC6EF010B08272F53CF7E547BBD799CF0C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Ozon.Pages;
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


namespace Ozon.Pages {
    
    
    /// <summary>
    /// AddEditSotrPage
    /// </summary>
    public partial class AddEditSotrPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Pages\AddEditSotrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxF;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\AddEditSotrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxI;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\AddEditSotrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxO;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\AddEditSotrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBDoljnost;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Pages\AddEditSotrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageSotr;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\AddEditSotrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSelectImage;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Pages\AddEditSotrPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSave;
        
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
            System.Uri resourceLocater = new System.Uri("/Ozon;component/pages/addeditsotrpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AddEditSotrPage.xaml"
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
            this.TBoxF = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\Pages\AddEditSotrPage.xaml"
            this.TBoxF.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TBoxF_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TBoxI = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\Pages\AddEditSotrPage.xaml"
            this.TBoxI.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TBoxI_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TBoxO = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\Pages\AddEditSotrPage.xaml"
            this.TBoxO.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TBoxO_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CBDoljnost = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.ImageSotr = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.BtnSelectImage = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Pages\AddEditSotrPage.xaml"
            this.BtnSelectImage.Click += new System.Windows.RoutedEventHandler(this.BtnSelectImage_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnSave = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Pages\AddEditSotrPage.xaml"
            this.BtnSave.Click += new System.Windows.RoutedEventHandler(this.BtnSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
