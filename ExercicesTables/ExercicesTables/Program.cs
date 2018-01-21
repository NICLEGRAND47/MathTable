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

namespace ExercicesTables
{
    class Program
    {
        string nom;
        List<string> équations = new List<string>();
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

        static void Main(string[] args)
        {
            new Program().Principale();
        }

        void Principale()
        {
            Donnees bd = Donnees.ObtenirInstance();

            WriteLine("Bonjour, bienvenue dans l'exerciseur de tables de mathématique.");
            nom = LireStringNonVide("Bonjour quel est ton nom : ");



            WriteLine($"Super!\n Maintenant, {nom} choisi le type de table que tu veux pratiquer.");
            Pause();

            bd.Utilisateurs.Add(Utilisateur.CréationUtilisateur(nom));

            for (; ; )
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

                switch (choix)
                {
                    case 1:
                        opérateur = '+';
                        op = opérateur;
                        break;
                    case 2:
                        opérateur = '-';
                        op = opérateur;
                        break;
                    case 3:
                        opérateur = '*';
                        op = 'X';
                        break;
                    case 4:
                        opérateur = '/';
                        op = (char)247;
                        break;
                    default: break;
                }

                ChoisirTables();
            }

        }

        void ChoisirTables()
        {

            WriteLine("Excellent!, maintenant choisi jusqu'à quelle table tu veux pratiquer.");
            table = LireInt32DansIntervalleOuSentinelle("Choisi entre 1 et 12 ou 0 pour revenir au menu précédent : ", 1, 12, 0);
            if (table == 0) return;

            WriteLine("Dernière quesiont combien veux tu pratiquer d'équations?");
            nbÉquations = LireInt32DansIntervalleOuSentinelle("Choisi un nombre entre 1 et 50 ou  0 pour revenir au menu précédent : ", 1, 50, 0);
            if (nbÉquations == 0) return;

            AfficherÉquations();
        }

        void AfficherÉquations()
        {
            string équation;


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


                équation = nbA + " " + op + " " + nbB + " = ";

                if (!équations.Any(é => é.Equals(équation)))
                {
                    i++;
                    équations.Add(équation);
                    for (; ; )
                    {
                        réponse = LireInt32PositifLigne(équation);
                        int bonneRéponse = nbA + opérateur + nbB;
                        switch (opérateur)
                        {
                            case '+': bonneRéponse = nbA + nbB; break;
                            case '-': bonneRéponse = nbA - nbB; break;
                            case '*': bonneRéponse = nbA * nbB; break;
                            case '/': bonneRéponse = nbA / nbB; break;
                            default: break;
                        }

                        /***/
                        if (réponse == réponse/*bonneRéponse*/) break;
                        /***/

                        AfficherErreur("Mauvaise réponse :-(");
                    }

                    AfficherValidation("Bonne réponse !");
                    réponses.Add(réponse);

                }
            }
            //Pause();
        }

        /// <summary>
        /// Fonction qui génère un nombre de façon aléatoire, à un paramètre
        /// </summary>
        /// <param name="p_limiteSuppérieure">limite supérieur de la plage</param>
        /// <returns>un nombre entier aléatoire</returns>
        int GénérerNombre(int p_limiteSuppérieure)
        {
            return m_random.Next(1, p_limiteSuppérieure + 1);
        }

        /// <summary>
        /// Fonction qui génère un nombre de façon aléatoire, à deux paramètres
        /// </summary>
        /// <param name="p_limiteInférieure">limite inférieure de la plage</param>
        /// <param name="p_limiteSuppérieure">limite suppérieure de la plage</param>
        /// <returns>Un nombre entier aléatoire</returns>
        int GénérerNombre(int p_limiteInférieure, int p_limitesuppérieure)
        {
            return m_random.Next(p_limiteInférieure, p_limitesuppérieure + 1);
        }
    }
}
