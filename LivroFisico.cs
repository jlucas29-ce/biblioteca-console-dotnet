using System.Diagnostics.CodeAnalysis;
namespace MyEstudos
{
    
    public class LivroFisico : Livro
    {
        [SetsRequiredMembers]
        public LivroFisico(string titulo, string autor, int nmrPaginas) : base(titulo, autor, nmrPaginas)
        {
            Titulo = titulo;
            Autor = autor;
            NmrPaginas = nmrPaginas;
        }
        public LivroFisico(){}

        public override void ExibirDetalhes()
        {
            Console.WriteLine($"📖 [Físico] {Titulo} | Autor: {Autor} | Páginas: {NmrPaginas}");
        }
        public override double CalcularPreco(double precoBase)
        {
            return precoBase + 15.0;       //Retorna com o preço de 15 reais a mais com o frete🏷️
        }  
     }
}