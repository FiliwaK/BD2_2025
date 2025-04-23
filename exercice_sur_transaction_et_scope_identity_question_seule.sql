/* Ajoutez ces 2 tables dans une de vos BD pour faire l'exercice suivant */



use k2fl_bd
go
CREATE TABLE tbl_departement (
    no_departement int identity NOT NULL,
	nom_departement nvarchar (30) NOT NULL 
) 
GO

ALTER TABLE tbl_departement
ADD CONSTRAINT [PK_departement] PRIMARY KEY (no_departement	) 
GO


CREATE TABLE tbl_employe (
	no_employe int identity NOT NULL primary key,
	nom nvarchar (30)  NOT NULL ,
	prenom nvarchar (30)   NULL default 'inconnu',
	no_departement int not NULL references tbl_departement(no_departement) 
) ON [PRIMARY]
GO


/* Faites une procédure stockée qui ajoute : un nouveau departement ET un employé dans ce département.
   Faites le travail dans une transaction afin que ces ajouts soient faits au complet ou pas du tout.
   Mettez une instruction en erreur dans votre procédure pour tester la transaction, un ajout avec référence erronée */

   create or alter procedure ajoutDeDepartementEtEmploye
   @nom_departement nvarchar(100), 
   @nom nvarchar(100),
   @prenom nvarchar(100)
   as
   begin try
    set nocount on 
   begin transaction 
   insert into tbl_departement(nom_departement) values (@nom_departement)
   declare @no int 
   set @no = SCOPE_IDENTITY()
   insert into tbl_employe(nom, prenom, no_departement) values (@nom, @prenom, @no)
      /*insert into tbl_employe(nom, prenom, no_departement) values (@nom, @prenom, 1000) /*erreur*/*/
   commit transaction 
   end try 
   begin catch
	if @@trancount > 0
		begin
			rollback transaction;
			throw 51000,'problème durant l''exécution, la destruction est annulée',1; /* no erreur > 50 000 et < 2 147 483 647 , state entre 0 et 255 (sévérité)*/
		end
	end catch

/* Faites le test avec votre erreur provoquée et sans elle (la mettre en commentaire, ne pas l'enlever ) pour valider vos transactions */

/* test avec l'erreur, rollback sera fait */



/* test sans l'erreur (la mettre en commentaire), les 2 ajouts seront faits */

exec ajoutDeDepartementEtEmploye 'Boxe2' , 'Off2' , 'take2'

select * from tbl_departement
select * from tbl_employe