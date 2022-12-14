<?php
class Employe
{

    /*****************Attributs***************** */
    private $_nom;
    private $_prenom;
    private $_dateEmbauche;
    private $_fonction;
    private $_salaireAnnuel;
    private $_service;
    private Agence $_agence;
    private $_enfants = [];
    private static $_compteur = 0;

    /*****************Accesseurs***************** */

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

    public function setDateEmbauche(DateTime $dateEmbauche)
    {
        $this->_dateEmbauche = $dateEmbauche;
    }

    public function getSalaireAnnuel()
    {
        return $this->_salaireAnnuel;
    }

    public function setSalaireAnnuel($salaireAnnuel)
    {
        $this->_salaireAnnuel = $salaireAnnuel;
    }

    public function getFonction()
    {
        return $this->_fonction;
    }

    public function setFonction($fonction)
    {
        $this->_fonction = $fonction;
    }

    public function getService()
    {
        return $this->_service;
    }

    public function setService($service)
    {
        $this->_service = ucfirst($service);
    }

    public function getAgence()
    {
        return $this->_agence;
    }

    public function setAgence(Agence $agence)
    {
        $this->_agence = $agence;
    }

    public function getEnfants()
    {
        return $this->_enfants;
    }

    public function setEnfants(array $enfants)
    {
        $this->_enfants = $enfants;
    }
    public static function getCompteur()
    {
        return self::$_compteur;
    }

    public static function setCompteur($compteur)
    {
        self::$_compteur = $compteur;
    }
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
        self::setCompteur(self::getCompteur() + 1); //on increment le compteur
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

    /*****************Autres M??thodes***************** */

    /**
     * Transforme l'objet en chaine de caract??res
     *
     * @return String
     */
    public function toString()
    {
        $aff = "\n\n*** SALARIE ***\n";
        $aff .= "Nom :" . $this->getNom() . "\nPrenom :" . $this->getPrenom() . "\nDateEmbauche :" . $this->getDateEmbauche()->format('Y-m-d') . "\nPosteEntreprise :" . $this->getFonction() . "\nSalaire annuel :" . $this->getSalaireAnnuel() . "K\nService :" . $this->getService() . "\n";
        $aff .= $this->recoitChequeVacances() ? "Ce salari?? b??n??ficie de ch??ques vacances\n" : "Ce salari?? ne b??n??ficie pas de ch??ques vacances\n";
        $aff .= "\n*** AGENCE ***\n" . $this->getAgence()->toString();
        $aff .= "\n*** ENFANTS ***\n";
        if (count($this->getEnfants()) > 0)
        {
            foreach ($this->getEnfants() as $enfant)
            {
                $aff .= $enfant->toString();
            }
        }
        else
        {
            $aff .= "Pas d'enfant";
        }
        $aff .= "\n*** CHEQUES NOEL ***\n";
        $cheques = $this->recoitChequeNoel();
        if (array_sum($cheques) > 0)
        {
            foreach ($cheques as $key=>$nbCheque) // on parcours le tableau de ch??ques
            {
                if ($nbCheque > 0)    //  si le nombre de ch??que est sup??rieur ?? 0
                {
                    $aff .= $nbCheque . " ch??que(s) de ".$key."\n";   //$nbCheque contient le nombre de ch??ques  et $key, la valeur du ch??que
                }
            }
        }
        else
        {
            $aff .= "Pas de ch??ques de No??l";
        }
        return $aff;
    }

