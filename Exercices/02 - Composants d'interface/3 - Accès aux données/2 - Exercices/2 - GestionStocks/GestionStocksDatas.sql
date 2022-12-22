USE GestionStocks;

INSERT INTO TypesProduits (LibelleTypeProduit) VALUES ("TypeProduit1");
INSERT INTO TypesProduits (LibelleTypeProduit) VALUES ("TypeProduit2");
INSERT INTO TypesProduits (LibelleTypeProduit) VALUES ("TypeProduit3");
INSERT INTO TypesProduits (LibelleTypeProduit) VALUES ("TypeProduit4");
INSERT INTO TypesProduits (LibelleTypeProduit) VALUES ("TypeProduit5");
INSERT INTO TypesProduits (LibelleTypeProduit) VALUES ("TypeProduit6");
INSERT INTO TypesProduits (LibelleTypeProduit) VALUES ("TypeProduit7");

INSERT INTO Categories (LibelleCategorie, IdTypeProduit) VALUES ("Categorie1", 6);
INSERT INTO Categories (LibelleCategorie, IdTypeProduit) VALUES ("Categorie2", 3);
INSERT INTO Categories (LibelleCategorie, IdTypeProduit) VALUES ("Categorie3", 3);
INSERT INTO Categories (LibelleCategorie, IdTypeProduit) VALUES ("Categorie4", 3);
INSERT INTO Categories (LibelleCategorie, IdTypeProduit) VALUES ("Categorie5", 5);
INSERT INTO Categories (LibelleCategorie, IdTypeProduit) VALUES ("Categorie6", 4);
INSERT INTO Categories (LibelleCategorie, IdTypeProduit) VALUES ("Categorie7", 1);

INSERT INTO Articles (LibelleArticle, QuantiteStockee, IdCategorie) VALUES ("Article1", 10, 3);
INSERT INTO Articles (LibelleArticle, QuantiteStockee, IdCategorie) VALUES ("Article2", 11, 3);
INSERT INTO Articles (LibelleArticle, QuantiteStockee, IdCategorie) VALUES ("Article3", 12, 7);
INSERT INTO Articles (LibelleArticle, QuantiteStockee, IdCategorie) VALUES ("Article4", 13, 7);
INSERT INTO Articles (LibelleArticle, QuantiteStockee, IdCategorie) VALUES ("Article5", 14, 4);
INSERT INTO Articles (LibelleArticle, QuantiteStockee, IdCategorie) VALUES ("Article6", 15, 7);
INSERT INTO Articles (LibelleArticle, QuantiteStockee, IdCategorie) VALUES ("Article7", 16, 6);
