namespace BlazorToDoList.Data.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
    }
}
