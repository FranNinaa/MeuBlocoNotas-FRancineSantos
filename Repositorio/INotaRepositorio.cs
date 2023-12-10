using MeuBlocoNotas.Models;

namespace MeuBlocoNotas.Repositorio
{
	// Interface que define operações básicas de um repositório de notas
	public interface INotaRepositorio
	{
		// Método para obter uma nota com base no seu ID
		NotaModel ListarPorId(int id);

		// Método para obter todas as notas
		List<NotaModel> BuscarTodos();

		// Método para adicionar uma nova nota
		NotaModel Adicionar(NotaModel nota);

		// Método para atualizar uma nota existente
		NotaModel Atualizar(NotaModel nota);

		// Método para apagar uma nota com base no seu ID
		bool Apagar(int id);
	}
}
