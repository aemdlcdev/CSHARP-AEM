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

namespace FPConnect.view.UserControls
{
    /// <summary>
    /// Lógica de interacción para EventosGridControl.xaml
    /// </summary>
    public partial class EventosGridControl : Page
    {
        public EventosGridControl()
        {
            InitializeComponent();
            GetMesActualConLetras();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void lblNota_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtNota.Focus();
        }

        private void txtNota_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtNota.Text) && txtNota.Text.Length > 0)
            {
                lblNota.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblNota.Visibility = Visibility.Visible;
            }
        }

        private void lblTime_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtTime.Focus();
        }

        private void txtTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTime.Text) && txtTime.Text.Length > 0)
            {
                lblTime.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblTime.Visibility = Visibility.Visible;
            }
        }

        private void GetMesActualConLetras()
        {
            string mes = DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"));
            mes = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mes.ToLower());

            string[] meses = new string[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

            for (int i = 0; i < meses.Length; i++)
            {
                if (meses[i] == mes)
                {
                    mes = meses[i];
                    break;
                }
            }

            lblMes.Text = mes;
        }


    }
}
