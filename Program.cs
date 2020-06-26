using System;

namespace jogoDaVelha
{
    class Program
    {
        static char[] ordemEMarcador (char[] vet)
        {
            char jogador1, jogador2;

            Console.WriteLine("Par ou impar para decidir a ordem de jogada!");
            
            Console.Write("Jogador 1, escolha, x ou o: ");
            jogador1 = Convert.ToChar(Console.ReadLine());

            while(jogador1 != 'x' && jogador1 != 'o')
            {
                Console.Write("Jogador 1, escolha, x ou o: ");
                jogador1 = Convert.ToChar(Console.ReadLine());
            }

            if(jogador1 == 'x')
            {
                jogador2 = 'o';

                Console.WriteLine("Jogador 1 marca {0} e Jogador 2 marca {1}", jogador1, jogador2);
            }
            else
            {
                jogador2 = 'x';
                Console.WriteLine("Jogador 1 marca {0} e Jogador 2 marca {1}", jogador1, jogador2);
            }

            vet[0] = jogador1;
            vet[1] = jogador2;

            Console.WriteLine();

            return vet;
        }
        static char[,] limpaTabuleiro (char[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i,j] = ' ';
                }   
            }

            return mat;
        }
        static void imprimiTabuleiro (char[,] mat)
        {
            Console.WriteLine("      0      1      2");

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                Console.Write("{0}  ", i);

                for (int j = 0; j < mat.GetLength(1); j++)
                {  
                   Console.Write(" | {0} | ", mat[i,j]);
                   
                   if(j == 2)
                   {
                       Console.WriteLine();
                   }
                }
                
            }
            
        }
        static char[,] jogada (char[,] mat, char[] vet)
        {   
            int linha = 0, coluna = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < vet.Length; j++)
                {
                    Console.WriteLine("\nJogador {0}", j+1);
                    Console.Write("\nLinha: ");
                    linha = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Coluna: ");
                    coluna = Convert.ToInt32(Console.ReadLine());

                    mat[linha, coluna] = vet[j];
                    imprimiTabuleiro(mat);
                    juiz(mat);
                }


                
            }

            return mat;
           
        }
        static void juiz (char[,] mat)
        {
            int o = 0, x = 0;

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if(mat[i,j] == 'x')
                    {
                        x++;
                    }
                    else
                    {
                        o++;
                    }
                }
            }

            
            
        }
        static void Main(string[] args)
        {

            char[] jogadores = new char[2];
            char[,] tabuleiro = new char[3,3];

            ordemEMarcador(jogadores);
            
            limpaTabuleiro(tabuleiro);

            imprimiTabuleiro(tabuleiro);

            jogada(tabuleiro, jogadores);
        }
    }
}
