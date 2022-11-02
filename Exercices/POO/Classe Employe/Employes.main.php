<?php

function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$agence[]=new Agences(["nomAgence"=>"SNCF", "adresse"=>"QQpart en france", "codePostal"=>"93000", "ville"=>"Paris", "restau"=>true]);
$agence[]=new Agences(["nomAgence"=>"EDF", "adresse"=>"QQpart en france", "codePostal"=>"93000", "ville"=>"Paris", "restau"=>false]);

$enfants[]=new Enfants(["prenom"=>"Damien", ]);

$employe[]= new Employes(["nom"=>"Doe", "prenom"=>"John", "dateEmbauche"=>new DateTime("2017-10-05"), "poste"=>"Chef", "salaire"=>12, "service"=>"Cantine", "agence"=> $agence[0]]);
$employe[]= new Employes(["nom"=>"Martin", "prenom"=>"Jacques", "dateEmbauche"=>new DateTime("2007-11-15"), "poste"=>"Chef", "salaire"=>22, "service"=>"Garage", "agence"=> $agence[1]]);
$employe[]= new Employes(["nom"=>"Bond", "prenom"=>"James", "dateEmbauche"=>new DateTime("2015-05-05"), "poste"=>"Chef", "salaire"=>52, "service"=>"Accueil", "agence"=> $agence[0]]);
$employe[]= new Employes(["nom"=>"Gear", "prenom"=>"Richard", "dateEmbauche"=>new DateTime("2022-10-05"), "poste"=>"Chef", "salaire"=>90, "service"=>"Cantine", "agence"=> $agence[1]]);
$employe[]= new Employes(["nom"=>"Bond", "prenom"=>"Alfred", "dateEmbauche"=>new DateTime("2010-10-05"), "poste"=>"Chef", "salaire"=>30, "service"=>"Cantine", "agence"=> $agence[0]]);

/////////////
// Modif pour test

$employe[2]->getAgence()->setRestau(false);

echo "L'entreprise possède ".count($employe)." employé(s).\n";

$employeTriNP=$employeTriSNP=$employe;
usort($employeTriNP, "Employes::compareToNP");
usort($employeTriSNP, "Employes::compareToSNP");

foreach($employe as $emp){
    //$emp->payerPrime();
    echo $emp;
    echo "Moyen de restauration: ".$emp->getAgence()->modeRestau()."\n";
    //"\t- Prime: \t".number_format($emp->calculPrime()*1000,2,",", " ")."\n\n";
}
/*
echo "Trie du tableau par Nom -> Prénom\n\n";

foreach($employeTriNP as $emp){
    echo $emp;
}

echo "Trie du tableau par Service -> Nom -> Prénom\n\n";

foreach($employeTriSNP as $emp){
    echo $emp;
}*/

$masseSalarial=0;
foreach ($employe as $emp) {
    $masseSalarial+=$emp->CalcMassSal();
}
/*
echo "La masse salariale de l'entreprise se monte à: ".number_format($masseSalarial*1000,2, ",", " ")."€\n";


echo $agence[0];*/