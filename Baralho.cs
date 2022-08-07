using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosModulo13EX02
{
    /// <summary>
    /// Classe para a criação de baralhos, contendo como field uma lista do tipo Cartas
    /// </summary>
    class Baralho
    {
        // Como field, o mesmo tem uma lista da classe de CARTAS.   
        public Carta[] cartas;

        /// <summary>
        /// Construtor para criação do baralho ao iniciar um novo objeto do tipo.
        /// Deve receber uma lista da classe CARTAS como parâmetro;
        /// </summary>
        /// <param name="cartas">Lista da classe CARTAS como parâmetro</param>
        public Baralho(Carta[] cartas)
        {
            this.cartas = cartas;
        }

        /// <summary>
        /// Distribuir as cartas , de acordo com a  quantidade de cartas informadas por parâmetro
        /// </summary>
        /// <param name="qtde">Quantidade de cartas a serem distribuídas</param>
        /// <returns>Lista com as cartas a serem distribuídas</returns>
        public Carta[] Distribuir(int qtde)
        {
            // Criando uma lista de CARTAS que receberá as cartas que serão distribuídas.
            Carta[] distribuir = new Carta[qtde];

            // FOR que pegará as primeiras cartas do baralho em questão
            // e adicionará na lista criada acima.
            // Além de setar como NULL o indice do baralho que foi distribuído,
            // pois não pertence mais ao baralho.
            for (int q = 0; q < qtde; q++)
            {
                distribuir[q] = this.cartas[q];
                this.cartas[q] = null;
            }
            return distribuir;
        }


        /// <summary>
        /// Exibir todas as cartas do baralho. Como não podemos mostrar as cartas 'distribuídas' (setadas como NULL no método DISTRIBUIR),
        /// percorrerá todo o field cartas(lista do tipo CARTAS) e se a posição for NULL, não mostrará.
        /// </summary>
        public void MostrarCartas()
        {
            Console.WriteLine("\nAs cartas atuais no baralho são:\n"); 
            foreach (Carta c in this.cartas)
            {
                if (c != null)
                {
                    Console.WriteLine($"{c.valor} de {c.naipe}");
                }
            }
        }

        /// <summary>
        /// Realizar o embaralhamento do BARALHO
        /// </summary>
        public void Embaralhar()
        {
            // Primeiro, percorreremos todo as CARTAS do baralho e gravaremos todos os indices que não são NULL,
            // ou seja, indices de cartas que não foram distribuídas.

            // Criando variaveis a serem utilizadas.

            // Lista que serão armazenados os indices que existem cartas.
            int[] indCartasExistentes = new int[this.cartas.Length];

            // Contador será usado para sabermos qual o indice que estamos lendo e guarda-lo caso não seja NULL dentro do baralho.
            int contador = 0;

            //Contador para sabermos quantos indices correspondem as cartas existentes no baralho e como o proprio indice para armazenar na lista acima (indCartasExistentes).
            int cartasExistentes = 0; 

            // Percorrendo as cartas do baralho (field de lista do tipo CARTAS).
            foreach (Carta c in this.cartas)
            {
                if (c != null)
                {
                    // Se a carta em questão (c) não for NULL, adiciona o índice (controlado pelo contador) a lista 'indCartasExistentes'
                    // o indice que será armazenado em 'indCartasExistentes' é a propria soma de cartas não NULL lidas até o momento.
                    // Abaixo, estamos acrescentado 1 ao indice armazenado (contador +1), pois abaixo percorreremos a lista 'indCartasExistentes' novamente,
                    // e como não sabemos se o indice estaria como ZERO(0) por ser indice 'em branco' ou por ser o real indice lido aqui, somamos 1, que será subtraido novamente no proximo passo.
                    indCartasExistentes[cartasExistentes] = contador + 1;
                    cartasExistentes++;
                }
                contador++;
            }


            // Como não sabemos exatamente quantas cartas ainda existem no baralho (visto que posso ter feito varias ditribuicoes),
            // a lista a cima foi criada com o tamanho total do baralho (tamanho field lista de CARTAS).
            // Como, provavelmente pela distribuição de cartas, teremos menos "indices existentes" do que o tamanho da lista 'indCartasExistentes', 
            // a mesma seria preenchida com vários ZEROS, correspondentes aos índices vazios do field lista de CARTAS lidos acima.
            // Vamos fazer essa correção abaixo,

            // Agora, percorreremos todo os itens da lista (indices salvos) criada acima (indCartasExistentes),
            // se o índice for diferente de zero (por esse motivo acrecentamos 1 em cima), ele salvará o mesmo (subtraindo o 1)
            // na nova lista 'existentes'.

            // Criando a lista 'existentes' que terá o tamanho de quantas cartas validamos acima.
            // Resetendo o contador para reutilização.
            int[] existentes = new int[cartasExistentes];
            contador = 0;
            foreach (int i in indCartasExistentes)
            {
                if (i != 0)
                {
                    // Subtraimos 1, pois assim voltamos a ter o real indice de onde temos cartas existente no atual baralho (explicado acima).
                    existentes[contador] = i - 1; 
                    contador++;
                }
            }

            // Criaremos um nova lista de cartas, cujo terá o mesmo tamaho de cartas existentes (diferente de NULL lida acima)
            // e que receberá,em ordem RANDOM (através de índices), as cartas que sobraram (existentes) no baralho atual.

            // Declarando as listas e variaveis que serão utilizadas.

            // Nova lista de cartas que adicionaremos em ordem aleatoria a nova ordenação das cartas.
            Carta[] embaralhadas = new Carta[cartasExistentes];

            // Lista que adiconaremos quais foram os índices já sorteados.
            int[] sorteados = new int[existentes.Length];

            // Variavel que sorteará o índice que contem uma carta existente no atual baralho.
            Random rand = new Random();

            // Resetando contador.
            contador = 0;

            // Um loop que só sairá quando o contador atingir o número de cartas (indices) que temos na lista 'existentes'
            // pois essa lista possui os indices que há cartas != NULL no atual baralho.
            while (contador < existentes.Length)
            {
                // Sorteando um número, cujo está entre o menor e o maior indice salvo na lista 'existentes'.
                int sorteado = rand.Next(existentes.Min(), existentes.Max() + 1); 

                // Se o número sorteado está contido nos índices salvos em 'existentes' e ele não estiver na lista de indices já sorteados
                // adicionaremos a lista de CARTAS 'embaralhadas' a carta correspondente ao índice sorteado (que é um índice que sabemos que há uma carta existente no atual baralho)
                // além de salvar esse índice dentro da lista 'sorteados', para evitar que a carta seja duplicada.
                // A carta é adicionada ao proximo indice livre da lista criada 'embaralhadas', controlado pela variavel 'contador', que só é incrementado quando adicionamos uma carta.
                if (existentes.Contains(sorteado) && !sorteados.Contains(sorteado))
                {
                    embaralhadas[contador] = this.cartas[sorteado];
                    sorteados[contador] = sorteado;
                    contador++;
                }
            }
            // Atribui a lista criada em ordem aleatoria ao field 'cartas' (listas de CARTAS) do baralho. 
            this.cartas = embaralhadas;
        }

    }

}
