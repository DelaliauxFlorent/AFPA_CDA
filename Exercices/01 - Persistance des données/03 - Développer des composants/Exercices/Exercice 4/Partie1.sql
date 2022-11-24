-- 1 Afficher toutes les informations concernant les employés
SELECT * FROM employe;
SELECT noemp, nom, prenom, dateemb, nosup, titre, nodep, salaire, tauxcom FROM employe;

-- 2 Afficher toutes les informations concernant les départements
SELECT nodept, nom, noregion FROM dept;

-- 3 Afficher le nom, la date d'embauche, le numéro du supérieur, le numéro de département et le salaire de tous les employés
SELECT nom AS "Nom de l'employé", dateemb AS "Date d'embauche", nosup AS "Numéro du supérieur", nodep AS "Numéro du département", salaire AS "Salaire" FROM employe;

-- 4 Afficher le titre de tous les employés.
SELECT titre FROM employe;

-- 5 Afficher les différentes valeurs des titres des employés.
SELECT DISTINCT titre FROM employe;

-- 6 Afficher le nom, le numéro d'employé et le numéro du département des employés dont le titre est «Secrétaire». 
SELECT nom AS "Nom de l'employé", noemp AS "Numéro d'employé'", nodep AS "Numéro du département" FROM employe WHERE titre="Secrétaire";

-- 7 Afficher le nom et le numéro de département dont le numéro de département est supérieur à 40.
SELECT nom AS "Nom du département", noept AS "Numéro du département" FROM dept WHERE nodept>40;

-- 8 Afficher le nom et le prénom des employés dont le nom est alphabétiquement antérieur au prénom.
SELECT nom AS "Nom de l'employé", prenom AS "Prénom de l'employé" FROM employe WHERE nom<prenom;

-- 9 Afficher le nom, le salaire et le numéro du département des employés dont le titre est «Représentant», le numéro de département est 35et le salaire est supérieur à 20000.
SELECT nom, salaire, nodep FROM employe WHERE titre="Représentant" AND nodep=35 AND salaire>20000;

-- 10 Afficher le nom, le titre et le salaire des employés dont le titre est «Représentant» ou dont le titre est «Président».
SELECT nom, titre, salaire FROM employe WHERE titre IN ("Représentant", "Président");

-- 11 Afficher le nom, le titre, le numéro de département, le salaire des employés du département 34, dont le titre est «Représentant» ou «Secrétaire».
SELECT nom, titre, nodep, salaire FROM employe WHERE nodep=34 AND titre IN ("Représentant","Secrétaire");

-- 12 Afficher le nom, le titre, le numéro de département, le salaire des employés dont le titre est Représentant, ou dont le titre est Secrétaire dans le département numéro 34.
SELECT nom, titre, nodep, salaire FROM employe WHERE titre="Représentant" OR (titre="Secrétaire" AND nodep=34);

-- 13 Afficher le nom, et le salaire des employés dont le salaire est compris entre 20000et 30000.
SELECT nom, salaire FROM employe WHERE salaire BETWEEN 20000 AND 30000;

-- 15 Afficher le nom des employés commençant par la lettre «H».
SELECT nom FROM employe WHERE nom LIKE "H%";

-- 16 Afficher le nom des employés se terminant par la lettre «n».
SELECT nom FROM employe WHERE nom LIKE "%n";

-- 17 Afficher le nom des employés contenant la lettre «u» en 3èmeposition
SELECT nom FROM employe WHERE nom LIKE "__u%";
