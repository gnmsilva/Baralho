using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosModulo13EX02
{
    /// <summary>
    /// Classe de cartas contendo property valor e Enum para os naipes 
    /// </summary>
    public class Carta
    {
        // Criando os fields pertencentes a classe Cartas.

        public int valor { get; set; }

        // Para o naipe, foi criado um ENUM para que os mesmo seja limitado às opções, alem de podem facilitar nas criações.
        public Naipe naipe { get; set; }

        /// <summary>
        /// ENUM para utilização dos NAIPES das CARTAS. Iniciando no valor 1 (adicionando +1 para os demais)
        /// </summary>
        public enum Naipe
        {
            Copas = 1,
            Paus,
            Espadas,
            Ouro,
        }

        /// <summary>
        /// Construtor que atribui aos fields ao criar uma carta, exigindo como parâmetro o valor (de 1 a 13) e naipe (ENUM);
        /// </summary>
        /// <param name="valor">Valor númerico para a carta</param>
        /// <param name="naipe">Naipe para a carta</param>
        public Carta(int valor, Naipe naipe)
        {
            this.valor = valor;
            this.naipe = naipe;
        }
    }
}
