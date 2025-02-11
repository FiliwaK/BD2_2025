/* Exercice sur les procédures stockées */

use k2fl_bd
go




/* 1.	Faites une procédure stockées qui retourne le nombre total de cours à une session donnée.
		elle prend en paramètre : la session

		A) pas de paramètre output  */

		create or alter procedure nombreCoursSession
		@session nchar(50) 
		as
		select count(no_cours) as 'nombre de cours'
		from tbl_offreCours
		where no_session = @session
		go


		/*Faites l'appel de cette procédure */

		exec nombreCoursSession 'H2025'
		go

		/* B)	même question mais retourne un paramètre output pour le nombre de cours de cette session,
				faites-vous une autre procédure stockées*/

		create or alter procedure nombreCoursSessionOutput
		@session nchar(50),
		@nombreCours int output 
		as 
		select @nombreCours = count(no_cours)
		from tbl_offreCours
		where no_session = @session
		go


		/*Faites l'appel de cette procédure */

		declare @nombreDeCours int 
		execute nombreCoursSessionOutput 'H2025', @nombreDeCours output
		select @nombreDeCours as 'nombre de cours'
		go

/* 2.	Faites une procédure stockées qui ajoute ou modifie un étudiant selon qu'il existe ou pas.
		les paramètres seront : son no de DA, nom,prenom,email
		Noter qu'on ne peut pas modifier la clé.
		Votre procédure aura un paramètre return qui nous indiquera si on a modifier ou pas
		Choisissez 2 valeurs > que 0 qui auront ces 2 significations soit ajout ou modification effectuée */

		create or alter procedure ajoutEtmodifEtudiant
		@no_da nchar(14), @nom nvarchar(200), @prenom nvarchar(200), @email nvarchar(200)
		as
		declare @retour int 
		if exists(select * from tbl_etudiant where no_da = @no_da)
		begin
		  update tbl_etudiant 
		  set nom = @nom, prenom = @prenom, email = @email
		  where no_da = @no_da
		  set @retour = 4
		end
	else
		begin
			insert into tbl_etudiant(no_da, nom, prenom, email)
			values (@no_da,@nom, @prenom, @email)
			set @retour = 7
		end
	return @retour
	go

		/* appel de votre procedure et affichage de la valeur return */

		declare @numeroRetour int 
		exec @numeroRetour = ajoutEtmodifEtudiant '2342864', 'Kouakou', 'Fabrice', 'kouakoufabrice@gmail.com' 
		select @numeroRetour as 'numero du retour'