
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisionBackend.Models
{
// Mod�le pour la table 'Region'
public class Region
{
    [Key] // Indique que 'CodRegion' est la cl� primaire
    [Column("cod_region")] // Mappe la propri�t� au nom de colonne SQL 'cod_region'
    public int CodRegion { get; set; }

    [Column("desi_region")] // Mappe la propri�t� au nom de colonne SQL 'desi_region'
    [StringLength(100)] // D�finit la longueur maximale de la cha�ne
    public string DesiRegion { get; set; }

    // Propri�t� de navigation pour les fermes associ�es � cette r�gion (relation One-to-Many)
    public ICollection<Ferme> Fermes { get; set; }
}}