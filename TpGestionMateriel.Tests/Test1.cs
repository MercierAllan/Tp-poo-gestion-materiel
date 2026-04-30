using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpGestionMateriel.App;

namespace TpGestionMateriel.Tests;
public class GestionMaterielTests
{

    [TestMethod]
    public void AjouterMateriel_RetourneTrue_QuandMaterielValide()
    {
        // Arrange 
        GestionMateriel    gestion = new GestionMateriel();
        OrdinateurPortable pc      = new OrdinateurPortable("PC-001", "Dell", "Latitude 5420", "Bon", 16, true);

        // Act 
        bool resultat = gestion.AjouterMateriel(pc);

        // Assert 
        Assert.IsTrue(resultat);
    }

    [TestMethod]
    public void AjouterMateriel_RetourneFalse_QuandDoublon()
    {
        // Arrange
        GestionMateriel    gestion = new GestionMateriel();
        OrdinateurPortable pc      = new OrdinateurPortable("PC-001", "Dell", "Latitude 5420", "Bon", 16, true);
        gestion.AjouterMateriel(pc);

        // Act
        bool resultat = gestion.AjouterMateriel(pc); 

        // Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void RechercherMateriel_RetourneObjet_QuandReferenceExiste()
    {
        // Arrange
        GestionMateriel    gestion = new GestionMateriel();
        OrdinateurPortable pc      = new OrdinateurPortable("PC-001", "Dell", "Latitude 5420", "Bon", 16, true);
        gestion.AjouterMateriel(pc);

        // Act
        Materiel resultat = gestion.RechercherMaterielParReference("PC-001");

        // Assert 
        Assert.IsNotNull(resultat);
    }

    [TestMethod]
    public void RechercherMateriel_RetourneNull_QuandReferenceInexistante()
    {
        // Arrange
        GestionMateriel gestion = new GestionMateriel();

        // Act
        Materiel resultat = gestion.RechercherMaterielParReference("XXX-999");

        // Assert 
        Assert.IsNull(resultat);
    }

    [TestMethod]
    public void EmprunterMateriel_RetourneTrue_EtDisponibleFalse_QuandDisponible()
    {
        // Arrange
        GestionMateriel    gestion = new GestionMateriel();
        OrdinateurPortable pc      = new OrdinateurPortable("PC-001", "Dell", "Latitude 5420", "Bon", 16, true);
        gestion.AjouterMateriel(pc);

        // Act
        bool    resultat = gestion.EmprunterMateriel("PC-001");
        Materiel m       = gestion.RechercherMaterielParReference("PC-001");

        Assert.IsTrue(resultat);
        Assert.IsFalse(m.Disponible);
    }

    [TestMethod]
    public void EmprunterMateriel_RetourneFalse_QuandDejaEmprunte()
    {
        // Arrange
        GestionMateriel    gestion = new GestionMateriel();
        OrdinateurPortable pc      = new OrdinateurPortable("PC-001", "Dell", "Latitude 5420", "Bon", 16, true);
        gestion.AjouterMateriel(pc);
        gestion.EmprunterMateriel("PC-001");

        // Act
        bool resultat = gestion.EmprunterMateriel("PC-001");

        // Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void EmprunterMateriel_RetourneFalse_QuandOrdiSansChargeur()
    {
        // Arrange
        GestionMateriel    gestion = new GestionMateriel();
        OrdinateurPortable pc      = new OrdinateurPortable("PC-002", "HP", "ProBook 450", "Bon", 8, false); // false = pas de chargeur

        gestion.AjouterMateriel(pc);

        // Act
        bool resultat = gestion.EmprunterMateriel("PC-002");

        // Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void EmprunterMateriel_RetourneFalse_QuandVideoprojecteurSansHDMI()
    {
        // Arrange
        GestionMateriel gestion = new GestionMateriel();
        Videoprojecteur vid     = new Videoprojecteur("VID-002", "BenQ", "MS560", "Bon", 4000, false); // false = pas de HDMI

        gestion.AjouterMateriel(vid);

        // Act
        bool resultat = gestion.EmprunterMateriel("VID-002");

        // Assert
        Assert.IsFalse(resultat);
    }

    [TestMethod]
    public void RetournerMateriel_RetourneTrue_EtDisponibleTrue_QuandEmprunte()
    {
        // Arrange
        GestionMateriel    gestion = new GestionMateriel();
        OrdinateurPortable pc      = new OrdinateurPortable("PC-001", "Dell", "Latitude 5420", "Bon", 16, true);
        gestion.AjouterMateriel(pc);
        gestion.EmprunterMateriel("PC-001");

        // Act
        bool     resultat = gestion.RetournerMateriel("PC-001", "À vérifier");
        Materiel m        = gestion.RechercherMaterielParReference("PC-001");

        // Assert 
        Assert.IsTrue(resultat);
        Assert.IsTrue(m.Disponible);
        Assert.AreEqual("À vérifier", m.Etat);
    }

    [TestMethod]
    public void RetournerMateriel_RetourneFalse_QuandDejaDisponible()
    {
        // Arrange
        GestionMateriel    gestion = new GestionMateriel();
        OrdinateurPortable pc      = new OrdinateurPortable("PC-001", "Dell", "Latitude 5420", "Bon", 16, true);
        gestion.AjouterMateriel(pc); 

        // Act
        bool resultat = gestion.RetournerMateriel("PC-001", "Bon");

        // Assert 
        Assert.IsFalse(resultat);
    }
}