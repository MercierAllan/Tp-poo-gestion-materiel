namespace TpGestionMateriel.App;

public class OrdinateurPortable : Materiel
{
    private int ramGo;
    private bool possedeChargeur;

    public int RamGo { get => ramGo; set => ramGo = value; }
    public bool PossedeChargeur { get => possedeChargeur; set => possedeChargeur = value; }

    public OrdinateurPortable(string reference, string marque, string modele, string etat, int ramGo, bool possedeChargeur)
        : base(reference, marque, modele, etat)
    {
        this.ramGo = ramGo;
        this.possedeChargeur = possedeChargeur;
    }

    public override int CalculerDureeMaxEmprunt()
    {
        return 14;
    }

    public override void AfficherInformations()
    {
        Console.WriteLine($"[Ordinateur Portable] Réf: {reference} | {marque} {modele} | État: {etat} | RAM: {ramGo} Go | Chargeur: {(possedeChargeur ? "Oui" : "Non")} | Disponible: {(disponible ? "Oui" : "Non")}");
    }
}