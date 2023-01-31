
<?php
class Eleves
{
    ////////////////////////////////////
    // Attributs

    private $_idEleve;
    private $_nom;
    private $_prenom;
    private $_idClasse;
    
    ////////////////////////////////////
    #region Accesseurs
    
    public function getIdEleve()
    {
        return $this->_idEleve;
    }
    
    public function setIdEleve(int $idEleve)
    {
        $this->_idEleve = $idEleve;
    }
    
    public function getNom()
    {
        return $this->_nom;
    }
    
    public function setNom(string $nom)
    {
        $this->_nom = $nom;
    }
    
    public function getPrenom()
    {
        return $this->_prenom;
    }
    
    public function setPrenom(string $prenom)
    {
        $this->_prenom = $prenom;
    }
    
    public function getIdClasse()
    {
        return $this->_idClasse;
    }
    
    public function setIdClasse(int $idClasse=null)
    {
        $this->_idClasse = $idClasse;
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
