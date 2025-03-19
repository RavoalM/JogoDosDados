namespace JogoDosDados.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        const int limiteLinhaChegada = 30;
        decimal saldo = 100;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("================================================");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("================================================");
        Console.Write("Digite seu nome: ");
        string nomeUsuario = Console.ReadLine()!;

        Console.ForegroundColor = ConsoleColor.Yellow;

        while (saldo > 0)
        {
            Console.Clear();
            Console.WriteLine($"Seu saldo atual: R$ {saldo:F2}");
            Console.Write("Digite o valor da sua aposta: R$ ");

            decimal aposta;
            while (!decimal.TryParse(Console.ReadLine(), out aposta) || aposta <= 0 || aposta > saldo)
            {
                Console.WriteLine("Valor inválido! Insira um valor entre R$ 1 e seu saldo disponível.");
                Console.Write("\nDigite o valor da sua aposta: R$ ");
            }
            Console.Clear();
            Console.WriteLine($"Você apostou R$ {aposta:F2}! Boa sorte!");
            Console.Write("Pressione ENTER para começar o jogo...");
            Console.ReadLine();

            int posicaoUsuario = 0;
            int posicaoComputador = 0;
            bool jogoEmAndamento = true;

            while (jogoEmAndamento)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("================================================");
                Console.WriteLine("Rodada do Usuário");
                Console.WriteLine("================================================");
                Console.WriteLine($"Casa {nomeUsuario}: {posicaoUsuario} ||| Casa Computador: {posicaoComputador}");
                Console.WriteLine("================================================");
                Console.Write("Pressione ENTER para lançar o dado...");
                Console.ReadLine();

                int resultadoUsuario = SortearDado();

                Console.WriteLine("\n================================================");
                Console.WriteLine($"O valor sorteado foi: {resultadoUsuario}!");
                Console.WriteLine("-----------------------");

                posicaoUsuario += resultadoUsuario;
                Console.WriteLine($"Você está na posição: {posicaoUsuario} de {limiteLinhaChegada}!");

                if (posicaoUsuario >= limiteLinhaChegada)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.WriteLine("************************************************");
                    Console.WriteLine("*   *     *       *   *         *    *      *  *");
                    Console.WriteLine("*     *    !!PARABÉNS, CAMPEÃO!!      *        *");
                    Console.WriteLine($"   *    {nomeUsuario} venceu o Jogo dos Dados!*");
                    Console.WriteLine("*   *      *        *            *      *      *");
                    Console.WriteLine("************************************************");
                    Console.WriteLine();
                    Console.WriteLine("Você venceu o Jogo dos Dados!");
                    saldo += aposta * 2;
                    Console.WriteLine($"Você ganhou R$ {aposta * 2:F2}! Saldo atual: R$ {saldo:F2}");
                    jogoEmAndamento = false;
                    continue;
                }
               
                Console.WriteLine("================================================");
                Console.Write("\nPressione ENTER para começar a rodada do computador...");
                Console.ReadLine();

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkRed;  
                Console.WriteLine("================================================");
                Console.WriteLine("Rodada do Computador");
                Console.WriteLine("================================================");
                Console.WriteLine($"Casa {nomeUsuario}: {posicaoUsuario} ||| Casa Computador: {posicaoComputador}");
                Console.WriteLine("================================================");
                Console.Write("Pressione ENTER para lançar o dado...");
                Console.ReadLine();

                int resultadoComputador = SortearDado();
                Console.WriteLine("\n================================================");
                Console.WriteLine($"O valor sorteado foi: {resultadoComputador}!");
                Console.WriteLine("-----------------------");

                posicaoComputador += resultadoComputador;
                Console.WriteLine($"O computador está na posição: {posicaoComputador} de {limiteLinhaChegada}!");

                if (posicaoComputador >= limiteLinhaChegada)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("************************************************");
                    Console.WriteLine("*                                              *");
                    Console.WriteLine("*        x GAME OVER! QUE PENA! x              *");
                    Console.WriteLine("*                                              *");
                    Console.WriteLine("*      PARECE QUE A CASA LEVOU ESSA            *");
                    Console.WriteLine("*                                              *");
                    Console.WriteLine("************************************************");
                    saldo -= aposta;
                    Console.WriteLine($"{nomeUsuario} perdeu R$ {aposta:F2}. Saldo atual: R$ {saldo:F2}");
                    jogoEmAndamento = false;
                    continue;
                }
                Console.WriteLine("================================================");
                Console.Write("\nPressione ENTER para começar a rodada do usuário...");
                Console.ReadLine();
            }

            if (saldo <= 0)
            {
                Console.WriteLine("Você ficou sem saldo! O jogo acabou.");
                break;
            }

            Console.Write("Deseja continuar? (S/N) ");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();

            if (opcaoContinuar != "S")
                break;
        }
    }

    static int SortearDado()
    {
        Random geradorDeNumeros = new Random();

        int resultado = geradorDeNumeros.Next(1, 7);

        return resultado;
    }
}
