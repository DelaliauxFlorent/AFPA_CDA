<?php

class Prismes extends Triangles{
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

    /**
    * Transforme l'objet en chaine de caractères
    *
    * @return String
    */
    public function __toString()
    {
        return "Périmètre: ".$this->perimetre()."\t- Volume: ".$this->volume()."\n";
    }

    /**
     * Undocumented function
     *
     * @return void
     */
    public function perimetre()
    {
        
        return parent::perimetre()*2+$this->getProfondeur()*3;
    }

    public function volume()
    {
        return parent::aire()*$this->_profondeur;
    }

    public function afficherPrisme()
    {
        echo "Périmètre: ".$this->perimetre()."\t- Volume: ".$this->volume()."\n";
    }
}