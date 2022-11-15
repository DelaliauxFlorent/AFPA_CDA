<?php

function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

/////////////////////////////////////
// Test pour demandePosition => OK
// Ajouté $this->creerTableau(); dans constructeur de Plateaux
// Changé return de caseExiste() pour refléter tableau taille 3 va de 0 à 2 et non 0 à 3
/*
$plateau=new Plateaux(["dimX"=>3, "dimY"=>3]);
echo $plateau."\n";
$case=$plateau->getTableau()[2][2];
$case->setContenu("x");
$reponsePosition=Affichages::demandePosition($plateau);
print_r($reponsePosition);
*/
//////////////////////////////////////
// Test pour demandeInfoJoueur

$infosJoueur=Affichages::demandeInfoJoueur();
print_r($infosJoueur);