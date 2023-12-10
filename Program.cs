using MeuBlocoNotas.Data;
using MeuBlocoNotas.Repositorio;
using Microsoft.EntityFrameworkCore;


namespace MeuBlocoNotas
{
    public class Program
    {
		public static void Main(string[] args)
		{
			// Criar o construtor da aplicação web (WebApplicationBuilder)
			var builder = WebApplication.CreateBuilder(args);

			// Adicionar serviços ao contêiner de injeção de dependência.
			builder.Services.AddControllersWithViews();

			// Configurar o contexto do banco de dados (usando o SQL Server neste exemplo).
			builder.Services.AddDbContext<Contexto>(
				options => options.UseSqlServer(
					"Data Source=DESKTOP-2LRLTRB;Initial Catalog=MeuBlocoNota;" +
					"Integrated Security=False;User ID=sa;Password=derick160315;" +
					"Encrypt=False;TrustServerCertificate=False"));

			// Adicionar um serviço Scoped para o repositório de notas.
			builder.Services.AddScoped<INotaRepositorio, NotaRepositorio>();

			// Construir a aplicação web.
			var app = builder.Build();

			// Configurar o pipeline de solicitações HTTP.

			// Se não estiver em ambiente de desenvolvimento, configurar o tratamento de erros.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");

				// O valor padrão do HSTS é 30 dias. Pode ser alterado para cenários de produção.
				// Veja https://aka.ms/aspnetcore-hsts para mais informações.
				app.UseHsts();
			}

			// Redirecionar solicitações HTTP para HTTPS.
			app.UseHttpsRedirection();

			// Servir arquivos estáticos (por exemplo, imagens, CSS, JavaScript).
			app.UseStaticFiles();

			// Configurar o roteamento.
			app.UseRouting();

			// Configurar a autorização.
			app.UseAuthorization();

			// Mapear as rotas dos controladores MVC.
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			// Executar a aplicação.
			app.Run();
		}
	}
}
