using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesTables
{
    [Serializable]
    class Utilisateur
    {
        public int ID { get; }

        public string Nom { get; }

        private Utilisateur(int p_id, string p_nom)
        {
            Nom = p_nom;
            ID = p_id;
        }

        /// <summary>
        /// Fabrique d'utilisateur en ajoutant un identifiant selon le nombre d'utilisateur total sur la machine.
        /// </summary>
        /// <param name="p_nom">Nom de l'utilisateur</param>
        /// <returns>(Utilisateur)</returns>
        public static Utilisateur CréationUtilisateur(string p_nom)
        {
            // Incrémenter l'identifiant selon le nombre d'utilisateur. (dans la BD);

            int id = /* nombre d'utilisateur + 1 */ 1;
            return new Utilisateur(id, p_nom);
        }

        // section de test de sérialisation
        public static void Sauvegarder()
        {
            Utilisateur u = CréationUtilisateur("Avance Hercule");
            BinaryFormatter b = new BinaryFormatter();

            using (FileStream stream = new FileStream("Utilisateur.bin", FileMode.Append))
                b.Serialize(stream, u);
        }

        public static void ObtenirUtilisateurs()
        {
            Utilisateur u;
            Utilisateur e;
            BinaryFormatter b = new BinaryFormatter();

            using (FileStream stream = new FileStream("Utilisateur.bin", FileMode.Open))
            {
                u = (Utilisateur)b.Deserialize(stream);
                e = (Utilisateur)b.Deserialize(stream);
            }

            Console.WriteLine(e.Nom);
            Console.WriteLine(u.Nom);
        }
    }


}
