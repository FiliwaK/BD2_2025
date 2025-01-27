/* script de création de la bdScolaire*/


/* no 1-2 création de la base de données si la database existe la détruire*/
use master
go
DROP DATABASE IF EXISTS k2fl_bd
go
CREATE DATABASE k2fl_bd
go

/*no 3 création de tbl_session  */

use k2fl_bd
go

create table tbl_session(
no_session nchar(5) primary key 
)

/*no 4 tbl_cours */

create table tbl_cours(
no_cours nchar(8) primary key,
nom_cours nvarchar(100), 
ponderation nchar(5)
)

alter table tbl_cours
add constraint pond_Default default '1-1-1' for ponderation 

/*no 5 tbl_offreCours */
create table tbl_offreCours(
no_offreCours int identity primary key, 
no_session nchar(5) references tbl_session(no_session) on update cascade,
no_cours nchar(8) references tbl_cours(no_cours) on update cascade,
constraint Contrainte_unique unique (no_session, no_cours)
)


/* no 6 tbl_etudiant */

create table tbl_etudiant(
no_da nchar(7) primary key,
nom nvarchar(100), 
prenom nvarchar(100),
email nvarchar(100) null 
)


/* no 7 table tbl_inscription, */

create table tbl_inscription(
no_da nchar(7) not null,
no_offreCours int identity not null, 
note decimal(5,2)
)


/* no 8 modification tbl_inscription */
alter table tbl_inscription
add constraint PK_inscription primary key (no_da, no_offreCours),
 constraint limit_note check (note between 0 and 100),
 constraint FK_inscription_da foreign key (no_da) references tbl_etudiant(no_da)on update cascade, 
 constraint FK_inscription_offreCours foreign key (no_offreCours) references tbl_offreCours(no_offreCours)


/* no 9 check sur session A H E*/

alter table tbl_session
add constraint check_session check (no_session like 'A%' or no_session like 'H%' or no_session like 'E%')


/* pour afficher les contraintes */
/*
sp_help tbl_session
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

--INSERT INTO tbl_inscription (no_da, no_offreCours, note)
--VALUES ('2023001', 1, 85.50),
--       ('2023002', 2, 92.00),
--       ('2023003', 3, 78.25);


/*


*/