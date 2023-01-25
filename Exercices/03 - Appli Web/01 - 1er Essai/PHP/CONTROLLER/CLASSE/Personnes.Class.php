<?php
class Personnes
{
    ////////////////////////////////////
    // Attributs

    private $_id;
    private $_nom;
    private $_prenom;
    private $_codePostal;
    private $_adresse;
    private $_ville;

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

    public function setNom(string $nom = null)
    {
        $this->_nom = $nom;
    }

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom(string $prenom = null)
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

    public function getChamps()
    {
        $array = get_object_vars($this);
        foreach ($array as $key => $value) {
            $listeChamps[]=ltrim($key, "_");
        }
        return $listeChamps;
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
        foreach ($data as $key => $value) {
            $methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
            if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe
            {
                $this->$methode($value);
            }
        }
    }

    /**
    * Transforme l'objet en chaine de caractères
    *
    * @return String
    */
    public function __toString()
    {
        $string=get_class($this).":<br />";
        $liste=$this->getChamps();
        foreach ($liste as $key=>$value) {
            $get = "get" . ucfirst($liste[$key]);
            $get = $this->$get();
            $string.=" - ".$value." = ".$get.";<br />";
        }
        return $string;
    }
}
