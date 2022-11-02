<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$joueur=new Joueurs();

do{
    if(rand(0,1)){
        $monstre=new MonstresFacile();
        $type="Facile";
    }else {
        $monstre=new MonstresDifficile();
        $type="Difficile";
    }
    do{
        $joueur->afficheHPBar();
        $joueur->attaque($monstre);
        if($monstre->getEstVivant()){
            echo "\e[93mCest un Monstre ".$type."\e[39m\n";
            $monstre->attaque($joueur);
        }
    }while($monstre->getEstVivant()&&$joueur->estVivant());
    if($joueur->estVivant()){
        echo "***************************************\tMonstre Suivant\n";
    }
    
}while($joueur->estVivant());
$joueur->affMsgMort();