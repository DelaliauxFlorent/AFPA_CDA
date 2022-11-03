<?php

function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

echo "création du client\n\t";
$client=new Clients(["nom"=>"Dupont", "prenom"=>"Paul", "compte"=> new Comptes(["numero"=>"50236R", "montant"=>120]), "livret"=>new livrets(["numero"=>"45789L", "montant"=>1200])]);
$client->affiche();

echo "le client reçoit 50€\n\t";
$client->recevoir(50);
$client->affiche();

echo "le client dépense 10€\n\t";
$client->depenser(10);
$client->affiche();

echo "le client épargne 100€\n\t";
$client->epargner(100);
$client->affiche();

echo "On applique les intérêts au livret\n\t";
$client->getLivret()->appliqueInteret();
$client->affiche();