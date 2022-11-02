<?php
class Clients{
    ////////////////////////////////////
    // Attributs

    private $_nom;
    private $_prenom;
    private Comptes $_Compte;
    private Livrets $_Livret;

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
    public function getCompte()
    {
        return $this->_Compte;
    }

    public function setCompte($Compte)
    {
        $this->_Compte = $Compte;
    }

    public function getLivret()
    {
        return $this->_Livret;
    }

    public function setLivret($Livret)
    {
        $this->_Livret = $Livret;
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
        return $this->getNom()." ".$this->getPrenom()." possède le compte n°".$this->getCompte()->getNumero()." contenant ".$this->getCompte()->getMontant()."€ et le livret n°".$this->getLivret()->getNumero()." contenant ".$this->getLivret()->getMontant();
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

    public function recevoir($somme)
    {
        $this->getCompte()->crediter($somme);
    }

    public function depenser($somme)
    {
        $this->getCompte()->debiter($somme);
    }

    public function epargner($somme)
    {
        $this->depenser($somme);
       // $this->getCompte()->
    }
    
}