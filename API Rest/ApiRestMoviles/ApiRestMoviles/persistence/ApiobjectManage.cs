using ApiRestMoviles.domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ApiRestMoviles.persistence
{
    internal class ApiobjectManage
    {
        public async void cargarObjeto(MainWindow mainWindow)
        {
            // Cargar datos desde la api: https://api.restful-api.dev/objects
            string urlApi = "https://api.restful-api.dev/objects";
            mainWindow.listDatos.Items.Clear();
            mainWindow.listDatos.Items.Add("Cargando datos...");

            try
            {
                // Realizar solicitud HTTP
                HttpClient cliente = new HttpClient();
                HttpResponseMessage response = await cliente.GetAsync(urlApi);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var objetos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApiObject>>(jsonResponse);

                    // Limpiar y cargar datos en el listbox
                    mainWindow.listDatos.Items.Clear();
                    foreach (var objeto in objetos)
                    {
                        if (objeto.data != null)
                        {
                            mainWindow.listDatos.Items.Add($"ID: {objeto.id}, Name: {objeto.name}, Color: {objeto.data.color}, Capacity: {objeto.data.capacity}, CPU Model: {objeto.data.cpuModel}, Hard Disk: {objeto.data.hardDiskSize}, Year: {objeto.data.year}, Price: {objeto.data.price}");
                        }
                        else
                        {
                            mainWindow.listDatos.Items.Add($"ID: {objeto.id}, Name: {objeto.name}, Data: no data");
                        }
                    }
                }
                else
                {
                    mainWindow.listDatos.Items.Clear();
                    mainWindow.listDatos.Items.Add("Error al cargar los datos");
                }
            }
            catch (Exception ex)
            {
                mainWindow.listDatos.Items.Clear();
                mainWindow.listDatos.Items.Add($"Error: {ex.Message}");
            }
        }

        public async void addObject(MainWindow mainWindow, AddObject ab)
        {
            ab.btnAdd.IsEnabled = false;
            ab.btnAdd.Content = "Adding object...";

            try
            {
                // Crear objeto para enviar a la API
                ApiObject objeto = new ApiObject();
                objeto.name = ab.txtName.Text;
                objeto.data = new Data();
                objeto.data.color = ab.txtColor.Text;
                objeto.data.capacity = ab.txtCapacity.Text;
                objeto.data.hardDiskSize = int.Parse(ab.txtHardDisk.Text);
                objeto.data.cpuModel = ab.txtCpuModel.Text;
                objeto.data.year = int.Parse(ab.txtYear.Text);
                objeto.data.price = int.Parse(ab.txtPrice.Text);

                // Enviar objeto a la API
                string urlApi = "https://api.restful-api.dev/objects";
                HttpClient cliente = new HttpClient();
                StringContent str = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await cliente.PostAsync(urlApi, str);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Object added successfully");
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var addedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiObject>(jsonResponse);

                    mainWindow.txtPost.Text = "Objeto añadido correctamente: " + jsonResponse;

                    ab.Close();
                }
                else
                {
                    MessageBox.Show("Error adding object");
                    mainWindow.txtPost.Text = "Error al añadir el objeto";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                mainWindow.txtPost.Text = $"Error: {ex.Message}";
            }
            finally
            {
                ab.btnAdd.IsEnabled = true;
                ab.btnAdd.Content = "Add object";
            }
        }

        public async void listByid(MainWindow mainWindow, ListById lb)
        {
            try
            {
                // Get single object by id https://api.restful-api.dev/objects/
                string apiUrl = "https://api.restful-api.dev/objects/" + lb.txtId.Text;
                HttpClient cliente = new HttpClient();
                HttpResponseMessage response = await cliente.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var objeto = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiObject>(jsonResponse);
                    mainWindow.listDatos.Items.Clear();
                    if (objeto.data != null)
                    {
                        mainWindow.listDatos.Items.Add($"ID: {objeto.id}, Name: {objeto.name}, Color: {objeto.data.color}, Capacity: {objeto.data.capacity}, CPU Model: {objeto.data.cpuModel}, Hard Disk: {objeto.data.hardDiskSize}, Year: {objeto.data.year}, Price: {objeto.data.price}");
                    }
                    else
                    {
                        mainWindow.listDatos.Items.Add($"ID: {objeto.id}, Name: {objeto.name}, Data: no data");
                    }
                    lb.Close();
                }
                else
                {
                    mainWindow.listDatos.Items.Clear();
                    mainWindow.listDatos.Items.Add("Error al cargar los datos");
                }
            }
            catch (Exception ex)
            {
                mainWindow.listDatos.Items.Clear();
                mainWindow.listDatos.Items.Add($"Error: {ex.Message}");
            }
        }



        public async void deleteObject(MainWindow mainWindow)
        {
            if (mainWindow.listDatos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un objeto para eliminar.");
                return;
            }

            try
            {
                string selectedItem = mainWindow.listDatos.SelectedItem.ToString();
                string id = selectedItem.Split(',')[0].Split(':')[1].Trim();

                // URL de la api
                string urlApi = "https://api.restful-api.dev/objects/" + id;
                HttpClient cliente = new HttpClient();
                HttpResponseMessage response = await cliente.DeleteAsync(urlApi);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    mainWindow.txtPost.Text = jsonResponse;
                    mainWindow.listDatos.Items.Remove(mainWindow.listDatos.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el objeto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


    }
}

