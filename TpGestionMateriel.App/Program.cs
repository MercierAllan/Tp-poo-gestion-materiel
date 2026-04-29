using TpGestionMateriel.App;

class Program
{
    static void Main(string[] args)
    {
        // --- Création des objets ---
        OrdinateurPortable pc1 = new OrdinateurPortable("PC-001", "Dell", "Latitude 5420", "Bon", 16, true);
        OrdinateurPortable pc2 = new OrdinateurPortable("PC-002", "HP", "ProBook 450", "Bon", 8, false);
        Tablette tab1 = new Tablette("TAB-001", "Samsung", "Galaxy Tab A8", "Bon", 10.5, true);
        Videoprojecteur vid1 = new Videoprojecteur("VID-001", "Epson", "EB-X49", "Bon", 3600, true);
        Videoprojecteur vid2 = new Videoprojecteur("VID-002", "BenQ", "MS560", "Bon", 4000, false);

        GestionMateriel gestion = new GestionMateriel();

        // Ajout d'un matériel
        Console.WriteLine("=== Tests d'ajout ===");
        Console.WriteLine("Ajout PC-001 : " + gestion.AjouterMateriel(pc1));   
        Console.WriteLine("Ajout PC-002 : " + gestion.AjouterMateriel(pc2));   
        Console.WriteLine("Ajout TAB-001 : " + gestion.AjouterMateriel(tab1)); 
        Console.WriteLine("Ajout VID-001 : " + gestion.AjouterMateriel(vid1)); 
        Console.WriteLine("Ajout VID-002 : " + gestion.AjouterMateriel(vid2)); 

        // Ajout d'un doublon
        Console.WriteLine("Ajout doublon PC-001 : " + gestion.AjouterMateriel(pc1));

        // Recherche d'un matériel existant
        Console.WriteLine("Tests de recherche");
        Materiel trouve = gestion.RechercherMaterielParReference("PC-001");
        Console.WriteLine("Recherche PC-001 : " + (trouve != null ? "Trouvé" : "Non trouvé"));

        // Recherche d'un matériel inexistant
        Materiel introuvable = gestion.RechercherMaterielParReference("XXX-999");
        Console.WriteLine("Recherche XXX-999 : " + (introuvable != null ? "Trouvé" : "Non trouvé"));

        // Emprunt d'un matériel disponible
        Console.WriteLine("Tests d'emprunt");
        Console.WriteLine("Emprunt PC-001 : " + gestion.EmprunterMateriel("PC-001"));

        // Emprunt d'un matériel déjà emprunté
        Console.WriteLine("Emprunt PC-001 (déjà emprunté) : " + gestion.EmprunterMateriel("PC-001"));

        // Emprunt d'un ordinateur sans chargeur
        Console.WriteLine("Emprunt PC-002 (sans chargeur) : " + gestion.EmprunterMateriel("PC-002"));

        // Emprunt d'un vidéoprojecteur sans câble HDMI
        Console.WriteLine("Emprunt VID-002 (sans HDMI) : " + gestion.EmprunterMateriel("VID-002"));

        // Retour d'un matériel emprunté
        Console.WriteLine("Tests de retour");
        Console.WriteLine("Retour PC-001 : " + gestion.RetournerMateriel("PC-001", "Bon"));

        // Retour d'un matériel déjà disponible
        Console.WriteLine("Retour PC-001 (déjà disponible) : " + gestion.RetournerMateriel("PC-001", "Bon"));

        // Affichage des matériels disponibles
        gestion.AfficherMaterielsDIsponibles();

        // Affichage de tous les matériels
        gestion.AfficherTousLesMaterials();

        // Calcul de la durée maximale totale
        Console.WriteLine("Durée maximale totale");
        Console.WriteLine("Durée totale : " + gestion.CalculerDureeMaxTotale() + " jours");
    }
}