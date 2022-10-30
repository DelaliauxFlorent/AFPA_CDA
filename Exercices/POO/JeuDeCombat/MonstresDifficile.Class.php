<?php

class MonstresDifficile extends MonstresFacile{
    ////////////////////////////////////
    // Attributs

    private $_puissanceSort; // Si l'on veut pouvoir corser les choses plus tard

    ////////////////////////////////////
    #region Accesseurs

    public function getPuissanceSort()
    {
        return $this->_puissanceSort;
    }

    #endregion Accesseurs
    ////////////////////////////////////
    // Constructeur

    public function __construct()
    {
        $this->_puissanceSort=5;
        $this->_ptsValue=2;
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

    private function lancerSort()
    {
        $dice=new Dices(6);
        $magicRole=$dice->lanceLeDe();
        $degatsMag=0;
        if($magicRole!=6){
            $degatsMag=$magicRole*$this->getPuissanceSort();
        }
        return $degatsMag;
    }

    /**
    * Attaque du monstre difficile
    * 
    * @param Joueurs $joueur Qui subit les dégats
    */
    public function attaque(Joueurs $joueur)
    {
        parent::attaque($joueur);
        $joueur->subitDegats($this->lancerSort());
    }


}