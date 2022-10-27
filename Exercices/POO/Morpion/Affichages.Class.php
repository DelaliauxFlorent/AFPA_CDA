<?php
class Affichages{
    
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
        return "";
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
    * @return void
    */
    public static function compareTo($obj1, $obj2)
    {
        return 0;
    }


    /**
     * [demandePosition description]
     *
     * @param   Plateaux  $Plateau  [$Plateau description]
     *
     * @return  array of int           [return postition de la case]
     */
    public static function demandePosition($Plateau)
    {
        
        do{
            do{
                $posX=readline("Indiquez la colonne: ");
                if(!is_numeric($posX)){
                    echo "Erreur: Entrée invalide!\n";
                }elseif(!ctype_digit($posX)){
                    echo "Erreur: Entrez un entier!\n";
                }elseif($Plateau->caseExiste([0, $posX])){
                    echo "Erreur: Cette colonne n'existe pas!";
                }
            }while($Plateau->caseExiste([0, $posX]));
            do{
                $posY=readline("Indiquez la ligne: ");
                if(!is_numeric($posY)){
                    echo "Erreur: entrée invalide!\n";
                }elseif(!ctype_digit($posY)){
                    echo "Erreur: entrez un entier!\n";
                }elseif($Plateau->caseExiste([$posY, 0])){
                    echo "Erreur: Cette ligne n'existe pas!";
                }
            }while($Plateau->caseExiste([$posY, 0]));
            $position=array("posX"=>$posX,"posY"=>$posY);
            $caseTeste=new Cases($position);
            if(!$caseTeste->estVide()){
                echo "Erreur, cette case n'est pas vide";
            }
            
        }while(!$caseTeste->estVide());
        
        return $position;
    }

    public static function demandeInfoJoueur()
    {
        $nomJoueur=readline("Quel est votre nom? ");
        do{
            $signe=readline("Quel caractère voulez-vous utiliser? ");
            if(Joueur::getSigneExiste($signe)){
                echo "\tErreur: Ce caractère est déjà utilisé par un autre joueur.\n";
            }
        }while(Joueur::getSigneExiste($signe));

    }
}