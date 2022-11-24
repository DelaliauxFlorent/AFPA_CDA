-- A) Les noms des étudiants nés avant l'étudiant « JULES LECLERCQ »
SELECT
    CONCAT(nomEtudiant, " ", prenomEtudiant) AS Nom
FROM
    etudiants
WHERE
    dateNaissanceEtudiant <(
        SELECT
            dateNaissanceEtudiant
        FROM
            etudiants
        WHERE
            prenomEtudiant = "JULES"
            AND nomEtudiant = "LECLERCQ"
    );

-- B) Les noms et notes des étudiants qui ont,à l'épreuve 4, une note supérieure à la moyenne de cette épreuve.
SELECT
    CONCAT(et.nomEtudiant, " ", et.prenomEtudiant) AS Nom,
    av.note AS "Note de l'épreuve 4"
FROM
    avoir_note AS av
    INNER JOIN etudiants AS et ON av.idEtudiant = et.idEtudiant
WHERE
    idEpreuve = 4
    AND av.note >(
        SELECT
            AVG(note)
        FROM
            avoir_note
        WHERE
            idEpreuve = 4
    );

-- C) Le nom des étudiants qui ont obtenu un 12 ou plus.
SELECT
    CONCAT(et.nomEtudiant, " ", et.prenomEtudiant) AS Nom
FROM
    avoir_note AS av
    INNER JOIN etudiants AS et ON av.idEtudiant = et.idEtudiant
WHERE
    av.note >= 12
    AND av.idEpreuve = 4;

-- D) Le nom des étudiants qui ont dans l'épreuve 4 une note supérieure à celle obtenue par « LUC DUPONT »(à cette même épreuve).
SELECT
    CONCAT(et.nomEtudiant, " ", et.prenomEtudiant) AS Nom
FROM
    avoir_note AS av
    INNER JOIN etudiants AS et ON av.idEtudiant = et.idEtudiant
WHERE
    av.idEpreuve = 4
    AND av.note >(
        SELECT
            av2.note
        FROM
            avoir_note AS av2
            INNER JOIN etudiants AS et2 ON av2.idEtudiant = et2.idEtudiant
        WHERE
            av2.idEpreuve = 4
            AND et2.prenomEtudiant = "LUC"
            AND et2.nomEtudiant = "DUPONT"
    );

-- E) Le nom des étudiants qui partagent une ou plusieurs notes avec « LUC DUPONT ».
SELECT
    DISTINCT CONCAT(et.nomEtudiant, " ", et.prenomEtudiant) AS Nom
FROM
    avoir_note AS av
    INNER JOIN etudiants AS et ON av.idEtudiant = et.idEtudiant
WHERE
    av.note IN (
        SELECT
            av2.note
        FROM
            avoir_note AS av2
            INNER JOIN etudiants AS et2 ON av2.idEtudiant = et2.idEtudiant
        WHERE
            et2.prenomEtudiant = "LUC"
            AND et2.nomEtudiant = "DUPONT"
    );

-- F) Ajoutez une colonne HOBBY à la table ETUDIANT. Cette colonne est de type chaine sur 20 caractères.
-- Par défaut le HOBBY est mis à SPORT. 
ALTER TABLE
    etudiants
ADD
    COLUMN hobby VARCHAR(20) DEFAULT "SPORT";

-- G) Ajouter à la table ETUDIANT une colonne NEWCOL de type INTEGER (vérifier en affichant la structure de la table) puis la supprimer (vérifier de nouveau la suppression).
ALTER TABLE
    etudiants
ADD
    COLUMN NEWCOL INT;

ALTER TABLE
    etudiants DROP COLUMN NEWCOL;

-- H) Vérifiez que PREnomEtudiant peut ne pas avoir de contenu puis indiquez que la colonne PREnomEtudiant doit obligatoirement avoir une valeur. Vérifiez sur la description de la table.
-- Check nullable
SELECT
    IS_NULLABLE
FROM
    INFORMATION_SCHEMA.COLUMNS
WHERE
    TABLE_SCHEMA = 'exercice3'
    AND TABLE_NAME = 'etudiants'
    AND COLUMN_NAME = 'prenomEtudiant';

-- Passer à NotNull
ALTER TABLE
    etudiants
MODIFY
    prenomEtudiant varchar(20) NOT NULL;

