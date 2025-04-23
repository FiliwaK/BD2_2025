/* exercice sur SQL : insert update delete*/
/* placez cet exercice dans le même fichier .sql de votre création de schéma. enregistrer sur votre github */

/* script de création de la bdScolaire*/


/* no 1-2 création de la base de données si la database existe la détruire*/
--use master
--go
--DROP DATABASE IF EXISTS k2fl_bd
--go
--CREATE DATABASE k2fl_bd
--go

use master
go
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'k2fl_bd')
BEGIN
    ALTER DATABASE k2fl_bd SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	drop database k2fl_bd
END
CREATE DATABASE k2fl_bd
go
/*no 3 création de tbl_session  */

use k2fl_bd
go

create table tbl_session(
no_session nchar(5) primary key 
)
go
/*no 4 tbl_cours */

create table tbl_cours(
no_cours nchar(8) primary key,
nom_cours nvarchar(100), 
ponderation nchar(5)
)
GO

alter table tbl_cours
add constraint pond_Default default '1-1-1' for ponderation
GO

/*no 5 tbl_offreCours */
create table tbl_offreCours(
no_offreCours int identity primary key, 
no_session nchar(5) references tbl_session(no_session) on update cascade,
no_cours nchar(8) references tbl_cours(no_cours) on update cascade,
constraint Contrainte_unique unique (no_session, no_cours)
)
GO


/* no 6 tbl_etudiant */

create table tbl_etudiant(
no_da nchar(7) primary key,
nom nvarchar(100), 
prenom nvarchar(100),
email nvarchar(100) null 
)
GO


/* no 7 table tbl_inscription, */

create table tbl_inscription(
no_da nchar(7) not null,
no_offreCours int not null, 
note decimal(5,2)
)
GO


/* no 8 modification tbl_inscription */
alter table tbl_inscription
add constraint PK_inscription primary key (no_da, no_offreCours),
 constraint limit_note check (note between 0 and 100),
 constraint FK_inscription_da foreign key (no_da) references tbl_etudiant(no_da)on update cascade, 
 constraint FK_inscription_offreCours foreign key (no_offreCours) references tbl_offreCours(no_offreCours)
GO

/* no 9 check sur session A H E*/

alter table tbl_session
add constraint check_session check (no_session like 'A%' or no_session like 'H%' or no_session like 'E%')


/* pour afficher les contraintes */
/*
sp_help tbl_inscription
*/
go
/* affiche le détail de la contrainte */
/*
sp_helptext check_session
*/
--INSERT INTO tbl_session (no_session)
--VALUES ('A001'),
--       ('H001'),
--       ('E001');
--INSERT INTO tbl_cours (no_cours, nom_cours, ponderation)
--VALUES ('CS101', 'Introduction à la Programmation', '1-1-1'),
--       ('MAT202', 'Calcul Différentiel', '1-2-1'),
--       ('PHY303', 'Physique Moderne', '2-1-1');
	   
--INSERT INTO tbl_offreCours (no_session, no_cours)
--VALUES ('A001', 'CS101'),
--       ('H001', 'MAT202'),
--       ('E001', 'PHY303');

--INSERT INTO tbl_etudiant (no_da, nom, prenom, email)
--VALUES ('2023001', 'Dupont', 'Jean', 'jean.dupont@email.com'),
--       ('2023002', 'Martin', 'Alice', 'alice.martin@email.com'),
--       ('2023003', 'Lemoine', 'Paul', 'paul.lemoine@email.com');

--INSERT INTO tbl_inscription (no_da, note)
--VALUES ('2023001', 85.50),
--       ('2023002', 92.00),
--       ('2023003', 78.25);


/*


*/

/* no 1*/

insert into tbl_etudiant (no_da, nom, prenom, email) values ('2342864', 'Kouakou', 'Fabrice', 'kouakoufabrice7@gmail.com')
GO

/* select * from tbl_etudiant */

/* no 2*/

insert into tbl_cours (no_cours, nom_cours, ponderation) values ('4204B2BA', 'Base de données 2', '2-3-2'), ('4203B1BA', 'Base de données 1', '2-2-1')

/* select * from tbl_cours*/ 
go
/* no 3 */

update tbl_cours set no_cours = '4203B2BA' where no_cours = '4203B1BA' 
GO

/* select * from tbl_cours*/ 

/* no 4 */
insert into tbl_session(no_session) values ('H2025')
GO

insert into tbl_offreCours (no_cours, no_session) values ('4203B2BA', 'H2025')
GO
--select* from tbl_offreCours 

insert into tbl_inscription (no_da, no_offreCours) values ('2342864', (select no_offreCours from tbl_offreCours where no_cours = '4203B2BA' and no_session = 'H2025')) 
GO

/* select * from tbl_inscription */
/* no 5 */

create table tbl_prealable (
no_coursDeBase nchar(8) not null,
no_coursPrealable nchar(8) not null
constraint prealableDeBase_FK foreign key (no_coursDeBase) references tbl_cours(no_cours), 
constraint prealable_FK foreign key (no_coursPrealable) references tbl_cours(no_cours), 
constraint PK_prealable primary key (no_coursDeBase, no_coursPrealable)
)
go

