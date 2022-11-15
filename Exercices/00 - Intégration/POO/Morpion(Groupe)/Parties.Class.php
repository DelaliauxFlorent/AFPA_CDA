<?php

class Parties
{

    /*****************Attributs***************** */

    private $_nbJoueur;
    private $_nbAlignes;
    private $_listeJoueurs;

    /*****************Accesseurs***************** */

    #region
    //////////

    /**
     * Get the value of _nbJoueur
     */ 

    public function getNbJoueur()
    {
        return $this->_nbJoueur;
    }

    /**
     * Set the value of _nbJoueur
     *
     * @return  self
     */ 
    public function setNbJoueur($nbJoueur)
    {
        $this->_nbJoueur = $nbJoueur;

        return $this;
    }

        /**
     * Get the value of _nbAlignes
     */ 
    public function getNbAlignes()
    {
        return $this->_nbAlignes;
    }

    /**
     * Set the value of _nbAlignes
     *
     * @return  self
     */ 
    public function setNbAlignes($nbAlignes)
    {
        $this->_nbAlignes = $nbAlignes;

        return $this;
    }
    public function getListeJoueurs()
    {
        return $this->_listeJoueurs;
    }

    public function setListeJoueurs($listeJoueurs) // mis a jour par tableau entier
    {
        $this->_listeJoueurs = $listeJoueurs;
    }
    public function addListeJoueurs(Joueurs $joueur) // mis a jour par ajout d'une case
    {
        $this->_listeJoueurs[] = $joueur;
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
     * @return 
     */
    private function initPartie()
    {

        $taillePlateau = Affichages::demandeTaillePlateau(); //Affiche la demande de taille du plateau
        $plateau = new Plateaux(); //Instantie le plateau

        $plateau->setDimX($taillePlateau["dimX"]); //Donne la dimension du plateau sur l'axe X
        $plateau->setDimY($taillePlateau["dimY"]);//Donne la dimension du plateau sur l'axe Y
        $plateau->creerTableau(); //Créer le plateau de jeu

        $this->setNbAlignes(Affichages::demandeNbAlignes());

        $this->setNbJoueur(Affichages::demandeNbJoueurs());//Demande le nombre de joueur

        
        for ($i=0; $i < $this->getNbJoueur(); $i++) { //Demande et définie les infos de chaque joueur
            $this->addListeJoueurs( Affichages::demandeInfoJoueur()); // Demande le nom et le signe du joueur 
           
        }
/*****************  JEU DE TESTS ******************* */
// $plateau= new Plateaux(["dimX"=>3,"dimY"=>3]);
// $plateau->creerTableau();
// $this->setNbAlignes(3);
// $this->setNbJoueur(2);
// $this->addListeJoueurs( new Joueurs(["nom"=>"moi","signe"=>"X","couleur"=>"0;31"]));
// $this->addListeJoueurs( new Joueurs(["nom"=>"toi","signe"=>"O","couleur"=>"0;34"]));
        return $plateau;
    }

    /**
     * Lance la partie
     * @param Plateaux $plateau
     * @param Joueurs $joueur
     * @return Void
     */
    public function lancerPartie()
    {
        $plateau=$this->initPartie(); //Initie la partie
        $joueurEnCours = null;
        $gagne = false;
        $plein = false;
        do{
            Affichages::affichePlateau($plateau); //Affiche le plateau
            // on change de joueur ou on définit le premier;
            //var_dump($plateau);
            $joueurEnCours = $this->prochainJoueur($joueurEnCours);
            Affichages::afficheInviteJoueur($joueurEnCours); //Affiche qui joue
            $position = Affichages::demandePosition($plateau); //Demande au joueur sur quelle case il joue
            // on affecte le joueur à la case
            $plateau->getTableau()[$position['posY']][$position['posX']]->setContenu($joueurEnCours);
            // test fait dans demande position
            // if($plateau->caseExiste() && !$case->estVide()){ //Si le joueur peut jouer sur la case
            //     $case->setPosX($position["posX"]); //Position où le joueur décide de jouer en X
            //     $case->setPosY($position["posY"]); //Position où le joueur décide de jouer en Y
            // }

            // $nbAligne = $plateau->estAligne($position['posX'],$position['posY'], $plateau->getDimX(), $plateau->getDimY()); //Vérifie l'alignement autour de la case
               $gagne = $this->estGagne($plateau,$position['posX'],$position['posY']);
               $plein = $plateau->estPlein();
        }
        while(!$plein && !$gagne); //Tant que la partie n'est pas finie
     
        Affichages::afficheResultat($joueurEnCours,$gagne); //Affiche le resultat de la partie
    }

    /**
     * Renvoie si la partie est gagnée
     * 
     * Si le 3 signes sont alignés
     * 
     * @return Bool
     */
    public function estGagne($plateau,$posX,$posY)
    {
        $aDroite = $plateau->estAligne($posX,$posY,1,0);
        $aGauche = $plateau->estAligne($posX,$posY,-1,0);
        $enHaut = $plateau->estAligne($posX,$posY,0,-1);
        $enBas = $plateau->estAligne($posX,$posY,0,1);
        $hautDroit = $plateau->estAligne($posX,$posY,1,-1);
        $basGauche = $plateau->estAligne($posX,$posY,-1,1);
        $hautGauche = $plateau->estAligne($posX,$posY,-1,-1);
        $basDroit = $plateau->estAligne($posX,$posY,1,1);
        return( $aDroite+$aGauche >$this->getNbAlignes() // horizontal
        || $enBas+$enHaut >$this->getNbAlignes()      // vertical
        || $hautDroit + $basGauche > $this->getNbAlignes() // 1ere diag
        || $hautGauche + $basDroit > $this->getNbAlignes()
    );
    }

    /**
     * 
     *
     * @return Joueurs le joueur qui doit jouer
     */
    public function prochainJoueur(Joueurs $j=null)
    {
        if($j==null){
            return $this->getListeJoueurs()[ rand(0,$this->getNbJoueur()-1)];
        }

        return $this->getListeJoueurs()[($j->getNum()+1)%($this->getNbJoueur())];
    }

    
}