using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosModulo13EX02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Cria um novo baralho com X cartas chamando direto o método 'CriarBarlaho'.
            Baralho baralho = CriarBaralho(15);

            // Criando uma mão [lista de CARTA], distribuindo as X primeiras cartas do baralho criado.
            Carta[] mao = baralho.Distribuir(10);

            // Mostrando todas as cartas restantes apos a distribuição.
            baralho.MostrarCartas();

            // Embaralhando as cartas restantes.
            baralho.Embaralhar();

            // Mostrando todas as cartas após embaralhar.
            baralho.MostrarCartas();
        }

        /// <summary>
        /// Criar um novo baralho de acordo com número de cartas informados por parâmetro
        /// </summary>
        /// <param name="numCartas">Número de cartas a serem criadas no baralho</param>
        /// <returns>Retorna um objeto do tipo baralho</returns>
        public static Baralho CriarBaralho(int numCartas)
        {
            // Ao iniciar o método Criar Baralho', 
            // criamos um novo Baralho chamado um segundo método,
            // que cria um novo baralho com todas as cartas possiveis [13 valores * 4 naipes].

            // Criando baralho como todas as cartas possíveis.
            Baralho baralhoInteiro = GerarTodasCartas();

            // Se o número informado no parâmetro for 52 (número maximo de cartas possiveis),
            // o baralho criado será todo o baralho gerado acima (com todas as cartas possíveis).
            if (numCartas == 52)
            {
                Console.WriteLine("Foi criado um baralho com todas as cartas!");
                return baralhoInteiro;
            }
            else // Se informar outro número, o baralho será de cartas aleatorias do baralho inteiro criado acima (Baralho baralhoInteiro = GerarTodasCartas()).
            {

                // Aqui, sorteremos números entre 0 e 51, que correspoderão ao indice do baralho inteiro criado acima.
                // Esses indices sorteador serão adicionados a uma lista, para que seja validado se já foi adicionado ou nao, evitando duplicidade de cartas.

                // Declarando variaveis que serão utilizadas.

                // Variavel do tipo RANDOM para sortear os indices.
                Random r = new Random();

                // Listas onde adionaremos as cartas dos indices sorteados.
                Carta[] cartasNovas = new Carta[numCartas];

                // Contador para sabermos quantas cartas ja adicionamos na lista acima.
                int cont = 0;

                // Listas que adionaremos o indices ja sorteados.
                int[] indSorteados = new int[numCartas]; 

                // Um loop que ficará enquanto o conntador for menor que número de cartas passadas como paramentro do novo baralho a ser criado.
                while (cont < numCartas)
                {
                    // Sorteando um número de 0 a 51 (indices que serão utilizados para pegar cartas em 'baralho inteiro').
                    int indice = r.Next(0, 51); 

                    // Se o indice sorteado acima não tiver sido sorteado anteriormente (evitando duplicidade de cartas):
                    // Adicionaremos a carta correspondente ao indice sorteado na lista de cartas Novas
                    // Adicionaremos o indice sorteado a lista 'indSorteados', para proximas validações
                    // Acionaremos +1 ao contador, que é um controle em qual indice adicionaremos em 'cartasNovas' a carta sorteada.
                    if (!indSorteados.Contains(indice))
                    {
                        cartasNovas[cont] = baralhoInteiro.cartas[indice];
                        indSorteados[cont] = indice;
                        cont++;
                    }

                }
                // Ao finalizar de gerar a lista 'cartasNovas', imprime confirmando quantas cartas foram geradas no baralho.
                Console.WriteLine($"Foram adicionadas {cont} cartas ao baralho!\n");

                // Percorrerá cada carta adicionada na lista 'cartasNovas' e mostrará na tela.
                foreach (Carta c in cartasNovas)
                {
                    Console.WriteLine($"{c.valor} de {c.naipe}");
                }
                // Retornará um novo baralho usando a lista criada acima como parâmetro.
                return new Baralho(cartasNovas);
            }
        }

        /// <summary>
        /// Método abaixo criará um baralho com todas as carta possiveis
        /// Como um baralho tem 13 valores e 4 naipes possiveis, teremos 52 cartas criadas, 
        /// valores -> de 'A' até 'K' do baralho e naipes -> validado pelo itens no ENUM Naipe.
        /// </summary>
        /// <returns></returns>
        public static Baralho GerarTodasCartas()
        {
            Carta[] temp = new Carta[52];
            int indice = 0;
            for (int v = 0; v < 13; v++)
            {                
                for (int n = 0; n < Enum.GetNames(typeof(Carta.Naipe)).Length; n++)
                {
                    Carta card = new Carta(v+1, (Carta.Naipe)n+1);
                    temp[indice] = card;
                    indice++;
                }
            }
            return new Baralho(temp);
        }

    }

}


