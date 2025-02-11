/* Exercice sur les proc�dures stock�es */

use k2fl_bd
go




/* 1.	Faites une proc�dure stock�es qui retourne le nombre total de cours � une session donn�e.
		elle prend en param�tre : la session

		A) pas de param�tre output  */

		create or alter procedure nombreCoursSession
		@session nchar(50) 
		as
		select count(no_cours) as 'nombre de cours'
		from tbl_offreCours
		where no_session = @session
		go


		/*Faites l'appel de cette proc�dure */

		exec nombreCoursSession 'H2025'
		go

		/* B)	m�me question mais retourne un param�tre output pour le nombre de cours de cette session,
				faites-vous une autre proc�dure stock�es*/

		create or alter procedure nombreCoursSessionOutput
		@session nchar(50),
		@nombreCours int output 
		as 
		select @nombreCours = count(no_cours)
		from tbl_offreCours
		where no_session = @session
		go


		/*Faites l'appel de cette proc�dure */

		declare @nombreDeCours int 
		execute nombreCoursSessionOutput 'H2025', @nombreDeCours output
		select @nombreDeCours as 'nombre de cours'
		go

/* 2.	Faites une proc�dure stock�es qui ajoute ou modifie un �tudiant selon qu'il existe ou pas.
		les param�tres seront : son no de DA, nom,prenom,email
		Noter qu'on ne peut pas modifier la cl�.
		Votre proc�dure aura un param�tre return qui nous indiquera si on a modifier ou pas
		Choisissez 2 valeurs > que 0 qui auront ces 2 significations soit ajout ou modification effectu�e */

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