using System;

namespace jogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            char jogador1, jogador2 ;
            char[] jogadores = new char[2];

            Console.WriteLine("Par ou impar para decidir a ordem de jogada!");
            
            Console.Write("Jogador 1, escolha, X ou O: ");
            jogador1 = Convert.ToChar(Console.ReadLine());

            while(jogador1 != 'X' && jogador1 != 'O')
            {
                Console.Write("Jogador 1, escolha, X ou O: ");
                jogador1 = Convert.ToChar(Console.ReadLine());
            }

            if(jogador1 == 'X')
            {
                jogador2 = 'O';

                Console.WriteLine("Jogador 1 marca {0} e Jogador 2 marca {1}", jogador1, jogador2);
            }
            else
            {
                jogador2 = 'X';
                Console.WriteLine("Jogador 1 marca {0} e Jogador 2 marca {1}", jogador1, jogador2);
            }
            
            jogadores[0] = jogador1;
            jogadores[1] = jogador2;
        }
    }
}
