<?php
class Dices{
    ////////////////////////////////////
    // Attributs

    private $_faces;

    ////////////////////////////////////
    #region Accesseurs

    public function getFaces()
    {
        return $this->_faces;
    }

    public function setFaces($faces)
    {
        $this->_faces = $faces;
    }

    #endregion Accesseurs
    ////////////////////////////////////
    // Constructeur

    public function __construct(int $faces)
    {
        $this->_faces=$faces;
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

    public function lanceLeDe()
    {
        return random_int(1,$this->getFaces());
    }

}