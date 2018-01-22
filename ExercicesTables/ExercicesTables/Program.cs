/***
 * Programme d'étude mathématique du primaire
 * 
 * Auteur : Michel Bourassa
 * 27 novembre 2017 
 ***/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilitaires.Util;
using static System.Console;
using System.Timers;
using System.Threading;

namespace ExercicesTables
{
    struct Équation
    {
        public int nb1;
        public int nb2;
        public char opérateur;
        public int? réponse;

        public override string ToString()
        {
            return nb1 + " " + opérateur + " " + nb2 + " = " + réponse;
        }
    }

    class Program
    {
        
        string nom;
        List<Équation> équations = new List<Équation>();
        List<int> réponses = new List<int>();
        char opérateur;
        char op;
        int choix;
        int table;
        int nbÉquations;
        int nbA;
        int nbB;
        int réponse;
        

        Random m_random = new Random();
        //Timer m_chrono = new Timer(1000);

        static void Main(string[] args)
        {
            new Program().Principale();
        }

        void Principale()
        {
            
            WriteLine("Bonjour, bienvenue dans l'exerciseur de tables de mathématique.");
            nom = LireStringNonVide("Bonjour quel est ton nom : ");

            WriteLine($"Super!\n Maintenant, {nom} choisi le type de table que tu veux pratiquer.");
            Pause();
            
             for(;;)
            {
                //Console.Clear();
                WriteLine("1 - Additions\n" +
                            "2 - Soustractions\n" +
                            "3 - Multiplicaitons\n" +
                            "4 - Divisions\n\n" +                            
                            "0 - Passer au menu suivant.");
                choix = LireInt32DansIntervalleOuSentinelle("Choisi la table que tu veux pratiquer ou  0 pour quitter: ", 1, 4, 0);

                /***/
                if (choix == 0) break;
                /***/
                
                switch(choix)
                {
                    case 1 :
                        opérateur = '+';
                        op = opérateur;
                        break;
                    case 2 :
                        opérateur = '-';
                        op = opérateur;
                        break;
                    case 3 : opérateur = '*';
                        op = 'X';
                        break;
                    case 4 : opérateur = '/';
                        op = (char)247;
                        break;
                    default:break;
                }

                ChoisirTables();
            }
            
        }

        /// <summary>
        /// Configuraiton des options de pratique pour l'utilisateur.
        /// </summary>
        void ChoisirTables()
        {

            WriteLine("Excellent!, maintenant choisi jusqu'à quelle table tu veux pratiquer.");
            table = LireInt32DansIntervalleOuSentinelle("Choisi entre 1 et 12 ou 0 pour revenir au menu précédent : ", 1, 12, 0);
            if (table == 0) return;

            WriteLine("Dernière question combien veux tu pratiquer d'équations?");
            
            //Validaiton du nombres de questions possibles en fonction des tables choisies:
            int nbMaxQuestions = (table >= 5) ? 50 : table * 12;

            nbÉquations = LireInt32DansIntervalleOuSentinelle($"Choisi un nombre entre 1 et {nbMaxQuestions} ou  0 pour revenir au menu précédent : ", 1, nbMaxQuestions, 0);
                        
            if (nbÉquations == 0) return;
            
            AfficherÉquations();
        }

        void AfficherÉquations()
        {
            Thread th = new Thread(ConstruireÉquations);
            th.Start();
            //Équation équation = new Équation();

            DateTime début = DateTime.Now;
            do
            {
                for (int i = 0; i < nbÉquations; ++i)

                
                    {
                        réponse = LireInt32PositifLigne(équations[i].ToString());
                    //équations[i].réponse.Value = réponse;
                    int bonneRéponse = nbA + opérateur + nbB;
                    //switch (opérateur)
                    //{
                    //    case '+': bonneRéponse = nbA + nbB; break;
                    //    case '-': bonneRéponse = nbA - nbB; break;
                    //    case '*': bonneRéponse = nbA * nbB; break;
                    //    case '/': bonneRéponse = nbA / nbB; break;
                    //    default: break;
                    //}
                    réponses.Add(réponse);
                    

                    if (i == équations.Count - 1)
                            i = 0;
                        if (équations.All(é => é.réponse != null))
                            i = -1;
                        break;
                    }
            }
            while (équations.Any(é => é.réponse != null) /*|| VérifierTempsAsync < new TimeSpan(0,5,0)*/);
            DateTime fin = DateTime.Now;
            TimeSpan chrono = fin - début;
            WriteLine($"Votre temps est de {chrono.Minutes}:{chrono.Seconds}");            
        }

        /// <summary>
        /// Fonction qui génère un nombre de façon aléatoire, à un paramètre
        /// </summary>
        /// <param name="p_limiteSuppérieure">limite supérieur de la plage</param>
        /// <returns>un nombre entier aléatoire</returns>
        int GénérerNombre(int p_limiteSuppérieure)
        {
            return m_random.Next(1, p_limiteSuppérieure+1);
        }

        /// <summary>
        /// Fonction qui génère un nombre de façon aléatoire, à deux paramètres
        /// </summary>
        /// <param name="p_limiteInférieure">limite inférieure de la plage</param>
        /// <param name="p_limiteSuppérieure">limite suppérieure de la plage</param>
        /// <returns>Un nombre entier aléatoire</returns>
        int GénérerNombre(int p_limiteInférieure, int p_limitesuppérieure)
        {
            return m_random.Next(p_limiteInférieure, p_limitesuppérieure +1);
        }

        async Task<TimeSpan> VérifierTempsAsync(DateTime p_début)
        {
            return DateTime.Now - p_début;
        }

        void ConstruireÉquations()
        {
            Équation équation = new Équation();
            for (int i = 0; i < nbÉquations;)
            {
                if (opérateur == '-' || opérateur == '/')
                    nbB = GénérerNombre(table);
                else
                    nbA = GénérerNombre(table);

                if (opérateur == '-')
                {
                    nbA = GénérerNombre(nbB, nbB + 11);
                }
                else if (opérateur == '/')
                {
                    do
                    {
                        nbA = GénérerNombre(nbB, nbB * 12);
                    }

                    while (nbA % nbB != 0);
                }
                else
                {
                    nbB = GénérerNombre(12);
                }

                équation.nb1 = nbA;
                équation.opérateur = op;
                équation.nb2 = nbB;


                //équation = nbA + " " + op + " " + nbB + " = ";

                if (!équations.Any(é => é.Equals(équation)))
                {
                    i++;
                    équations.Add(équation);
                    WriteLine(équation.ToString());
                }
            }
        }
    }
}
