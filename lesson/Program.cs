using System.Net.NetworkInformation;
using System.Reflection.Emit;

namespace lesson
{
    public class Program
    {
        /// <summary>
        /// Variabile globale che rappresenta la matrice da caricare e stampare.
        /// </summary>
        private static int[,] matrix;

        /// <summary>
        /// The main entrypoint of your application.
        /// </summary>
        /// <param name="args">The arguments passed to the program</param>
        public static void Main(string[] args)
        {
            try
            {
                int choice = CreateMenu();
                DoOperation(choice);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                Main(args);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Crea un menù che accetta un input utente e pone le seguenti opzioni.
        /// 1 - Carica matrice
        /// 2 - Stampa matrice caricata
        /// 3 - Stampa matrice identità
        /// </summary>
        /// <returns>La scelta dell'utente, se valida, altrimenti -1.</returns>
        private static int CreateMenu()
        {
            Console.WriteLine("1 - Carica matrice");
            Console.WriteLine("2 - Stampa matrice caricata");
            Console.WriteLine("3 - Stampa matrice identità");

            Console.Write("Fai la tua scelta:");

            
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice < 1 || choice > 3)
            {
                throw new ArgumentException(
                    "Hai sbagliato, voglio una scelta valida"
                );
            }

            return choice;
        }

        /// <summary>
        /// In base alla scelta specificata, esegue l'operazione 
        /// come specificato dal menù.
        /// </summary>
        /// <param name="choice">La scelta dell'operazione</param>
        private static void DoOperation(int choice)
        {
            switch(choice)
            {
                case 1:
                    LoadMatrix();
                    break;
                case 2:
                    PrintMatrix();
                    break;
                case 3:
                    PrintIdentityMatrix();
                    break;
                default:
                    throw new ArgumentException("Scelta non valida");
            }
        }


        /// <summary>
        /// Carica una matrice 2x2
        /// </summary>
        private static void LoadMatrix()
        {
            matrix = new int[2, 2];

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    try
                    {
                        Console.Write($"matrix[{i}, {j}] = ");
                        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Valore non valido");

                        j--; // torno indietro per richiedere l'input
                    }
                }
            }
        }

        /// <summary>
        /// Stampa la matrice caricata precedentemente
        /// </summary>
        private static void PrintMatrix()
        {
            try
            {
                int rows = matrix.GetLength(0);
                int columns = matrix.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }

                    Console.WriteLine();
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Matrice non inizializzata");
            }
        }

        /// <summary>
        /// Stampa una matrice identità 3x3
        /// </summary>
        private static void PrintIdentityMatrix()
        {
            matrix = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            PrintMatrix();
        }
    }
}
