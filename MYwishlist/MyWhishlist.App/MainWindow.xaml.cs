﻿using MYwishlist.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWhishlist.App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IWishRepository repository = new WishRepositoryImpl();
        WishViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new WishViewModel(repository);
            DataContext = viewModel;

        }

        private void TitleBoxPDname_TextChanged(object sender, TextChangedEventArgs e)
        {
            TitleBoxPDname_Template.Visibility = TitleBoxPDname.Text=="" ? Visibility.Visible : Visibility.Collapsed;

        }

        private void TitleBoxLinkname_TextChanged(object sender, TextChangedEventArgs e)
        {
            TitleBoxLinkname_Template.Visibility = TitleBoxLinkname.Text == "" ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TitleBoxWMname_TextChanged(object sender, TextChangedEventArgs e)
        {
            TitleBoxWMname_Template.Visibility = TitleBoxWMname.Text == "" ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TitleBoxCostname_TextChanged(object sender, TextChangedEventArgs e)
        {
            TitleBoxCostname_Template.Visibility = TitleBoxCostname.Text == "" ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
