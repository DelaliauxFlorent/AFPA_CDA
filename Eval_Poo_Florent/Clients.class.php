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
        return "Le client ".$this->getNom()." ".$this->getPrenom()." a ".$this->getCompte()->getMontant()."€ sur son compte n°".$this->getCompte()->getNumero()." et ".$this->getLivret()->getMontant()."€ sur son livret n°".$this->getLivret()->getNumero()."\n";
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
        $this->getLivret()->crediter($somme);
    }
    
}