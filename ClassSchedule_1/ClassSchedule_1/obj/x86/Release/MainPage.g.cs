﻿#pragma checksum "C:\Users\zhaoy\source\repos\ClassSchedule_1\ClassSchedule_1\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "074BAE2204FF2BCA9A39A8E9147EDE98"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassSchedule_1
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 12
                {
                    this.HamburgerMenuButtonStyle = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 3: // MainPage.xaml line 18
                {
                    this.TitleStyle = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 4: // MainPage.xaml line 22
                {
                    this.HamburgerText = (global::Windows.UI.Xaml.Style)(target);
                }
                break;
            case 5: // MainPage.xaml line 40
                {
                    this.HamburgerMenu = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 6: // MainPage.xaml line 42
                {
                    this.HamburgerSelection = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.HamburgerSelection).SelectionChanged += this.HamburgerSelection_SelectionChanged;
                }
                break;
            case 7: // MainPage.xaml line 58
                {
                    this.myFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 8: // MainPage.xaml line 37
                {
                    this.HamburgerButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.HamburgerButton).Click += this.HamburgerButton_Click;
                }
                break;
            case 9: // MainPage.xaml line 38
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

