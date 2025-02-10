
/* Voyez-vous la distinction entre ajouter ou ne pas ajouter certaines tables dans le from */
	use k2fl_bd


	select * from tbl_inscription
	select * from tbl_prealable
	
	select * from tbl_cours

	select distinct tbl_cours.no_cours,nom_cours
	from tbl_offreCours inner join tbl_cours
	on tbl_offreCours.no_cours = tbl_cours.no_cours 


	select distinct tbl_cours.no_cours,nom_cours
	from tbl_offreCours inner join tbl_cours
	on tbl_offreCours.no_cours = tbl_cours.no_cours
	inner join tbl_prealable
	on tbl_prealable.no_coursDeBase = tbl_cours.no_cours





/* exercice : */
use k2fl_bd
go
/* afficher les cours qui ont un préalable (no_cours, son nom et le no_cours de son préalable )*/

select no_cours, nom_cours, no_coursPrealable
from tbl_cours inner join tbl_prealable
on tbl_cours.no_cours = tbl_prealable.no_coursDeBase


/*Faire afficher les cours et leur préalable (qu’il en ait ou pas) (no_cours, son nom et le no_cours de son préalable ) */

select no_cours, nom_cours, no_coursPrealable
from tbl_cours left outer join tbl_prealable 
on tbl_cours.no_cours = tbl_prealable.no_coursDeBase




