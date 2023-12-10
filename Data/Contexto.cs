using Microsoft.EntityFrameworkCore;
using MeuBlocoNotas.Models;

namespace MeuBlocoNotas.Data
{
	// Contexto representa a camada de acesso a dados da aplicação
	public class Contexto : DbContext
	{
		// Construtor que recebe opções de configuração do DbContext
		public Contexto(DbContextOptions<Contexto> options) : base(options)
		{
		}

		// Define uma propriedade DbSet para a entidade NotaModel
		public DbSet<NotaModel> Nota { get; set; }
	}
}
