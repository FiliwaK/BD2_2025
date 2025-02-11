/* Les stored procedures ou procédures stockées */
	use k2fl_bd
	go
/* Utilisation de procédures stockées de MASTER :
   commence par sp_ : attention ne pas appeller nos procédures sp_ car il les 
   cherchera dans master */

/* fonctions systeme connus */
	sp_help tbl_etudiant
	go
	sp_helptext listerSelonNom  /* faire exécuter la procédure listerSelonNom avant, voir plus bas */
	go
	sp_who 'CORPORATIF\lthibaudeau' /* permet de voir sur quoi travaille un user, kill pourait arrêter le processus */
	go

	
/* ajout de nom prenom dans la table si vous en avez pas assez :*/

	insert into tbl_etudiant (no_da,prenom,nom,email)
	select '25000' + str(businessEntityID,2) as Contact_ID,FirstName,LastName, FirstName + LastName + '@'+'gmail.com'
	from AdventureWorks2022.Person.person
	where businessEntityID >21 and businessEntityID< 99
	order by LastName,FirstName
	go

/* création d'une procédure stockée qui affiche les étudiants d'un nom de famille donnée
   paramètre : nom */

	create procedure listerSelonNom 
	@nom nvarchar(50)
	AS
	select *
	from tbl_etudiant
	where nom = @nom
	order by nom,prenom
	GO

/* Appel de la procédure pour voir son exécution : execute ou exec*/
	execute listerSelonNom 'Brown'

	exec listerSelonNom 'Abercrombie'

	go
/* Exemple de paramètre optionnel  */


	create or alter procedure listerSelonNom 
	@nom nvarchar(50) = 'Brown'
	AS
	select *
	from tbl_etudiant
	where nom = @nom
	order by nom,prenom
	GO
/* Appel de la procédure avec paramètre optionnel */

	execute listerSelonNom 'Abercrombie'

	execute listerSelonNom /* prend la valeur par défaut si elle n'est pas fournie */
	go

/* exemple avec paramètre output */
	/* compte le nombre de cours pour un étudiant donné */
		create or alter procedure compterCours 
		@no_da nvarchar(8) ,
		@nombreCours int output 
		AS
		select @nombreCours = COUNT(distinct no_offreCours)
		from tbl_inscription
		where no_da = @no_da
		GO
/* 
	Appel de la procédure avec paramètre output:
	Il faut absolument mettre le mot OUTPUT après le nom de notre variable en output dans le execute
	DECLARE me permet de déclarer des variables en transact SQL 
	Une variable ne contient qu'une seule valeur à la fois : la dernière 
   */

		declare @nombreCours int
		execute compterCours '2342864',@nombreCours output 
		select @nombreCours as 'nombre de cours'
		go
		select * from tbl_inscription where no_da = '2342864'
		go
/* sans le mot output : il retourne null */
		declare @nombreCours int
		execute compterCours '2342864',@nombreCours output
		select @nombreCours
		go

/* Destruction de procédure stockée */

	DROP PROCEDURE listerSelonNom
	go

/* La gestion des erreurs avec return : */
	create or alter procedure ajouterModifierCours
	@no_cours nchar(10),
	@nom_cours nvarchar(50),
	@ponderation nchar(3)
	as
	declare @etat int
	if exists(select * from tbl_cours where no_cours = @no_cours)
		begin
		  update tbl_cours 
		  set nom_cours = @nom_cours, pond = @ponderation
		  where no_cours = @no_cours
		  set @etat = 70
		end
	else
		begin
			insert into tbl_cours (no_cours, nom_cours,pond)
			values (@no_cours,@nom_cours, @ponderation)
			set @etat = 80
		end
	return @etat
	go

/* Appel de la procédure */
/* le code 70 pourrait nous permettre de mettre un commentaire de maj réussi dans notre application
   alors que le code 80 serait un message ajout réussi*/

	declare @erreurs int
	execute @erreurs = ajouterModifierCours '420888BA', 'Introduction2','333'
	select @erreurs 

/* utilisation de Scope_identity : retourne le dernier numéro automatique retournée
   ce qui pourrait me permettre de faire un ajout après dans une autre table où la clé est étrangère 
   exemple : un nouveau département et l'ajout d'un employé qui en ferait partie */

   /* pour creer FK_Cie : */
   /*
		use master
		go
		IF EXISTS (SELECT name FROM sys.databases WHERE name = 'FK_Cie')
		BEGIN
			ALTER DATABASE FK_Cie SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
			drop database FK_Cie
		END
		go
		use master
		go
		CREATE DATABASE FK_Cie
		go
		use FK_Cie
		go
		CREATE TABLE tbl_departement (
			no_departement	int identity NOT NULL,
			nom_departement	nvarchar (30) NOT NULL 
		) 
		GO
		ALTER TABLE tbl_departement
		ADD CONSTRAINT [PK_departement] PRIMARY KEY (no_departement	) 
		GO
		CREATE TABLE tbl_employe (
			no_employe		int identity NOT NULL ,
			nom				nvarchar (50)  NOT NULL ,
			prenom			nvarchar (50)   NULL default 'inconnu',
			no_departement	int not NULL ,
			constraint pk_employe primary key (no_employe),
			constraint fk_no_departement foreign key (no_departement) references tbl_departement(no_departement) on update cascade
		) 
		GO
		*/

		use FK_Cie
		go
		create or alter proc ajouterDepartement
		@nom_departement nvarchar(30),
		@no_dep int output
		as
		insert into tbl_departement (nom_departement)
		values (@nom_departement)
		select @no_dep = scope_identity()
		go

		declare @no_departement int
		exec ajouterDepartement "readaptation physique2", @no_departement output
		select @no_departement as 'no automatique'

		select * from tbl_departement
		go

/* la valeur retournée par la procédure stockées (return) : attention ce n'est pas un paramètre ouptut */
		use k2fl_bd
		go
		create or alter procedure listerSelonNom 
		@nom nvarchar(50)
		AS
		select *
		from tbl_etudiant
		where nom = @nom
		order by nom,prenom
		if @@rowcount = 0 
		  return(1) /*	signifie qu'il retourne un resultat, on pourrait faire une action différente 
						selon le cas dans le langage de programmation */
		GO

		declare @erreurs int
		execute @erreurs = listerSelonNom 'Monaco'
		select @erreurs


		select * from tbl_etudiant

		declare @erreurs int
		execute @erreurs = listerSelonNom 'Ovidiu'
		select @erreurs