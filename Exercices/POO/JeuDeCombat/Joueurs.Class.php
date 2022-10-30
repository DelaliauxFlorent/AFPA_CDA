<?php

class Joueurs{
    ////////////////////////////////////
    // Attributs

    private $_health;
    private $_exploits;

    private static $_shield = 2;  // résultat max du DR shield pour protection

    ////////////////////////////////////
    #region Accesseurs
    
    public function getHealth()
    {
        return $this->_health;
    }

    public static function getShield()
    {
        return self::$_shield;
    }

    public function getExploits()
    {
        return $this->_exploits;
    }

    #endregion Accesseurs
    ////////////////////////////////////
    // Constructeur

    public function __construct(array $options = [])
    {
        $this->_health=50;
        $this->_exploits=array("easy"=>0, "hard"=>0);
    }

    ////////////////////////////////////
    // Autres méthodes

    /**
    * Transforme l'objet en chaine de caractères
    *
    * @return String
    */
    public function __toString()
    {
        return "";
    }

    /**
    * Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
    *
    * @param [type] $obj
    * @return bool
    */
    public function equalsTo($obj)
    {
        return true;
    }

    /**
    * Compare 2 objets
    * Renvoi 1 si le 1er est >
    *        0 si ils sont égaux
    *        -1 si le 1er est <
    *
    * @param [type] $obj1
    * @param [type] $obj2
    * @return void
    */
    public static function compareTo($obj1, $obj2)
    {
        return 0;
    }

    /**
     * Check if PC is alive
     * @return bool
     */
    public function estVivant()
    {
        return $this->getHealth()>0;
    }

    public function attaque($monstre)
    {
        $dice=new Dices(6);
        $lancePC=$dice->lanceLeDe();
        $lanceMonst=$dice->lanceLeDe();
        if($lancePC>=$lanceMonst){
            $monstre->setEstVivant(false);
            $this->memory($monstre);    //Le joueur se souvient avoir tuer autant de monstres
        }
    }

    public function subitDegats($degatsSubit)
    {
        $this->_health-=$degatsSubit;
    }

    private function memory($monstre)
    {
        if(method_exists($monstre, "lancerSort")){
            $this->_exploits["hard"]++;
        }
        else{
            $this->_exploits["easy"]++;
        }
    }

    private function calcScore(){
        return $this->getExploits()["easy"]*MonstresFacile::getPtsValue()+$this->getExploits()["hard"]*MonstresDifficile::getPtsValue();
    }

    public function affMsgMort()
    {
        echo "Domage, vous êtes mort...\n";
        echo "Cela dit, vous avez tué ".$this->getExploits()["easy"]." monstre(s) facile(s) et ".$this->getExploits()["hard"]." monstre(s) difficile(s).\n";
        echo "Vous avez ".$this->calcScore()." points.";
    }

}