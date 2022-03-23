﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "28FAC4F7E84956C6A802FB9160E04CEAAAF7470BE567778B76D2C7E28340F40D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MultiScreener_Media;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace MultiScreener_Media {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MultiScreener_Media.MainWindow mainWindow;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox contentsListBox;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu fileMenu;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem openFolderMenuItem;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem openFilesMenuItem;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button playButton;
        
        #line default
        #line hidden
        
        
        #line 244 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button stopButton;
        
        #line default
        #line hidden
        
        
        #line 269 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button toggleMuteButton;
        
        #line default
        #line hidden
        
        
        #line 294 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button restartButton;
        
        #line default
        #line hidden
        
        
        #line 319 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider masterVolumeSlider;
        
        #line default
        #line hidden
        
        
        #line 385 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label currentTimeLabel;
        
        #line default
        #line hidden
        
        
        #line 386 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label maxDurationLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/MultiScreener Media;component/mainwindow.xaml", System.UriKind.Relative);
            
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
            this.mainWindow = ((MultiScreener_Media.MainWindow)(target));
            
            #line 8 "..\..\MainWindow.xaml"
            this.mainWindow.Loaded += new System.Windows.RoutedEventHandler(this.mainWindow_Loaded);
            
            #line default
            #line hidden
            
            #line 8 "..\..\MainWindow.xaml"
            this.mainWindow.Closed += new System.EventHandler(this.mainWindow_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.contentsListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 200 "..\..\MainWindow.xaml"
            this.contentsListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.contentsListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.fileMenu = ((System.Windows.Controls.Menu)(target));
            return;
            case 4:
            this.openFolderMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 203 "..\..\MainWindow.xaml"
            this.openFolderMenuItem.Click += new System.Windows.RoutedEventHandler(this.openFolderMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.openFilesMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 204 "..\..\MainWindow.xaml"
            this.openFilesMenuItem.Click += new System.Windows.RoutedEventHandler(this.openFilesMenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 213 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.jumpButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 215 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.playButton = ((System.Windows.Controls.Button)(target));
            
            #line 219 "..\..\MainWindow.xaml"
            this.playButton.Click += new System.Windows.RoutedEventHandler(this.playButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.stopButton = ((System.Windows.Controls.Button)(target));
            
            #line 244 "..\..\MainWindow.xaml"
            this.stopButton.Click += new System.Windows.RoutedEventHandler(this.stopButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.toggleMuteButton = ((System.Windows.Controls.Button)(target));
            
            #line 269 "..\..\MainWindow.xaml"
            this.toggleMuteButton.Click += new System.Windows.RoutedEventHandler(this.muteButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.restartButton = ((System.Windows.Controls.Button)(target));
            
            #line 294 "..\..\MainWindow.xaml"
            this.restartButton.Click += new System.Windows.RoutedEventHandler(this.restartButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.masterVolumeSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 319 "..\..\MainWindow.xaml"
            this.masterVolumeSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.masterVolumeSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.currentTimeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.maxDurationLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
