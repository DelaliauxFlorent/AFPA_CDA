
<?php
class Articles
{
    ////////////////////////////////////
    // Attributs

    private $_idArticle;
    private $_refArticle;
    private $_libelleArticle;
    private $_prix;
    
    ////////////////////////////////////
    #region Accesseurs
    
    public function getIdArticle()
    {
        return $this->_idArticle;
    }
    
    public function setIdArticle(int $idArticle)
    {
        $this->_idArticle = $idArticle;
    }
    
    public function getRefArticle()
    {
        return $this->_refArticle;
    }
    
    public function setRefArticle(string $refArticle)
    {
        $this->_refArticle = $refArticle;
    }
    
    public function getLibelleArticle()
    {
        return $this->_libelleArticle;
    }
    
    public function setLibelleArticle(string $libelleArticle)
    {
        $this->_libelleArticle = $libelleArticle;
    }
    
    public function getPrix()
    {
        return $this->_prix;
    }
    
    public function setPrix(int $prix=null)
    {
        $this->_prix = $prix;
    }
    
    public static function getChamps()
    {
        $array = get_class_vars(__CLASS__);
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
}