insert into tbl_prealable values ('4204B2BA', '4203B2BA')
go

/* 
select * from tbl_prealable 
select * from tbl_cours
select * from tbl_inscription
*/


/* no 6 */

insert into tbl_etudiant (no_da, nom, prenom, email)
select '25000' + str(BusinessEntityID,2) as BusinessEntityID,FirstName,LastName, FirstName + LastName '@gmail.com'
from AdventureWorks2022.Person.person
where BusinessEntityID >10 and BusinessEntityID< 20
GO

/* 
select * from AdventureWorks2022.Person.person 
select * from tbl_etudiant 
*/


/* no 7 */

insert into tbl_cours (no_cours, nom_cours, ponderation) values ('4204A2BA','méthode de développement', '2-1-1')
insert into tbl_offreCours (no_cours, no_session) values ('4204A2BA', 'H2025')
insert into tbl_inscription(no_da, no_offreCours) 
select no_da , (select no_offreCours from tbl_offreCours where no_cours = '4204A2BA' and no_session = 'H2025') 
from tbl_etudiant
go
/* 
select * from tbl_cours
select * from tbl_offreCours
select * from tbl_inscription

*/

/* no 8 */

delete from tbl_inscription 
where no_da = '2500017'
GO

--delete from tbl_inscription
--where no_da in (select no_da from tbl_etudiant where prenom = 'Kevin' and nom = 'Brown')


delete from tbl_etudiant where no_da = '2500017'
GO

--delete from tbl_etudiant where prenom = 'Kevin' and nom = 'Brown'
/*
select * from tbl_etudiant where prenom = 'Kevin' and nom = 'Brown'
select * from tbl_inscription 
select * from tbl_etudiant
*/


/*  no 9 */
--select * from tbl_cours 

/* ajouter une colonne */

alter table tbl_cours
add pond nchar(5)
GO

/* transferer les donnée */

UPDATE TBL_COURS SET POND = PONDERATION 
GO
/* detruire pondération */

ALTER TABLE TBL_COURS DROP CONSTRAINT pond_Default
GO

ALTER TABLE TBL_COURS DROP COLUMN PONDERATION
GO


/* si vous avez enlevé une contrainte, n'oubliez pas de la remettre */

alter table tbl_cours
add constraint pond_Default default '1-1-1' for pond
GO

/*	Faire générer un gros select (concevoir une requête dans l’éditeur) sur toutes vos tables 
	pour bien voir le resultat final. */

update tbl_inscription
	set note = 80 + convert(int,substring(no_da,7,1))
	from tbl_offreCours inner join tbl_inscription
	on tbl_inscription.no_offreCours = tbl_offreCours.no_offreCours
	where tbl_offreCours.no_cours = '4204A2BA' and no_session = 'H2025'
	go
/* Mettre une note pour l'etudiant inscrit au cours 4203B2BA  */
	update tbl_inscription
	set note = 70
	from tbl_offreCours inner join tbl_inscription
	on tbl_inscription.no_offreCours = tbl_offreCours.no_offreCours
	where tbl_offreCours.no_cours = '4203B2BA'and no_session = 'H2025'

/*un ajout de cours avec note pour Ovidiu Cracium OvidiuCracium@gmail.com 2500011*/
	insert into tbl_inscription (no_offreCours,no_da,note)
	values ((select no_offreCours 
				from tbl_offreCours 
				where no_cours = '4203B2BA'and no_session = 'H2025'),
				(select no_da 
				from tbl_etudiant 
				where nom = 'Ovidiu' and prenom = 'Cracium' ),
				85)
go

/* ajouter un etudiant qui ne suit pas de cours */
	insert into tbl_etudiant (no_da,prenom,nom,email)
	values ('2554322','Jean','Dit','jDit@gmail.com')
	go


	insert into tbl_session (no_session)
values ('H2024')
go
insert into tbl_offreCours (no_session,no_cours)
values('H2024','4204A2BA')
go


insert into tbl_inscription(no_da,no_offreCours)
select no_da,(select no_offreCours from tbl_offreCours where no_cours = '4204A2BA' and no_session ='H2024') from tbl_etudiant
 where no_da > '2400031' and no_da < '2400040'
go

/* procedure stockée pour scanneur */

create procedure ListerResultatEtudiant
@no_Da nchar(7)
as
SELECT        tbl_etudiant.no_da, tbl_etudiant.nom, tbl_etudiant.prenom, tbl_inscription.note, tbl_cours.nom_cours, tbl_offreCours.no_session
FROM            tbl_inscription 
				INNER JOIN  tbl_etudiant ON tbl_inscription.no_da = tbl_etudiant.no_da 
				INNER JOIN  tbl_offreCours ON tbl_inscription.no_offreCours = tbl_offreCours.no_offreCours 
				INNER JOIN  tbl_cours ON tbl_offreCours.no_cours = tbl_cours.no_cours
