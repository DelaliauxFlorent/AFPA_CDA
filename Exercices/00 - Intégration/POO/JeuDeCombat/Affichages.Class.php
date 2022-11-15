<?php

class Affichages{
    
    public static function afficheHPBar(Joueurs $player)
    {
        $upper="╔══════════════════════════════════════════════════╗";
        $side ="║";
        $lower="╚══════════════════════════════════════════════════╝";
        $jauge="██████████████████████████████████████████████████";
        echo $upper."\n".$side;
        
        $hpActu=$player->getHealth();
        $hpPerdu=50-$hpActu;
        echo "\e[92m";
        if($player->estVivant()){
            for($i=1;$i<=$hpActu;$i++){
                echo "█";
            }
            echo "\e[91m";
            for($j=1;$j<=$hpPerdu;$j++){
                echo "█";
            }
        }else{
            echo "\e[91m".$jauge;
        }
        echo "\e[39m".$side."\t".(($hpActu>0)?"\e[92m":"\e[91m").$hpActu."\e[39m/50\n".$lower."\n";
    }

    public function afficherEnCouleur(string $string, $couleur)
    {        
        switch ($couleur) {
            case 'rouge':
                $newString="\e[91m";
                break;
            case 'vert':
                $newString="\e[92m";
                break;
            case 'jaune':
                $newString="\e[93m";
                break;
            default:
            $newString="\e[39m";
                break;
        }
        echo $newString.$string."\e[39m";
    }
}