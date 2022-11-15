<?php
class Agences{
    ////////////////////////////////////
    // Attributs

    private $_nomAgence;
    private $_adresse;
    private $_codePostal;
    private $_ville;

    private bool $_restau = true;

    ////////////////////////////////////
    #region Accesseurs

    public function getNomAgence()
    {
        return $this->_nomAgence;
    }

    public function setNomAgence($nomAgence)
    {
        $this->_nomAgence = $nomAgence;
    }

    public function getAdresse()
    {
        return $this->_adresse;
    }

    public function setAdresse($adresse)
    {
        $this->_adresse = $adresse;
    }

    public function getCodePostal()
    {
        return $this->_codePostal;
    }

    public function setCodePostal($codePostal)
    {
        $this->_codePostal = $codePostal;
    }

    public function getVille()
    {
        return $this->_ville;
    }

    public function setVille($ville)
    {
        $this->_ville = $ville;
    }

    public function getRestau()
    {
        return $this->_Restau;
    }

    public function setRestau($Restau)
    {
        $this->_Restau = $Restau;
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
        return "Agence:\n\t- Nom:\t\t".$this->getNomAgence()."\n\t- Adresse:\t".$this->getAdresse()."\n\t- Code Postal:\t".$this->getCodePostal()."\n\t- Ville:\t".$this->getVille()."\n";
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

    public function modeRestau()
    {
        if($this->getRestau()){
            return "Restaurant d'entreprise";//$this->getRestau();
        }
        return "Tickets Restaurants";
    }
    
}