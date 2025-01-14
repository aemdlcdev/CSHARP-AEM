using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApiRestMoviles
{
    /// <summary>
    /// Lógica de interacción para AddObject.xaml
    /// </summary>
    public partial class AddObject : Window
    {
        private MainWindow _mainWindow;

        public AddObject(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.btnAdd.IsEnabled = true;
            this.btnAdd.Content = "Adding object...";
            this.btnAdd.IsEnabled = false;

            // Creo objeto para enviar a la API
            ApiObject objeto = new ApiObject();
            objeto.name = txtName.Text;
            objeto.data = new Data();
            objeto.data.color = txtColor.Text;
            objeto.data.capacity = txtCapacity.Text;
            objeto.data.hardDiskSize = int.Parse(txtHardDisk.Text);
            objeto.data.cpuModel = txtCpuModel.Text;
            objeto.data.year = int.Parse(txtYear.Text);
            objeto.data.price = int.Parse(txtPrice.Text);

            // Envio objeto a la API
            string urlApi = "https://api.restful-api.dev/objects";
            HttpClient cliente = new HttpClient();
            StringContent str = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await cliente.PostAsync(urlApi, str);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Object added successfully");
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var addedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiObject>(jsonResponse);

                _mainWindow.txtPost.Text = "Objeto añadido correctamente: " + jsonResponse;

                this.Hide();
            }
            else
            {
                MessageBox.Show("Error adding object");
                _mainWindow.txtPost.Text = "Error al añadir el objeto";
            }

            this.btnAdd.IsEnabled = true;
            this.btnAdd.Content = "Add object";
        }

    }
}
