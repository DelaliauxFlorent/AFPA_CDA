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
    }else {
        $monstre=new MonstresDifficile();
    }
    do{
        $joueur->attaque($monstre);
        if($monstre->getEstVivant()){
            $monstre->attaque($joueur);
        }
    }while($monstre->getEstVivant());

}while($joueur->estVivant());
$joueur->affMsgMort();