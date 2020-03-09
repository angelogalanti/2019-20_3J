using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //aggiungo la libreria per la gestione dei file di testo

namespace GestioneFileDiTesto
{
    class Program
    {
        static void Main(string[] args)
        {
            //GESTIONE COSTRUTTO TRY CATCH
            Console.WriteLine("GESTIONE COSTRUTTO TRY CATCH");
            try //costrutto try catch per gestire errori es. file non trovato
            {
                StreamReader fileInesistente = new StreamReader("nonEsiste.txt");
                //non trovando il file l'istruzione c'e' un errore e viene eseguito
                //le istruzioni del blocco catch
                //se non ci fosse errore le istruzioni del blocco catch
                //non verrebbero eseguite
            }
            catch (Exception e) //e e' una variabile particolare che contiene l'errore
            {
                Console.WriteLine("Si e' verificato un errore" );
                //DECOMMENTARE LA RIGA SEGUENTE PER VEDERE IL DETTAGLIO DELL'ERRORE
                //Console.WriteLine(" " + e.ToString()); //stampo l'errore
            }

            //GESTIONE FILE - PERCORSO DEL FILE DI TESTO
            Console.WriteLine("GESTIONE FILE - PERCORSO DEL FILE DI TESTO");
            //il modo piu' semplice e' creare il file nella stessa cartella
            //del file eseguibile del progetto, nel mio caso:
            //C:\Users\angel\Documents\Visual Studio 2013\Projects\
            //GestioneFileDiTesto\GestioneFileDiTesto\bin\Debug
            //la cartella contiene GestioneFileDiTesto.exe e anche il file esiste.txt
            try
            {
                //se nella stessa cartella e' sufficiente specificare il nome
                StreamReader fileEsistente = new StreamReader("esiste.txt");
                Console.WriteLine("file aperto correttamente");
                fileEsistente.Close();

                //oppure posso specificare il percorso assoluto del file, attenzione alla @
                fileEsistente = new StreamReader(@"C:\Users\angel\Downloads\esisteAncheQuesto.txt");
                Console.WriteLine("file aperto correttamente");
                fileEsistente.Close();
            }
            catch (Exception e) //non eseguito perche' il file e' stato trovato
            {
                Console.WriteLine(" " + e.ToString());
            }


            //GESTIONE FILE - LEGGI UNA RIGA
            Console.WriteLine("GESTIONE FILE - LEGGI UNA RIGA");
            string riga = "";
            try //costrutto try catch per gestire errori es. file non trovato
            {
                StreamReader fileEsistente = new StreamReader("esiste.txt");
                riga = fileEsistente.ReadLine();
                Console.WriteLine("riga del file:" + riga);
                fileEsistente.Close();
            }
            catch (Exception e) //e e' una variabile particolare che contiene l'errore
            {
                Console.WriteLine(" " + e.ToString()); //stampo l'errore
            }

            //GESTIONE FILE - LEGGI TUTTO IL FILE
            Console.WriteLine("GESTIONE FILE - LEGGI TUTTO IL FILE");
            try //costrutto try catch per gestire errori es. file non trovato
            {
                StreamReader fileEsistente = new StreamReader("esiste.txt");
                //fino a che non e' stata raggiunta la fine del file
                while (!fileEsistente.EndOfStream)
                {
                    riga = fileEsistente.ReadLine();
                    Console.WriteLine("riga del file:" + riga);
                }
                fileEsistente.Close();
            }
            catch (Exception e) //e e' una variabile particolare che contiene l'errore
            {
                Console.WriteLine(" " + e.ToString()); //stampo l'errore
            }

            //GESTIONE FILE - LEGGI TUTTO IL FILE DI NUMERI
            Console.WriteLine("GESTIONE FILE - LEGGI TUTTO IL FILE DI NUMERI");
            int numero;
            int totale = 0; //somma tutti i numeri del file
            try //costrutto try catch per gestire errori es. file non trovato
            {
                StreamReader fileDiNumeri = new StreamReader("numeri.txt");
                //fino a che non e' stata raggiunta la fine del file
                while (!fileDiNumeri.EndOfStream)
                {
                    numero = Convert.ToInt32(fileDiNumeri.ReadLine());
                    Console.WriteLine("riga del file:" + numero);
                    totale = totale + numero;
                }
                fileDiNumeri.Close();
                Console.WriteLine("totale:" + totale);
            }
            catch (Exception e) //e e' una variabile particolare che contiene l'errore
            {
                Console.WriteLine(" " + e.ToString()); //stampo l'errore
            }

        }
    }
}
