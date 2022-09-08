class Program
{
    static void Main(string[] args)
    {
        int statusDoJogo = 0;
        int jogadorAtual = -1;
        char[] marcadores = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        Console.ForegroundColor = ConsoleColor.Cyan;

        do
        {
            Console.Clear();

            jogadorAtual = GetProximoJogador(jogadorAtual);

            Iniciar(jogadorAtual);
            DesenharTabuleiro(marcadores);

            Engine(marcadores, jogadorAtual);

            statusDoJogo = VerificarGanhador(marcadores);

        } while (statusDoJogo.Equals(0));

        Console.Clear();
        Iniciar(jogadorAtual);
        DesenharTabuleiro(marcadores);

        if (statusDoJogo.Equals(1))
        {
   
            Console.WriteLine($"Jogador {jogadorAtual} é o vencedor!");
        }

        if (statusDoJogo.Equals(2))
        {
            Console.WriteLine($"O jogo empatou!");
        }
    }

    private static int VerificarGanhador(char[] marcadores)
    {
        if (IsGanhador(marcadores))
        {
            return 1;
        }

        if (IsEmpate(marcadores))
        {
            return 2;
        }

        return 0;
    }

    private static bool IsEmpate(char[] marcadores)
    {
        return marcadores[0] != '1' &&
               marcadores[1] != '2' &&
               marcadores[2] != '3' &&
               marcadores[3] != '4' &&
               marcadores[4] != '5' &&
               marcadores[5] != '6' &&
               marcadores[6] != '7' &&
               marcadores[7] != '8' &&
               marcadores[8] != '9';
    }

    private static bool IsGanhador(char[] marcadores)
    {
        if (IsMesmoMarcadores(marcadores, 0, 1, 2))
        {
            return true;
        }

        if (IsMesmoMarcadores(marcadores, 3, 4, 5))
        {
            return true;
        }

        if (IsMesmoMarcadores(marcadores, 6, 7, 8))
        {
            return true;
        }

        if (IsMesmoMarcadores(marcadores, 0, 3, 6))
        {
            return true;
        }

        if (IsMesmoMarcadores(marcadores, 1, 4, 7))
        {
            return true;
        }

        if (IsMesmoMarcadores(marcadores, 2, 5, 8))
        {
            return true;
        }

        if (IsMesmoMarcadores(marcadores, 0, 4, 8))
        {
            return true;
        }

        if (IsMesmoMarcadores(marcadores, 2, 4, 6))
        {
            return true;
        }

        return false;
    }

    private static bool IsMesmoMarcadores(char[] verificaMarcadores, int pos1, int pos2, int pos3)
    {
        return verificaMarcadores[pos1].Equals(verificaMarcadores[pos2]) && verificaMarcadores[pos2].Equals(verificaMarcadores[pos3]);
    }

    private static void Engine(char[] marcadores, int jogadorAtual)
    {
        bool movimentoInvalido = true;

        do
        {
            string inputUsuario = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputUsuario) &&
                (inputUsuario.Equals("1") ||
                inputUsuario.Equals("2") ||
                inputUsuario.Equals("3") ||
                inputUsuario.Equals("4") ||
                inputUsuario.Equals("5") ||
                inputUsuario.Equals("6") ||
                inputUsuario.Equals("7") ||
                inputUsuario.Equals("8") ||
                inputUsuario.Equals("9")))
            {

                int.TryParse(inputUsuario, out var marcador);

                char marcadorAtual = marcadores[marcador - 1];

                if (marcadorAtual.Equals('X') || marcadorAtual.Equals('O'))
                {
                    Console.WriteLine("Posição já marcada, por favor, selecione outra posição.");
                }
                else
                {
                    marcadores[marcador - 1] = GetMarcador(jogadorAtual);

                    movimentoInvalido = false;
                }
            }
            else
            {
                Console.WriteLine("Valor inválido, por favor, selecione uma posição correta!");
            }
        } while (movimentoInvalido);
    }

    private static char GetMarcador(int jogador)
    {
        if (jogador % 2 == 0)
        {
            return 'O';
        }

        return 'X';
    }

    static void Iniciar(int NumeroDoJogador)
    {

        Console.WriteLine("Jogador 1: X");
        Console.WriteLine("Jogador 2: O");
        Console.WriteLine();

        Console.WriteLine($"Jogador {NumeroDoJogador}, para se mover, selecione um número de 1 a 9 do tabuleiro.");
        Console.WriteLine();
    }

    static void DesenharTabuleiro(char[] marcadores)
    {
        Console.WriteLine($" {marcadores[0]} | {marcadores[1]} | {marcadores[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {marcadores[3]} | {marcadores[4]} | {marcadores[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {marcadores[6]} | {marcadores[7]} | {marcadores[8]} ");
    }

    static int GetProximoJogador(int player)
    {
        if (player.Equals(1))
        {
            return 2;
        }

        return 1;
    }
}