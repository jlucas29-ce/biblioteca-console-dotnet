namespace MyEstudos
{
    public class Notificacao
    {
        public static void ExibirNotificacao(Livro livro)
        {
        Console.WriteLine($"\n🔔 [EVENTO]: O livro '{livro.Titulo}' foi cadastrado com sucesso!"); 
        }
    }
}