
<?php
class Clients
{
    ////////////////////////////////////
    // Attributs

    private $_idClient;
    private $_nomClient;
    private $_prenomClient;
    private $_dateEntreeClient;
    
    ////////////////////////////////////
    #region Accesseurs
    
    public function getIdClient()
    {
        return $this->_idClient;
    }

    public function setIdClient(int $idClient)
    {
        $this->_idClient = $idClient;
    }
    
    public function getNomClient()
    {
        return $this->_nomClient;
    }

    public function setNomClient(string $nomClient = null)
    {
        $this->_nomClient = $nomClient;
    }
    
    public function getPrenomClient()
    {
        return $this->_prenomClient;
    }

    public function setPrenomClient(string $prenomClient = null)
    {
        $this->_prenomClient = $prenomClient;
    }
    
    public function getDateEntreeClient()
    {
        return $this->_dateEntreeClient;
    }

    public function setDateEntreeClient(string $dateEntreeClient = null)
    {
        $this->_dateEntreeClient = $dateEntreeClient;
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
