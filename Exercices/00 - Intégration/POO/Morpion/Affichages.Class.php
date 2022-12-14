<?php

class Affichages
{

    /*****************Attributs***************** */

    private static $_listeCouleur = array(
        "Gris Foncé"=>"1;30", 
        "Rouge"=>"0;31", 
        "Rose"=>"1;31", 
        "Vert"=>"0;32", 
        "Vert Clair"=>"1;32",
        "Marron"=>"0;33",
        "Jaune"=>"1;33",
        "Bleu"=>"0;34",
        "Bleu Ciel"=>"1;34",
        "Violet"=>"0;35",
        "Violet Clair"=>"1;35",
        "Cyan"=>"0;36",
        "Cyan Clair"=>"1;36",
        "Gris Clair"=>"1;37");
    
    /*****************Accesseurs***************** */

    
    public static function getListeCouleur()
    {
        return self::$_listeCouleur;
    }

    public static function setListeCouleur($listeCouleur)
    {
        self::$_listeCouleur = $listeCouleur;
    }
    
    /*****************Constructeur***************** */

    /*****************Autres Méthodes***************** */

    /**
     * Fonction d'affichage du tableau
     * @param Plateaux $plateau
     */
    
    public static function afficheTableau(Plateaux $plateau){
        $tirret = "+---";

        for ($i = 1; $i < $plateau->getDimX(); $i++){
            $tirret .= "+---";
        }

        echo $tirret."+"."\n";

        foreach ($plateau->getTableau() as $numCol => $colonne) {
            echo "|";
            foreach ($colonne as $case ) {
                if ($case->getContenu() == null){
                    echo "   |";
                }
                else{
                    echo " ".$case->getContenu()." |";
                } 
            }
            echo "\n".$tirret."+"."\n";
        }
    }

    /**
     *  Affiche le nom du joueur
     * @param Joueurs $joueur
     */
    public static function afficheInviteJoueur(Joueurs $joueur){
        echo "C'est à " . $joueur->getNom() . " de jouer !";
    }

    /**
     * Affiche qui a gagné la partie
     * @param Joueurs $joueur
     */
    public static function afficheResultat(Joueurs $joueur){
        echo "Le joueur " . $joueur->getNom() . "a gagné";
    }

    //////////
    #region test en cour Florent

    //Manque méthode PlateaucaseExiste pour test
    /**
     * [Demande au joueur la case où il veut insérer son signe]
     *
     * @param   Plateaux  [le plateau de la partie en cour]
     *
     * @return  array     [retourne un tableau assoc contenant "posX" et "posY"]
     */
    public static function demandePosition(Plateaux $plateau)
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
                    echo "Erreur: Entrez un entier positif!\n";
                    $errorX=true;
                }
                //
                //////////////////////////////////////////////////////
                elseif(!$plateau->caseExiste(0, $posX)){
                    echo "Erreur: Cette colonne n'existe pas!\n";
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
                    echo "Erreur: entrez un entier positif!\n";
                    $errorY=true;
                }
                //
                //////////////////////////////////////////////////////
                elseif(!$plateau->caseExiste($posY, 0)){
                    echo "Erreur: Cette ligne n'existe pas!\n";
                    $errorY=true;
                }
            }while($errorY);
            $position=array("posX"=>$posX,"posY"=>$posY);
            $caseTeste=$plateau->getTableau()[$posX][$posY];
            if(!$caseTeste->estVide()){
                echo "\tErreur: Cette case n'est pas vide!\n";
            }
            
        }while(!$caseTeste->estVide());
        
        return $position;
    }

    /**
     * [Demande (et vérifie) les données joueur]
     *
     * @return  array  [retourne un tableau assoc avec "nom", "signe" et "Couleur" choisi]
     */
    public static function demandeInfoJoueur()
    {
        $caractInterdit=array(""," ");
        $nomJoueur=readline("Quel est votre nom? ");
        $charactError=false;
        do{
            $signe=readline("Quel caractère voulez-vous utiliser? ");
            if(in_array($signe, $caractInterdit)){
                $charactError=true;
                echo "\tErreur: Caractère invalide.";
            }elseif(Joueurs::signeExiste($signe)){
                $charactError=true;
                echo "\tErreur: Ce caractère est déjà utilisé par un autre joueur.\n";
            }elseif(strlen($signe)>1){
                $charactError=true;
                echo "\tErreur: Veuillez n'entrer qu'un seul caractère.\n";
            }
            ///////////////////////////////////////
            // A commenter si chiffres autorisés
            elseif(is_numeric($signe)){
                $charactError=true;
                echo "\tErreur: Vous ne pouvez pas choisir un chiffre en tant que caractère.\n";
            }
        }while($charactError);
        $listeCouleurs="Les couleurs autorisées sont: ";
        foreach(self::getListeCouleur() as $coul=>$value){
            $listeCouleurs.=$coul.", ";
        }
        $listeCouleurs=substr($listeCouleurs,0,-2);
        $listeCouleurs.=".\n";

        do{
            echo $listeCouleurs;
            $couleur=readline("Quel couleur voulez-vous utiliser? ");
            if(!array_key_exists(strtolower($couleur), array_change_key_case(self::getListeCouleur()))){
                echo "Erreur: Couleur inconnue. Vérifiez l'othographe. Vous aviez tapé: ".$couleur."\n";
            }
        }while(!array_key_exists(strtolower($couleur), array_change_key_case(self::getListeCouleur())));

        ///////////////////////////////////////
        // Retourne valeur couleur en string
        //return array("nom"=>$nomJoueur, "signe"=>$signe, "Couleur"=>ucwords(strtolower($couleur)));

        ///////////////////////////////////////
        // Retourne valeur couleur avec code 
        return array("nom"=>$nomJoueur, "signe"=>$signe, "Couleur"=>self::getListeCouleur()[ucwords(strtolower($couleur))]);
    }
    #endregion
    ///////////////

}