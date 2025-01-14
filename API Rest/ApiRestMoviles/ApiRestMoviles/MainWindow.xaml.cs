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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            // Cargar datos desde la api: https://api.restful-api.dev/objects
            string urlApi = "https://api.restful-api.dev/objects";
            listDatos.Items.Clear();
            listDatos.Items.Add("Cargando datos...");

            // Realizar solicitud HTTP
            HttpClient cliente = new HttpClient();
            HttpResponseMessage response = await cliente.GetAsync(urlApi);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                var objetos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApiObject>>(jsonResponse);

                // Limpiar y cargar datos en el listbox
                listDatos.Items.Clear();
                foreach (var objeto in objetos)
                {
                    if (objeto.data != null)
                    {
                        listDatos.Items.Add($"ID: {objeto.id}, Name: {objeto.name}, Color: {objeto.data.color}, Capacity: {objeto.data.capacity}, CPU Model: {objeto.data.cpuModel}, Hard Disk: {objeto.data.hardDiskSize}, Year: {objeto.data.year}, Price: {objeto.data.price}");
                    }
                    else
                    {
                        listDatos.Items.Add($"ID: {objeto.id}, Name: {objeto.name}, Data: no data");
                    }
                }
            }
            else
            {
                listDatos.Items.Clear();
                listDatos.Items.Add("Error al cargar los datos");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddObject addObjectWindow = new AddObject(this);
            addObjectWindow.Show();
        }

        private void btnCargarId_Click(object sender, RoutedEventArgs e)
        {
            ListById listByIdWindow = new ListById(this);
            listByIdWindow.Show();
        }

        private async void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            if (listDatos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un objeto para eliminar.");
                return;
            }

            // Borrar por id, seleccionando del list box
            string id = listDatos.SelectedItem.ToString().Split(',')[0].Split(':')[1].Trim();
            string urlApi = "https://api.restful-api.dev/objects/" + id;
            HttpClient cliente = new HttpClient();
            HttpResponseMessage response = await cliente.DeleteAsync(urlApi);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                txtPost.Text = jsonResponse;
                listDatos.Items.Remove(listDatos.SelectedItem);
            }
            else
            {
                MessageBox.Show("Error al eliminar el objeto");
            }
        }


    }

    public class ApiObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string color { get; set; }
        public string capacity { get; set; }
        public string cpuModel { get; set; }
        public int hardDiskSize { get; set; }
        public int year { get; set; }
        public double price { get; set; }
    }
}
