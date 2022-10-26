<?php

class Employes{
    ////////////////////////////////////
    // Attributs

    private $_nom;
    private $_prenom;
    private $_dateEmbauche;
    private $_poste;
    private $_salaire;
    private $_service;

    ////////////////////////////////////
    #region Accesseurs

    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = $nom;
    }

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom($prenom)
    {
        $this->_prenom = $prenom;
    }

    public function getDateEmbauche()
    {
        return $this->_dateEmbauche;
    }

    public function setDateEmbauche($dateEmbauche)
    {
        $this->_dateEmbauche = $dateEmbauche;
    }

    public function getPoste()
    {
        return $this->_poste;
    }

    public function setPoste($poste)
    {
        $this->_poste = $poste;
    }

    public function getSalaire()
    {
        return $this->_salaire;
    }

    public function setSalaire($salaire)
    {
        $this->_salaire = $salaire;
    }

    public function getService()
    {
        return $this->_service;
    }

    public function setService($service)
    {
        $this->_service = $service;
    }
    #endregion Accesseurs

    ////////////////////////////////////
    // Constructeur

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
     * Fonction donnant l'ancienneté
     *
     * @return int
     */
    public function anciennete()
    {
        $today=new DateTime();
        $anciennete = date_diff($this->getDateEmbauche(), $today);
        return intval($anciennete->format("%y"));
    }

    private function percentBrut($pourcentage)
    {
        return $this->getSalaire()/100*$pourcentage;
    }

    public function calculPrime()
    {
        return ($this->percentBrut(5)) //Prime sur salaire de 5% du Brut
                +(($this->percentBrut(2))*$this->anciennete()); //Prime 2% par années d'ancienneté
    }

    public function payerPrime()
    {
        $datePayPrime=new DateTime("2022-10-26"); //Date du jour de payment de la prime
        $today=new DateTime();

    }
    
}