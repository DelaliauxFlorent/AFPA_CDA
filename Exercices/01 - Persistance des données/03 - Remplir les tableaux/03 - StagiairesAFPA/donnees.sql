INSERT INTO
    Hebergements (libelleHebergement)
VALUES
    ("AFPA"),
    ("AUTRE");

INSERT INTO
    Matieres (nomMatiere)
VALUES
    ("Sport"),
    ("Français"),
    ("Math");

INSERT INTO
    Groupes (libelleGroupe)
VALUES
    ("Informatique"),
    ("Automatisme"),
    ("Reseau");

INSERT INTO
    Formations (libelleFormation, idGroupe)
VALUES
    ("TSAII", 2),
    ("TRTE", 3),
    ("DWWM", 1),
    ("CDA", 1),
    ("TSSR", 3);

INSERT INTO
    Constitutions (idFormation, idMatiere)
VALUES
    (1, 1),
    (1, 3),
    (2, 2),
    (2, 1),
    (3, 3),
    (3, 2),
    (4, 1),
    (4, 2),
    (5, 2),
    (5, 3);

INSERT INTO
    Formateurs (nomFormateur, prenomFormateur)
VALUES
    ("Poix", "Martine"),
    ("Dubois", "Thomas"),
    ("Butterdroghe", "Hervé"),
    ("Batzic", "Jean Paul");

INSERT INTO
    Animations (idFormateur, idFormation)
VALUES
    (2, 5),
    (1, 3),
    (2, 2),
    (4, 5),
    (1, 4),
    (3, 1),
    (4, 3),
    (4, 2);

INSERT INTO
    Stagiaires (
        nomStagiaire,
        prenomStagiaire,
        adresseStagiaire,
        ville,
        codePostal,
        telStagiaire,
        dateEntree,
        genreStagiaire,
        dateNaissance,
        idFormation,
        idFormateur,
        idHebergement
    )
VALUES
    (
        "roblin",
        "lea",
        "12,bd de la liberte",
        "calais",
        62100,
        "21345678",
        "2014-09-01",
        "F",
        "1995-01-14",
        5,
        2,
        2
    ),
    (
        "macarthur",
        "leon",
        "121,bd gambetta",
        "calais",
        62100,
        "21-30-65-09",
        "2014-09-01",
        "M",
        "1994-04-12",
        3,
        1,
        2
    ),
    (
        "minol",
        "luc",
        "9,rue des prairies",
        "boulogne",
        62200,
        "21-30-20-10",
        "2014-09-01",
        "M",
        "1997-03-12",
        2,
        2,
        2
    ),
    (
        "minol",
        "sophie",
        "12,rue des capucines",
        "wimereux",
        62930,
        "21-89-04-30",
        "2014-09-01",
        "F",
        "1996-03-21",
        5,
        4,
        2
    ),
    (
        "minol",
        "marc",
        "67,allee ronde",
        "marcq",
        62300,
        "21-90-87-65",
        "2014-09-01",
        "M",
        "1993-02-05",
        3,
        1,
        2
    ),
    (
        "vendraux",
        "marc",
        "5,rue de marseille",
        "calais",
        62100,
        "21-96-00-09",
        "2013-09-01",
        "M",
        "1996-01-21",
        4,
        1,
        2
    ),
    (
        "vendermaele",
        "helene",
        "456,rue de paris",
        "boulogne",
        62200,
        "21-45-45-60",
        "2014-09-01",
        "F",
        "1995-03-30",
        5,
        2,
        2
    ),
    (
        "besson",
        "loic",
        "3,allee carpentier",
        "dunkerque",
        59300,
        "28-90-89-78",
        "2014-09-01",
        "M",
        "1994-05-21",
        1,
        3,
        1
    ),
    (
        "godart",
        "jean-paul",
        "123,rue de lens",
        "marck",
        59870,
        "28-09-87-65",
        "2013-09-01",
        "M",
        "1993-01-12",
        1,
        3,
        1
    ),
    (
        "beaux",
        "marie",
        "1,allee des cygnes",
        "dunkerque",
        59100,
        "21-30-87-90",
        "2014-09-01",
        "F",
        "1996-04-12",
        2,
        2,
        2
    ),
    (
        "turini",
        "elsa",
        "12,route de paris",
        "boulogne",
        62200,
        "21-32-47-97",
        "2014-09-01",
        "F",
        "1996-07-17",
        1,
        3,
        2
    ),
    (
        "torelle",
        "elise",
        "123,vallee du denacre",
        "boulogne",
        62200,
        "21-67-86-90",
        "2014-09-01",
        "F",
        "1997-04-16",
        3,
        1,
        1
    ),
    (
        "pharis",
        "pierre",
        "12,avenue foch",
        "calais",
        62100,
        "21-21-85-90",
        "2014-09-01",
        "M",
        "1996-03-18",
        4,
        1,
        1
    ),
    (
        "ephyre",
        "luc",
        "12,rue de lyon",
        "calais",
        62100,
        "21-35-32-90",
        "2014-09-01",
        "M",
        "1995-01-21",
        3,
        4,
        1
    ),
    (
        "leclercq",
        "jules",
        "12,allee des ravins",
        "boulogne",
        62200,
        "21-36-71-92",
        "2014-09-01",
        "M",
        "1994-05-19",
        3,
        1,
        2
    ),
    (
        "dupont",
        "luc",
        "21,avenue monsigny",
        "calais",
        62200,
        "21-21-34-99",
        "2014-09-01",
        "M",
        "1996-11-02",
        2,
        2,
        2
    ),
    (
        "marke",
        "loic",
        "312,route de paris",
        "wimereux",
        62930,
        "21-87-87-71",
        "2014-09-01",
        "M",
        "1996-11-12",
        5,
        4,
        1
    ),
    (
        "dewa",
        "leon",
        "121,allee des eglantines",
        "dunkerque",
        59100,
        "28-30-87-90",
        "2014-09-01",
        "M",
        "1997-04-03",
        2,
        4,
        1
    );

INSERT INTO
    Suivis (idStagiaire, idMatiere, note)
VALUES
    (1, 2, 10),
    (1, 3, 19),
    (11, 1, 12),
    (12, 3, 14),
    (3, 1, 12),
    (15, 2, 3),
    (8, 1, 8),
    (16, 2, 4),
    (14, 3, 7),
    (9, 1, 1);