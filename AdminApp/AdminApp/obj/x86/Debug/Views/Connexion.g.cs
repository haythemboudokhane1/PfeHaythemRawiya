﻿#pragma checksum "C:\Users\ASUS\Documents\GitHub\PfeHaythemRawiya\AdminApp\AdminApp\Views\Connexion.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8926E901EB2A5CE62B7D6B6B9C3A918F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminApp.Views
{
    partial class Connexion : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.txtemail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 2:
                {
                    this.txtpw = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 3:
                {
                    this.btnCnx = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 25 "..\..\..\Views\Connexion.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCnx).Click += this.btnCnx_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.btnshowGrid = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 16 "..\..\..\Views\Connexion.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)this.btnshowGrid).Tapped += this.btnshowGrid_Tapped;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

