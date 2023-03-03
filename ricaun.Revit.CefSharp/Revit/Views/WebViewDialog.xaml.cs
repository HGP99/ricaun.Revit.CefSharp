﻿using CefSharp;
using CefSharp.Wpf;
using System;
using System.Windows;

namespace ricaun.Revit.CefSharps.Revit.Views
{
    public partial class WebViewDialog : Window
    {
        public WebViewDialog(string address)
        {
            InitializeComponent();
            InitializeWindow();
            InitializeAddress(address);
        }

        private void InitializeAddress(string address)
        {
            Browser.Address = address;
            Browser.ConsoleMessage += (s, e) =>
            {
                Console.WriteLine(e.Message);
            };
            Browser.TitleChanged += (s, e) =>
            {
                this.Title = $"{Browser.Title} - CefSharp: {CefSharp.Cef.CefSharpVersion}";
            };
            Browser.MenuHandler = new NoMenuContextHandler();
        }

        #region InitializeWindow
        private void InitializeWindow()
        {
            this.MinHeight = 480;
            this.MinWidth = 320;
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ShowInTaskbar = false;
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            new System.Windows.Interop.WindowInteropHelper(this) { Owner = Autodesk.Windows.ComponentManager.ApplicationWindow };
        }
        #endregion
    }
}