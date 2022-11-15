<?php

class Affichages
{

    /*****************Attributs***************** */

    private static $_listeCouleur = array(
        "gris foncé"=>"1;30", 
        "rouge"=>"0;31", 
        "rose"=>"1;31", 
        "vert"=>"0;32", 
        "vert clair"=>"1;32",
        "marron"=>"0;33",
        "jaune"=>"1;33",
        "bleu"=>"0;34",
        "bleu ciel"=>"1;34",
        "violet"=>"0;35",
        "violet clair"=>"1;35",
        "cyan"=>"0;36",
        "cyan clair"=>"1;36",
        "gris clair"=>"1;37");
    
    /*****************Accesseurs***************** */
    public static function getListeCouleur()
    {
        return self::$_listeCouleur;
    }
    /*****************Constructeur***************** */

    /*****************Autres Méthodes***************** */

    /**
     * Fonction d'affichage du tableau
     * @param Plateaux $plateau
     */
    
    public static function affichePlateau(Plateaux $plateau){
        $tirret = "+---";
        $color = "";

        for ($i = 1; $i < $plateau->getDimX(); $i++){
            $tirret .= "+---";
        }

        echo $tirret."+"."\n";

        foreach ($plateau->getTableau() as $numCol => $colonne) {
            echo "|";
            foreach ($colonne as $case ) {
                $color = $case->getContenu()->getCouleur();
                if ($case->getContenu()->getSigne() == null){
                    echo "   |";
                }
                else{
                    // on affiche le signe en couleur sur fonc noir
                    echo " \e[".$color.";40m".$case->getContenu()->getSigne()."\e[0m |";
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
    public static function afficheResultat(Joueurs $joueur,bool $gagne=true){
        if ($gagne)
        echo "Le joueur " . $joueur->getNom() . "a gagné";
        else
        echo "Partie terminée";

    }

    //////////
    #region test en cour Florent

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
            $caseTeste=$plateau->getTableau()[$posY][$posX];
            if(!$caseTeste->estVide()){
                echo "\tErreur: Cette case n'est pas vide!\n";
            }
            
        }while(!$caseTeste->estVide());
        
        return $position;
    }

    /**
     * [Demande (et vérifie) les données joueur]
     *
     * @return  Joueurs   retourne un joueur
     */
    public static function demandeInfoJoueur()
    {
        $j = new Joueurs();
        $caractInterdit=array(""," ");
        $j->setNom(readline("Quel est votre nom? "));
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
        $j->setSigne($signe);
        $listeCouleurs="Les couleurs autorisées sont: ";
        foreach(self::getListeCouleur() as $coul=>$value){
            $listeCouleurs.=$coul.", ";
        }
        $listeCouleurs=substr($listeCouleurs,0,-2);
        $listeCouleurs.=".\n";

        do{
            echo $listeCouleurs;
            $couleur=readline("Quel couleur voulez-vous utiliser? ");
            if(!array_key_exists(strtolower($couleur), self::getListeCouleur())){
                echo "Erreur: Couleur inconnue. Vérifiez l'othographe. Vous aviez tapé: ".$couleur."\n";
            }
        }while(!array_key_exists(strtolower($couleur), self::getListeCouleur()));
        $j->setCouleur(self::getListeCouleur()[$couleur]);
        ///////////////////////////////////////
        // Retourne valeur couleur en string
        //return array("nom"=>$nomJoueur, "signe"=>$signe, "Couleur"=>ucwords(strtolower($couleur)));

        ///////////////////////////////////////
        // Retourne valeur couleur avec code 
        return $j;
    }
    #endregion
    ///////////////
    /**
     * 
     * @param 
     * @return int
     * 
     */
    public static function demandeNbAlignes()
    {
        
        do {
            $nombreAlignes= readline("entre un nombre de cases à aligner pour gagner:");
        } while (!is_numeric($nombreAlignes));
        return $nombreAlignes;
    }

    /**
     * Fonction demandant et retournant le nombre de joueurs
     *
     * @return int
     */
    public static function demandeNbJoueurs()
    {
        do {
            $nbJoueurs = readline("Combien de joueurs participent ? ");
        } while (!is_numeric($nbJoueurs) || intval($nbJoueurs) < 2);
        return $nbJoueurs * 1;
    }

    /**
     * Demande les dimensions du plateau (lignes puis colonnes)
     *
     * @return array 
     */
    public static function demandeTaillePlateau()
    {      
        do {
            $dimX = readline("Combien de lignes pour le plateau : ");
        } while (!is_numeric($dimX) || intval($dimX) < 1);
        do {
            $dimY = readline("Combien de colonnes pour le plateau : ");
        } while (!is_numeric($dimY) || intval($dimY) < 1);
        return ["dimX" => $dimX* 1, "dimY" => $dimY * 1];
    }
}