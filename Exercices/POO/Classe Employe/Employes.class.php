<?php

class Employes{
    ////////////////////////////////////
    // Attributs

    private $_nom;
    private $_prenom;
    private $_dateEmbauche;
    private $_poste;
    private $_salaire;
    private $_service;

    private Agences $agence;

    ////////////////////////////////////
    #region Accesseurs

    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = $nom;
    }

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom($prenom)
    {
        $this->_prenom = $prenom;
    }

    public function getDateEmbauche()
    {
        return $this->_dateEmbauche;
    }

    public function setDateEmbauche($dateEmbauche)
    {
        $this->_dateEmbauche = $dateEmbauche;
    }

    public function getPoste()
    {
        return $this->_poste;
    }

    public function setPoste($poste)
    {
        $this->_poste = $poste;
    }

    public function getSalaire()
    {
        return $this->_salaire;
    }

    public function setSalaire($salaire)
    {
        $this->_salaire = $salaire;
    }

    public function getService()
    {
        return $this->_service;
    }

    public function setService($service)
    {
        $this->_service = $service;
    }

    public function getAgence()
    {
        return $this->_agence;
    }

    public function setAgence(Agences $agence)
    {
        $this->_agence = $agence;
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
    * Transforme l'objet en chaine de caractères
    *
    * @return String
    */
    public function __toString()
    {
        return "Employé:\n\t- Nom: \t\t".$this->getNom()."\n\t- Prénom: \t".$this->getPrenom()."\n\t- Embauché le: \t".date_format($this->getDateEmbauche(),"d/m/Y")."\n\t- Fonction: \t".$this->getPoste()."\n\t- Salaire: \t".number_format($this->getSalaire()*1000,2,",", " ")."€\n\t- Service: \t".$this->getService()."\n".$this->chequeVacance()."\n".$this->getAgence()."\n";
    }

    /**
    * Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
    *
    * @param [type] $obj
    * @return bool
    */
    public function equalsTo($obj)
    {
        return true;
    }

    /**
    * Compare 2 objets
    * Renvoi 1 si le 1er est >
    *        0 si ils sont égaux
    *        -1 si le 1er est <
    *
    * @param [type] $obj1
    * @param [type] $obj2
    * @return int
    */
    public static function compareToNP($obj1, $obj2)
    {
        if(strcmp($obj1->getNom(),$obj2->getNom())=="0"){
            return strcmp($obj1->getPrenom(),$obj2->getPrenom()); //S'occupe du prénom SSI Noms identiques
        }else{
            return strcmp($obj1->getNom(),$obj2->getNom());            
        }
    }

    /**
    * Compare 2 objets
    * Renvoi 1 si le 1er est >
    *        0 si ils sont égaux
    *        -1 si le 1er est <
    *
    * @param [type] $obj1
    * @param [type] $obj2
    * @return int
    */
    public static function compareToSNP($obj1, $obj2)
    {
        if(strcmp($obj1->getService(),$obj2->getService())==0){
            return self::compareToNP($obj1, $obj2);
        }else{
            return strcmp($obj1->getService(),$obj2->getService());
        }
    }

    /**
     * Fonction donnant l'ancienneté
     *
     * @return int
     */
    public function anciennete()
    {
        $auj = new DateTime('now');
        $interval = $auj->diff($this->getDateEmbauche(), true); //diff renvoi une DateIntervalle, true oblige cet interval a être positif
        $annee = $interval->format('%y') * 1; // on *1 pour avoir un int
        return $annee;
    } 

    private function percentBrut($pourcentage)
    {
        return $this->getSalaire()/100*$pourcentage;
    }

    public function calculPrime()
    {
        return ($this->percentBrut(5)) //Prime sur salaire de 5% du Brut
                +(($this->percentBrut(2))*$this->anciennete()); //Prime 2% par années d'ancienneté
    }

    public function payerPrime()
    {
        $datePayPrime=new DateTime("2021-10-26"); //Date du jour de payment de la prime
        $today=new DateTime();
        $diffDate=date_diff($datePayPrime, $today);
       // var_dump($datePayPrime); echo"\n"; var_dump($today);echo"\n"; var_dump($diffDate);
        if(intval($diffDate->format("%m"))==0 && intval($diffDate->format("%d"))==0){
            echo "Une prime de ".number_format($this->calculPrime()*1000,2,",", " ")." euros vient de lui être payé.\n";
        }else{
            echo "Une prime de ".number_format($this->calculPrime()*1000,2,",", " ")." euros lui a été payé il y a ".$diffDate->format("%m")." mois et ".$diffDate->format("%d")." jour(s).\n";
        }
    }
    
    public function CalcMassSal()
    {
        return $this->getSalaire()+$this->calculPrime();
    }

    private function chequeVacance(){
        if($this->anciennete()>=1){
            return "Il peut bénificier de chèques vacances.\n";
        }else{
            return "Il ne peut pas bénificier de chèques vacances.\n";
        }
    }

}