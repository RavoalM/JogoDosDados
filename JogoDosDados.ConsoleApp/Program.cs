namespace JogoDosDados.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        const int limiteLinhaChegada = 30;
        decimal saldo = 100;

        Console.WriteLine("================================================");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("================================================");
        Console.Write("Digite seu nome: ");
        string nomeUsuario = Console.ReadLine()!;

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

                Console.WriteLine("================================================");
                Console.WriteLine("Rodada do Usuário");
                Console.WriteLine("================================================");
                Console.WriteLine($"Casa {nomeUsuario}:{posicaoUsuario}|||Casa Computador:{posicaoComputador}");
                Console.WriteLine("================================================");
                Console.Write("Pressione ENTER para lançar o dado...");
                Console.ReadLine();

                int resultadoUsuario = SortearDado();
               
                Console.WriteLine("\n================================================");
                Console.WriteLine($"O valor sorteado foi: {resultadoUsuario}!");
                Console.WriteLine("-----------------------");

                posicaoUsuario += resultadoUsuario;
                Console.WriteLine($"Você está na posição: {posicaoUsuario} de {limiteLinhaChegada}!");
                
                
                if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15 || posicaoUsuario == 25)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Avanço extra de 3 casas!");
                    posicaoUsuario += 3;
                    Console.WriteLine($"Você avançou para a posição: {posicaoUsuario}!");
                   
                }
                else if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Retorne 2 casas!");
                    posicaoUsuario -= 2;
                    Console.WriteLine($"Você recuou para a posição: {posicaoUsuario}!");

                }

                if (posicaoUsuario >= limiteLinhaChegada)
                {
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

                Console.WriteLine("================================================");
                Console.WriteLine("Rodada do Computador");
                Console.WriteLine("================================================");
                Console.WriteLine($"Casa {nomeUsuario}:{posicaoUsuario}|||Casa Computador:{posicaoComputador}");
                Console.WriteLine("================================================");
                Console.Write("Pressione ENTER para lançar o dado...");
                Console.ReadLine();

                int resultadoComputador = SortearDado();
                Console.WriteLine("\n================================================");
                Console.WriteLine($"O valor sorteado foi: {resultadoComputador}!");
                Console.WriteLine("-----------------------");

                posicaoComputador += resultadoComputador;
                Console.WriteLine($"O computador está na posição: {posicaoComputador} de {limiteLinhaChegada}!");

                
                if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15 || posicaoComputador == 25)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Avanço extra de 3 casas!");
                    posicaoComputador += 3;
                    Console.WriteLine($"O computador avançou para a posição: {posicaoComputador}!");
                    
                }
                else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("EVENTO ESPECIAL: Retorne de 2 casas!");
                    posicaoComputador -= 2;
                    Console.WriteLine($"O computador recuou para a posição: {posicaoComputador}!");
                    
                }

                if (posicaoComputador >= limiteLinhaChegada)
                {
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
