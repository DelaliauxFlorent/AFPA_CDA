<?php

function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$dateEmbauche=new DateTime("2010-06-05");

$employe[0]= new Employes(["nom"=>"Doe", "prenom"=>"John", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>12, "service"=>"Cantine"]);
$employe[1]= new Employes(["nom"=>"Martin", "prenom"=>"Jacques", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>22, "service"=>"Cantine"]);
$employe[2]= new Employes(["nom"=>"Bond", "prenom"=>"James", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>52, "service"=>"Cantine"]);
$employe[3]= new Employes(["nom"=>"Gear", "prenom"=>"Richard", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>90, "service"=>"Cantine"]);
$employe[4]= new Employes(["nom"=>"Pagnol", "prenom"=>"Marcel", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>5, "service"=>"Cantine"]);

foreach($employe as $emp){
    $emp->payerPrime();echo "\n";
    //var_dump($emp);
}
