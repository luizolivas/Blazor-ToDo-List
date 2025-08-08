using BlazorToDoList.Data.Models;

namespace BlazorToDoList.Data.Services.Interfaces
{
    public interface IToDoService
    {
        Task<List<Tarefa>> ObterTarefasAsync();
        Task SalvarTarefaAsync(Tarefa tarefa);
    }
}
