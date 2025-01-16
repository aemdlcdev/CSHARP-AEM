using ApiRestMoviles.persistence;

namespace ApiRestMoviles.domain
{
    public class ApiObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public Data data { get; set; }
        private ApiobjectManage apiobjectManage;

        public ApiObject()
        {
            apiobjectManage = new ApiobjectManage();
        }

        public void cargarDatos(MainWindow mainWindow)
        {
            apiobjectManage.cargarObjeto(mainWindow);
        }

        public void addObject(MainWindow mainWindow, AddObject ab)
        {
            apiobjectManage.addObject(mainWindow, ab);
        }

        public void listById(MainWindow mainWindow, ListById lb)
        {
            apiobjectManage.listByid(mainWindow, lb);
        }

        public void deleteById(MainWindow mainWindow)
        {
            apiobjectManage.deleteObject(mainWindow);
        }
    }
}

