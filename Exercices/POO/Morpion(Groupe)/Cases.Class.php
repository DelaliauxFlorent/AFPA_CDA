<?php

class Cases{
    /*****************Attributs***************** */
    private $_posX;
    private $_posY;
    private $_contenu;

    /*****************Accesseurs***************** */
    public function getPosX(){
        return $this->_posX;
    }

    public function setPosX($posX){
        $this->_posX = $posX;
    }

    public function getPosY(){
        return $this->_posY;
    }

    public function setPosY($posY){
        $this->_posY = $posY;
    }

    public function getContenu(){
        return $this->_contenu;
    }

    public function setContenu($contenu){
        $this->_contenu = $contenu;
    }
    /*****************Constructeur***************** */
    public function __construct(array $options = []){
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide{
            $this->hydrate($options);
        }
    public function hydrate($data){
        foreach ($data as $key => $value){
            $methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
            if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe{
                $this->$methode($value);
            }
        }

    /*****************Autres Méthodes***************** */
    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function __toString(){
        return "";
    }

    /**
     * Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
     *
     * @param [type] $obj
     * @return bool
     */
    public function equalsTo($obj){
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
    public static function compareTo($obj1, $obj2){
        return 0;
    }
/**
 * Fonction qui vérifie si la case souhaité est vide ou pleine.
 *
 * @return bool
 */
    public function estVide(){
        return ($this->getContenu()->getSigne() == "" ) ? true : false;
    }
}
