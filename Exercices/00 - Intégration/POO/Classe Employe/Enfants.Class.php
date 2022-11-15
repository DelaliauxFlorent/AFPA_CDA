<?php

class Enfants{
    ////////////////////////////////////
    // Attributs

    private $_prenom;   // Prénom de l'enfant => nom identique au parent
    private $_dOB;      // Date de naissance

    private $_chequeNoel=0;

    ////////////////////////////////////
    #region Accesseurs    

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom($prenom)
    {
        $this->_prenom = $prenom;
    }

    public function getDOB()
    {
        return $this->_dOB;
    }

    public function setDOB($dOB)
    {
        $this->_dOB = $dOB;
    }    

    public function getChequeNoel()
    {
        return $this->_chequeNoel;
    }

    #endregion Accesseurs
    ////////////////////////////////////
    // Constructeur

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
            if($this->getAge()<=10)
            {
                $this->_chequeNoel=20;
            }elseif($this->getAge()<=15)
            {
                $this->_chequeNoel=30;
            }elseif($this->getAge()<=18)
            {
                $this->_chequeNoel=50;
            }
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

    public function getAge()
    {
        $auj = new DateTime('now');
        $interval = $auj->diff($this->getDOB(), true); //diff renvoi une DateIntervalle, true oblige cet interval a être positif
        $annee = $interval->format('%y') * 1; // on *1 pour avoir un int
        return $annee;
    }


}