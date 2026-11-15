namespace MyEstudos
{
    public class MenuCadastro
    {
        private readonly IBiblioteca _biblioteca;

        // 🔌 Recebemos a interface da biblioteca ao criar a classe
        public MenuCadastro(IBiblioteca biblioteca)
        {
            _biblioteca = biblioteca;
        }

        // 🚀 Método principal que o Menu.cs vai chamar
        public void Executar()
        {
            int adicionar;
            do
            {   Console.Clear();
                Console.WriteLine("=== CADASTRO DE LIVROS ===");
                Console.WriteLine("1 - Livro Físico");
                Console.WriteLine("2 - Ebook");
                Console.WriteLine("3 - Retornar");
                Console.Write("Opção: ");

                if (int.TryParse(Console.ReadLine(), out adicionar))
                {
                    Console.WriteLine();
                    Console.Clear();

                    switch (adicionar)
                    {
                        case 1:
                            CadastrarLivroFisico();
                            break;

                        case 2:
                            CadastrarEbook();
                            break;

                        case 3:
                            Console.WriteLine("Retornando ao menu principal...");
                            break;
                    }
                }
            } while (adicionar != 3);
        }

        // ✂️ Podemos isolar a leitura do Livro Físico em um método auxiliar!
        private void CadastrarLivroFisico()
        {
            Console.Write("Digite o título: ");
            string titulo = Console.ReadLine() ?? "";

            Console.Write("Digite o autor: ");
            string autor = Console.ReadLine() ?? "";

            Console.Write("Digite o número de páginas: ");
            int.TryParse(Console.ReadLine(), out int paginas);

            LivroFisico novoLivro = new LivroFisico(titulo, autor, paginas);
            _biblioteca.AdicionarLivro(novoLivro);
            

            Console.WriteLine("✅ Livro Físico cadastrado com sucesso!\n");
        }

        // ✂️ E a leitura do Ebook em outro!
        private void CadastrarEbook()
        {
            Console.Write("Digite o título: ");
            string tituloEbook = Console.ReadLine() ?? "";

            Console.Write("Digite o autor: ");
            string autorEbook = Console.ReadLine() ?? "";

            Console.Write("Digite o número de páginas: ");
            int.TryParse(Console.ReadLine(), out int paginasEbook);

            Console.Write("Informe o tamanho do livro em MB: ");
            int.TryParse(Console.ReadLine(), out int tamanhoMB);

            Ebook novoEbook = new Ebook(tamanhoMB, tituloEbook, autorEbook, paginasEbook);
            _biblioteca.AdicionarLivro(novoEbook);

            Console.WriteLine("✅ Ebook cadastrado com sucesso!\n");
        }
    }
}