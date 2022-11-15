<?php
class Joueurs
{

    /*****************Attributs***************** */
    private $_num;
    private $_signe;
    private $_nom;
    

    private static $_compteur = 0;
    private static $_listeSignes = [];

    /*****************Accesseurs***************** */
    public function getNum()
    {
        return $this->_num;
    }

    public function setNum($num)
    {
        $this->_num = $num;
    }

    public function getSigne()
    {
        return $this->_signe;
    }

    public function setSigne($signe)
    {
        $this->_signe = $signe;
        self::$_listeSignes[] = $signe;
    }

    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = ucfirst($nom);
    }

    public static function getCompteur()
    {
        return self::$_compteur;
    }
    
    public static function getListeSignes()
    {
        return self::$_listeSignes;
    }

    public static function setListeSignes($listeSignes)
    {
        self::$_listeSignes[] = $listeSignes;
    }

    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
            self::$_compteur++;
            $this->setNum(self::$_compteur);

        }
    }
    public function hydrate($data)
    {
        foreach ($data as $key => $value) {
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
     * Fonction static qui sert à vérifier si un signe a déjà été utilisé ou pas
     * Renvoi true si existe
     *
     * @param String $signeATester
     * @return bool
     */
    public static function signeExiste($signeATester) {
        return in_array($signeATester, self::getListeSignes());
    }
}
