namespace MyEstudos
{
    public interface IBiblioteca
    {
        event LivroAdicionadoHandler OnLivroAdicionado;
        void AdicionarLivro(Livro livro);
        List<Livro> ObterTodos();
        void ExibirColecao(List<Livro> livros);
        List<Livro> BuscarAutor(string autor);
        List<Livro> ObterLivrosLogos();
        Task CarregarDadosAsync();

    }
}