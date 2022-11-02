<?php
class Livrets extends Comptes{
    
    public function appliqueInteret()
    {
        $montantActu=$this->getMontant();
        $nouveauMontant=$montantActu+($montantActu/20);
        $this->setMontant($nouveauMontant);
    }
}