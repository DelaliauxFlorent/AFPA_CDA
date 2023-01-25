<?php
class Personnes{
    ////////////////////////////////////
    // Attributs

    private $_id;
    private $_nom;
    private $_prenom;
    private $_codePostal;
    private $_adresse;
    private $_ville;

    private $_nomsChamps = ["id", "nom", "prenom", "codePostal", "adresse", "ville"];

    ////////////////////////////////////
    #region Accesseurs

    public function getId()
    {
        return $this->_id;
    }

    public function setId(int $id)
    {
        $this->_id = $id;
    }

    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom(string $nom=null)
    {
        $this->_nom = $nom;
    }

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom(string $prenom=null)
    {
        $this->_prenom = $prenom;
    }

    public function getCodePostal()
    {
        return $this->_codePostal;
    }

    public function setCodePostal(int $codePostal = null)
    {
        $this->_codePostal = $codePostal;
    }

    public function getAdresse()
    {
        return $this->_adresse;
    }

    public function setAdresse(string $adresse)
    {
        $this->_adresse = $adresse;
    }

    public function getVille()
    {
        return $this->_ville;
    }

    public function setVille(string $ville)
    {
        $this->_ville = $ville;
    }

    public function getNomsChamps()
    {
        return $this->_nomsChamps;
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

    

}