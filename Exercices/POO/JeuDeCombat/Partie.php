<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$joueur=new Joueurs();
$tour=1;

do{
    if(rand(0,1)){
        $monstre=new MonstresFacile();
        $type="Facile";
    }else {
        $monstre=new MonstresDifficile();
        $type="Difficile";
    }
    do{
        echo "\n\nTour ".$tour."\n";
        $joueur->afficheHPBar();
        $joueur->attaque($monstre);
        if($monstre->getEstVivant()){
            echo "\e[93mCest un Monstre ".$type."\e[39m\n";
            $monstre->attaque($joueur);
        }
        $tour++;
    }while($monstre->getEstVivant()&&$joueur->estVivant());
    if($joueur->estVivant()){
        echo "****************************************************\tMonstre Suivant\n";
    }
    
}while($joueur->estVivant());
echo "\n\n";
Affichages::afficheHPBar($joueur);

echo "Domage, vous êtes mort...\n";
echo "Cela dit, vous avez survécu pendant ".$tour." tour(s), tué ".$joueur->getExploits()["easy"]." monstre(s) facile(s) et ".$joueur->getExploits()["hard"]." monstre(s) difficile(s).\n";
echo "Vous avez marqué".$joueur->calcScore()." points.\n\n\n";