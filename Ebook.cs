using System.Diagnostics.CodeAnalysis;
namespace MyEstudos
{
    public class Ebook : Livro, IPromocional

    {
            public double TamanhoEmMB {get; set;}
            public void AplicarCupom(string cupom)
            {
                Console.WriteLine($"O cupom {cupom} aplicado com sucesso!");
            }

            [SetsRequiredMembers]
            public Ebook(double tamanhoEmmb, string titulo, string autor, int nmrPaginas) : base(titulo, autor, nmrPaginas)
            {
                TamanhoEmMB = tamanhoEmmb;
            }
            public override double CalcularPreco(double precoBase)
            {
            return precoBase * 0.9; // Retorna o preço com 10% de desconto 🏷️
            }
            public override void ExibirDetalhes()
            {
                Console.WriteLine($"📱 [E-Book] {Titulo} | Autor: {Autor} | Páginas: {NmrPaginas} | Tamanho: {TamanhoEmMB}MB");
            }
            public Ebook(){}
    }
}