-- Un module de gestion des commandes réservé au service commercial :
--  Créer une nouvelle commande
--  Ajouter des produits dans la commande
--  Connaître l’état de la commande (saisie, annulée, en préparation, expédiée, facturée, retard de paiement, soldée)
--  Consulter les clients en retard de paiement à une date donnée
--  Modifier ou annuler la commande avant qu’elle ne soit en préparation
--  Les commandes seront saisies par le biais d’une interface accessible par internet
CREATE USER 'Commercial' @'%' IDENTIFIED WITH mysql_native_password AS '***';

GRANT USAGE ON *.* TO 'Commercial' @'%' REQUIRE NONE WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;

CREATE DATABASE IF NOT EXISTS `Commercial`;

GRANT ALL PRIVILEGES ON `Commercial`.* TO 'Commercial' @'%';

--
-- Table `commandes`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`commandes`
FROM
    'Commercial' @'%';

GRANT
SELECT
,
INSERT
,
UPDATE
    ON `villagegreenv2`.`commandes` TO 'Commercial' @'%';

--
-- Table `etatscommande`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`etatscommande`
FROM
    'Commercial' @'%';

GRANT
SELECT
,
UPDATE
    ON `villagegreenv2`.`etatscommande` TO 'Commercial' @'%';

--
-- Table `histoetatcom`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`histoetatcom`
FROM
    'Commercial' @'%';

GRANT
SELECT
    ON `villagegreenv2`.`histoetatcom` TO 'Commercial' @'%';

--
-- Table `lignescommande`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`lignescommande`
FROM
    'Commercial' @'%';

GRANT
SELECT
,
INSERT
,
UPDATE
    ON `villagegreenv2`.`lignescommande` TO 'Commercial' @'%';

--
-- Table `reglements`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`reglements`
FROM
    'Commercial' @'%';

GRANT
SELECT
    ON `villagegreenv2`.`reglements` TO 'Commercial' @'%';

--
-- Table `paiements`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`paiements`
FROM
    'Commercial' @'%';

GRANT
SELECT
    ON `villagegreenv2`.`paiements` TO 'Commercial' @'%';

--
-- Table `clients`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`clients`
FROM
    'Commercial' @'%';

GRANT
SELECT
    ON `villagegreenv2`.`clients` TO 'Commercial' @'%';

--
-- Table `adresses`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`adresses`
FROM
    'Commercial' @'%';

GRANT
SELECT
    ON `villagegreenv2`.`adresses` TO 'Commercial' @'%';

-- Un module de gestion des produits réservé au service de gestion des produits doit permettre :
--  D’ajouter des produits
--  D’en supprimer
--  D’en modifier les caractéristiques (libellé, caractéristique, tarif)
CREATE USER 'Gestion' @'%' IDENTIFIED WITH mysql_native_password AS '***';

GRANT USAGE ON *.* TO 'Gestion' @'%' REQUIRE NONE WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;

CREATE DATABASE IF NOT EXISTS `Gestion`;

GRANT ALL PRIVILEGES ON `Gestion`.* TO 'Gestion' @'%';

--
-- Table `produits`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`produits`
FROM
    'Gestion' @'%';

GRANT
SELECT
,
INSERT
,
UPDATE
,
    DELETE ON `villagegreenv2`.`produits` TO 'Gestion' @'%';

--
-- Table `approvisions`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`approvisions`
FROM
    'Gestion' @'%';

GRANT
SELECT
    ON `villagegreenv2`.`approvisions` TO 'Gestion' @'%';

--
-- Table `fournisseurs`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`fournisseurs`
FROM
    'Gestion' @'%';

GRANT
SELECT
    ON `villagegreenv2`.`fournisseurs` TO 'Gestion' @'%';

--
-- Table `applicationstva`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`applicationstva`
FROM
    'Gestion' @'%';

GRANT
SELECT
    ON `villagegreenv2`.`applicationstva` TO 'Gestion' @'%';

--
-- Table `tvas`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`tvas`
FROM
    'Gestion' @'%';

GRANT
SELECT
    ON `villagegreenv2`.`tvas` TO 'Gestion' @'%';

--
-- Table `rubriques`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`rubriques`
FROM
    'Gestion' @'%';

GRANT
SELECT
    ON `villagegreenv2`.`rubriques` TO 'Gestion' @'%';

-- Un module d'e-commerce pour les clients permettant :
--  Consulter le catalogue
--  De saisir de nouvelles commandes
--  De visualiser les anciennes commandes
CREATE USER 'Client' @'%' IDENTIFIED WITH mysql_native_password AS '***';

GRANT USAGE ON *.* TO 'Client' @'%' REQUIRE NONE WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;

CREATE DATABASE IF NOT EXISTS `Client`;

GRANT ALL PRIVILEGES ON `Client`.* TO 'Client' @'%';

--
--  Table `clients`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`clients` FROM 'Client' @'%';
GRANT SELECT ON `villagegreenv2`.`clients` TO 'Client'@'%';

--
--  Table `produits`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`produits` FROM 'Client' @'%';
GRANT SELECT ON `villagegreenv2`.`produits` TO 'Client'@'%';

--
--  Table `lignescommande`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`lignescommande` FROM 'Client' @'%';
GRANT SELECT, INSERT ON `villagegreenv2`.`lignescommande` TO 'Client'@'%';

--
--  Table `villes`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`villes` FROM 'Client' @'%';
GRANT SELECT ON `villagegreenv2`.`villes` TO 'Client'@'%';

--
--  Table `commandes`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`commandes` FROM 'Client' @'%';
GRANT SELECT, INSERT ON `villagegreenv2`.`commandes` TO 'Client'@'%';

--
--  Table `adresses`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`adresses` FROM 'Client' @'%';
GRANT SELECT, UPDATE (idVille, emailAdresse, adresse, telFixe, complementAdresse, telMobile, province) ON `villagegreenv2`.`adresses` TO 'Client'@'%';

--
--  Table `rubriques`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`rubriques` FROM 'Client' @'%';
GRANT SELECT ON `villagegreenv2`.`rubriques` TO 'Client'@'%';

--
--  Table `pays`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`pays` FROM 'Client' @'%';
GRANT SELECT, UPDATE (nomPays) ON `villagegreenv2`.`pays` TO 'Client'@'%';

--
--  Table `livraisons`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`livraisons` FROM 'Client' @'%';
GRANT SELECT ON `villagegreenv2`.`livraisons` TO 'Client'@'%';

--
--  Table `etatscommande`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`etatscommande` FROM 'Client' @'%';
GRANT SELECT ON `villagegreenv2`.`etatscommande` TO 'Client'@'%';

--
--  Table `histoetatcom`
--
REVOKE ALL PRIVILEGES ON `villagegreenv2`.`histoetatcom` FROM 'Client' @'%';
GRANT SELECT ON `villagegreenv2`.`histoetatcom` TO 'Client'@'%';