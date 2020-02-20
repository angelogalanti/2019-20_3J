using System;

namespace ConsoleApp1
{
    class Program
    {
        static string caratteriUnivoci(string stringa)
        {
            string nonRipetuti = "";
            bool carattereGiaPresente = false;
            foreach (var carattere in stringa)
            {
                //Console.WriteLine(carattere);

                //controllo se il carattere è già presente
                //confrontandolo con tutti quelli già nella stringa
                for (int i = 0; i < nonRipetuti.Length; i++)
                {
                    if (carattere == nonRipetuti[i])
                        carattereGiaPresente = true;
                }
                //se sono qui e carattereGiaPresente è falso aggiungo il carattere
                if (carattereGiaPresente == false)
                    nonRipetuti = nonRipetuti + carattere;
                //resetto la variabile carattereGiaPresente per la prossima iterazione
                carattereGiaPresente = false;
            }
            return nonRipetuti;
        }

        static int contaOccorrenzeCarattere(char carattereDaContare, string stringa)
        {
            int contatore = 0;
            foreach (var carattere in stringa)
            {
                if (carattere == carattereDaContare)
                    contatore++;
            }
            return contatore;
        }

        static int[] trovaPiuPresente(int[] numeroOccorrenze)
        {
            int max = trovaMax(numeroOccorrenze);
            int[] indice;
            int j = 0;
            indice = new int[numeroOccorrenze.Length]; //migliorabile
            for (int i = 0; i < numeroOccorrenze.Length; i++)
            {
                if (numeroOccorrenze[i] == max)
                {
                    indice[j] = i;
                    j++;
                }
            }
            return indice;
        }

        static int trovaMax(int[] numeroOccorrenze)
        {
            int max = 0;
            for (int i = 0; i < numeroOccorrenze.Length; i++)
            {
                if (numeroOccorrenze[i] > max)
                    max = numeroOccorrenze[i];
            }
            return max;
        }

        static void stampaPiuPresente(string stringa, string nonRipetuti, int[] numeroOccorrenze, int[] indice)
        {
            Console.WriteLine(stringa);
            Console.WriteLine(nonRipetuti);
            for (int i = 0; i < numeroOccorrenze.Length; i++)
            {
                if(numeroOccorrenze[i] > 0) //perché?
                    Console.Write(numeroOccorrenze[i]);
            }
            Console.WriteLine("");
            for (int i = 0; i < indice.Length; i++)
            {
                if (indice[i] > 0) {
                    Console.WriteLine(indice[i] + " " + nonRipetuti[indice[i]] + " " + numeroOccorrenze[indice[i]]);
                }
            }
            Console.WriteLine("");
        }

        ////////////////////////////////////////////////
        //CONTA IL CARATTERE PIÙ PRESENTE NELLA STRINGA 
        ////////////////////////////////////////////////
        static void Main(string[] args)
        {
            string stringa = "questa è la stringa";

            //CREA STRINGA CARATTERI UNIVOCI
            string nonRipetuti = caratteriUnivoci(stringa);
            //PER OGNI CARATTERE DELLA STRINGA nonRipetuti 
            //CONTA OCCORRENZE NELLA STRINGA stringa
            int[] numeroOccorrenze;
            numeroOccorrenze = new int[stringa.Length]; //migliorabile
            int i = 0;
            foreach (var carattere in nonRipetuti)
            {
                numeroOccorrenze[i] = contaOccorrenzeCarattere(carattere, stringa);
                i = i + 1;
            }
            //TROVA CARATTERE/I PIU PRESENTE
            int[] indice = trovaPiuPresente(numeroOccorrenze);
            //STAMPA CARATTERE/I PIU PRESENTE
            stampaPiuPresente(stringa, nonRipetuti, numeroOccorrenze, indice);
        }
    }
}