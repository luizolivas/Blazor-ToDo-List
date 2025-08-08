using BlazorToDoList.Data.Models;

namespace BlazorToDoList.Data.Services.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<Tarefa>> ObterTarefasAsync();
        Task SalvarTarefaAsync(List<Tarefa> tarefas);
    }
}
