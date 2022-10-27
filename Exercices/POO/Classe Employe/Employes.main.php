<?php

function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$dateEmbauche=new DateTime("2017-10-05");
$agence[]=new Agences(["nomAgence"=>"SNCF", "adresse"=>"QQpart en france", "codePostal"=>"93000", "ville"=>"Paris"]);
$agence[]=new Agences(["nomAgence"=>"EDF", "adresse"=>"QQpart en france", "codePostal"=>"93000", "ville"=>"Paris", "restau"=>false]);

$employe[0]= new Employes(["nom"=>"Doe", "prenom"=>"John", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>12, "service"=>"Cantine", "agence"=> $agence[0]]);
$employe[1]= new Employes(["nom"=>"Martin", "prenom"=>"Jacques", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>22, "service"=>"Garage", "agence"=> $agence[0]]);
$employe[2]= new Employes(["nom"=>"Bond", "prenom"=>"James", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>52, "service"=>"Accueil", "agence"=> $agence[0]]);
$employe[3]= new Employes(["nom"=>"Gear", "prenom"=>"Richard", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>90, "service"=>"Cantine", "agence"=> $agence[0]]);
$employe[4]= new Employes(["nom"=>"Bond", "prenom"=>"Alfred", "dateEmbauche"=>$dateEmbauche, "poste"=>"Chef", "salaire"=>30, "service"=>"Cantine", "agence"=> $agence[0]]);

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