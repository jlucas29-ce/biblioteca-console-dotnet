namespace MyEstudos
{
    public class MenuFiltro
    {
        private readonly IBiblioteca _biblioteca;

        public MenuFiltro(IBiblioteca biblioteca)
        {
            _biblioteca = biblioteca;
        }

        public void Executar()
        {
            int opcao;
            do
            {   Console.Clear();
                Console.WriteLine("=== MENU DE FILTROS ===");
                Console.WriteLine("1 - Buscar por autor");
                Console.WriteLine("2 - Livros com mais de 350 páginas");
                Console.WriteLine("3 - Retornar ao menu principal");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine();
                    Console.Clear();

                    switch (opcao)
                    {
                        case 1:
                            FiltrarPorAutor();
                            break;

                        case 2:
                            FiltrarLivrosLongos();
                            break;

                        case 3:
                            Console.WriteLine("Retornando ao menu principal...\n");
                            break;

                        default:
                            Console.WriteLine("⚠️ Opção inválida!\n");
                            break;
                    }
                }
            } while (opcao != 3);
        }

        private void FiltrarPorAutor()
        {
            Console.Write("Digite o nome do autor: ");
            string autor = Console.ReadLine() ?? "";

            List<Livro> resultados = _biblioteca.BuscarAutor(autor);

            if (resultados.Count == 0)
            {
                Console.WriteLine($"⚠️ Nenhum livro encontrado para o autor '{autor}'.\n");
            }
            else
            {
                _biblioteca.ExibirColecao(resultados);
                Console.ReadKey();
            }
        }

        private void FiltrarLivrosLongos()
        {
            Console.WriteLine("--- LIVROS COM MAIS DE 350 PÁGINAS ---");
            List<Livro> livrosLongos = _biblioteca.ObterLivrosLogos();
            _biblioteca.ExibirColecao(livrosLongos);
        }
    }
}