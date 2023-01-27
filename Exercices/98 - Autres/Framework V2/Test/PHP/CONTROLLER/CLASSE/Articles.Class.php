
<?php
class Articles
{
    ////////////////////////////////////
    // Attributs

    private $_idArticle;
    private $_descriptionArticle;
    private $_prixArticle;
    
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
    
    public function getDescriptionArticle()
    {
        return $this->_descriptionArticle;
    }

    public function setDescriptionArticle(string $descriptionArticle = null)
    {
        $this->_descriptionArticle = $descriptionArticle;
    }
    
    public function getPrixArticle()
    {
        return $this->_prixArticle;
    }

    public function setPrixArticle(int $prixArticle = null)
    {
        $this->_prixArticle = $prixArticle;
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
