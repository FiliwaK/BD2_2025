/* script de démonstration de création de schéma et de tables */


/* exemple de création minimale d'une base de données */
use master
go
CREATE DATABASE LT_Cie
go

/* autre mode de création de bd c'est-à-dire en spécifiant un collate précis: mode de comparaison des string

CREATE DATABASE LT_Cie COLLATE French_CS_AS						case sensitive et accent sensitive
ou comme au cegep
CREATE DATABASE LT_Cie COLLATE SQL_Latin1_General_CP1_CI_AS		case insensitive et accent sensitive

*/

/* exemple si on veut détruire la bd si elle existe  */
DROP DATABASE IF EXISTS LT_Cie
go
CREATE DATABASE LT_Cie
go


/* exemple création d'une table	sans contrainte  */

use LT_Cie 
go

CREATE TABLE tbl_departement (
    no_departement	int identity NOT NULL,
	nom_departement	nvarchar (200) NOT NULL 
) 
GO


/* création de l'autre table mais en ajoutant les contraintes dans le create
		NE fonctionnera PAS pas car...	
		réponse : il faut une clé primaire avant dans l'autre table pour y faire référence */


CREATE TABLE tbl_employe (
	no_employe		int identity NOT NULL primary key,
	nom				nvarchar (200)  NOT NULL ,
	prenom			nvarchar (200)   NULL default 'inconnu',
	no_departement	int not NULL references tbl_departement(no_departement) 
) 
GO

/* ajout de la clé primaire de la table departement APRÈS création pour pouvoir faire le lien avec tbl_employe */

ALTER TABLE tbl_departement
ADD CONSTRAINT PK_departement PRIMARY KEY (no_departement) 
GO

/* Voici une AUTRE façon de définir les contraintes, APRÈS les champs pour la table employe */

CREATE TABLE tbl_employe (
	no_employe		int identity NOT NULL ,
	nom				nvarchar (200)  NOT NULL ,
	prenom			nvarchar (200)   NULL default 'inconnu',
	no_departement	int not NULL ,
	constraint pk_employe primary key (no_employe),
	constraint fk_no_departement foreign key (no_departement) references tbl_departement(no_departement) 
) 
GO


/* ajoutons une contrainte check APRÈS création*/

ALTER TABLE tbl_departement WITH NOCHECK 
ADD CONSTRAINT CK_departement CHECK (no_departement >= 100)
GO

/* si on n'avait pas ajouter une contrainte de cle etrangère dans le create,
   on pourrait le faire APRÈS création */

ALTER TABLE tbl_employe 
ADD CONSTRAINT FK_employe_departement FOREIGN KEY (no_departement) REFERENCES tbl_departement (no_departement) 
GO


/* Exemple pour ajouter un champ */
   alter table tbl_departement
   add no_local char(5) null

/* Exemple pour ajouter un defaut après création */
   alter table tbl_departement
   add constraint DF_depart default 'B-533' for no_local 

/* Exemple pour enlever un champ si libre de contrainte : non fonctionnel ici car on a une contrainte defaut*/
   alter table tbl_departement
   drop column no_local 

/* Exemple pour enlever une contrainte */  
   alter table tbl_departement
   drop constraint DF_depart

/* Exemple pour changer le type d’une colonne  */
	alter table tbl_departement
	alter column no_local nchar(3)
	go

/* N.B. en sql on ne peut pas changer le nom d’une colonne, 
  il faut faire un DROP et un ADD de la colonne. 

  Par contre en transact SQL, il existe une instruction rename 
  EXEC sp_rename 'tbl_departement.no_local', 'noLocal', 'COLUMN';

  select * from tbl_departement
  */


/* pour afficher les renseignements sur une table */
sp_help tbl_employe
go
/* pour afficher le texte d'une contrainte*/
sp_helptext DF__tbl_emplo__preno__3D5E1FD2



