using System;

namespace jogoDaVelha
{
    class Program
    {
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
            int j = 0, linha = 0, coluna = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                for (j = 0; j < vet.Length; j++)
                {
                    Console.WriteLine("\nJogador {0}", j+1);
                    Console.Write("\nLinha: ");
                    linha = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Coluna: ");
                    coluna = Convert.ToInt32(Console.ReadLine());
                    
                    if(mat[linha, coluna] !=' ')
                    {
                        Console.WriteLine("Espaço marcado, faça outra jogada");
                        j--;
                    }
                    else if(linha < 0 || linha > 2)
                    {
                        Console.WriteLine("Linha inválida, faça outra jogada");
                        j--;
                    }
                    else if((coluna < 0 || coluna > 2))
                    {
                        Console.WriteLine("Coluna inválida, faça outra jogada");
                        j--;
                    }
                    else
                    {
                        mat[linha, coluna] = vet[j];
                    }

                    if(i >= 2)
                    {
                        juiz(mat, vet);
                    }

                    if(vet[j] == 'v')
                    {
                        imprimiTabuleiro(mat);
                        Console.WriteLine("Parabéns, o Jogador {0} venceu!", j+1);
                        return mat;
                    }
                    
                    if(vet[j] == 'e')
                    {
                        imprimiTabuleiro(mat);
                        Console.WriteLine("Deu Velha!!");
                        return mat;
                    }

                     imprimiTabuleiro(mat);
                }                         
            }

            return mat;     
        }

        static char[] juiz (char[,] mat, char[] vet)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < vet.Length; j++)
                {
                    if(mat[i, 0] == mat[i,1] && mat[i, 0] == mat[i,2] && mat[i,0] == vet[j])
                    {
                        vet[j] = 'v';
                        return vet;
                    }
                }       
            }   
            
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                for(int j = 0; j < vet.Length; j++)
                {
                    if(mat[0,i] == mat[1,i] && mat[0,i] == mat[2,i] && mat[0,i] == vet[j])
                    {
                        vet[j] = 'v';
                        return vet;
                    }
                }       
            }   

            if(mat[0,0] == mat[1,1] && mat[0,0] == mat[2,2])
            {
                for (int i = 0; i < vet.Length; i++)
                {
                    if(mat[0,0] == vet[i])
                    {
                        vet[i] = 'v';
                        return vet;
                    }    
                }
            }

            if(mat[0,2] == mat[1,1] && mat[0,2] == mat[2,0])
            {
                for (int i = 0; i < vet.Length; i++)
                {
                    if(mat[0,2] == vet[i])
                    {
                        vet[i] = 'v';
                        return vet;
                    }
                }
                
            }

            int contador = 0;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    if(mat[i,j] != ' ')  
                    {
                        contador++;
                        if(contador == 9)
                        {
                            vet[0] = 'e';
                            vet[1] = 'e';
                            return vet;
                        }
                    }
                }    
            }
            return vet;        
        }
        
        static void Main(string[] args)
        {
            char jogador1 ='x', jogador2 = 'o';
            char[] jogadores = new char[]{jogador1, jogador2};
            char[,] tabuleiro = new char[3,3];

            Console.WriteLine();
            Console.WriteLine("Par ou impar para decidir a ordem de jogada!");
            Console.WriteLine("Jogador 1 marca x\n Jogador 2 marca o");
            Console.WriteLine();

            limpaTabuleiro(tabuleiro);

            imprimiTabuleiro(tabuleiro);

            jogada(tabuleiro, jogadores);
        }
    }
}