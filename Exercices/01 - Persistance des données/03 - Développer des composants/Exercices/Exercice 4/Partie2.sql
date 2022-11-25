--
-- Jointures
--
-- 1 Rechercher le prénom des employés et le numéro de la région de leur département.
SELECT
    e.prenom,
    d.noregion
FROM
    employe AS e
    INNER JOIN dept AS d ON e.nodep = d.nodept;

-- 2 Rechercher le numéro du département, le nom du département, le nom des employés classés par numéro de département (renommer les tables utilisées).
SELECT
    d.nodept,
    d.nom,
    e.nom
FROM
    employe AS e
    INNER JOIN dept AS d ON e.nodep = d.nodept
ORDER BY
    d.nodept;

-- 3 Rechercher le nom des employés du département Distribution
SELECT
    e.nom
FROM
    employe AS e
    INNER JOIN dept AS d ON e.nodep = d.nodept
WHERE
    d.nom = "Distribution";

--
-- Auto-jointures
--
-- 4 Rechercher le nom et le salaire des employés qui gagnent plus que leur patron, et le nom et le salaire de leur patron.
SELECT
    e.nom AS "Nom Employé",
    e.salaire AS "Salaire Employé",
    p.nom AS "Nom du Patron",
    p.salaire AS "Salaire du Patron"
FROM
    employe AS e
    INNER JOIN employe AS p ON e.nosup = p.noemp
WHERE
    e.salaire > p.salaire;

--
-- Sous-requêtes
--
-- 5 Rechercher le nom et le titre des employés qui ont le même titre que Amartakaldire
SELECT
    nom,
    titre
FROM
    employe
WHERE
    titre =(
        SELECT
            titre
        FROM
            employe as e
        WHERE
            e.nom = "Amartakaldire"
    );

-- 6 Rechercher le nom, le salaire et le numéro de département des employés qui gagnent plus qu'un seul employé du département 31, classés par numéro de département et salaire.
SELECT
    nom,
    salaire,
    nodep
FROM
    employe
WHERE
    salaire > ANY (
        SELECT
            salaire
        FROM
            employe
        WHERE
            nodep = 31
    )
ORDER BY
    nodep,
    salaire;

-- 7 Rechercher le nom, le salaire et le numéro de département des employés qui gagnent plus que tous les employés du département 31, classés par numéro de département et salaire.
SELECT
    nom,
    salaire,
    nodep
FROM
    employe
WHERE
    salaire > ALL (
        SELECT
            salaire
        FROM
            employe
        WHERE
            nodep = 31
    )
ORDER BY
    nodep,
    salaire;

-- 8 Rechercher le nom et le titre des employés du service 31qui ont un titre que l'on trouve dans le département 32.
SELECT
    e0.nom,
    e0.titre
FROM
    employe AS e0
WHERE
    e0.nodep = 31
    AND e0.titre IN (
        SELECT
            DISTINCT e.titre
        FROM
            employe AS e
        WHERE
            e.nodep = 32
    );

-- 9 Rechercher le nom et le titre des employés du service 31qui ont un titre l'on ne trouve pas dans le département 32.
SELECT
    e0.nom,
    e0.titre
FROM
    employe AS e0
WHERE
    e0.nodep = 31
    AND e0.titre NOT IN (
        SELECT
            DISTINCT e.titre
        FROM
            employe AS e
        WHERE
            e.nodep = 32
    );

-- 10 Rechercher le nom, le titre et le salaire des employés qui ont le même titre et le même salaire que Fairant.
SELECT
    nom,
    titre,
    salaire
FROM
    employe
WHERE
    titre =(
        SELECT
            titre
        FROM
            employe
        WHERE
            nom = "Fairent"
    )
    AND salaire =(
        SELECT
            salaire
        FROM
            employe
        WHERE
            nom = "Fairent"
    );

-- 11 Rechercher le numéro de département, le nom du département, le nom des employés, en affichant aussi les départements dans lesquels il n'y a personne, classés par numéro de département.
SELECT
    d.nodept,
    d.noregion,
    e.nom
FROM
    dept as d
    LEFT JOIN employe as e ON d.nodept = e.nodep
ORDER BY
    d.nodept;

-- "PARTIE 2"
-- 1 Calculer le nombre d'employés de chaque titre.
SELECT
    titre,
    COUNT(*) AS "Nbre de titulaires"
FROM
    employe
GROUP BY
    titre;

-- 2 Calculer la moyenne des salaireset leur somme, par région.
SELECT
    d.noregion,
    ROUND(AVG(e.salaire), 2) AS "Moyenne des salaires",
    SUM(e.salaire) AS "Total des salaires"
FROM
    employe AS e
    INNER JOIN dept AS d ON e.nodep = d.nodept
GROUP BY
    d.noregion;

-- 3 Afficher les numéros des départements ayant au moins 3 employés.
SELECT
    nodep
FROM
    employe
GROUP BY
    nodep
HAVING
    COUNT(*) >= 3;

-- 4 Afficher les lettres qui sont l'initiale d'au moins trois employés.
SELECT
    LEFT(nom, 1)
FROM
    employe
GROUP BY
    LEFT(nom, 1)
HAVING
    COUNT(*) >= 3;

-- 5 Rechercher le salaire maximum et le salaire minimum parmi tous les salariés et l'écart entre les deux.
SELECT
    MAX(salaire) AS "Salaire Max",
    MIN(salaire) AS "Salaire Min",
    MAX(salaire) - MIN(salaire) AS "Écart de salaire"
FROM
    employe;

-- 6 Rechercher le nombre de titres différents.
SELECT
    COUNT(DISTINCT titre) AS "Nbre de titres"
FROM
    employe;

-- 7 Pour chaque titre, compter le nombre d'employés possédant ce titre.
SELECT
    titre,
    COUNT(*) AS "Effectif"
FROM
    employe
GROUP BY
    titre;

-- 8 Pour chaque nom de département, afficher le nom du département et le nombre d'employés.
SELECT
    d.nom AS "Département",
    COUNT(*) AS "Effectif"
FROM
    dept AS d
    LEFT JOIN employe AS e ON d.nodept = e.nodep
GROUP BY
    d.nom;

-- 9 Rechercher les titres et la moyenne des salaires par titre dont la moyenne est supérieure à la moyenne des salaires des Représentants.
SELECT
    titre,
    ROUND(AVG(salaire), 2) AS "Salaire moyen du titre"
FROM
    employe
GROUP BY
    titre
HAVING
    AVG(salaire) >(
        SELECT
            AVG(salaire)
        FROM
            employe
        WHERE
            titre = "représentant"
    );

-- 10 Rechercher le nombre de salaires renseignés et le nombre de taux de commission renseignés.
SELECT
    COUNT(salaire) AS "Nbre salaires renseignés",
    COUNT(tauxcom) AS "Nbre taux commissions renseignés"
FROM
    employe;