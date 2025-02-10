/* demonstration select complexe */

use k2fl_bd
go
/* Mettre des notes différentes à tous les étudiants du cours 4204A2BA  */
	select * from tbl_offreCours
	select * from tbl_inscription
	go

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


	select * from tbl_etudiant
	select * from tbl_inscription
	select * from tbl_offreCours
	select * from tbl_cours

/* 2 tables dans le from, sans liaison, nous donnent des données erronées*/
	select nom, prenom,tbl_inscription.no_da, no_offreCours ,note
	from tbl_inscription,tbl_etudiant

/*ou équivalent d'un cross join */
	select nom, prenom,tbl_inscription.no_da, no_offreCours ,note
	from tbl_inscription cross join tbl_etudiant


/* inner Join :n'inclut pas ceux qui ne sont pas inscrit à des cours*/

	select nom, prenom,tbl_inscription.no_da, no_offreCours ,note
	from tbl_etudiant inner join tbl_inscription
	on tbl_etudiant.no_da = tbl_inscription.no_da
	order by nom,prenom

/* inner join sur trois tables*/
	select nom, prenom,tbl_inscription.no_da, tbl_inscription.no_offreCours ,note, no_cours
	from tbl_etudiant inner join tbl_inscription
	on tbl_etudiant.no_da = tbl_inscription.no_da
	inner join tbl_offreCours
	on tbl_offreCours.no_offreCours = tbl_inscription.no_offreCours
	order by nom,prenom

	/* inner join sur 4 tables*/
	select nom, prenom,tbl_inscription.no_da, tbl_inscription.no_offreCours ,note, tbl_cours.no_cours, nom_cours
	from tbl_etudiant inner join tbl_inscription
	on tbl_etudiant.no_da = tbl_inscription.no_da
	inner join tbl_offreCours
	on tbl_offreCours.no_offreCours = tbl_inscription.no_offreCours
	inner join tbl_cours
	on tbl_cours.no_cours = tbl_offreCours.no_cours
	order by nom,prenom

/* outer join : inclut ceux qui ne sont pas inscrit à des cours*/

	select nom, prenom,tbl_inscription.no_da, no_offreCours ,note
	from tbl_etudiant left outer join tbl_inscription
	on tbl_etudiant.no_da = tbl_inscription.no_da
	order by nom,prenom


/* full outer join sur trois tables : 
		donne les etudiants qui ne suivent pas de cours
		donne les cours qui n'ont pas d'inscriptions */

	select nom, prenom,tbl_inscription.no_da, tbl_inscription.no_offreCours ,note, tbl_cours.no_cours, nom_cours
	from tbl_etudiant full outer join tbl_inscription
	on tbl_etudiant.no_da = tbl_inscription.no_da
	full outer join tbl_offreCours
	on tbl_offreCours.no_offreCours = tbl_inscription.no_offreCours
	full outer join tbl_cours
	on tbl_cours.no_cours = tbl_offreCours.no_cours
	order by nom,prenom


/* Donnez les noms des etudiants qui ne suivent pas de cours ? */

	/* avec un outer join */ 
	select nom, prenom,tbl_inscription.no_da, no_offreCours ,note
	from tbl_etudiant left outer join tbl_inscription
	on tbl_etudiant.no_da = tbl_inscription.no_da
	where no_offreCours is null
	order by nom,prenom

	/* avec une sous requëte */
	Select nom, prenom
	from tbl_etudiant
	where no_da not in (select no_da
						from tbl_inscription)

	/* sous-requëte et notion de EXISTS*/
	Select nom, prenom
	from tbl_etudiant
	where not exists (	select *
              			from tbl_inscription 
	      			where tbl_inscription.no_da = tbl_etudiant.no_da)


/* afficher la moyenne de chaque etudiant avec alias, tout cours confondu */	    
	select e.no_da,nom, prenom, avg(note) as 'Moyenne'
	from tbl_etudiant as e inner join tbl_inscription as i
	on e.no_da = i.no_da
	group by e.no_da,nom,prenom

	select * from tbl_inscription
	select * from tbl_etudiant

/* voir les notes de Ovidium Cracium avec alias*/
	select *
	from tbl_etudiant as e inner join tbl_inscription as i
	on e.no_da = i.no_da
	where e.nom = 'Ovidiu' and e.prenom = 'Cracium'

/* Qui a une note plus basse que la plus basse note de Ovidiu Cracium ? */

	select distinct nom,prenom,note
	from tbl_etudiant as e  inner join tbl_inscription as i
	on e.no_da = i.no_da
	where  note < (	select min(note)
					from tbl_etudiant as e inner join tbl_inscription as i
					on e.no_da = i.no_da
					where e.nom = 'Ovidiu' and e.prenom = 'Cracium')

/*autre facon le ALL */ 
	select nom,prenom,note
	from tbl_etudiant as e  inner join tbl_inscription as i
	on e.no_da = i.no_da
	where  note < all(	select  note
						from tbl_etudiant as e inner join tbl_inscription as i
						on e.no_da = i.no_da
						where e.nom = 'Ovidiu' and e.prenom = 'Cracium')


/* Voyons la différence avec ANY */
	select distinct nom,prenom,note
	from tbl_etudiant as e  inner join tbl_inscription as i
	on e.no_da = i.no_da
	where  note < any(	select  note
						from tbl_etudiant as e inner join tbl_inscription as i
						on e.no_da = i.no_da
						where e.nom = 'Ovidiu' and e.prenom = 'Cracium')




go
select * from tbl_inscription 
select * from tbl_etudiant


go









