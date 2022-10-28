<?php

class Parties
{

    /*****************Attributs***************** */
    private $_compteur;
    private $_nbJoueur;
    private $_nbAlignes;

    /*****************Accesseurs***************** */

    #region
  //////////

    /**
     * Get the value of _compteur
     */ 
    public function get_compteur()
    {
        return $this->_compteur;
    }

    /**
     * Set the value of _compteur
     *
     * @return  self
     */ 
    public function set_compteur($_compteur)
    {
        $this->_compteur = $_compteur;

        return $this;
    }

    /**
     * Get the value of _nbJoueur
     */ 

    public function get_nbJoueur()
    {
        return $this->_nbJoueur;
    }

    /**
     * Set the value of _nbJoueur
     *
     * @return  self
     */ 
    public function set_nbJoueur($_nbJoueur)
    {
        $this->_nbJoueur = $_nbJoueur;

        return $this;
    }

        /**
     * Get the value of _nbAlignes
     */ 
    public function get_nbAlignes()
    {
        return $this->_nbAlignes;
    }

    /**
     * Set the value of _nbAlignes
     *
     * @return  self
     */ 
    public function set_nbAlignes($_nbAlignes)
    {
        $this->_nbAlignes = $_nbAlignes;

        return $this;
    }

      //////////
#endregion

    /*****************Constructeur***************** */

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

    /*****************Autres Méthodes***************** */

    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function toString()
    {
        return "";
    }

    
    /**
     * Initialise la partie
     *
     * @return Void
     */
    private function initPartie()
    {

        $taillePlateau = Affichages::demandeTaillePlateau(); //Affiche la demande de taille du plateau
        $plateau = new Plateaux(); //Instantie le plateau

        $plateau->setDimX($taillePlateau["dimX"]); //Donne la dimension du plateau sur l'axe X
        $plateau->setDimY($taillePlateau["dimY"]);//Donne la dimension du plateau sur l'axe Y
        $plateau->creerTableau(); //Créer le plateau de jeu

        $this->set_nbAlignes(Affichages::demandeNbAlignes());

        $this->set_nbJoueur(Affichages::demandeNbJoueur());//Demande le nombre de joueur

        $table = [];
        $joueur = new Joueurs(); //Crée les joueurs

        for ($i=1; $i < $this->get_nbJoueur(); $i++) { //Demande et définie les infos de chaque joueur
            $table = Affichages::demandeInfoJoueur(); // Demande le nom et le signe du joueur 
            $joueur->setNom($table[$i]["nom"]); //Définie le nom du joueur
            $joueur->setSigne($table[$i]["signe"]); //Définie le signe du joueur
        }

        return [$plateau, $joueur];
    }

    /**
     * Lance la partie
     * @param Plateaux $plateau
     * @param Joueurs $joueur
     * @return Void
     */
    public static function lancerPartie(Plateaux $plateau, Joueurs $joueur)
    {
        self::initPartie(); //Initie la partie

        $case = new Cases(); //Instantie les cases

        $fini = false;

        // do{
        //     for ($i=1; $i < self::get_nbJoueur(); $i++){ //Tour de jeu de chaque joueur
                
        //         Affichages::affichePlateau($plateau->getTableau()); //Affiche le plateau
        //         Affichages::afficheInviteJoueur($joueur[$i]); //Affiche qui joue
        //         $position = Affichages::demandePosition($plateau); //Demande au joueur sur quelle case il joue

        //         if($plateau->caseExiste() && !$case->estVide()){ //Si le joueur peut jouer sur la case
        //             $case->setPosX($position["posX"]); //Position où le joueur décide de jouer en X
        //             $case->setPosY($position["posY"]); //Position où le joueur décide de jouer en Y
        //         }

        //         $nbAligne = $plateau->estAligne($case->getPosX(), $case->getPosY(), $plateau->getDimX(), $plateau->getDimY()); //Vérifie l'alignement autour de la case
                
        //         if(!$plateau->estPlein() || !self::estGagne($nbAligne)){ //Tant que la partie n'est pas finie
        //             $fini=true;
        //         }

        //         self::prochainJoueur();
        //     }
        // }
        // while(!$fini); //Tant que la partie n'est pas finie

        $premierJoueur=$this->prochainJoueur();
        do{
            for ($i=$premierJoueur; $i < $this->get_nbJoueur(); $i++) {  
                Affichages::affichePlateau($plateau->getTableau()); //Affiche le plateau
                Affichages::afficheInviteJoueur($joueur[$i]); //Affiche qui joue
                $position = Affichages::demandePosition($plateau); //Demande au joueur sur quelle case il joue

                if($plateau->caseExiste() && !$case->estVide()){ //Si le joueur peut jouer sur la case
                    $case->setPosX($position["posX"]); //Position où le joueur décide de jouer en X
                    $case->setPosY($position["posY"]); //Position où le joueur décide de jouer en Y
                }

                $nbAligne = $plateau->estAligne($case->getPosX(), $case->getPosY(), $plateau->getDimX(), $plateau->getDimY()); //Vérifie l'alignement autour de la case
                
                if(!$plateau->estPlein() || !self::estGagne($nbAligne)){ //Tant que la partie n'est pas finie
                    $fini=true;
                }

                self::prochainJoueur();
            }
            $i=1;
        }
        while(!$fini) //Tant que la partie n'est pas finie
        

        Affichages::afficheResultat();
    }

    /**
     * Renvoie si la partie est gagnée
     * 
     * Si le 3 signes sont alignés
     * 
     * @return Bool
     */
    public function estGagne($nbAlignes)
    {
        if($nbAlignes >= $this->get_nbAlignes()){ //Si la methode renvoie vrai
            return true; // La partie est gagnée
        }
        return false; // Personne n'a gagné
    }

    /**
     * 
     *
     * @return Int
     */
    public function premierJoueur()
    {

        return 2;
    }
}