<?php
class Joueurs
{

    /*****************Attributs***************** */
    private $_num;
    private $_signe="";
    private $_nom;
    private $_couleur;

    private static $_compteur = 0; // pour déterminer le numéro du joueur
    private static $_listeSignes = []; // signes utilisés par les joueurs

    /*****************Accesseurs***************** */
    public function getNum()
    {
        return $this->_num;
    }

    private function setNum($num) // la méthode est private car le numéro est fixé par le compteur
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
        self::$_listeSignes[] = $signe; // on met le signe dans la liste des signes
    }

    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = ucfirst($nom);
    }

    public function getCouleur()
    {
        return $this->_couleur;
    }

    public function setCouleur($couleur)
    {
        $this->_couleur = $couleur;
    }

    public static function getCompteur()
    {
        return self::$_compteur;
    }
    
    public static function getListeSignes()
    {
        return self::$_listeSignes;
    }

    // cette classe est utile uniquement sur un reset
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
            $this->setNum(self::$_compteur);
            self::$_compteur++;
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
