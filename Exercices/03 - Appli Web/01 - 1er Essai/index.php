<?php

include "./PHP/CONTROLLER/Outils.php";
spl_autoload_register("ChargerClasse");

//on active la connexion à la base de données
Parametre::init();
DbConnect::init();

echo "<br/><hr/><br/>";
$params=["nom"=>"Toto", "prenom"=>"Tutu", "codePostal"=>null, "adresse"=>"sfjhbsb", "ville"=>"jdsfhjsegdjh"];
$params2=["id"=>7,"nom"=>"Toto", "prenom"=>"Tutu", "codePostal"=>99099, "adresse"=>"sfjhbsb", "ville"=>"jdsfhjsegdjh"];

//var_dump($individu);
echo "<br/><hr/><br/>";
//var_dump(PersonneManager::GetAllPersonnes());
$individu = new Personnes($params2);
//PersonneManager::UpdatePersonne($individu);

PersonneManager::DeletePersonne(PersonneManager::GetPersonneById(7));
echo "<br/><hr/><br/>";

var_dump(PersonneManager::GetAllPersonnes());
echo "<br/><hr/><br/>";
var_dump(PersonneManager::GetPersonneById(3));

DbConnect::close();
