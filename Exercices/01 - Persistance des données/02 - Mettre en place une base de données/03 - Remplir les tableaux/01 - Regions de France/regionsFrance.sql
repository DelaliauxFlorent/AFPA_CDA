DROP DATABASE IF EXISTS regionsFrance;

CREATE DATABASE regionsFrance DEFAULT CHARACTER SET utf8;

USE regionsFrance;

-- 
-- Table Regions
--
CREATE TABLE Regions(
    idRegion INT AUTO_INCREMENT PRIMARY KEY,
    numeroRegion INT NOT NULL,
    nomRegion VARCHAR(100) NOT NULL,
    nbDepartement INT
);

-- 
-- Table Departements
--
CREATE TABLE Departements(
    idDepartement INT AUTO_INCREMENT PRIMARY KEY,
    numeroDepartement VARCHAR(3),
    nomDepartement VARCHAR(100) NOT NULL,
    idRegion INT NOT NULL
);

ALTER TABLE
    Departements
ADD
    CONSTRAINT FK_Departements_Regions FOREIGN KEY(idRegion) REFERENCES Regions(idRegion);

INSERT INTO
    Regions (idRegion, numeroRegion, nomRegion)
VALUES
    (1, 1, "Auvergne-Rhône-Alpes"),
    (2, 2, "Bourgogne-Franche-Comté"),
    (3, 3, "Bretagne"),
    (4, 4, "Centre-Val de Loire"),
    (5, 5, "Corse"),
    (6, 6, "Grand-Est"),
    (7, 7, "Hauts-de-France"),
    (8, 8, "Ile-de-France"),
    (9, 9, "Normandie"),
    (10, 10, "Nouvelle-Aquitaine"),
    (11, 11, "Occitanie"),
    (12, 12, "Pays de la Loire"),
    (13, 13, "Provence-Alpes-Côte d'Azur"),
    (14, 14, "DOM-TOM");

INSERT INTO
    Departements (numeroDepartement, nomDepartement, idRegion)
VALUES
    ("1", "Ain", 1),
    ("2", "Aisne", 7),
    ("3", "Allier", 1),
    ("4", "Alpes-de-Haute-Provence", 13),
    ("5", "Hautes-Alpes", 13),
    ("6", "Alpes-Maritimes", 13),
    ("7", "Ardèche", 1),
    ("8", "Ardennes", 6),
    ("9", "Ariège", 11),
    ("10", "Aube", 6),
    ("11", "Aude", 11),
    ("12", "Aveyron", 11),
    ("13", "Bouches-du-Rhône", 13),
    ("14", "Calvados", 9),
    ("15", "Cantal", 1),
    ("16", "Charente", 10),
    ("17", "Charente-Maritime", 10),
    ("18", "Cher", 4),
    ("19", "Correze", 10),
    ("21", "Côte-d'Or", 2),
    ("22", "Côtes-d'Armor", 3),
    ("23", "Creuse", 10),
    ("24", "Dordogne", 10),
    ("25", "Doubs", 2),
    ("26", "Drôme", 1),
    ("27", "Eure", 9),
    ("28", "Eure-et-Loir", 4),
    ("29", "Finistère", 3),
    ("2A", "Corse-du-Sud", 5),
    ("2B", "Haute-Corse ", 5),
    ("30", "Gard", 11),
    ("31", "Haute-Garonne", 11),
    ("32", "Gers", 11),
    ("33", "Gironde", 10),
    ("34", "Hérault", 11),
    ("35", "Ille-et-Vilaine", 3),
    ("36", "Indre", 4),
    ("37", "Indre-et-Loire", 4),
    ("38", "Isère", 1),
    ("39", "Jura", 2),
    ("40", "Landes", 10),
    ("41", "Loir-et-Cher", 4),
    ("42", "Loire", 1),
    ("43", "Haute-Loire", 1),
    ("44", "Loire-Atlantique", 12),
    ("45", "Loiret", 4),
    ("46", "Lot", 11),
    ("47", "Lot-et-Garonne", 10),
    ("48", "Lozère", 11),
    ("49", "Maine-et-Loire", 12),
    ("50", "Manche", 9),
    ("51", "Marne", 6),
    ("52", "Haute-Marne", 6),
    ("53", "Mayenne", 12),
    ("54", "Meurthe-et-Moselle", 6),
    ("55", "Meuse", 6),
    ("56", "Morbihan", 3),
    ("57", "Moselle", 6),
    ("58", "Nièvre", 2),
    ("59", "Nord", 7),
    ("60", "Oise", 7),
    ("61", "Orne", 9),
    ("62", "Pas-de-Calais", 7),
    ("63", "Puy-de-Dôme", 1),
    ("64", "Pyrénées-Atlantiques", 10),
    ("65", "Hautes-Pyrénées", 11),
    ("66", "Pyrénées-Orientales", 11),
    ("67", "Bas-Rhin", 6),
    ("68", "Haut-Rhin", 6),
    ("69", "Rhône", 1),
    ("70", "Haute-Saône", 2),
    ("71", "Saône-et-Loire", 2),
    ("72", "Sarthe", 12),
    ("73", "Savoie", 1),
    ("74", "Haute-Savoie", 1),
    ("75", "Paris", 8),
    ("76", "Seine-Maritime", 9),
    ("77", "Seine-et-Marne", 8),
    ("78", "Yvelines", 8),
    ("79", "Deux-Sèvres", 10),
    ("80", "Somme", 7),
    ("81", "Tarn", 11),
    ("82", "Tarn-et-Garonne", 11),
    ("83", "Var", 13),
    ("84", "Vaucluse", 13),
    ("85", "Vendée", 12),
    ("86", "Vienne", 10),
    ("87", "Haute-Vienne", 10),
    ("88", "Vosges", 6),
    ("89", "Yonne", 2),
    ("90", "Territoire de Belfort", 2),
    ("91", "Essonne", 8),
    ("92", "Hauts-de-Seine", 8),
    ("93", "Seine-Saint-Denis", 8),
    ("94", "Val-de-Marne", 8),
    ("95", "Val-d'Oise", 8),
    ("971", "Guadeloupe", 14),
    ("972", "Martinique", 14),
    ("973", "Guyane", 14),
    ("974", "La Réunion", 14),
    ("975", "Saint-Pierre-et-Miquelon", 14),
    ("976", "Mayotte", 14),
    ("977", "Saint-Barthélemy", 14),
    ("978", "Saint-Martin", 14),
    (
        "984",
        "Terres australes et antarctiques françaises",
        14
    ),
    ("986", "Wallis-et-Futuna", 14),
    ("987", "Polynésie française", 14),
    ("988", "Nouvelle-Calédonie", 14),
    ("989", "Clipperton", 14);