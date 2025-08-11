
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
// Modèle pour la table 'Region'
public class Region
{
    [Key] // Indique que 'CodRegion' est la clé primaire
    [Column("cod_region")] // Mappe la propriété au nom de colonne SQL 'cod_region'
    public int CodRegion { get; set; }

    [Column("desi_region")] // Mappe la propriété au nom de colonne SQL 'desi_region'
    [StringLength(100)] // Définit la longueur maximale de la chaîne
    public string DesiRegion { get; set; }

    // Propriété de navigation pour les fermes associées à cette région (relation One-to-Many)
    public ICollection<Ferme> Fermes { get; set; }
}}