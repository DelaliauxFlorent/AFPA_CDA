
<?php
class Classes
{
    ////////////////////////////////////
    // Attributs

    private $_idClasse;
    private $_libelle;
    
    ////////////////////////////////////
    #region Accesseurs
    
    public function getIdClasse()
    {
        return $this->_idClasse;
    }
    
    public function setIdClasse(int $idClasse)
    {
        $this->_idClasse = $idClasse;
    }
    
    public function getLibelle()
    {
        return $this->_libelle;
    }
    
    public function setLibelle(string $libelle)
    {
        $this->_libelle = $libelle;
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
