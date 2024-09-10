using GeradorAtack.Models;
using System.Text.Json;

namespace GeradorAtack.Services
{
    public class JsonFileService
    {
        private readonly string filePath = "dados.json";

      
        public List<Cliente> CarregarDados()
        {
            if (!File.Exists(filePath))
            {
                return new List<Cliente>();
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Cliente>>(jsonData);
        }

        
        public void SalvarDados(List<Cliente> clientes)
        {
            var jsonData = JsonSerializer.Serialize(clientes);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
