using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitaires
{
    public static class Util
    {
        /// <summary>
        /// Sert à l'obtention d'un entier valide
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <returns>retourne un entier (int) valide</returns>
        public static int LireInt32(string p_question)
        {
            int nombre;     //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                Console.Write(p_question);
                /***/
                if (Int32.TryParse(Console.ReadLine(), out nombre)) break;
                /***/
                Util.AfficherErreur("Veuillez entrer un simple nombre entier.");
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un entier valide
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <returns>retourne un entier (int) valide</returns>
        public static int LireInt32Ligne(string p_question)
        {
            int nombre;     //Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                Console.Write(p_question);
                /***/
                if (Int32.TryParse(Console.ReadLine(), out nombre)) break;
                /***/
                Util.AfficherErreur("Veuillez entrer un simple nombre entier.");
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un nombre valide
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <returns>retourne un nombre valide</returns>
        public static double LireDouble(string p_question)
        {
            double nombre;     //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                Console.Write(p_question + "\n");
                /***/
                if (Double.TryParse(Console.ReadLine(), out nombre)) break;
                /***/
                Util.AfficherErreur("Veuillez entrer un nombre.");
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un entier positif valide
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <returns>retourne un entier positif valide</returns>
        public static int LireInt32Positif(string p_question)
        {
            int nombre;         //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                nombre = LireInt32(p_question);
                /***/
                if (nombre >= 0) break;
                /***/
                Util.AfficherErreur("Veuillez entrer un nombre entier positif.");
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un entier positif valide
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <returns>retourne un entier positif valide</returns>
        public static int LireInt32PositifLigne(string p_question)
        {
            int nombre;         //Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireInt32Ligne(p_question);
                /***/
                if (nombre >= 0) break;
                /***/
                Util.AfficherErreur("Veuillez entrer un nombre entier positif.");
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un nombre positif valide
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <returns>retourne un nombre positif valide</returns>
        public static double LireDoublePositif(string p_question)
        {
            double nombre;         //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                nombre = LireDouble(p_question);
                /***/
                if (nombre >= 0.0) break;
                /***/
                Util.AfficherErreur("Veuillez entrer un nombre positif.");
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un entier plus grand qu'un minimum
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <param name="p_minimum">valeur minimum du entier</param>
        /// <returns>retourne un entier plus grand qu'un minimum</returns>
        public static int LireInt32AvecMinimum(string p_question, int p_minimum)
        {
            int nombre; //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                nombre = LireInt32(p_question);
                /***/
                if (nombre >= p_minimum) break;
                /***/
                Util.AfficherErreur(String.Format("Veuillez entrer un nombre entier supérieur ou égal à {0}.", p_minimum));
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un nombre plus grand qu'un minimum
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <param name="p_minimum">valeur minimum d'un nombre</param>
        /// <returns>retourne un nombre plus grand qu'un minimum</returns>
        public static double LireDoubleMinimum(string p_question, double p_minimum)
        {
            double nombre; //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                nombre = LireDouble(p_question);
                /***/
                if (nombre >= p_minimum) break;
                /***/
                Util.AfficherErreur(String.Format("Veuillez entrer un nombre entier supérieur ou égal à {0}.", p_minimum));
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un entier dans un intervalle
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <param name="p_minimum">valeur minimum de l'intervalle</param>
        /// <param name="p_maximum">valeur maximum de l'intervalle</param>
        /// <returns>retourne un entier dans un intervalle</returns>
        public static int LireInt32DansIntervalle(string p_question, int p_minimum, int p_maximum)
        {
            int nombre;     //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                nombre = LireInt32(p_question);
                /***/
                if (p_minimum <= nombre && nombre <= p_maximum) break;
                /***/
                Util.AfficherErreur(String.Format("Veuillez entrer un nombre entier entre {0} et {1}.", p_minimum, p_maximum));
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un nombre dans un intervalle
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <param name="p_minimum">valeur minimum de l'intervalle</param>
        /// <param name="p_maximum">valeur maximum de l'intervalle</param>
        /// <returns>retourne un nombre dans un intervalle</returns>
        public static double LireDoubleDansIntervalle(string p_question, double p_minimum, double p_maximum)
        {
            double nombre;     //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                nombre = LireDouble(p_question);
                /***/
                if (p_minimum <= nombre && nombre <= p_maximum) break;
                /***/
                Util.AfficherErreur(String.Format("Veuillez entrer un nombre entier entre {0} et {1}.", p_minimum, p_maximum));
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un entier avec un minimum ou une sentinelle
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <param name="p_minimum">valeur minimum de l'entier</param>
        /// <param name="p_sentinelle">valeur de la sentinelle</param>
        /// <returns>retourne un entier avec un minimum ou une sentinelle</returns>
        public static int LireInt32AvecMinimumOuSentinelle(string p_question, int p_minimum, int p_sentinelle)
        {
            int nombre;     //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                nombre = LireInt32(p_question);
                /***/
                if (nombre >= p_minimum && nombre != p_sentinelle) break;
                /***/
                Util.AfficherErreur(String.Format("Veuillez entrer une valeur supérieure ou égale à {0}, ou {1} pour annuler.", p_minimum, p_sentinelle));
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un nombre avec un minimum ou une sentinelle
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <param name="p_minimum">valeur minimum du nombre</param>
        /// <param name="p_sentinelle">valeur de la sentinelle</param>
        /// <returns>retourne un nombre avec un minimum ou une sentinelle</returns>
        public static double LireDoubleAvecMinimumOuSentinelle(string p_question, double p_minimum, double p_sentinelle)
        {
            double nombre;     //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                nombre = LireDouble(p_question);
                /***/
                if (nombre >= p_minimum && nombre != p_sentinelle) break;
                /***/
                Util.AfficherErreur(String.Format("Veuillez entrer une valeur supérieure ou égale à {0}, ou {1} pour annuler.", p_minimum, p_sentinelle));
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un entier dans un intervalle ou une sentinelle
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <param name="p_minimum">valeur minimum d'un intervalle</param>
        /// <param name="p_maximum">valeur maximum d'un intervalle</param>
        /// <param name="p_sentinelle">valeur de la sentinelle</param>
        /// <returns>retourne un entier dans un intervalle ou une sentinelle</returns>
        public static int LireInt32DansIntervalleOuSentinelle(string p_question, int p_minimum, int p_maximum, int p_sentinelle)
        {
            int nombre;     //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                nombre = LireInt32(p_question);
                /***/
                if (p_minimum <= nombre && nombre <= p_maximum || nombre == p_sentinelle) break;
                /***/
                Util.AfficherErreur(String.Format("Veuillez entrer une valeur entre {0} et {1}, ou {2} pour annuler.", p_minimum, p_maximum, p_sentinelle));
            }
            return nombre;
        }

        /// <summary>
        /// Sert à l'obtention d'un nombre dans un intervalle ou une sentinelle
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <param name="p_minimum">valeur minimum d'un intervalle</param>
        /// <param name="p_maximum">valeur maximum d'un intervalle</param>
        /// <param name="p_sentinelle">valeur de la sentinelle</param>
        /// <returns>retourne un nombre dans un intervalle ou une sentinelle</returns>
        public static double LireDoubleDansIntervalleOuSentinelle(string p_question, double p_minimum, double p_maximum, double p_sentinelle)
        {
            double nombre;     //Contiendra le nombre provenant d'une lecture validée

            for (; ; )
            {
                nombre = LireDouble(p_question);
                /***/
                if (p_minimum <= nombre && nombre <= p_maximum || nombre == p_sentinelle) break;
                /***/
                Util.AfficherErreur(String.Format("Veuillez entrer une valeur entre {0} et {1}, ou {2} pour annuler.", p_minimum, p_maximum, p_sentinelle));
            }
            return nombre;
        }


        //texte//
        /// <summary>
        /// Sert à l'obtention d'un caractère valide
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <returns>retourne un caractère valide</returns>
        public static char LireChar(string p_question)
        {
            char caractère;     //Contiendra le caractère provenant d'une lecture validée

            for (; ; )
            {
                Console.Write(p_question);
                /***/
                if (Char.TryParse(Console.ReadLine(), out caractère)
                    &&
                    !Char.IsControl(caractère)) break;
                /***/
                Util.AfficherErreur("Veuillez entrer un, et un seul, caractère (ordinaire).");
            }
            return caractère;
        }

        /// <summary>
        /// Sert à l'obtention d'un string valide
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <returns>retourne un string valide</returns>
        public static string LireString(string p_question)
        {
            Console.Write(p_question);
            return Console.ReadLine().Trim();
        }

        /// <summary>
        /// Sert à l'obtention d'un string de taille contrôlée
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <param name="p_lgMin">longueur minimum du string</param>
        /// <param name="p_lgMax">longueur maximum du string</param>
        /// <returns>retourne un string de taille contrôlée</returns>
        public static string LireStringTailleContôlée(string p_question, int p_lgMin, int p_lgMax)
        {
            string texte; //Contiendra le texte sans les espaces des extrémités

            for (; ; )
            {
                Console.Write(p_question);
                texte = Console.ReadLine().Trim();
                /***/
                if (p_lgMin <= texte.Length && texte.Length <= p_lgMax) break;
                /***/
                Util.AfficherErreur(String.Format("Veuillez entrer un texte contenant entre {0} et {1} caractères.", p_lgMin, p_lgMax));
            }
            return texte;
        }

        /// <summary>
        /// Sert à l'obtention d'un string non vide
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <returns>retourne un string non vide</returns>
        public static string LireStringNonVide(string p_question)
        {
            string texte;       //Contiendra le texte sans les espaces des extrémités

            for (; ; )
            {
                Console.Write(p_question);
                texte = Console.ReadLine().Trim();
                /***/
                if (texte.Length > 0) break;
                /***/
                Util.AfficherErreur("Veuillez entrer un texte non vide.");
            }
            return texte;
        }

        /// <summary>
        /// Sert à confirmer une action
        /// </summary>
        /// <param name="p_question">texte expliquant ce qui est demandé à l'utilisateur</param>
        /// <returns>retourne si l'action est confirmer ou non</returns>
        public static bool ConfirmerOuiNon(string p_question)
        {
            char caractère;     //Contiendra le caractère provenant d'une lecture validée

            for (; ; )
            {
                caractère = LireChar(p_question + "(O pour confirmer ou N pour annuler)");

                if (Char.ToUpper(caractère) == 'O')
                    return true;
                if (Char.ToUpper(caractère) == 'N')
                    return false;
                Util.AfficherErreur("Veuillez entrer O pour confirmer ou N pour annuler");
            }
        }


        //vecteurs//
        /// <summary>
        /// Enlève une valeur d'un vecteur à partir de l'indice
        /// </summary>
        /// <typeparam name="T">Type de donnée</typeparam>
        /// <param name="p_v">Liste de donnée</param>
        /// <param name="p_indice">indice de la valeur à enlever</param>
        public static void RemoveAtSansOrdre<T>(this List<T> p_v, int p_indice)
        {
            p_v[p_indice] = p_v[p_v.Count - 1];
            p_v.RemoveAt(p_v.Count - 1);
        }

        /// <summary> 
        /// Enlève la première donnée d'une certaine valeur
        /// </summary>
        /// <typeparam name="T">Type de donnée</typeparam>
        /// <param name="p_v">Liste de donnée</param>
        /// <param name="p_valeur">valeur à enlever</param>
        /// <returns>retourne true si la valeur à été trouver et false si la valeur n'existe pas</returns>
        public static bool RemoveSansOrdre<T>(this List<T> p_v, T p_valeur)
        {
            int indiceValeur = p_v.IndexOf(p_valeur);

            if (indiceValeur == -1)
                return false;

            p_v[indiceValeur] = p_v[p_v.Count - 1];
            p_v.RemoveAt(p_v.Count - 1);
            return true;
        }

        /// <summary>
        /// Enlève toute les données d'une liste répondants à une certaine condition
        /// </summary>
        /// <typeparam name="T">Type de donnée</typeparam>
        /// <param name="p_v">Liste de donnée</param>
        /// <param name="p_Prédicat">Condition des valeurs à enlever</param>
        /// <returns>retourne le nombre d'éléments enlever</returns>
        public static int RemoveAllSansOrdre<T>(this List<T> p_v, Predicate<T> p_Prédicat)
        {
            int nbRetraits = 0;

            for (int i = 0; i != p_v.Count - nbRetraits; ++i)
            {
                if (!p_Prédicat(p_v[i]))
                    ++i;
                else
                {
                    ++nbRetraits;
                    p_v[i] = p_v[p_v.Count - nbRetraits];
                }
            }

            p_v.RemoveRange(p_v.Count - nbRetraits, nbRetraits);
            return nbRetraits;
        }


        //en cours de développement//

        /// <summary>
        /// Compare une liste de string et un string en ignorant la case
        /// </summary>
        /// <param name="p_v">Liste de string</param>
        /// <param name="texte">String à comparer</param>
        /// <returns>retourne vrai si le message est le même et false si le message est différent</returns>
        public static bool StringListContainsIgnoreCase(this List<string> p_v, string texte)
        {
            if (p_v.Any(v => v.Equals(texte, StringComparison.InvariantCultureIgnoreCase)))
                return true;
            else
                return false;
        }

        /***
         * Utilitaires ajoutés par Michel Bourassa
         * Date: 3 fév 2015
         * 
         */



        /// <summary>
        /// Modifie la couleur d'un message d'erreur en rouge.
        /// </summary>
        /// <param name="erreur">message d'erreur affiché</param>
        public static void AfficherErreur(string erreur)
        {

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("*** " + erreur);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Modifie la couleur d'un message de validation en cyan.
        /// </summary>
        /// <param name="validation">message de validation affiché.</param>
        public static void AfficherValidation(string validation)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(validation);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Affichage console de la fin d'un menu
        /// </summary>
        public static void AffichageFinMenu(int p_largeurMenu)
        {
            AffichageLigneMenuVide(p_largeurMenu);

            //Ligne pleine
            for (int i = 0; i < p_largeurMenu; i++)
            {
                double j = i;
                if (j % 2.0 == 0.0)
                {
                    Console.Write("*");                   
                }
                else
                    Console.Write(" ");
            }

            Console.Write("\n\n");            
        }

        /// <summary>
        /// Affiche le début d'un menu
        /// </summary>
        /// <param name="p_titreMenu">titre du menu</param>
        /// <param name="p_largeurMenu">lageur de la boîte</param>
        public static void AffichageDébutMenu(string p_titreMenu,
                                              int p_largeurMenu)
        {
            int cptTours = 0; // compteur utilisé pour positionner les caratères
            //Ligne pleine
            for (int i = 0; i < p_largeurMenu / 2 - p_titreMenu.Length / 2; i++)
            {

                // itérateur dans une boucle pour identifier les itérations pairs et impairs:
                double j = i;
                if (j % 2.0 == 0.0)
                {
                    Console.Write("*");                   
                }

                else if (i < p_largeurMenu - 1)
                    Console.Write(" ");

                ++cptTours;
            }
           
            Console.Write(" {0} ", p_titreMenu);

            for (int i = p_titreMenu.Length + cptTours + 2; i < p_largeurMenu; i++)
            {
                // itérateur dans une boucle pour identifier les itérations pairs et impairs:
                double j = i;
                if (j % 2.0 == 0.0)
                {
                    Console.Write("*");                   
                }
                else
                    Console.Write(" ");

                ++cptTours;
            }
            Console.Write("\n");

            AffichageLigneMenuVide(p_largeurMenu);           
        }

        /// <summary>
        /// Affiche une ligne d'un menu
        /// </summary>
        /// <param name="p_message"> contenu de la ligne</param>
        /// <param name="p_largeurMenu">largeur du menu en caractères</param>
        public static void AffichageLigneMenu(string p_message, int p_largeurMenu)
        {
            Console.Write("*");
            Console.Write(" {0} ", p_message);
            for (int i = 3 + p_message.Length; i < p_largeurMenu - 2; i++)
            {
                Console.Write(" ");
            }            
            Console.Write("*\n");
        }

        /// <summary>
        /// Affiche une ligne du menu dont le contenu doit être centré
        /// </summary>
        /// <param name="p_message">contenu de la ligne</param>
        /// <param name="p_largeurMenu">largeur du menu</param>
        public static void AffichageLigneMenuCentrée(string p_message,
                                                     int p_largeurMenu)
        {
            Console.Write("*");

            int cptTours = 1; // compteur utilisé pour positionner les chaînes de caractère
            //Ligne pleine
            for (int i = 0; i < p_largeurMenu / 2 - p_message.Length / 2; i++)
            {
                Console.Write(" ");
                ++cptTours;
            }

            Console.Write(p_message);

            for (int i = cptTours + p_message.Length; i < p_largeurMenu - 2; i++)
            {
                Console.Write(" ");
            }            
            Console.Write("*\n");
        }

        /// <summary>
        /// Affiche une ligne de menu vide. Afin d'avoir une belle présentation
        /// </summary>
        /// <param name="p_largeurMenu">largeur du menu en caratères.</param>
        public static void AffichageLigneMenuVide(int p_largeurMenu)
        {
            //Ligne vide            
            Console.Write("*");

            for (int i = 0; i < p_largeurMenu - 3; i++)
            {
                Console.Write(" ");
            }            
            Console.Write("*\n");            
        }

        /// <summary>
        /// Fait une pause dans les opération et attend l'entée d'une touche.
        /// </summary>
        public static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nAppuyez sur une touche pour continuer.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Gray;
        }        

        //public static char LireMenu(string p_menu)
        //{
        //    string choixPossible;
        //    for (int i = 1; i = p_menu.Length; ++i)
        //    {
        //        if (p_menu[i - 1] == '[' && p_menu[i + 1] == ']')
        //            choixPossible.Insert(choixPossible.Length, Char.ToLower(p_menu[i]));
        //    }

        //    char choix;

        //    for (; ; )
        //    {
        //        choix = Char.ToLower(Util.LireChar(p_menu));
        //        /***/
        //        if (choixPossible.Contains(choix)) break;
        //        /***/
        //    }

        //    return choix;
        //}

        /// <summary>
        /// Fonction fournie par pierre à utiliser à la fin d'un programme
        /// </summary>
        public static void FermerAvecAffichage()
        {
            Console.WriteLine("Appuyez sur une touche pour fermer");
            Console.ReadKey(true);
            Environment.Exit(-1);
        }
    }
}
