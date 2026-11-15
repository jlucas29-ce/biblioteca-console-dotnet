namespace MyEstudos
{   
    public delegate void LivroAdicionadoHandler(Livro livro); //1. O Delegate define a 'assinatura': o método inscrito deve receber um (Livro) e ser void
    public class Biblioteca : IBiblioteca
    {
            private List<Livro> colecao = new List<Livro>();
            public event LivroAdicionadoHandler? OnLivroAdicionado; // 2. O Evento usa o delegate como tipo
            private readonly BibliotecaContext _context;

            public void AdicionarLivro(Livro livro)
            {
                using(var context = new BibliotecaContext())
                {
                context.Livros.Add(livro);
                context.SaveChanges(); // 💾 Grava as alterações no arquivo biblioteca.db
                }                                   
                OnLivroAdicionado?.Invoke(livro); // 3. Notificamos os inscritos! (O operador ?. garante que só dispara se houver inscritos)
                Console.Clear();
            }

            public List<Livro> ObterTodos()
            {
                using (var context = new BibliotecaContext()) 
                {
                    return context.Livros.ToList(); 
                }
            }

            public void ExibirTodos()
            {
                using (var context = new BibliotecaContext())
                {
                    var livros = context.Livros.ToList(); 

                    Console.WriteLine("\n--- Catálogo completo da biblioteca ---");

                    foreach (var livro in livros) 
                    {
                        livro.ExibirDetalhes(); 
                    }
                }
            }

            public List<Livro> ObterLivrosLogos()
            {
                using (var context = new BibliotecaContext())
                {
                    return context.Livros
                                .Where(l => l.NmrPaginas > 350) 
                                .ToList();
                }
            }
            public List<Livro> BuscarAutor(string autor)
            {
                return _context.Livros
                    .Where(l => l.Autor.ToLower() == autor.ToLower())
                    .ToList();
            }

            public void ExibirColecao(List<Livro> lista)
            {
                foreach (Livro livro in lista)
                {
                    livro.ExibirDetalhes(); // Cada livro se exibe do seu jeito! 🎭
                }
            }

            public async Task CarregarDadosAsync()
            {

                Console.WriteLine("Carregando banco de dados da biblioteca...");

                //Task.Delay simula a espera de 3000 milissegundos sem travar o sistema
                await Task.Delay(3000);
                
                Console.WriteLine("Dados carregados!");
            }
            public Biblioteca(BibliotecaContext context)
            {
                _context = context;
            }
    }
}