<?php
class MonstresFacile{
    ////////////////////////////////////
    // Attributs

    protected $_estVivant=true;
    private static $_ptsValue = 1;
    protected $_puissanceAttaque=10; // Si l'on veut pouvoir corser les choses plus tard

    ////////////////////////////////////
    #region Accesseurs

    public function getEstVivant()
    {
        return $this->_estVivant;
    }

    public function setEstVivant($estVivant)
    {
        $this->_estVivant = $estVivant;
    }

    public function getPuissanceAttaque()
    {
        return $this->_puissanceAttaque;
    }

    public static function getPtsValue()
    {
        return self::$_ptsValue;
    }

    #endregion Accesseurs
    ////////////////////////////////////
    // Constructeur
/*
    public function __construct()
    {
        $this->_estVivant=true;
        $this->_puissanceAttaque=10;
    }
*/
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
     * Gestion de la défense au bouclier
     * @param int $shield Valeur à battre pour blesser joueur
     * @return bool Passé outre le bouclier 
     */
    protected function gestionBouclier($shield)
    {
        $dice=new Dices(6);
        $bouclier=$dice->lanceLeDe();
        if($bouclier>$shield){
            return true;
        }
        return false;
    }

    
    /**
     * Attaque du monstre faible
     * 
     * @param Joueurs $joueur Qui subit les dégats
     */
    public function attaque(Joueurs $joueur)
    {
        $dice=new Dices(6);
        $lanceMonst=$dice->lanceLeDe();
        $lancePC=$dice->lanceLeDe();
        
        if($lanceMonst>$lancePC){
           if($this->gestionBouclier(Joueurs::getShield())){
                $joueur->subitDegats($this->getPuissanceAttaque());
           }
        }
    }

}