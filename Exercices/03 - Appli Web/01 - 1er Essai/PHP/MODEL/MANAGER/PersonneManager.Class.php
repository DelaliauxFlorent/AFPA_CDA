<?php
class PersonneManager{
    ////////////////////////////////////
    // Attributs

    //private $_;

    ////////////////////////////////////
    #region Accesseurs

    

    #endregion Accesseurs
    ////////////////////////////////////

    public static function GetAllPersonnes()
    {
        $stmt = DbConnect::getDb()->prepare("
        SELECT * FROM Personnes
        ");
        $stmt->execute();
        $result=$stmt->fetchAll(PDO::FETCH_ASSOC);
        foreach ($result as $personne) {
            $ListPersonnes[] = new Personne($personne);
        }
        return $ListPersonnes;
    }

    public static function GetPersonneById(int $idVoulu)
    {
        $stmt = DbConnect::getDb()->prepare("
        SELECT * FROM Personnes WHERE id=:idVoulu
        ");
        $stmt->execute([
            ":idVoulu"=>$idVoulu
        ]);
        $individu=new Personne($stmt->fetch(PDO::FETCH_ASSOC));
        return $individu;
    }

    /**
     * Ajouter une personne
     *
     * @param [string] $nom
     * @param [string] $prenom
     * @param [int] $codePostal
     * @param [string] $adresse
     * @param [string] $ville
     * @return void
     */
    public static function AddPersonne($nom = null, $prenom =null, $codePostal =null, $adresse, $ville)
    {
        $stmt = DbConnect::getDb()->prepare("
        INSERT INTO PERSONNES VALUES (null, :nom, :prenom, :codePostal, :adresse, :ville)
        ");
        $stmt->execute([
            ":nom"=>$nom,
            ":prenom"=>$prenom,
            ":codePostal"=>$codePostal,
            ":adresse"=>$adresse,
            ":ville"=>$ville
        ]);
    }
}