﻿using System;
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
using RegistroSQLLITE.UI.Registros;
using RegistroSQLLITE.UI.Consultas;

namespace RegistroSQLLITE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroButton_Click(object sender, RoutedEventArgs e)
        {
            RPersonas rPersonas = new RPersonas();

            rPersonas.Show();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            CPersonas cPersonas = new CPersonas();

            cPersonas.Show();
        }
    }
}
