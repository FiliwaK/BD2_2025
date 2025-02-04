/* Exercice sur le select simple */

use BD_ville
go

/*	1- faites afficher le contenu de la table ville mais nous voulons avoir
	seulement les 10 premiers enregistrements (10 lignes)*/

	select top 10* from tbl_ville 

/*	2- Faites afficher les villes (seulement le nom de ville et le gentile) 
	qui ont dans leur nom le mot 'saint' suivi de 'pr' pas nécessairement tout de suite après
	(12 lignes)*/

	select nomVille, gentile from tbl_ville where nomVille like '%saint%pr%'


/*	3- Faites afficher les villes qui n'ont pas de gentile (null comme valeur)
	(87 lignes)*/

	select* from tbl_ville where gentile is null

/*	4- Donner les villes qui ont comme designation 1, 3, 6, ou 8 (pensez IN)
	affichez le no de designation, le nom de la ville, sa population et son gentile en ordre de ville 
	(utiliser un ensemble) (66 lignes)*/

	select no_designation, nomVille, population, gentile from tbl_ville where no_designation in ('1','3','6','8')

/*	5- Maintenant, faites afficher la population moyenne des villes de notre BD. 
	Donnez un titre de colonne pertinent (1 ligne :7450)*/

	select avg(population) as 'Population Moyenne' from tbl_ville


/*	6- Faites afficher la population moyenne de nos villes par region. 
	Donnez un titre de colonne pertinent. (17 lignes) */

	select no_region, AVG(population) as 'Population Moyenne par region' from tbl_ville group by no_region

/*	7- Faites afficher par region, la superficie par km carré maximum
	Mais nous voulons avoir que les superficies Maximum qui sont plus grandes que 4000
	(5 enr.)*/

	select no_region, max(superficieKMcarree) from tbl_ville group by no_region having max(superficieKMcarree) > 4000 


/*	8- Combien y a t-il de ville qui ont une population plus grande que 100 000 habitants
	Mettez un nom de colonne pertinent.
	(1 ligne : 10)*/

	select count(no_ville)  as 'Ville avec le max de population' from tbl_ville where population > 100000

/*	9- Quel est la plus grande population ?  (1801546 )*/

	select max(population) as 'population max' from tbl_ville

/*  10- Quelle est le nom de la ville qui la plus grande population 
   Servez-vous de votre instruction précédente en la plaçant dans le where de celle-ci. 
   Vous pourrez comparer la population à la plus grande population */

   select nomVille from tbl_ville where population = (select max(population) as 'population max' from tbl_ville)
   



