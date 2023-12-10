using MeuBlocoNotas.Models;
using MeuBlocoNotas.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuBlocoNotas.Controllers
{
	public class NotaController : Controller
	{
		// Injeção de dependência do repositório de notas
		private readonly INotaRepositorio _notaRepositorio;

		// Construtor que recebe o repositório de notas por injeção de dependência
		public NotaController(INotaRepositorio notaRepositorio)
		{
			_notaRepositorio = notaRepositorio;
		}

		// Ação para exibir a lista de notas
		public IActionResult Index()
		{
			// Buscar todas as notas no repositório
			var notas = _notaRepositorio.BuscarTodos();

			// Retornar a View com a lista de notas
			return View(notas);
		}

		// Ação para exibir o formulário de criação de notas
		public IActionResult Criar()
		{
			return View();
		}

		// Ação acionada quando o formulário de criação é enviado (HTTP POST)
		[HttpPost]
		public IActionResult Criar(NotaModel nota)
		{
			try
			{
				// Adicionar a nota ao repositório
				_notaRepositorio.Adicionar(nota);

				// Mensagem de sucesso para exibir na próxima requisição
				TempData["MensagemSucesso"] = "Anotação Salva com Sucesso !";

				// Redirecionar para a lista de notas (Index)
				return RedirectToAction("Index");
			}
			catch (Exception erro)
			{
				// Mensagem de erro em caso de falha
				TempData["MensagemErro"] = $"Erro ao Salvar " +
					$"a Anotação, tente novamente, detalhe: {erro.Message}";

				// Redirecionar para a lista de notas (Index)
				return RedirectToAction("Index");
			}
		}

		// Ação para exibir o formulário de edição de uma nota específica
		public IActionResult Editar(int id)
		{
			// Buscar a nota pelo ID
			NotaModel nota = _notaRepositorio.ListarPorId(id);

			// Retornar a View com os detalhes da nota para edição
			return View(nota);
		}

		// Ação acionada quando o formulário de edição é enviado (HTTP POST)
		[HttpPost]
		public IActionResult Alterar(NotaModel nota)
		{
			try
			{
				// Verificar se o modelo é válido antes de atualizar
				if (ModelState.IsValid)
				{
					// Atualizar a nota no repositório
					_notaRepositorio.Atualizar(nota);

					// Mensagem de sucesso para exibir na próxima requisição
					TempData["MensagemSucesso"] = "Anotação Alterada com Sucesso !";

					// Redirecionar para a lista de notas (Index)
					return RedirectToAction("Index");
				}

				// Se o modelo não for válido, retornar para a View de edição com os erros
				return View("Editar", nota);
			}
			catch (Exception error)
			{
				// Mensagem de erro em caso de falha
				TempData["MensagemErro"] = $"Erro ao atualizar a Anotação, tente novamente, detalhe: {error.Message}";

				// Redirecionar para a lista de notas (Index)
				return RedirectToAction("Index");
			}
		}

		// Ação para exibir a confirmação de exclusão de uma nota
		public IActionResult ApagarConfirmacao(int id)
		{
			// Buscar a nota pelo ID
			NotaModel nota = _notaRepositorio.ListarPorId(id);

			// Retornar a View de confirmação de exclusão
			return View(nota);
		}

		// Ação acionada para excluir uma nota específica
		public IActionResult Apagar(int id)
		{
			try
			{
				// Tentar excluir a nota pelo ID
				bool apagado = _notaRepositorio.Apagar(id);

				// Exibir mensagem de sucesso ou erro com base no resultado da exclusão
				if (apagado)
				{
					TempData["MensagemSucesso"] = "Anotação apagada com Sucesso !";
				}
				else
				{
					TempData["MensagemErro"] = "Erro ao apagar sua anotação !";
				}

				// Redirecionar para a lista de notas (Index)
				return RedirectToAction("Index");
			}
			catch (Exception error)
			{
				// Mensagem de erro em caso de falha
				TempData["MensagemErro"] = $"Erro ao apagar sua Anotação, tente novamente, detalhe: {error.Message}";

				// Redirecionar para a lista de notas (Index)
				return RedirectToAction("Index");
			}
		}
	}


}

