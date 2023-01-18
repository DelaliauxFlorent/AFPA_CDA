USE PizzaPadananas;
ALTER TABLE Menus ADD CONSTRAINT FK_Menus_TaillePizzas
FOREIGN KEY(idTaillePizza) REFERENCES TaillePizzas(idTaillePizza);

ALTER TABLE Pizzas ADD CONSTRAINT FK_Pizzas_TaillePizzas FOREIGN KEY(idTaillePizza) REFERENCES TaillePizzas(idTaillePizza);

ALTER TABLE Pizzas ADD CONSTRAINT FK_Pizzas_TypePizzas FOREIGN KEY(idTypePizza) REFERENCES TypePizzas(idTypePizza);

ALTER TABLE Accompagnements ADD CONSTRAINT FK_Accompagnements_TypeAccompagnements FOREIGN KEY(idTypeAccompagnement) REFERENCES TypeAccompagnements(idTypeAccompagnement);

--
-- Table Comptes
--
ALTER TABLE Comptes ADD CONSTRAINT FK_Comptes_Roles FOREIGN KEY(idRole) REFERENCES Roles(idRole);

ALTER TABLE Adresses ADD CONSTRAINT FK_Adresses_Comptes FOREIGN KEY(idCompte) REFERENCES Comptes(idCompte);

ALTER TABLE Commandes ADD CONSTRAINT FK_Commandes_SeuilFidelites FOREIGN KEY(idSeuilFidelite) REFERENCES SeuilFidelites(idSeuilFidelite);

ALTER TABLE Commandes ADD CONSTRAINT FK_Commandes_Comptes FOREIGN KEY(idCompte) REFERENCES Comptes(idCompte);

ALTER TABLE Commandes ADD CONSTRAINT FK_Commandes_Statuts FOREIGN KEY(idStatut) REFERENCES Statuts(idStatut);

ALTER TABLE Compositions ADD CONSTRAINT FK_Compositions_TypePizzas FOREIGN KEY(idTypePizza) REFERENCES TypePizzas(idTypePizza);

ALTER TABLE Compositions ADD CONSTRAINT FK_Compositions_Ingredients FOREIGN KEY(idIngredient) REFERENCES Ingredients(idIngredient);

--
-- Table LignesCommandes
--

ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_Accompagnements FOREIGN KEY(idAccompagnement) REFERENCES Accompagnements(idAccompagnement);

ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_Menus FOREIGN KEY(idMenu) REFERENCES Menus(idMenu);

ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_Commandes FOREIGN KEY(idCommande) REFERENCES Commandes(idCommande);

ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_Pizzas FOREIGN KEY(idPizza) REFERENCES Pizzas(idPizza);

--
-- Table ItemsMenus
--
ALTER TABLE ItemsMenus ADD CONSTRAINT FK_ItemsMenus_TypePizzas FOREIGN KEY(idTypePizza) REFERENCES TypePizzas(idTypePizza);

ALTER TABLE ItemsMenus ADD CONSTRAINT FK_ItemsMenus_Accompagnements FOREIGN KEY(idAccompagnement) REFERENCES Accompagnements(idAccompagnement);

ALTER TABLE ItemsMenus ADD CONSTRAINT FK_ItemsMenus_Menus FOREIGN KEY(idMenu) REFERENCES Menus(idMenu);

ALTER TABLE Ingredients ADD CONSTRAINT FK_Ingredients_TypeIngredients FOREIGN KEY (idTypeIngredient) REFERENCES typeingredients(idTypeIngredient);