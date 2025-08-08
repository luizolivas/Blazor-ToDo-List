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
        
        public async Task<List<Tarefa>> ObterTarefasAsync()
        {
            string jsonPath = Path.Combine(_path, "tarefas.json");
            if(!File.Exists(jsonPath))
            {
                return [];
            }
            string json = await File.ReadAllTextAsync(jsonPath);

            if(json == string.Empty)
            {
                return [];
            }
            List<Tarefa> tarefas = JsonSerializer.Deserialize<List<Tarefa>>(json);

            return tarefas;
        }

        public async Task SalvarTarefaAsync(Tarefa tarefa)
        {
            List<Tarefa> listaTarefas = await ObterTarefasAsync();

            listaTarefas.Add(tarefa);
            
            string json = JsonSerializer.Serialize(listaTarefas);
            string jsonPath = Path.Combine(_path, "tarefas.json");

            await File.WriteAllTextAsync(jsonPath, json);
        }
    }
}