-- I) Insérez les enregistrements suivants: 7, 'interro écrite',9,1,'21-oct-96',1 dans EPREUVE 
INSERT INTO
    epreuves (
        idEpreuve,
        libelleEpreuve,
        idEnseignantEpreuve,
        idMatiereEpreuve,
        dateEpreuve,
        CoefficientEpreuve
    )
VALUES
    (
        7,
        'interro écrite',
        9,
        1,
        STR_TO_DATE('21-oct-96', '%d-%b-%y'),
        1
    );

-- 1,7,10
-- 2,7,08
-- 3,7,05
-- 4,7,09 
-- 17,3,15 dans AVOIR_NOTE
INSERT INTO
    avoir_note (idEtudiant, idEpreuve, note)
VALUES
    (1, 7, 10),
    (2, 7, 08),
    (3, 7, 05),
    (4, 7, 09),
    (17, 3, 15);

-- J) Changez la note de n°3 dans l'épreuve7, elle passe à 07. Vérifiez les valeurs avant et après la requête.
SELECT
    note
FROM
    avoir_note
WHERE
    idEtudiant = 3
    AND idEpreuve = 7;

UPDATE
    avoir_note
SET
    note = 7
WHERE
    idEtudiant = 3
    AND idEpreuve = 7;

SELECT
    note
FROM
    avoir_note
WHERE
    idEtudiant = 3
    AND idEpreuve = 7;

-- K) N°1 a mis de la bonne volonté, on augmente sa note dans l'épreuve 7 de 1 point. Vérifiez.
SELECT
    note
FROM
    avoir_note
WHERE
    idEtudiant = 1
    AND idEpreuve = 7;

UPDATE
    avoir_note
SET
    note = note + 1
WHERE
    idEtudiant = 1
    AND idEpreuve = 7;

SELECT
    note
FROM
    avoir_note
WHERE
    idEtudiant = 1
    AND idEpreuve = 7;

-- L) Détruisez l'épreuve 7 qui a été annulée pour cause de tricherie et les notes qui lui correspondent. Vérifiez.
DELETE FROM
    avoir_note
WHERE
    idEpreuve = 7;

DELETE FROM
    epreuves
WHERE
    idEpreuve = 7;

-- M) Réflexion : N'y aurait-il pas eu moyen de détruire les notes de l'épreuve automatiquement dès la destruction de l'épreuve ?
-- Ajouter "ON DELETE CASCADE" pour la clé étrangère idEpreuve dans avoir_note
-- passer de 
--    ALTER TABLE `avoir_note`
--    ADD CONSTRAINT `FK_AvoirNote_Epreuves` FOREIGN KEY (`idEpreuve`) REFERENCES `epreuves` (`idEpreuve`),
--    ADD CONSTRAINT `FK_AvoirNote_Etudiants` FOREIGN KEY (`idEtudiant`) REFERENCES `etudiants` (`idEtudiant`);
-- à
ALTER TABLE
    avoir_note DROP FOREIGN KEY FK_AvoirNote_Epreuves;

ALTER TABLE
    avoir_note
ADD
    CONSTRAINT FK_AvoirNote_Epreuves FOREIGN KEY (idEpreuve) REFERENCES epreuves (idEpreuve) ON DELETE CASCADE;

-- N) Changez toutes les notes de MARKE dans la matière « BASES DE DONNEES ». Suite à un mauvais comportement, elles diminuent toutes de 3 points. Attention, la requête doit intégrer le nom de la matière. (et non chercher à repérer le numéro avant de la taper.)
UPDATE
    avoir_note AS av
    INNER JOIN etudiants AS et ON av.idEtudiant = et.idEtudiant
    INNER JOIN epreuves AS ep ON av.idEpreuve = ep.idEpreuve
    INNER JOIN matieres as ma ON ep.idMatiereEpreuve = ma.idMatiere
SET
    note = note - 3
WHERE
    et.nomEtudiant = "MARKE" -- pas de ligne « BASES DE DONNEES » dans matieres, seulement "BD"
    AND ma.nomMatiere = "BD";

-- VERSION moins gourmande
UPDATE
    avoir_note
SET
    note = note - 3
WHERE
    idEpreuve IN (
        SELECT
            ep.idEpreuve
        FROM
            epreuves AS ep
            INNER JOIN matieres AS m ON (ep.idMatiereEpreuve = m.idMatiere)
        WHERE
            m.nomMatiere = 'BD'
    )
    AND idEtudiant = (
        SELECT
            idEtudiant
        FROM
            etudiants
        WHERE
            nomEtudiant = 'marke'
    );

