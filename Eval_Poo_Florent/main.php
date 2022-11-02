<?php

function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

echo "création du client\n\t";
$client=new Clients(["nom"=>"Dupont", "prenom"=>"Paul", "compte"=> new Comptes(["numero"=>"50236R", "montant"=>120]), "livret"=>new livrets(["numero"=>"45789L", "montant"=>1200])]);
echo $client;

echo "le client reçoit 50€\n\t";
$client->recevoir(50);
echo $client;

echo "le client dépense 10€\n\t";
$client->depenser(10);
echo $client;

echo "le client épargne 100€\n\t";
$client->epargner(100);
echo $client;

echo "On applique les intérêts au livret\n\t";
$client->getLivret()->appliqueInteret();
echo $client;