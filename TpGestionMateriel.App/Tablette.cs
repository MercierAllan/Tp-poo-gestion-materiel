namespace TpGestionMateriel.App;

public class Tablette : Materiel
{
    private double tailleEcran;
    private bool possedeStylet;

    public double TailleEcran { get => tailleEcran; set => tailleEcran = value; }
    public bool PossedeStylet { get => possedeStylet; set => possedeStylet = value; }

    public Tablette(string reference, string marque, string modele, string etat, double tailleEcran, bool possedeStylet)
        : base(reference, marque, modele, etat)
    {
        this.tailleEcran = tailleEcran;
        this.possedeStylet = possedeStylet;
    }

    public override int CalculerDureeMaxEmprunt()
    {
        return 7;
    }

    public override void AfficherInformations()
    {
        Console.WriteLine($"[Tablette] Réf: {reference} | {marque} {modele} | État: {etat} | Écran: {tailleEcran} pouces | Stylet: {(possedeStylet ? "Oui" : "Non")} | Disponible: {(disponible ? "Oui" : "Non")}");
    }
}