namespace MiKoliAPI.Service
{
    using MiKoliAPI.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MainMenuService
    {
        private readonly string filePath = "MainMenu.json";
        
        public List<MainMenu> GetAllMenus()
        {
            return ReadFile();
        }

        public MainMenu GetMenuById(int id)
        {
            return ReadFile().FirstOrDefault(e => e.MainMenuID == id);
        }        
        
        private List<MainMenu> ReadFile()
        {
            if (!File.Exists(filePath))
            {
                return new List<MainMenu>();
            }
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<MainMenu>>(json);
        }
       
    }

}