-- O) DEWA a manqué l'épreuve 4. Vu son niveau, on décide de lui créer une entrée dans AVOIR_NOTE en lui attribuant la moyenne des notes obtenues à cette épreuve par ses collègues*0.9. Attention, la requête doit intégrer le nom de l'étudiant (et non chercher à repérer le numéro avant de la taper.)
INSERT INTO
    avoir_note AS av (idEtudiant, idEpreuve, note)
VALUES
    (
        (
            SELECT
                idEtudiant
            FROM
                etudiants
            WHERE
                nomEtudiant = "DEWA";

),
4,
(
    SELECT
        AVG(note) * 0.9
    FROM
        avoir_note
    WHERE
        idEpreuve = 4
)
);

-- Version avec transaction
START TRANSACTION;

SELECT
    @newNote := ROUND(AVG(note), 2) * 0.9
FROM
    Avoir_note
WHERE
    idEpreuve = 4;

SELECT
    @newID := idEtudiant
FROM
    Etudiants
WHERE
    UPPER(nomEtudiant) = "DEWA";

INSERT INTO
    Avoir_note (idEtudiant, idEpreuve, note)
VALUES
    (@newID, 4, @newNote);

COMMIT;

-- P) Insérez un nouvel étudiant dont vous ne connaissez que le numéro, le nom, le prénom, le hobby et l'année: 25, 'DARTE','REMY','SCULPTURE',1.
INSERT INTO
    etudiants (
        idEtudiant,
        nomEtudiant,
        prenomEtudiant,
        hobby,
        anneeEtudiant
    )
VALUES
    (25, 'DARTE', 'REMY', 'SCULPTURE', 1);

--
-- Création de VUES
--
-- VUE regroupant etudiants, avoir_note et epreuves quand relation entre elles
CREATE VIEW VW_Etudiants_Epreuves AS
SELECT
    et.idEtudiant,
    nomEtudiant,
    prenomEtudiant,
    adresseEtudiant,
    villeEtudiant,
    codePostalEtudiant,
    telephoneEtudiant,
    dateEntreeEtudiant,
    anneeEtudiant,
    remarqueEtudiant,
    sexeEtudiant,
    dateNaissanceEtudiant,
    hobby,
    idAvoirNote,
    note,
    libelleEpreuve,
    idEnseignantEpreuve,
    idMatiereEpreuve,
    dateEpreuve,
    CoefficientEpreuve,
    anneeEpreuve
FROM
    etudiants AS et
    INNER JOIN avoir_note AS av ON av.idEtudiant = et.idEtudiant
    INNER JOIN epreuves AS ep ON av.idEpreuve = ep.idEpreuve;
--------------------------------------
--------------------------------------
-- #1221 - Incorrect usage of UPDATE and LIMIT?
--------------------------------------
--------------------------------------


-- VUE regroupant TOUS etudiants, avoir_note et epreuves 
CREATE VIEW VW_L_Etudiants_L_Epreuves_ AS
SELECT
    et.idEtudiant,
    nomEtudiant,
    prenomEtudiant,
    adresseEtudiant,
    villeEtudiant,
    codePostalEtudiant,
    telephoneEtudiant,
    dateEntreeEtudiant,
    anneeEtudiant,
    remarqueEtudiant,
    sexeEtudiant,
    dateNaissanceEtudiant,
    hobby,
    idAvoirNote,
    note,
    libelleEpreuve,
    idEnseignantEpreuve,
    idMatiereEpreuve,
    dateEpreuve,
    CoefficientEpreuve,
    anneeEpreuve
FROM
    etudiants AS et
    LEFT JOIN avoir_note AS av ON av.idEtudiant = et.idEtudiant
    LEFT JOIN epreuves AS ep ON av.idEpreuve = ep.idEpreuve
ORDER BY
    et.idEtudiant;

--------------------------------------
--------------------------------------
-- #1288 - The target table vw_l_etudiants_l_epreuves_ of the UPDATE is not updatable
--------------------------------------
--------------------------------------

-- Retour sur précédent exercices
-- N
UPDATE
    VW_Etudiants_Epreuves
SET
    note = note - 3
WHERE
    nomEtudiant = "MARKE"
    AND nomMatiere = "BD";
    