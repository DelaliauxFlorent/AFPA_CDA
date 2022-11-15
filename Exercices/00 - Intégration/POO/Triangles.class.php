<?php
class Triangles{
    ////////////////////////////////////
    // Attributs

    private $_base;
    private $_hauteur;

    ////////////////////////////////////
    // Accesseurs

    public function getBase()
    {
        return $this->_base;
    }

    public function setBase($base)
    {
        $this->_base = $base;
    }

    public function getHauteur()
    {
        return $this->_hauteur;
    }

    public function setHauteur($hauteur)
    {
        $this->_hauteur = $hauteur;
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
     * function hypothenuse
     *
     * @return float
     */
    public function hypothenuse()
    {
        return sqrt(pow($this->getBase(),2)+pow($this->getHauteur(),2));
    }

    /**
     * function perimetre
     *
     * @return float
     */
    public function perimetre()
    {
        return ($this->getHauteur()+$this->getBase()+$this->hypothenuse());
    }
    
    public function aire()
    {
        return (($this->getHauteur()*$this->getBase())/2);
    }

    public function afficherTriangle()
    {
        echo "Base: ".$this->getBase()."\t- Hauteur: ".$this->getHauteur()."\t- Périmètre: ".$this->perimetre()."\t- Aire: ".$this->aire()."\n";
    }
}