using BlazorToDoList.Data.Models;
using BlazorToDoList.Data.Services.Interfaces;
using System.Collections;
using System.Text.Json;

namespace BlazorToDoList.Data.Services
{
    public class ToDoService : IToDoService
    {
        private string _path;

        public ToDoService()
        {
            _path = Directory.GetCurrentDirectory();
        }
        
        public async Task<IEnumerable<Tarefa>> ObterTarefasAsync()
        {
            string jsonPath = Path.Combine(_path, "tarefas.json");
            if(!File.Exists(jsonPath))
            {
                return Enumerable.Empty<Tarefa>();
            }
            string json = await File.ReadAllTextAsync(jsonPath);

            if(json == string.Empty)
            {
                return Enumerable.Empty<Tarefa>();
            }
            List<Tarefa> tarefas = JsonSerializer.Deserialize<List<Tarefa>>(json);

            return tarefas;
        }

        public async Task SalvarTarefaAsync(List<Tarefa> tarefas)
        {
            string json = JsonSerializer.Serialize(tarefas);
            string jsonPath = Path.Combine(_path, "tarefas.json");

            await File.WriteAllTextAsync(jsonPath, json);
        }
    }
}
