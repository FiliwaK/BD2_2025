

use lt_biblio
go
/*Exercices */

/* 1- type : select simple */
	/* afficher les livres dont le prix est entre 20 et 45 $(5 lignes) */
	 
	 select *
	 from LIVRES where Livres.PRIX between 20 and 45

/* 2- type : fonctions d'aggrégations */
	/* a) Combien avons-nous de livres dans notre bd ? (1 ligne :14 livres)*/
	 
	 select count(*) from LIVRES

	/* b) Pour chaque livre affichez combien ils ont d'auteurs avec un nom de colonne significatif  (14 lignes)*/
	 
	 select count(LIVRES_AUTEURS.ID_AUTEUR) as 'nombre auteurs' , LIVRES.TITRE from LIVRES_AUTEURS inner join LIVRES on LIVRES_AUTEURS.ID_LIVRE = LIVRES.ID_LIVRE group by LIVRES.TITRE 
	/* c) Afficher les livres qui ont 2 auteurs. no et titre (6 lignes) */
	 
	 select count(LIVRES_AUTEURS.ID_AUTEUR) as 'nombre auteurs' , LIVRES.TITRE from LIVRES_AUTEURS inner join LIVRES on LIVRES_AUTEURS.ID_LIVRE = LIVRES.ID_LIVRE group by LIVRES.TITRE having count(LIVRES_AUTEURS.ID_AUTEUR) = 2;
	
	/* d) afficher les auteurs qui ont écrit des livres seulement dans une catégorie 
	truc : ajouter distinct dans le count (count(distinct ...) pour compter combien de catégories différentes
	(8 lignes)*/
	 
	 select AUTEURS.NOM, AUTEURS.PRENOM, count(distinct CATEGORIES.ID_CATEGORIE) as 'nombre de categorie' from AUTEURS inner join LIVRES_AUTEURS on AUTEURS.ID_AUTEUR = LIVRES_AUTEURS.ID_AUTEUR 
	 inner join LIVRES on LIVRES_AUTEURS.ID_LIVRE = LIVRES.ID_LIVRE 
	 inner join CATEGORIES on CATEGORIES.ID_CATEGORIE = LIVRES.ID_CATEGORIE
	 group by AUTEURS.NOM, AUTEURS.PRENOM
	 having	count(distinct CATEGORIES.ID_CATEGORIE) = 1


/* 3- type : outer join */
	/*Quelles categories n'ont pas de livres qui ont été écrit dans notre bd ? à faire avec les 3 méthodes vues (outer join, not in, not exists) (6 lignes)*/
	 
	 select CATEGORIES.LIB_CATEGORIE from CATEGORIES left outer join LIVRES on CATEGORIES.ID_CATEGORIE = LIVRES.ID_CATEGORIE where LIVRES.ID_CATEGORIE is null

	 select LIB_CATEGORIE from CATEGORIES where ID_CATEGORIE not in (select ID_CATEGORIE from LIVRES)

	 select LIB_CATEGORIE from CATEGORIES where not exists (select* from LIVRES where CATEGORIES.ID_CATEGORIE = LIVRES.ID_CATEGORIE)


