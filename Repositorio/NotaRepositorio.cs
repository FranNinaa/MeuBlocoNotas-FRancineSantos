using MeuBlocoNotas.Data;
using MeuBlocoNotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuBlocoNotas.Repositorio
{
	// Repositório para operações CRUD relacionadas a notas
	public class NotaRepositorio : INotaRepositorio
	{
		// Contexto de dados usado para interagir com o banco de dados
		private readonly Contexto _contexto;

		// Construtor que recebe um contexto de dados ao ser instanciado
		public NotaRepositorio(Contexto contexto)
		{
			_contexto = contexto;
		}

		// Retorna todas as notas do banco de dados
		public List<NotaModel> BuscarTodos()
		{
			return _contexto.Nota.ToList();
		}

		// Retorna uma nota com base no ID fornecido
		public NotaModel ListarPorId(int id)
		{
			return _contexto.Nota.FirstOrDefault(x => x.Id == id);
		}

		// Adiciona uma nova nota ao banco de dados
		public NotaModel Adicionar(NotaModel nota)
		{
			// Adiciona a nota ao contexto e salva as alterações no banco de dados
			_contexto.Nota.Add(nota);
			_contexto.SaveChanges();

			return nota;
		}

		// Atualiza uma nota existente no banco de dados
		public NotaModel Atualizar(NotaModel nota)
		{
			// Obtém a nota existente pelo ID
			NotaModel notaDB = ListarPorId(nota.Id);

			// Verifica se a nota existe
			if (notaDB == null)
				throw new Exception("Houve um erro na atualização da anotação");

			// Atualiza os campos da nota com os novos valores
			notaDB.Titulo = nota.Titulo;
			notaDB.DataAnotacao = nota.DataAnotacao;
			notaDB.ConteudoAnotacao = nota.ConteudoAnotacao;

			// Atualiza a nota no contexto e salva as alterações no banco de dados
			_contexto.Nota.Update(notaDB);
			_contexto.SaveChanges();

			return notaDB;
		}

		// Apaga uma nota com base no ID fornecido
		public bool Apagar(int id)
		{
			// Obtém a nota pelo ID
			NotaModel notaDB = ListarPorId(id);

			// Verifica se a nota existe
			if (notaDB == null)
				throw new Exception("Houve um erro ao apagar a anotação");

			// Remove a nota do contexto e salva as alterações no banco de dados
			_contexto.Nota.Remove(notaDB);
			_contexto.SaveChanges();

			return true;
		}
	}
}
