using System;
using System.Collections.Generic;
using System.Linq;
using kami_heim.Models;

namespace kami_heim.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Biens.Any() || context.Locataires.Any() || context.Locations.Any())
                return; // Données déjà présentes

            var biens = new List<Bien>
            {
                new() { Adresse = "10 rue des Lilas", CodePostal = "34000", Ville = "Montpellier", Type = "Appartement" },
                new() { Adresse = "5 avenue du Soleil", CodePostal = "34170", Ville = "Castelnau", Type = "Maison" },
                new() { Adresse = "1 place de l’Église", CodePostal = "34200", Ville = "Sète", Type = "Studio" },
                new() { Adresse = "99 impasse des Pins", CodePostal = "34090", Ville = "Montpellier", Type = "Loft" },
                new() { Adresse = "28 chemin du Moulin", CodePostal = "34300", Ville = "Agde", Type = "Maison" },
                new() { Adresse = "62 boulevard Saint-Roch", CodePostal = "34500", Ville = "Béziers", Type = "Appartement" },
                new() { Adresse = "3 route de Nîmes", CodePostal = "34400", Ville = "Lunel", Type = "Studio" },
                new() { Adresse = "16 montée des Cèdres", CodePostal = "34700", Ville = "Lodève", Type = "Appartement" },
                new() { Adresse = "45 rue des Écoles", CodePostal = "34230", Ville = "Paulhan", Type = "Maison" },
                new() { Adresse = "12 boulevard Gambetta", CodePostal = "34800", Ville = "Clermont-l’Hérault", Type = "Loft" },
                new() { Adresse = "101 rue du Port", CodePostal = "34350", Ville = "Valras", Type = "Villa" },
                new() { Adresse = "17 impasse des Peupliers", CodePostal = "34550", Ville = "Bessan", Type = "Studio" },
                new() { Adresse = "23 rue Pasteur", CodePostal = "34120", Ville = "Pézenas", Type = "Appartement" },
                new() { Adresse = "40 cours Mirabeau", CodePostal = "34830", Ville = "Jacou", Type = "Maison" },
                new() { Adresse = "77 chemin du Lac", CodePostal = "34280", Ville = "Carnon", Type = "Villa" }
            };

            var locataires = new List<Locataire>
            {
                new() { Nom = "Martin", Prenom = "Lucie", Telephone = "0600000001", Email = "lucie.martin@example.com" },
                new() { Nom = "Durand", Prenom = "Antoine", Telephone = "0600000002", Email = "antoine.durand@example.com" },
                new() { Nom = "Bernard", Prenom = "Sophie", Telephone = "0600000003", Email = "sophie.bernard@example.com" },
                new() { Nom = "Petit", Prenom = "Julien", Telephone = "0600000004", Email = "julien.petit@example.com" },
                new() { Nom = "Robert", Prenom = "Camille", Telephone = "0600000005", Email = "camille.robert@example.com" },
                new() { Nom = "Richard", Prenom = "Léo", Telephone = "0600000006", Email = "leo.richard@example.com" },
                new() { Nom = "Garcia", Prenom = "Manon", Telephone = "0600000007", Email = "manon.garcia@example.com" },
                new() { Nom = "Michel", Prenom = "Yanis", Telephone = "0600000008", Email = "yanis.michel@example.com" },
                new() { Nom = "Lefebvre", Prenom = "Nina", Telephone = "0600000009", Email = "nina.lefebvre@example.com" },
                new() { Nom = "Moreau", Prenom = "Lucas", Telephone = "0600000010", Email = "lucas.moreau@example.com" },
                new() { Nom = "Fournier", Prenom = "Inès", Telephone = "0600000011", Email = "ines.fournier@example.com" },
                new() { Nom = "Girard", Prenom = "Thomas", Telephone = "0600000012", Email = "thomas.girard@example.com" },
                new() { Nom = "Andre", Prenom = "Emma", Telephone = "0600000013", Email = "emma.andre@example.com" },
                new() { Nom = "Laurent", Prenom = "Hugo", Telephone = "0600000014", Email = "hugo.laurent@example.com" },
                new() { Nom = "Roux", Prenom = "Eva", Telephone = "0600000015", Email = "eva.roux@example.com" }
            };

            var locations = new List<Location>();
            for (int i = 0; i < 15; i++)
            {
                locations.Add(new Location
                {
                    Bien = biens[i],
                    Locataire = locataires[i],
                    DateDebut = new DateTime(2023 + (i % 3), 1 + (i % 12), 1),
                    DateFin = i % 3 == 0 ? null : new DateTime(2024 + (i % 2), 1 + (i % 12), 1)
                });
            }

            context.Biens.AddRange(biens);
            context.Locataires.AddRange(locataires);
            context.Locations.AddRange(locations);
            context.SaveChanges();
        }
    }
}
