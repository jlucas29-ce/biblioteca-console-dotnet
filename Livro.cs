using System.Diagnostics.CodeAnalysis;

namespace MyEstudos
{ 
    public abstract class Livro
    {
        public int Id{get; set;}
        public required string Titulo { get; set; }
        public required string Autor{get; set;}
        private int nmrpaginas;
        public abstract void ExibirDetalhes();
        public abstract double CalcularPreco(double precoBase);
            public Livro(){}

        //List<Livro> colecao = new List<Livro>();

        [SetsRequiredMembers]
        public Livro(string titulo, string autor, int nmrPaginas)
        {
            Titulo = titulo;
            Autor = autor;
            NmrPaginas = nmrPaginas;
                
        }
        public int NmrPaginas
        {
            get{return nmrpaginas; }
            set
            {
                if (value > 0)
                {
                    nmrpaginas = value;
                }
                else
                {
                    throw new ArgumentException("Número de páginas inválido!");
                }
            }
        }
    }
}