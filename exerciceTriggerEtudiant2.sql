
/*
A faire : 
   Les épreuves sont pour un certain groupe d'âge.
   nous connaissons la dateNaissance de chaque compétiteur.
   Assurez-vous par un trigger que chaque ajout d'une inscription respecte le groupe d'âge du compétiteur.
  
*/

/*	pour trouver l'age juste https://blog.developpez.com/sqlpro/p12468/langage-sql-norme/calculs-sql-avec-des-dates-age-exact-revolu-et-anniversaires
*/

/*	Je vous donne cette fonction afin de faciliter le calcul de l'âge à partir de'une date de naissance.
	Faite-là executer.
*/
use k2fl_bdCompetition
go
CREATE FUNCTION donnerAge (@date_naissance datetime)
RETURNS int
AS
BEGIN
   return (YEAR(GETDATE( )) - YEAR( @date_naissance) - 
			CASE WHEN MONTH(GETDATE( )) < MONTH( @date_naissance) OR (MONTH(GETDATE( )) = MONTH( @date_naissance) 
			AND DAY(GETDATE( )) < DAY( @date_naissance)) THEN 1 ELSE 0 END)
END;
GO
/* voici comment l'appeler, il suffit de la mettre dans un select :  

	SELECT nom, prenom, date_naissance, dbo.donnerAge(date_naissance) AS 'age'
	from tbl_competiteur

*/



/* trigger fonctionnelle en batch et unitaire */

create or alter trigger triggerVerifierInscriptionPourGroupeAge
on tbl_inscription
for insert, update
as 
set nocount on 
begin
	if update (no_epreuve) and update(no_competiteur)
	begin 
		if exists(
		select tbl_competiteur.no_competiteur, nom, prenom, date_naissance, tbl_epreuve.no_epreuve, dbo.donnerAge(date_naissance) AS 'age' , age_minimum, age_maximum
		from tbl_competiteur inner join inserted
		on tbl_competiteur.no_competiteur = inserted.no_competiteur
		inner join tbl_epreuve on inserted.no_epreuve = tbl_epreuve.no_epreuve
		inner join tbl_categorie on tbl_categorie.no_categorie = tbl_epreuve.no_categorie
		where dbo.donnerAge(date_naissance) not between age_minimum and age_maximum)
		begin
			rollback; /*obligatoire avant le throw*/
			THROW 51000, 'cette personne ne respecte pas les conditions d''age', 16;
		end
	end
end
set nocount off
go



/* tests unitaires */
		/* select utile pour tests unitaires */
				select *,dbo.donnerAge(date_naissance) AS 'age'
				from tbl_competiteur

				select * from tbl_epreuve inner join tbl_categorie on tbl_categorie.no_categorie = tbl_epreuve.no_categorie

				select * from tbl_inscription

		/* Test non FONCTIONNEL :ajout d'un competiteur dans un mauvais groupe, utiliser le compétiteur 2, ajuster le commentaire */
		insert into tbl_inscription(no_epreuve,no_competiteur)
		values (1,2) /* groupe d'age  : 11-12  pour competiteur de : 28 ans => ajoutera PAS*/

		delete from tbl_inscription where no_epreuve =1 and no_competiteur = 2

		/* Test FONCTIONNEL : ajout d'un competiteur dans un bon groupe, utiliser le compétiteur 2, ajuster le commentaire */
		insert into tbl_inscription(no_epreuve,no_competiteur)
		values (6,2) /* groupe d'age  : 26-30 pour competiteur de 28 ans => ok ajoutera */

		delete from tbl_inscription where no_epreuve =6 and no_competiteur = 2



/* test en batch */
		/* doit refuser l'ajout en batch, indiquer pour chaque ajout s'il sera accepté ou refusé, au moins 3 ajouts */
		insert into tbl_inscription(no_epreuve,no_competiteur)
		values	(1,2) /* groupe d'age  : 11-12  pour competiteur de : 28 ans =>	ajoutera PAS*/
				,(5,16) /* groupe d'age  : 21-25   pour competiteur de 25 ans =>	ok ajoutera */
				,(4,14) /* groupe d'age  : 18-20   pour competiteur de : 20 ans =>	ok ajoutera */
		go
		delete from tbl_inscription where no_epreuve =4 and no_competiteur = 14

		/* doit accepter l'ajout en batch, indiquer pour chaque ajout s'il sera accepté ou refusé, au moins 3 ajouts */ 
		insert into tbl_inscription(no_epreuve,no_competiteur)
		values	(1,17) /* groupe d'age  : 11-12  pour competiteur de : 12 ans =>	ok ajoutera*/
				,(4,14) /* groupe d'age  : 18-20  pour competiteur de x ans =>	ok ajoutera */
				,(5,16) /* groupe d'age  : 21-25  pour competiteur de : x ans =>	ok ajoutera */
		go
		
		delete from tbl_inscription where no_epreuve =5 and no_competiteur = 16

