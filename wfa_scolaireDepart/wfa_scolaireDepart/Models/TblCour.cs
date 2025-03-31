﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace wfa_scolaireDepart.Models;

[Table("tbl_cours")]
public partial class TblCour
{
    [Key]
    [Column("no_cours")]
    [StringLength(8, ErrorMessage = "le no de cours est trop long, maximum 8")]//dataAnnotations
    public string NoCours { get; set; }

    [Column("nom_cours")]
    [StringLength(100)]
    public string NomCours { get; set; }

    [Column("pond")]
    [StringLength(5)]
    //[Range (1, 100)]
    public string Pond { get; set; }

    [InverseProperty("NoCoursNavigation")]
    public virtual ICollection<TblOffreCour> TblOffreCours { get; set; } = new List<TblOffreCour>();

    [ForeignKey("NoCoursPrealable")]
    [InverseProperty("NoCoursPrealables")]
    public virtual ICollection<TblCour> NoCoursDeBases { get; set; } = new List<TblCour>();

    [ForeignKey("NoCoursDeBase")]
    [InverseProperty("NoCoursDeBases")]
    public virtual ICollection<TblCour> NoCoursPrealables { get; set; } = new List<TblCour>();
}