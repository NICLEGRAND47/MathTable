using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ExercicesTables
{
    class Donnees
    {
        // Nom du fichier d'utilisateur
        private const string NomFichierUtilisateurs = "Utilisateurs.bin";
        // Unique instance de la base de données
        private static Donnees m_instance = null;
        // Liste d'utilisateurs sur cette machine.
        public List<Utilisateur> Utilisateurs { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        private Donnees() => OuvrirBd();
     
        /// <summary>
        /// Fabrique de singleton base de données.
        /// </summary>
        /// <returns></returns>
        public static Donnees ObtenirInstance()
        {
            return (m_instance == null) ? m_instance = new Donnees() : m_instance;
        }

        /// <summary>
        /// Mise en mémoire toutes les données.
        /// </summary>
        private void OuvrirBd()
        {
            Utilisateurs = new List<Utilisateur>();

            if (File.Exists(NomFichierUtilisateurs))
            {
                List<Utilisateur> tmpListeUtilisateur = new List<Utilisateur>();
                ObtenirListe(ref tmpListeUtilisateur, NomFichierUtilisateurs);
                if (tmpListeUtilisateur.Count != 0)
                    Utilisateurs = tmpListeUtilisateur;
            }

            // ObtenirListe(stats);
        }

        /// <summary>
        /// Enregistrer les données sur un ou des fichiers.
        /// </summary>
        public void Sauvegarder()
        {
            EnregistrerListe(Utilisateurs, NomFichierUtilisateurs);
        }

        /// <summary>
        /// Enregistre un liste dans un fichier en particulier
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p_liste"></param>
        /// <param name="p_cheminFichier"></param>
        private void EnregistrerListe<T>(List<T> p_liste, string p_cheminFichier)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(p_cheminFichier, FileMode.Create))
            {
                formatter.Serialize(stream, p_liste);
            }
        }

        /// <summary>
        /// Obtient une liste selon un fichier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p_liste"></param>
        /// <param name="p_cheminFichier"></param>
        private void ObtenirListe<T>(ref List<T> p_liste, string p_cheminFichier)
        {
            p_liste.Clear();
            T obj = default(T);
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(p_cheminFichier, FileMode.Open))
            {
                p_liste = (List<T>)formatter.Deserialize(stream);
            }
        }
    }
}
