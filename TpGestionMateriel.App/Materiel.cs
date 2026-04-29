namespace TpGestionMateriel.App;

public abstract class Materiel
{
    protected string reference;
    protected string marque;
    protected string modele;
    protected bool disponible;
    protected string etat;

    public string Reference { get => reference; set => reference = value; }
    public string Marque { get => marque; set => marque = value; }
    public string Modele { get => modele; set => modele = value; }
    public bool Disponible { get => disponible; set => disponible = value; }
    public string Etat { get => etat; set => etat = value; }

    public Materiel(string reference, string marque, string modele, string etat)
    {
        this.reference = reference;
        this.marque = marque;
        this.modele = modele;
        this.etat = etat;
        this.disponible = true;
    }

    public abstract int CalculerDureeMaxEmprunt();

    public abstract void AfficherInformations();
}