    /**
     * Renvoi vrai si l'objet en param??tre est ??gal ?? l'objet appelant
     *
     * @param [type] obj
     * @return bool
     */
    public function equalsTo($obj)
    {
        return true;
    }
    /**
     * Compare 2 objets sur le nom et le pr??nom
     * Renvoi 1 si le 1er est >
     *        0 si ils sont ??gaux
     *        -1 si le 1er est <
     *
     * @param [type] $obj1
     * @param [type] $obj2
     * @return void
     */
    public static function compareToNomPrenom($obj1, $obj2)
    {
        // if ($obj1->getNom() < $obj2->getNom())
        // {
        //     return -1;
        // }
        // else if ($obj1->getNom() > $obj2->getNom())
        // {
        //     return 1;
        // }// ils ont le meme nom
        // else if ($obj1->getPrenom() < $obj2->getPrenom())
        // {
        //     return -1;
        // }
        // else if ($obj1->getPrenom() > $obj2->getPrenom())
        // {
        //     return 1;
        // }
        // // ils ont le meme nom et prenom
        // return 0;

        /* *** version courte *** */
            if (strcmp($obj1->getNom(),$obj2->getNom())==0)
            {
                return strcmp($obj1->getPrenom(),$obj2->getPrenom());
            }
            return strcmp($obj1->getNom(),$obj2->getNom());
    }
    /**
     * Compare 2 objets sur le nom et le pr??nom
     * Renvoi 1 si le 1er est >
     *        0 si ils sont ??gaux
     *        -1 si le 1er est <
     *
     * @param [type] $obj1
     * @param [type] $obj2
     * @return void
     */
    public static function compareToServiceNomPrenom($obj1, $obj2)
    {
        if ($obj1->getService() < $obj2->getService())
        {
            return -1;
        }
        else if ($obj1->getService() > $obj2->getService())
        {
            return 1;
        }
        else
        {
            return self::compareToNomPrenom($obj1, $obj2);
        }

    }
    /**
     * Renvoi l'anciennete de l'employe
     *
     * @return int  le nombre d'annee d'anciennet??
     */
    public function anciennete()
    {
        $auj = new DateTime('now');
        $interval = $auj->diff($this->getDateEmbauche(), true); //diff renvoi une DateIntervalle, true oblige cet interval a ??tre positif
        $annee = $interval->format('%y') * 1; // on *1 pour avoir un int
        return $annee;
    }

    /**
     * methode pour pour calculer la prime salaire
     *
     * @return  double  le montant de la prime salaire
     */
    private function primeSalaire()
    {
        return $this->getSalaireAnnuel() * 1000 * 0.05; // on retourne le montant de la prime annuelle
    }

    /**
     * methode pour pour calculer la prime d'anciennet??
     *
     * @return   double le montant de la prime d'anciennet??
     */
    private function primeAnciennete()
    {
        return $this->getSalaireAnnuel() * 1000 * 0.02 * $this->anciennete(); // on retourne le montant de la prime annuelle
    }

    /**
     * methode pour pour calculer la prime annuelle
     *
     * @return  double  le montant de la prime annuelle
     *
     *
     */
    public function prime()
    {
        return $this->primeSalaire() + $this->primeAnciennete(); // on retourne le montant de la prime annuelle
    }
    /**
     * Renvoi la masse salariale de l'employ??
     *
     * @return int
     */
    public function masseSalariale()
    {
        return $this->getSalaireAnnuel() * 1000 + $this->prime();
    }

    /**
     *
     * verifie si l'employ?? est eligible aux cheques vacances
     *
     * @return string oui ou non selon si l'employ?? est eligible ou pas
     */
    public function recoitChequeVacances()
    {

        return ($this->anciennete() >= 1); // on verifie par rapport a l'anciennete si l employ?? est dans l'entreprise depuis plus d'un an
    }
    /**
     * renvoi un tableau contenant le nombre de ch??que de chaque montant
     *
     * @return array
     */
    public function recoitChequeNoel()
    {
        $cheque = ["0" => 0, "20" => 0, "30" => 0, "50" => 0];
        foreach ($this->getEnfants() as $enfant)
        {
            $cheque[$enfant->montantChequeNoel()] += 1; // on augmente la valeur li??e ?? l'??tiquette correspondant au montant retourn?? par la fonction
        }
        $cheque["0"] = 0;       // pour que la somme du tableau corresponde au nombre de ch??ques ?? distibuer
        return $cheque;
    }

}
