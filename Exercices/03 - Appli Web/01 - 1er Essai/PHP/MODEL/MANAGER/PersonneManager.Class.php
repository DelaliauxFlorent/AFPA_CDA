<?php
class PersonneManager{
    ////////////////////////////////////
    // Attributs

    //private $_;

    ////////////////////////////////////
    #region Accesseurs

    

    #endregion Accesseurs
    ////////////////////////////////////

    /**
     * Récupérer toutes les personnes
     *
     * @return void
     */
    public static function GetAllPersonnes()
    {
        $stmt = DbConnect::getDb()->prepare("
        SELECT * FROM personnes
        ");
        $stmt->execute();
        $result=$stmt->fetchAll(PDO::FETCH_ASSOC);
        foreach ($result as $personne) {
            $ListPersonnes[] = new Personne($personne);
        }
        return $ListPersonnes;
    }

    /**
     * Récupérer une personne précise
     *
     * @param integer $idVoulu
     * @return void
     */
    public static function GetPersonneById(int $idVoulu)
    {
        $stmt = DbConnect::getDb()->prepare("
        SELECT * FROM personnes WHERE id=:idVoulu
        ");
        $stmt->bindValue(':idVoulu', $idVoulu, PDO::PARAM_INT);
        $stmt->execute();
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
    public static function AddPersonne(string $nom = null, string $prenom =null, int $codePostal =null, string $adresse, string $ville)
    {
        $stmt = DbConnect::getDb()->prepare("
        INSERT INTO personnes VALUES (null, :nom, :prenom, :codePostal, :adresse, :ville)
        ");
        $stmt->bindValue(":nom",$nom,PDO::PARAM_STR);
        $stmt->bindValue(":prenom",$prenom,PDO::PARAM_STR);
        $stmt->bindValue(":codePostal",$codePostal,PDO::PARAM_INT);
        $stmt->bindValue(":adresse",$adresse,PDO::PARAM_STR);
        $stmt->bindValue(":ville",$ville,PDO::PARAM_STR);
        $stmt->execute();
    }

    public static function UpdatePersonne(int $id, string $nom = null, string $prenom=null, int $codePostal=null, string $adresse = null, string $ville=null)
    {
        $champs=["nom", "prenom", "codePostal", "adresse", "ville"];
        $params=[$nom, $prenom, $codePostal, $adresse, $ville];
        $liste=[];
        $sql = "UPDATE personnes SET ";
        $modif=0;
        for ($i=0; $i < count($params); $i++) { 
            if($params[$i]!=null){
                $sql.=$champs[$i]."=:".$champs[$i].",";
                $liste[]=$i;
                $modif++;
            }
        }
        if($modif!=0){
            $sql=substr($sql, 0,-1)." WHERE id = :id";
            var_dump($sql);
            $stmt = DbConnect::getDb()->prepare($sql);
            for ($i=0; $i < count($liste); $i++) { 
                $stmt->bindValue(":".$champ[$liste[$i]], $params[$liste[$i]], )
            }
            $stmt->bindValue(":id", $id, PDO::PARAM_INT);
            //$stmt->bindValue(":nom", $nom, PDO::PARAM_STR);
            $stmt->bindValue(":prenom", $prenom, PDO::PARAM_STR);
            //$stmt->bindValue(":codePostal", $codePostal, PDO::PARAM_INT);
            $stmt->bindValue(":adresse", $adresse, PDO::PARAM_STR);
            $stmt->bindValue(":ville", $ville, PDO::PARAM_STR);
            return $stmt->execute();            
        }
    }

}