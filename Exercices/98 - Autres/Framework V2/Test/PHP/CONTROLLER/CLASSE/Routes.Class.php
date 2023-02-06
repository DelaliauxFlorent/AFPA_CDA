<?php
class Routes
{
    ////////////////////////////////////
    // Attributs

    private ?int $_idRoute;
    private ?string $_nomPage;
    private ?string $_chemin;
    private ?int $_roleMini;
    private ?string $_titre;
    private ?int $_api;
    
    ////////////////////////////////////
    #region Accesseurs
    
    public function getIdRoute()
    {
        return $this->_idRoute;
    }
    
    public function setIdRoute(int $idRoute)
    {
        $this->_idRoute = $idRoute;
    }
    
    public function getNomPage()
    {
        return $this->_nomPage;
    }
    
    public function setNomPage(string $nomPage)
    {
        $this->_nomPage = $nomPage;
    }
    
    public function getChemin()
    {
        return $this->_chemin;
    }
    
    public function setChemin(string $chemin)
    {
        $this->_chemin = $chemin;
    }
    
    public function getRoleMini()
    {
        return $this->_roleMini;
    }
    
    public function setRoleMini(int $roleMini)
    {
        $this->_roleMini = $roleMini;
    }
    
    public function getTitre()
    {
        return $this->_titre;
    }
    
    public function setTitre(string $titre)
    {
        $this->_titre = $titre;
    }
    
    public function getApi()
    {
        return $this->_api;
    }
    
    public function setApi(int $api)
    {
        $this->_api = $api;
    }
    
    /**
     * Récupérer la liste des attributs de la classe
     *
     * @return  array  liste des champs
     */
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
