namespace JogoDosDados.ConsoleApp;

internal class Program
{
    static decimal saldo = 100;
    static int posicaoUsuario = 0;
    static int posicaoComputador = 0;
    static void Main(string[] args)
    {
        const int limiteLinhaChegada = 30;

        string nomeUsuario = Menu();

        while (saldo > 0)
        {
            posicaoUsuario = 0;
            posicaoComputador = 0;

            decimal aposta = ObterAposta();

            bool jogoEmAndamento = true;

            while (jogoEmAndamento)
            {
                MenuUsuario(nomeUsuario);

                if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15 || posicaoUsuario == 25)
                {
                    AvançoUser();
                }
                else if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
                {
                    RetornoUser();
                }

                if (posicaoUsuario >= limiteLinhaChegada)
                {
                    VitoriaUsuario(nomeUsuario, aposta);
                    jogoEmAndamento = false;
                    continue;
                }

                RodadaUsuario();

                MenuComputador(nomeUsuario);

                if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15 || posicaoUsuario == 25)
                {
                    AvançoComputer();

                }
                else if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
                {
                    RetornoComputer();
                }
                if (posicaoComputador >= limiteLinhaChegada)
                {
                    DerrotaUsuario(nomeUsuario, aposta);
                    jogoEmAndamento = false;
                    continue;
                }

                RodadaComputador();
            }

            if (saldo <= 0)
            {
                SaldoZerado();
                break;
            }

            string opcaoContinuar = Loop();

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

    static string Menu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("================================================");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("================================================");
        Console.Write("Digite seu nome: ");
        string nomeUsuario = Console.ReadLine()!;

        return nomeUsuario;
    }

    static decimal ObterAposta()
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

        return aposta;
    }

    static void RodadaUsuario()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("================================================");
        Console.Write("\nPressione ENTER para começar a rodada do computador...");
        Console.ReadLine();
    }

    static void RodadaComputador()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("================================================");
        Console.Write("\nPressione ENTER para começar a rodada do usuário...");
        Console.ReadLine();
    }

    static void MenuUsuario(string nomeUsuario)
    {
        const int limiteLinhaChegada = 30;

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Blue;
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
    }

    static void MenuComputador(string nomeUsuario)
    {
        const int limiteLinhaChegada = 30;

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Magenta;
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
    }

    static void AvançoUser()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("-----------------------");
        Console.WriteLine("EVENTO ESPECIAL: Avanço extra de 3 casas!");
        posicaoUsuario += 3;
        Console.WriteLine($"Você avançou para a posição: {posicaoUsuario}!");
        Console.WriteLine("================================================");
    }

    static void RetornoUser()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("-----------------------");
        Console.WriteLine("EVENTO ESPECIAL: Retorne 2 casas!");
        posicaoUsuario -= 2;
        Console.WriteLine($"Você recuou para a posição: {posicaoUsuario}!");
        Console.WriteLine("================================================");
    }

    static void AvançoComputer()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("-----------------------");
        Console.WriteLine("EVENTO ESPECIAL: Avanço extra de 3 casas!");
        posicaoUsuario += 3;
        Console.WriteLine($"O computador avançou para a posição: {posicaoUsuario}!");
        Console.WriteLine("================================================");
    }

    static void RetornoComputer()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("-----------------------");
        Console.WriteLine("EVENTO ESPECIAL: Retorne 2 casas!");
        posicaoUsuario -= 2;
        Console.WriteLine($"O computador recuou para a posição: {posicaoUsuario}!");
        Console.WriteLine("================================================");
    }

    static void VitoriaUsuario(string nomeUsuario, decimal aposta)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
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

    }

    static void DerrotaUsuario(string nomeUsuario, decimal aposta)
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
    }

    static void SaldoZerado()
    {
        Console.WriteLine("Você ficou sem saldo! O jogo acabou.");

    }

    static string Loop()
    {
        Console.Write("Deseja continuar? (S/N) ");
        string opcaoContinuar = Console.ReadLine()!.ToUpper();
        return opcaoContinuar;
    }
}
