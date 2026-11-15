using System;

namespace MyEstudos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new BibliotecaContext();
          IBiblioteca minhaBiblioteca = new Biblioteca(context);

          Menu meuMenu = new Menu(minhaBiblioteca);
          await meuMenu.ExibirMenuAsync();

            //Console.WriteLine($"Preço final do Livro Físico: {L.CalcularPreco(70)}");

           //await minhaBiblioteca.CarregarDadosAsync();
           minhaBiblioteca.OnLivroAdicionado += Notificacao.ExibirNotificacao;
           
        }
    }
}
    
    
    
    

    
    
    



