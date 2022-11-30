-- 1.	Obtenir la liste des villes qui ont un nom d''au moins 40 lettres
SELECT * FROM villes_france WHERE length(ville_nom)>=40;

-- 2.	Obtenir la liste des départements d’outre-mer, c’est-à-dire ceux dont le numéro de département commence par “97”
SELECT * FROM departements WHERE departement_code LIKE("97%");

-- 3.	Obtenir la liste des départements des Hauts-de-France trier par ordre alphabétique des noms de département (sans jointure)
SELECT * FROM departements WHERE departement_regionId=(SELECT region_id FROM regions WHERE region_nom="Hauts-de-France") ORDER BY departement_nom;

-- 4.	Obtenir le nom de toutes les villes, ainsi que le nom du département associé. Les plus peuplées en 2012 apparaitront en premier
SELECT ville_nom, departement_nom FROM villes_france LEFT JOIN departements ON departement_code=ville_departement ORDER BY ville_population_2012 DESC;

-- 5.	Obtenir la liste du nom de chaque département, associé à son code et du nombre de commune au sein de ces départements, en triant afin d’obtenir en priorité les départements qui possèdent le plus de communes
SELECT departement_nom, departement_code, (SELECT count(*) FROM villes_france WHERE ville_departement=departement_code) AS villesParDept FROM departements ORDER BY villesParDept DESC;

-- 6.	Obtenir la liste des départements, classés en fonction de leur superficie (plus grand en premier)
SELECT *, (SELECT SUM(ville_surface) FROM villes_france WHERE ville_departement=departement_code) AS superficie FROM departements ORDER BY superficie DESC;

-- 7.	Compter le nombre de villes dont le nom commence par “Saint”
SELECT count(*) AS nbrSaint FROM villes_france WHERE ville_nom_reel LIKE ("Saint%");

-- 8.	Obtenir la liste des villes qui ont un nom existants plusieurs fois, et trier afin d’obtenir en premier celles dont le nom est le plus souvent utilisé par plusieurs communes
SELECT ville_nom,count(*) AS iterations FROM villes_france GROUP BY ville_nom HAVING iterations>1 ORDER BY iterations DESC;

-- 9.	Obtenir en une seule requête SQL la liste des villes dont la superficie est supérieure à la superficie moyenne
-- SELECT ville_nom, ville_surface, (SELECT AVG(ville_surface) FROM villes_france) AS surfMoyenne FROM villes_france HAVING ville_surface>surfMoyenne;
SELECT * FROM villes_france WHERE ville_surface>(SELECT AVG(ville_surface) FROM villes_france);

-- 10.	Obtenir la liste des départements qui possèdent plus de 1.5 millions d’habitants en 2012
--SELECT ville_departement, SUM(ville_population_2012) AS population FROM villes_france GROUP BY ville_departement having population>1500000; 
SELECT * FROM departements WHERE departement_code IN(
SELECT ville_departement FROM villes_france GROUP BY ville_departement HAVING SUM(ville_population_2012)>1500000);

-- 11.	Remplacez les tirets par un espace vide, pour toutes les villes commençant par “SAINT-” (dans la colonne qui contient les noms en majuscule)
UPDATE villes_france SET ville_nom=REPLACE(ville_nom, "-", " ") WHERE ville_nom LIKE "SAINT-";

-- 12.	Supplémentaire. Obtenir la liste des 50 villes ayant la plus faible superficie
SELECT * FROM villes_france ORDER BY ville_surface LIMIT 50;

-- 13.	Ajouter une colonne region_nbDepartement dans la table regions (mettre le code dans le script de réponse)
ALTER TABLE regions ADD region_nbDepartement int(3);

-- 14.	Ecrire une procédure stockée (nommée MajRegion), qui vient mettre à jour cette colonne
CREATE PROCEDURE `MajRegion`() NOT DETERMINISTIC CONTAINS SQL SQL SECURITY DEFINER UPDATE regions SET region_nbDepartement = (SELECT count(*) FROM departements WHERE departement_regionID=region_id); 

-- 15.	Créer une vue qui regroupe les 3 tables
CREATe view VueTroisTable AS
SELECT v.*, d.departement_id, d.departement_nom, d.departement_nom_soundex, d.departement_nom_uppercase, d.departement_slug, r.region_id, r.region_nom, r.region_nbDepartement FROM villes_france AS v LEFT JOIN departements AS d ON v.ville_departement=d.departement_code LEFT JOIN regions AS r ON d.departement_regionId=r.region_id;

-- Facultatif : Créer les contraintes de clés étrangères pour visualiser les relations