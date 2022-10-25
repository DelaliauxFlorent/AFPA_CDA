<?php

class Voiture{
    private $_couleur;
    private $_marque;
    private $_modele;
    private $_nbKm;
    private $_motorisation;

    //////////////////////////
    // Accesseurs

    public function get_couleur(){
        return $this->_couleur;
    }
    public function set_couleur($couleur){
        $this->_couleur= $couleur;
    }
    public function get_marque(){
        return $this->_marque;
    }
    public function set_marque($marque){
        $this->_marque = $marque;
    }
    public function get_modele(){
        return $this->_modele;
    }
    public function set_modele($modele){
        $this->_modele = $modele;
    }
    public function get_nbKm(){
        return $this->_nbKm;
    }
    public function set_nbKm($nbKm){
        $this->_nbKm = $nbKm;
    }
    public function get_motorisation(){
        return $this->_motorisation;
    }
    public function set_motorisation($motorisation){
        $this->_motorisation = $motorisation;
    }

    //////////////////////////
    // Constructeur
    
    public function __construct($couleur,$marque,$modele,$nbKm,$motorisation)
    {
        $this->set_couleur($couleur);
        $this->set_marque($marque);
        $this->set_modele($modele);
        $this->set_nbKm($nbKm);
        $this->set_motorisation($motorisation);
    }



    ///////////////////////////////////////////////////////////
    // Autres méthodes

    public function description(){
        echo "Cette voiture est un ".$this->_modele." de la marque ".$this->_marque.", de la couleur ".$this->_couleur.", de motorisation ".$this->_motorisation.", avec ".$this->_nbKm." Kilomètres.";
    }
}