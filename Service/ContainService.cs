namespace MiKoliAPI.Service
{
    using MiKoliAPI.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ContainService
    {
        private readonly string filePath = "Contain.json";
        
        public Contains GetContainById(int menuId, int parameterId)
        {
            return ReadFile().FirstOrDefault(e => e.MainMenuID == menuId && e.ParameterID==parameterId);
        }

        private List<Contains> ReadFile()
        {
            if (!File.Exists(filePath))
            {
                return new List<Contains>();
            }
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Contains>>(json);
        }

    }

}
