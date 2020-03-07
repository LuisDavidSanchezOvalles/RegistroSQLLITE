using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroSQLLITE.BLL;
using RegistroSQLLITE.Entidades;

namespace RegistroSQLLITE.UI.Consultas
{
    /// <summary>
    /// Interaction logic for CPersonas.xaml
    /// </summary>
    public partial class CPersonas : Window
    {
        public CPersonas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Persona>();

            Listado = PersonasBLL.GetList(p => true);

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}
