namespace JogoDosDados.ConsoleApp;

internal class Program
{
    static decimal saldo = 100;
    static int posicaoUsuario = 0;
    static int posicaoComputador = 0;
    static void Main(string[] args)
    {
        const int limiteLinhaChegada = 30;

        string nomeUsuario = Corrida.Menu();

        while (saldo > 0)
        {
            posicaoUsuario = 0;
            posicaoComputador = 0;

            decimal aposta = Corrida.ObterAposta();

            bool jogoEmAndamento = true;

            while (jogoEmAndamento)
            {
                Corrida.MenuUsuario(nomeUsuario);

                if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15 || posicaoUsuario == 25)
                {
                    Corrida.AvançoUser();
                }
                else if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
                {
                    Corrida.RetornoUser();
                }

                if (posicaoUsuario >= limiteLinhaChegada)
                {
                    Corrida.Vitoria(nomeUsuario, aposta);
                    jogoEmAndamento = false;
                    continue;
                }

                Corrida.RodadaUsuario();

                Corrida.MenuComputador(nomeUsuario);

                if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15 || posicaoUsuario == 25)
                {
                    Corrida.AvançoComputer();

                }
                else if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
                {
                    Corrida.RetornoComputer();
                }
                if (posicaoComputador >= limiteLinhaChegada)
                {
                    Corrida.Derrota(nomeUsuario, aposta);
                    jogoEmAndamento = false;
                    continue;
                }

                Corrida.RodadaComputador();
            }

            if (saldo <= 0)
            {
                Corrida.SaldoZerado();
                break;
            }

            string opcaoContinuar = Corrida.Loop();

            if (opcaoContinuar != "S")
                break;
        }
    }

}
