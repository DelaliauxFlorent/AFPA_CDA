<?php
class PersonneManager{

    private const TABLE = "Personnes";

    /**
     * Récupérer toutes les personnes
     *
     * @return Personnes[]
     */
    public static function GetAllPersonnesTest()
    {
        $colonnes=["nom", "prenom"];
        $conditions=["nom"=>"%e"];
        $orderby="nom, prenom DESC";
        $limit="0,50";
        return DAO::select($colonnes, self::TABLE, $conditions,null,null, false, true);
    }
    public static function GetAllPersonnes()
    {
        return DAO::select(null, self::TABLE);
    }
    /**
     * Récupérer une personne précise
     *
     * @param integer $idVoulu
     * @return Personnes
     */
    // public static function GetPersonneById(int $idVoulu)
    // {
    //     return DAO::GetById(self::TABLE, $idVoulu);
    // }

    /**
     * Ajouter une personne
     *
     * @param Personnes $personne
     * @return void
     */
    public static function AddPersonne(Personnes $personne)
    {
        return DAO::Create($personne);
    }

    /**
     * Mise à jour d'une personne
     *
     * @param Personnes $personne
     * @return void
     */
    public static function UpdatePersonne(Personnes $personne)
    {
        return DAO::Update($personne);
    }

    /**
     * Suppression d'une personne
     *
     * @param Personnes $personne
     * @return void
     */
    public static function DeletePersonne(Personnes $personne)
    {
        return DAO::Delete($personne);
    }

}