where			tbl_etudiant.no_da = @no_Da
Order by		no_session, nom_cours 
go

create or alter procedure nombreCoursSession
		@session nchar(5) 
		as
		select count(distinct no_cours) as 'nombre de cours'
		from tbl_offreCours
		where no_session = @session
		go

create or alter procedure nombreCoursSessionOutput
		@session nchar(5),
		@nombreCours int output 
		as 
		select @nombreCours = count(distinct no_cours)
		from tbl_offreCours
		where no_session = @session
		go



insert into tbl_etudiant (no_da,prenom,nom,email)
select '23000' + str(businessEntityID,2) as Contact_ID,FirstName,LastName, FirstName + LastName + '@'+'gmail.com'
from AdventureWorks2022.Person.person
where businessEntityID >30 and businessEntityID< 40
go
/*select * from tbl_etudiant
select * from tbl_inscription
select * from tbl_offreCours
select * from tbl_session
*/

insert into tbl_session (no_session)
values ('H2023')
go
insert into tbl_offreCours (no_session,no_cours)
values('H2023','4204A2BA')
go


insert into tbl_inscription(no_da,no_offreCours)
select no_da,(select no_offreCours from tbl_offreCours where no_cours = '4204A2BA' and no_session ='H2023') from tbl_etudiant
 where no_da > '2300031' and no_da < '2300040'
go

create or alter view VueListerResultat 
as
select tbl_inscription.no_da, nom, prenom, note, tbl_inscription.no_offreCours 
from tbl_etudiant inner join tbl_inscription 
on tbl_etudiant.no_da = tbl_inscription.no_da
go

--faut toujours mettre tous les selects de la vue dans les parametre de modification et dans le meme ordre

create procedure ModifierNoteEtudiant
@no_da nchar(7),
@no_offreCours int,
@note decimal(5,2),
@nom nvarchar(100),
@prenom nvarchar(100)
as
update VueListerResultat
set note = @note 
where no_da = @no_da and no_offreCours = @no_offreCours
go

/* ajout de quelques données */
insert into tbl_etudiant (no_da,nom,prenom)  values ('2300060','Roy','Luc')
go
insert into tbl_inscription(no_offreCours,no_da) 
values ((select no_offreCours  from tbl_offreCours where no_cours = '4203B2BA' and no_session = 'H2025'),
		'2300060')
go
insert into tbl_session (no_session)values ('A2023')
go
insert into tbl_offreCours(no_cours,no_session)
values('4203B2BA','A2023')
go
insert into tbl_inscription(no_offreCours,no_da)  
values ((select no_offreCours  from tbl_offreCours where no_cours = '4203B2BA' and no_session = 'A2023'),
		'2300060')
go
select * from tbl_etudiant where no_da = '2300060'
select * from tbl_inscription where no_da = '2300060'
select * from tbl_offreCours
go

/* creation d'une procedure stockée sans transaction avec une erreur */

create proc detruireEtudiantEtInscription
@no_etudiant nchar(7)
as
delete from tbl_inscription where no_da = @no_etudiant
/* erreur provoquée : contrainte de reference :no_offreCours inexistant*/
insert into tbl_inscription (no_da,no_offreCours) values ('2300060',100)
delete from tbl_etudiant where no_da = @no_etudiant
go

/* execution pouvant provoquer une mauvaise intégrité des données car 1 des instructions n'est pas effectuées */

exec detruireEtudiantEtInscription '2300060'
select * from tbl_etudiant where no_da = '2300060'
select * from tbl_inscription where no_da = '2300060'

/* ajout de transactions dans notre procedure */

alter proc detruireEtudiantEtInscription
@no_etudiant nchar(7)
as
begin try
	set nocount on
	begin transaction
		delete from tbl_inscription where no_da = @no_etudiant
		/* erreur provoquée : contrainte de reference :no_offreCours inexistant*/
		insert into tbl_inscription (no_da,no_offreCours) values ('2300060',100)
		delete from tbl_etudiant where no_da = @no_etudiant
	commit transaction
end try
begin catch
	if @@trancount > 0
		begin
			rollback transaction;
			throw 51000,'problème durant l''exécution, la destruction est annulée',1; /* no erreur > 50 000 et < 2 147 483 647 , state entre 0 et 255 (sévérité)*/
		end
end catch
go

/* remettre les données*/
insert into tbl_etudiant (no_da,nom,prenom)  values ('2300060','Roy','Luc')
insert into tbl_inscription(no_offreCours,no_da) 
values ((select no_offreCours  from tbl_offreCours where no_cours = '4203B2BA' and no_session = 'H2025'),
		'2300060')
insert into tbl_inscription(no_offreCours,no_da)  
values ((select no_offreCours  from tbl_offreCours where no_cours = '4203B2BA' and no_session = 'A2023'),
		'2300060')
/* essaie de la procedure  avec l'erreur (rien n'est détruit), puis essayer sans l'erreur, tout est détruit */
exec detruireEtudiantEtInscription '2300060'

select * from tbl_etudiant where no_da = '2300060'
select * from tbl_inscription where no_da = '2300060'