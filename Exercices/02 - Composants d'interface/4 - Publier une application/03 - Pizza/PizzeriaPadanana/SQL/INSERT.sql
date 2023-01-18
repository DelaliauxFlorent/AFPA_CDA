USE PizzaPadananas;
--
-- Table TypeAccompagnements
--
INSERT INTO typeaccompagnements (nomTypeAccompagnement)
VALUES
('Boissons'),
('Desserts');

--
-- Table Accompagnements
--
INSERT INTO accompagnements (nomAccompagnement, prixAccompagnement, mesureAccompagnement, imageAccompagnement, idTypeAccompagnement)
VALUES
('Coca Cola', 1.5, 0.33, './img/boissons/cocacola.png', 1),
('Fanta', 1.5, 0.33, './img/boissons/fanta.png', 1),
('Eau', 0.5, 0.25, './img/boissons/eau.png', 1),

('Tiramisu', 0.5, 0.1, './img/desserts/tiramisu.png', 2),
('Mousse au chocolat', 0.5, 0.12, './img/desserts/mousseauchocolat.png', 2),
('Compote', 0.5, 0.8, './img/desserts/compote.png', 2);

--
-- Table Adresses
--
INSERT INTO adresses (Adresse, complementAdresse, cdPost, Ville, idCompte)
VALUES
('50 avenue des lilas', NULL, 59000, 'Lille', 1),
('14 rue Jean Jaurès', NULL, 59200, 'Tourcoing', 2),
('64 rue Pasteur', NULL, 59000, 'Lille', 3),
('29 avenue Michel Leeb', NULL, 59000, 'Lille', 4);

--
-- Table Commandes
--
INSERT INTO commandes (idCommande, numCommande, dateCommande, payementCommande, idSeuilFidelite, idCompte, idStatut)
VALUES
(NULL, 'TestCommandeEnCours', CURRENT_TIMESTAMP, '0', 1, '3', 1),
(NULL, 'TestCommandePassée', CURRENT_TIMESTAMP, 1, '2', '4', '2');

--
-- Table Comptes
--
INSERT INTO comptes (identifiant, mdp, nom, prenom, niveauFidelite, idRole)
VALUES
('mario.padanana@gmail.com', 'noanana487', 'Padanana', 'Mario', 0, 3),
('luigi.padanana@gmail.com', 'abaléanana123', 'Padanana', 'Luigi', 0, 2),
('darksasuke@gmail.com', 'jesuistropdark666', 'Dupont', 'Timothée', 10, 1),
('michel.berger@gmail.com', 'dommagepasdanana707', 'Berger', 'Michel', 0, 1);

--
-- Table TypeAccompagnement
--
INSERT INTO typeingredients (nomTypeIngredient, prixTypeIngredient)
VALUES
('Legumes', 0.5),
('Fromages', 0.7),
('Viandes', 1);

--
-- Table Ingrédients
--
INSERT INTO ingredients (nomIngredient, imageIngredient, idTypeIngredient)
VALUES
('Poivron', './img/ingredients/legumes/poivron.png', 1),
('Oignon rouge', './img/ingredients/legumes/oignonrouge.png', 1),
('Champignon', './img/ingredients/legumes/champignon.png', 1),

('Mozzarella', './img/ingredients/legumes/mozzarella.png', 2),
('Cheddar', './img/ingredients/legumes/cheddar.png', 2),

('Chorizo', './img/ingredients/legumes/chorizo.png', 3),
('Boeuf hachée', './img/ingredients/legumes/boeufhachee.png', 3);

--
-- Table Menus
--
INSERT INTO menus (nomMenu, reductionMenu, imageMenu, idTaillePizza)
VALUES
('2 personnes', 10, './img/menus/2personnes.png', 2),
('1 personne', 5, './img/menus/1personne.png', 1);

--
-- Table Roles
--
INSERT INTO roles (nomRole, niveauAcreditation)
VALUES
('Administrateur', 3),
('Employe', 2),
('Client', 1);

--
-- Table SeuilFidelites
--
INSERT INTO seuilfidelites (maxSeuil, montantFidelite)
VALUES
(10, 0),
(20, 10),
(30, 25),
(40, 40),
(50, 60);

--
-- Table Status
--
INSERT INTO statuts (nomStatut)
VALUES
('Non validée'),
('En attente'),
('En préparation'),
('En cours de livraison'),
('livrée');

--
-- Table TaillePizzas
--
INSERT INTO taillepizzas (valeurTaillePizza, multiplicateurPrixPizza)
VALUES
('Petite', 1),
('Moyenne', 1.5),
('Grande', 2);

--
-- Table TypePizza
--
INSERT INTO typepizzas (nomTypePizza, prixBaseTypePizza, imagePizza)
VALUES
('Pizza1', 5, './img/pizzas/pizza1.png'),
('Pizza2', 6, './img/pizzas/pizza2.png'),
('Pizza3', 7, './img/pizzas/pizza3.png'),
('Pizza4', 6, './img/pizzas/pizza4.png');
