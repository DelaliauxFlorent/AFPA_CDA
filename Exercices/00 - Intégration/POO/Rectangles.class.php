<?php
class Rectangles
{

    /*****************Attributs***************** */
    private $_longueur;
    private $_largeur;

    /*****************Accesseurs***************** */
    public function getLongueur()
    {
        return $this->_longueur;
    }

    public function setLongueur(int $longueur)
    {
        $this->_longueur = $longueur;
    }

    public function getLargeur()
    {
        return $this->_largeur;
    }

    public function setLargeur($largeur)
    {
        $this->_largeur = $largeur;
    }
    
    /*****************Constructeur***************** */

    // public function __construct($longueur,$largeur)
    // {
    //     $this->setLongueur($longueur);
    //     $this->setLargeur($largeur);
    // }


    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
    }
    public function hydrate($data)
    {
        foreach ($data as $key => $value)
        {
            $methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
            if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe
            {
                $this->$methode($value);
            }
        }
    }

    /*****************Autres Méthodes***************** */
    
    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function toString()
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

    public function perimetre(){
        return ($this->_largeur+$this->_longueur)*2;
    }

   public function aire(){
        return ($this->_largeur*$this->_longueur);
   }
   
   public function estCarre(){
        if($this->_largeur==$this->_longueur){
            return true;
        }
        return false;
   }

   public function afficherRectangle(){
        echo "Longueur: ".$this->_longueur."\t- Largeur: ".$this->_largeur."\t- Périmètre: ".$this->perimetre()."\t- Aire: ".$this->aire()."\t- ".($this->estCarre()?"Il s'agit d'un carré.":"Il ne s'agit pas d'un carré.");
   }
}