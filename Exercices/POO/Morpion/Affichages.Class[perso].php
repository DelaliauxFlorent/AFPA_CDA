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
     * [Demande au joueur la case où il veut insérer son signe]
     *
     * @param   Plateaux  [le plateau de la partie en cour]
     *
     * @return  array     [retourne un tableau assoc contenant "posX" et "posY"]
     */
    public static function demandePosition(Plateaux $Plateau)
    {
        
        do{
            do{
                $posX=readline("Indiquez la colonne: ");
                $errorX=false;
                //////////////////////////////////////////////////////
                // A changer si colonne devient lettre au lieu de chiffre (tableau associatif)
                if(!is_numeric($posX)){
                    echo "Erreur: Entrée invalide!\n";
                    $errorX=true;
                }elseif(!ctype_digit($posX)){
                    echo "Erreur: Entrez un entier!\n";
                    $errorX=true;
                }
                //
                //////////////////////////////////////////////////////
                elseif(!$Plateau->caseExiste([0, $posX])){
                    echo "Erreur: Cette colonne n'existe pas!";
                    $errorX=true;
                }
            }while($errorX);
            do{
                $posY=readline("Indiquez la ligne: ");
                $errorY=false;
                //////////////////////////////////////////////////////
                // A changer si ligne devient lettre au lieu de chiffre (tableau associatif)
                if(!is_numeric($posY)){
                    echo "Erreur: entrée invalide!\n";
                    $errorY=true;
                }elseif(!ctype_digit($posY)){
                    echo "Erreur: entrez un entier!\n";
                    $errorY=true;
                }
                //
                //////////////////////////////////////////////////////
                elseif(!$Plateau->caseExiste([$posY, 0])){
                    echo "Erreur: Cette ligne n'existe pas!";
                    $errorY=true;
                }
            }while($errorY);
            $position=array("posX"=>$posX,"posY"=>$posY);
            $caseTeste=new Cases($position);
            if(!$caseTeste->estVide()){
                echo "\tErreur: Cette case n'est pas vide";
            }
            
        }while(!$caseTeste->estVide());
        
        return $position;
    }

    /**
     * [Demande (et vérifie) les données joueur]
     *
     * @return  array  [retourne un tableau assoc avec "nom" et "signe" choisi]
     */
    public static function demandeInfoJoueur()
    {
        $caractInterdit=array(""," ");
        $nomJoueur=readline("Quel est votre nom? ");
        do{
            $signe=readline("Quel caractère voulez-vous utiliser? ");
            if(in_array($signe, $caractInterdit)){
                echo "\tErreur: Caractère invalide.";
            }
            if(Joueurs::signeExiste($signe)){
                echo "\tErreur: Ce caractère est déjà utilisé par un autre joueur.\n";
            }
        }while(Joueurs::signeExiste($signe)||in_array($signe, $caractInterdit));
        return array("nom"=>$nomJoueur, "signe"=>$signe);
    }
}