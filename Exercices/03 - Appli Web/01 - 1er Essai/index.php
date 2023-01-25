<?php

include "./PHP/CONTROLLER/Outils.php";
spl_autoload_register("ChargerClasse");

//on active la connexion à la base de données
Parametre::init();
DbConnect::init();

echo "<br/><hr/><br/>";
$params=["nom"=>"Toto", "prenom"=>"Tutu", "codePostal"=>null, "adresse"=>"sfjhbsb", "ville"=>"jdsfhjsegdjh"];
$individu= new Personnes($params);
var_dump(PersonneManager::AddPersonne($individu));
echo "<br/><hr/><br/>";
var_dump(PersonneManager::GetAllPersonnes());
// echo "<br/><hr/><br/>";
// var_dump(PersonneManager::GetPersonneById(3));

DbConnect::close();
