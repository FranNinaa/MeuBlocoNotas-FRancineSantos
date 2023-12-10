using System.ComponentModel.DataAnnotations;

namespace MeuBlocoNotas.Models
{
	// Classe que representa o modelo de dados para uma nota
	public class NotaModel
	{
		// Identificador único da nota
		public int Id { get; set; }

		// Título da nota 
		public string? Titulo { get; set; }

		// Conteúdo da anotação 
		public string? ConteudoAnotacao { get; set; }

		// Data da anotação 
		public string? DataAnotacao { get; set; }
	}
}
