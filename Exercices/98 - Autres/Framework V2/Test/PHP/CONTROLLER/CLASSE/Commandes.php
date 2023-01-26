
<?php
class Commandes
{
    ////////////////////////////////////
    // Attributs

    private $_idCommande;
    private $_idClient;
    private $_idArticle;
    private $_dateCommande;
    private $_quantiteCommande;
    private $_cde_total;
    
    ////////////////////////////////////
    #region Accesseurs
    
    public function getIdCommande()
    {
        return $this->_idCommande;
    }

    public function setIdCommande(int $idCommande)
    {
        $this->_idCommande = $idCommande;
    }
    
    public function getIdClient()
    {
        return $this->_idClient;
    }

    public function setIdClient(int $idClient = null)
    {
        $this->_idClient = $idClient;
    }
    
    public function getIdArticle()
    {
        return $this->_idArticle;
    }

    public function setIdArticle(int $idArticle = null)
    {
        $this->_idArticle = $idArticle;
    }
    
    public function getDateCommande()
    {
        return $this->_dateCommande;
    }

    public function setDateCommande(string $dateCommande = null)
    {
        $this->_dateCommande = $dateCommande;
    }
    
    public function getQuantiteCommande()
    {
        return $this->_quantiteCommande;
    }

    public function setQuantiteCommande(int $quantiteCommande = null)
    {
        $this->_quantiteCommande = $quantiteCommande;
    }
    
    public function getCde_total()
    {
        return $this->_cde_total;
    }

    public function setCde_total(int $cde_total = null)
    {
        $this->_cde_total = $cde_total;
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
