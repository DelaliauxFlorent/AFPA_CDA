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
// echo "<br/><hr/><br/>";
//var_dump(PersonneManager::GetAllPersonnes());
// $individu = new Personnes($params2);
// echo $individu;
// //print_r($individu->getChamps());
// //PersonneManager::UpdatePersonne($individu);

// //PersonneManager::DeletePersonne(PersonneManager::GetPersonneById(7));
// echo "<br/><hr/><br/>";
$liste=PersonneManager::GetAllPersonnes();
if(is_array($liste)){
foreach ($liste as $key => $value) {
    echo $value."<br />";
}}else{
    echo $liste;
}
// echo "<br/><hr/><br/>";
// echo PersonneManager::GetPersonneById(3);

DbConnect::close();
