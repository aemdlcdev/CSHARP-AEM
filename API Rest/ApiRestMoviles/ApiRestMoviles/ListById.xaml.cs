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
    /// Lógica de interacción para ListById.xaml
    /// </summary>
    public partial class ListById : Window
    {
        private MainWindow _mainWindow;
        public ListById(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private async void btnCargarId_Click(object sender, RoutedEventArgs e)
        {
            // Get single object by id https://api.restful-api.dev/objects/7

            // Realizar solicitud HTTP

            string apiUrl = "https://api.restful-api.dev/objects/"+txtId.Text;
            HttpClient cliente = new HttpClient();
            HttpResponseMessage response = await cliente.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var objeto = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiObject>(jsonResponse);
                _mainWindow.listDatos.Items.Clear();
                if (objeto.data != null)
                {
                    _mainWindow.listDatos.Items.Add($"ID: {objeto.id}, Name: {objeto.name}, Color: {objeto.data.color}, Capacity: {objeto.data.capacity}, CPU Model: {objeto.data.cpuModel}, Hard Disk: {objeto.data.hardDiskSize}, Year: {objeto.data.year}, Price: {objeto.data.price}");
                }
                else
                {
                    _mainWindow.listDatos.Items.Add($"ID: {objeto.id}, Name: {objeto.name}, Data: no data");
                }
            }
            else
            {
                _mainWindow.listDatos.Items.Clear();
                _mainWindow.listDatos.Items.Add("Error al cargar los datos");

            }
            this.Hide();
        }
    }
}
