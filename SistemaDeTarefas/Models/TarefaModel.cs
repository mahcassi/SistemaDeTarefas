using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public EStatusTarefa Status { get; set; }

        public int? UsuarioId { get; set; }

        // referencia da UsuarioId para a tabela de Usuarios
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
