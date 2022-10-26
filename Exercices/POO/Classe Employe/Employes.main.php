<?php

function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$dateEmbauche=new DateTime("2010-06-05");

$employe1= new Employes(["nom"=>"Doe", "prenom"=>"John", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>1.2, "service"=>"Cantine"]);

echo $employe1->anciennete();