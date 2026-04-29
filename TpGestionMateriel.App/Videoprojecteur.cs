namespace TpGestionMateriel.App;

public class Videoprojecteur : Materiel
{
    private int luminositeLumens;
    private bool possedeHDMI;

    public int LuminositeLumens { get => luminositeLumens; set => luminositeLumens = value; }
    public bool PossedeHDMI { get => possedeHDMI; set => possedeHDMI = value; }

    public Videoprojecteur(string reference, string marque, string modele, string etat, int luminositeLumens, bool possedeHDMI)
        : base(reference, marque, modele, etat)
    {
        this.luminositeLumens = luminositeLumens;
        this.possedeHDMI = possedeHDMI;
    }

    public override int CalculerDureeMaxEmprunt()
    {
        return 3;
    }

    public override void AfficherInformations()
    {
        Console.WriteLine($"[Vidéoprojecteur] Réf: {reference} | {marque} {modele} | État: {etat} | Luminosité: {luminositeLumens} lm | HDMI: {(possedeHDMI ? "Oui" : "Non")} | Disponible: {(disponible ? "Oui" : "Non")}");
    }
}