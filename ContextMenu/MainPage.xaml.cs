using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ContextMenu.Resources;

namespace ContextMenu
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (isContextMenuOpened)
            {
                isContextMenuOpened = false;
                e.Cancel = true;
            }
        }

        bool isContextMenuOpened;
        private void ContextMenu_opened(object sender, RoutedEventArgs e)
        {
            isContextMenuOpened = true;
        }

        private void ContextMenu_closed(object sender, RoutedEventArgs e)
        {
            isContextMenuOpened = false;
        }

        private void ShowContextMenu_OnTap(object sender, GestureEventArgs e)
        {
            var moreOptions = sender as Button;
            Microsoft.Phone.Controls.ContextMenu contextMenu = ContextMenuService.GetContextMenu(moreOptions);
            if (contextMenu.Parent == null)
            {
                contextMenu.IsOpen = true;
                isContextMenuOpened = true;
            }
        }

        private void ContextMenuItemChat_Click(object sender, RoutedEventArgs e)
        {
            string header = (sender as MenuItem).Header.ToString();
                        
            if (header == "edit")
            {
                //add your action here
            }

            if (header == "delete")
            {
                //add your action here                
            }

            if (header == "copy")
            {
                //add your action here
            }
        }

        private void OpnenContextMenu_OnHold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MenuItem editMenu = new MenuItem() { Header = "edit" };
            editMenu.Click += ContextMenuItemChat_Click;

            MenuItem deleteMenu = new MenuItem() { Header = "delete" };
            deleteMenu.Click += ContextMenuItemChat_Click;

            MenuItem copyMenu = new MenuItem() { Header = "delete" };
            copyMenu.Click += ContextMenuItemChat_Click;

            Microsoft.Phone.Controls.ContextMenu contextMenu = new Microsoft.Phone.Controls.ContextMenu() { VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Left, IsFadeEnabled = false, IsZoomEnabled = false, IsOpen = true };

            contextMenu.Items.Add(editMenu);
            contextMenu.Items.Add(deleteMenu);
            contextMenu.Items.Add(copyMenu);

            ContextMenuService.SetContextMenu(sender as StackPanel, contextMenu);

        }

    }
}