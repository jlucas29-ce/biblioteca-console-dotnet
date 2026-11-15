namespace MyEstudos
{

    public class Menu
    {   
        public int escolha{get; set;}
        private IBiblioteca _biblioteca;
        public Menu(IBiblioteca biblioteca)
        {
            _biblioteca = biblioteca;
        }
        public async Task ExibirMenuAsync()
        {
            int escolha;
            do
            {   Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1 - Cadastrar novo livro");
                Console.WriteLine("2 - Filtar livros");
                Console.WriteLine("3 - Verificar biblioteca");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("======================");
                Console.Write("Escolha uma opção: ");

                if(int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.WriteLine();
                    Console.Clear();
                    switch (escolha)
                    {
                    case 1: 
                        var menuCadastro = new MenuCadastro(_biblioteca);
                        menuCadastro.Executar();
                        break;

                    case 2:
                        var menuFiltro = new MenuFiltro(_biblioteca);
                        menuFiltro.Executar();
                        break;

                    case 3:
                        await _biblioteca.CarregarDadosAsync();
                        var livros = _biblioteca.ObterTodos();
                        _biblioteca.ExibirColecao(livros);
                        break;

                    case 0:
                        Console.WriteLine("Saindo do sistema... Até logo!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida! Digite apenas números.");
                    escolha = -1; // Garante que o loop continue após um texto inválido
                }
                if (escolha != 0)
                {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                }

            } while(escolha != 0);
        }

    }
}
    
