<?php

class Plateaux
{

    /*****************Attributs***************** */
    private $_dimX;
    private $_dimY;
    private $_tableau;

    /*****************Accesseurs***************** */

    public function getDimX()
    {
        return $this->_dimX;
    }

    public function setDimX($dimX)
    {
        $this->_dimX = $dimX;
    }

    public function getDimY()
    {
        return $this->_dimY;
    }

    public function setDimY($dimY)
    {
        $this->_dimY = $dimY;
    }

    public function getTableau()
    {
        return $this->_tableau;
    }

    public function setTableau($tableau)
    {
        $this->_tableau = $tableau;
    }

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
        foreach ($data as $key => $value) {
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
    public function __toString()
    {
        return "Plateau " . $this->getDimX() . " " . $this->getDimY();
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
     *  Permet de créer un tableau à 2 dimensions
     * @return array renvoi le tableau
     */

    public function creerTableau()
    {

        $tab = [];

        for ($i = 0; $i < $this->getDimY(); $i++) {
            for ($j = 0; $j < $this->getDimX(); $j++) {
                $tab[$i][$j] = new Cases(["posX" => $j, "posY" => $i, "contenu" => new Joueurs()]);
            }
        }

        $this->setTableau($tab); // on affecte le tableau a l'attribut
    }

    public function caseExiste($y, $x)
    {
        // if ($x >= 0 && $y >= 0){
        //     return ($y > $this->getDimY() || $x > $this->getDimX()) ? 0 : 1;
        // }
        // else return 0;
        return ($x >= 0 && $y >= 0 && $y < $this->getDimY() && $x < $this->getDimX());
    }

    public function estPlein()
    {
        foreach ($this->getTableau() as $key => $tabCases) {
            foreach ($tabCases as $cases) {
                if ($cases->getContenu()->getSigne() == "") {
                    return false;
                }
            }
        }
        return true;
    }

    /**
     * renvoi le nombre de cases alignés dans un sens de direction avec le même signe
     *
     * @param int $posX position de la case
     * @param int $posY position de la case
     * @param int $dirX direction sur l'axe des abscisses
     * @param int $dirY direction sur l'axe des ordonnées
     * @return int nombre de cases alignées
     */
    public function estAligne($posX, $posY, $dirX, $dirY)
    {
        $newPosX = $posX + $dirX; //Calcul de la position direction X
        $newPosY = $posY + $dirY; //Calcul de la position direction Y
        if ($this->caseExiste($newPosY, $newPosX)) { //determine le signe actuelle de la case
            $signe = ($this->getTableau()[$posY][$posX])->getContenu()->getSigne(); //Recuperation du tableau PositionX et Position Y
            $signeDir = ($this->getTableau()[$newPosY][$newPosX])->getContenu()->getSigne();
            //Recuperation du tableau NewPositionX et NewPositionY
            if ($signe == $signeDir) {
                $posX = $newPosX; // nouvelles positions
                $posY = $newPosY;
                return 1 + $this->estAligne($posX, $posY, $dirX, $dirY); //relance
            } else {
                return 1;
            }
        } else {
            return 1;
        }
    }
}
