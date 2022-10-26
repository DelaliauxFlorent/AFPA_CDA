<?php

class Paves extends Rectangles{
    ////////////////////////////////////
    // Attributs

    private $_profondeur;

    ////////////////////////////////////
    // Accesseurs

    public function getProfondeur()
    {
        return $this->_profondeur;
    }

    public function setProfondeur($profondeur)
    {
        $this->_profondeur = $profondeur;
    }

    ////////////////////////////////////
    // Constructeur

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            
            $this->hydrate($options);
        }
    }

    ////////////////////////////////////
    // Autres méthodes
    
    public function perimetre()
    {
        return parent::perimetre();
    }

    public function volume()
    {
        return $this->perimetre()*$this->_profondeur;
    }

    public function AfficherPave()
    {
        echo "Périmètre: ".$this->perimetre()."\t- Volume: ".$this->volume();
    }

    /**
    * Transforme l'objet en chaine de caractères
    *
    * @return String
    */
    public function __toString()
    {
        return $this->AfficherPave();
    }
    
}