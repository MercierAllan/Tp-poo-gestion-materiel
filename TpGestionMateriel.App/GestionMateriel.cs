namespace TpGestionMateriel.App;

public class GestionMateriel
{
    private List<Materiel> materiels;

    public List<Materiel> Materiels { get => materiels; set => materiels = value; }

    public GestionMateriel()
    {
        materiels = new List<Materiel>();
    }

    public bool AjouterMateriel(Materiel materiel)
    {
        if (materiel == null)
            return false;

        if (RechercherMaterielParReference(materiel.Reference) != null)
            return false;

        materiels.Add(materiel);
        return true;
    }

    public Materiel RechercherMaterielParReference(string reference)
    {
        foreach (Materiel m in materiels)
        {
            if (m.Reference == reference)
                return m;
        }
        return null;
    }

    public bool EmprunterMateriel(string reference)
    {
        Materiel m = RechercherMaterielParReference(reference);

        if (m == null) return false;
        if (!m.Disponible) return false;
        if (m.Etat == "Hors service") return false;

        if (m is OrdinateurPortable op && !op.PossedeChargeur)
            return false;

        if (m is Videoprojecteur vp && !vp.PossedeHDMI)
            return false;

        m.Disponible = false;
        return true;
    }

    public bool RetournerMateriel(string reference, string nouvelEtat)
    {
        Materiel m = RechercherMaterielParReference(reference);

        if (m == null) return false;
        if (m.Disponible) return false;

        m.Disponible = true;
        m.Etat = nouvelEtat;
        return true;
    }

    public void AfficherMaterielsDIsponibles()
    {
        Console.WriteLine("Matériels disponibles");
        foreach (Materiel m in materiels)
        {
            if (m.Disponible && m.Etat != "Hors service")
                m.AfficherInformations();
        }
    }

    public void AfficherTousLesMaterials()
    {
        Console.WriteLine("Tous les matériels");
        foreach (Materiel m in materiels)
        {
            m.AfficherInformations();
        }
    }

    public int CalculerDureeMaxTotale()
    {
        int total = 0;
        foreach (Materiel m in materiels)
        {
            total += m.CalculerDureeMaxEmprunt();
        }
        return total;
    }
}