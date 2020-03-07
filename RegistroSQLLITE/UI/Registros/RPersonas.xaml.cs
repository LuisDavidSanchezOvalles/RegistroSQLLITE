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
using RegistroSQLLITE.Entidades;
using RegistroSQLLITE.BLL;

namespace RegistroSQLLITE.UI.Registros
{
    /// <summary>
    /// Interaction logic for RPersonas.xaml
    /// </summary>
    public partial class RPersonas : Window
    {
        Persona persona = new Persona();
        public RPersonas()
        {
            InitializeComponent();
            this.DataContext = persona;
            PersonaIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            PersonaIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(PersonaIdTextBox.Text))
                paso = false;
            else
            {
                try
                {
                    int i = Convert.ToInt32(PersonaIdTextBox.Text);
                }
                catch (FormatException)
                {
                    paso = false;
                }
            }

            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
                paso = false;
            else
            {
                foreach (var caracter in NombresTextBox.Text)
                {
                    if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                        paso = false;
                }
            }

            if (paso == false)
                MessageBox.Show("Datos invalidos");

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Persona personaAnterior = PersonasBLL.Buscar(persona.PersonaId);

            return personaAnterior != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (persona.PersonaId == 0)
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = PersonasBLL.Modificar(persona);
                }
                else
                {
                    MessageBox.Show("No se Puede Modificar una persona que no existe");
                    return;
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("La Persona No se Pudo Guardar");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonasBLL.Eliminar(persona.PersonaId))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo eliminar una persona que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Persona personaAnterior = PersonasBLL.Buscar(persona.PersonaId);

            if (personaAnterior != null)
            {
                persona = personaAnterior;
            }
            else
            {
                Limpiar();
                MessageBox.Show("Persona no encontrada");
            }
        }
    }
}
