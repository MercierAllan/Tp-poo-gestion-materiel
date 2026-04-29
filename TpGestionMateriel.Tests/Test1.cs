using Microsoft.VisualStudio.TestTools.UnitTesting; 
using TpGestionMateriel.App; 
 
namespace TpGestionMateriel.Tests; 
 
[TestClass] 
public class GestionMaterielTests 
{ 
    [TestMethod] 
    public void AjouterMateriel_RetourneTrue_QuandMaterielValide() 
    { 
        // Arrange 
        GestionMateriel gestion = new GestionMateriel(); 
        OrdinateurPortable pc = new OrdinateurPortable("PC-001", "Dell", "Latitude 5420","Bon", 16, true); 
 
        // Act 
        bool resultat = gestion.AjouterMateriel(pc); 
 
        // Assert 
        Assert.IsTrue(resultat); 
    } 
} 