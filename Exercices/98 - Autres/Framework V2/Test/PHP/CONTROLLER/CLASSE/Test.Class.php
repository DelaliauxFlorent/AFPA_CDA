
<?php
class Test
{
    ////////////////////////////////////
    // Attributs

    private $_intid;
    private $_varcharNom;
    private $_texte;
    private $_date;
    private $__tinyint;
    private $__smallint;
    private $__mediumint;
    private $__bigint;
    private $__decimal;
    private $__float;
    private $__double;
    private $__real;
    private $__bit;
    private $__bool;
    
    ////////////////////////////////////
    #region Accesseurs
    
    public function getIntid()
    {
        return $this->_intid;
    }
    
    public function setIntid(int $intid)
    {
        $this->_intid = $intid;
    }
    
    public function getVarcharNom()
    {
        return $this->_varcharNom;
    }
    
    public function setVarcharNom(string $varcharNom)
    {
        $this->_varcharNom = $varcharNom;
    }
    
    public function getTexte()
    {
        return $this->_texte;
    }
    
    public function setTexte(string $texte)
    {
        $this->_texte = $texte;
    }
    
    public function getDate()
    {
        return $this->_date;
    }
    
    public function setDate(string $date)
    {
        $this->_date = $date;
    }
    
    public function get_tinyint()
    {
        return $this->__tinyint;
    }
    
    public function set_tinyint(int $_tinyint)
    {
        $this->__tinyint = $_tinyint;
    }
    
    public function get_smallint()
    {
        return $this->__smallint;
    }
    
    public function set_smallint(int $_smallint)
    {
        $this->__smallint = $_smallint;
    }
    
    public function get_mediumint()
    {
        return $this->__mediumint;
    }
    
    public function set_mediumint(int $_mediumint)
    {
        $this->__mediumint = $_mediumint;
    }
    
    public function get_bigint()
    {
        return $this->__bigint;
    }
    
    public function set_bigint(int $_bigint)
    {
        $this->__bigint = $_bigint;
    }
    
    public function get_decimal()
    {
        return $this->__decimal;
    }
    
    public function set_decimal(float $_decimal)
    {
        $this->__decimal = $_decimal;
    }
    
    public function get_float()
    {
        return $this->__float;
    }
    
    public function set_float(float $_float)
    {
        $this->__float = $_float;
    }
    
    public function get_double()
    {
        return $this->__double;
    }
    
    public function set_double(float $_double)
    {
        $this->__double = $_double;
    }
    
    public function get_real()
    {
        return $this->__real;
    }
    
    public function set_real(float $_real)
    {
        $this->__real = $_real;
    }
    
    public function get_bit()
    {
        return $this->__bit;
    }
    
    public function set_bit(int $_bit)
    {
        $this->__bit = $_bit;
    }
    
    public function get_bool()
    {
        return $this->__bool;
    }
    
    public function set_bool(int $_bool)
    {
        $this->__bool = $_bool;
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
