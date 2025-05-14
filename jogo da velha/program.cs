using System;

class JogoDaVelha
{
    static char[] tabuleiro = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int jogadorAtual = 1; // Jogador 1 começa
    static int escolha;
    static int vencedor = 0; // 0 = sem vencedor, 1 = jogador 1, 2 = jogador 2

    static void Main(string[] args)
    {
        do
        {
            Console.Clear(); // Limpa o console a cada jogada
            Console.WriteLine("Jogador 1: X | Jogador 2: O");
            Console.WriteLine("\n");
            
            DesenharTabuleiro();
            
            // Verifica se o jogo terminou em empate
            if (VerificarEmpate())
            {
                Console.WriteLine("\nEmpate! Ninguém venceu.");
                break;
            }
            
            // Verifica se há um vencedor
            if (vencedor != 0)
            {
                Console.WriteLine("\nJogador {0} venceu!", vencedor);
                break;
            }
            
            Console.WriteLine("\nJogador {0}, escolha uma posição: ", jogadorAtual);
            
            bool entradaValida = int.TryParse(Console.ReadLine(), out escolha);
            
            if (entradaValida && escolha >= 1 && escolha <= 9 && tabuleiro[escolha - 1] != 'X' && tabuleiro[escolha - 1] != 'O')
            {
                // Marca a jogada no tabuleiro
                char marca = (jogadorAtual == 1) ? 'X' : 'O';
                tabuleiro[escolha - 1] = marca;
                
                // Verifica se há um vencedor após a jogada
                if (VerificarVencedor(marca))
                {
                    vencedor = jogadorAtual;
                }
                else
                {
                    // Alterna para o próximo jogador
                    jogadorAtual = (jogadorAtual == 1) ? 2 : 1;
                }
            }
            else
            {
                Console.WriteLine("Jogada inválida. Tente novamente.");
                Console.ReadLine();
            }
            
        } while (true);
        
        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    private static void DesenharTabuleiro()
    {
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", tabuleiro[0], tabuleiro[1], tabuleiro[2]);
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", tabuleiro[3], tabuleiro[4], tabuleiro[5]);
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", tabuleiro[6], tabuleiro[7], tabuleiro[8]);
        Console.WriteLine("     |     |     ");
    }

    private static bool VerificarVencedor(char marca)
    {
        // Verifica linhas
        if ((tabuleiro[0] == marca && tabuleiro[1] == marca && tabuleiro[2] == marca) ||
            (tabuleiro[3] == marca && tabuleiro[4] == marca && tabuleiro[5] == marca) ||
            (tabuleiro[6] == marca && tabuleiro[7] == marca && tabuleiro[8] == marca) ||
            // Verifica colunas
            (tabuleiro[0] == marca && tabuleiro[3] == marca && tabuleiro[6] == marca) ||
            (tabuleiro[1] == marca && tabuleiro[4] == marca && tabuleiro[7] == marca) ||
            (tabuleiro[2] == marca && tabuleiro[5] == marca && tabuleiro[8] == marca) ||
            // Verifica diagonais
            (tabuleiro[0] == marca && tabuleiro[4] == marca && tabuleiro[8] == marca) ||
            (tabuleiro[2] == marca && tabuleiro[4] == marca && tabuleiro[6] == marca))
        {
            return true;
        }
        return false;
    }

    private static bool VerificarEmpate()
    {
        foreach (char posicao in tabuleiro)
        {
            if (posicao != 'X' && posicao != 'O')
            {
                return false; // Ainda há posições vazias
            }
        }
        return true; // Todas as posições estão preenchidas
    }
}