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
        /*
        $stmt = DbConnect::getDb()->prepare("
        SELECT * FROM personnes;
        ");
        $stmt->execute();
        $result=$stmt->fetchAll(PDO::FETCH_ASSOC);
        foreach ($result as $personne) {
            $ListPersonnes[] = new Personnes($personne);
        }
        return $ListPersonnes;
        */
        return DAO::GetAll("Personnes");
    }

    /**
     * Récupérer une personne précise
     *
     * @param integer $idVoulu
     * @return void
     */
    public static function GetPersonneById(int $idVoulu)
    {
        /*
        $stmt = DbConnect::getDb()->prepare("
        SELECT * FROM personnes WHERE id=:idVoulu
        ");
        $stmt->bindValue(':idVoulu', $idVoulu, PDO::PARAM_INT);
        $stmt->execute();
        $individu=new Personnes($stmt->fetch(PDO::FETCH_ASSOC));
        return $individu;
        */
        return DAO::GetById("Personnes", $idVoulu);
    }

    /**
     * Ajouter une personne
     *
     * @param Personnes $personne
     * @return void
     */
    public static function AddPersonne(Personnes $personne)
    {
        // $stmt = DbConnect::getDb()->prepare("
        // INSERT INTO personnes VALUES (null, :nom, :prenom, :codePostal, :adresse, :ville)
        // ");
        // $stmt->bindValue(":nom",$nom,PDO::PARAM_STR);
        // $stmt->bindValue(":prenom",$prenom,PDO::PARAM_STR);
        // $stmt->bindValue(":codePostal",$codePostal,PDO::PARAM_INT);
        // $stmt->bindValue(":adresse",$adresse,PDO::PARAM_STR);
        // $stmt->bindValue(":ville",$ville,PDO::PARAM_STR);
        // return $stmt->execute();
        DAO::Create($personne);
    }

    /**
     * Mise à jour d'une personne
     *
     * @param integer $id
     * @param string|null $nom
     * @param string|null $prenom
     * @param integer|null $codePostal
     * @param string|null $adresse
     * @param string|null $ville
     * @return void
     */
    public static function UpdatePersonne(int $id, string $nom = null, string $prenom=null, int $codePostal=null, string $adresse = null, string $ville=null)
    {
        $champs=Personnes::getNomsChamps();
        $params=[$nom, $prenom, $codePostal, $adresse, $ville];

        //Création de la QUERY
        $sql = "UPDATE personnes SET ";
        // - Compteur de modification
        $modif=0;
        for ($i=0; $i < count($params); $i++) { 
            if($params[$i]!=null){
                $sql.=$champs[$i]."=:".$champs[$i].", ";
                $liste[]=$i;
                $modif++;
            }
        }
        // Si au moins 1 modification =>
        if($modif!=0){
            // on finalise la QUERY
            $sql=substr($sql, 0, -2)." WHERE id = :id";
            $stmt = DbConnect::getDb()->prepare($sql);
            // On bind tous les paramètres nécessaires
            $stmt->bindValue(":id", $id, PDO::PARAM_INT);
            for ($i=0; $i < count($params); $i++) { 
                if($params[$i]!=null){
                    $var = ":".$champs[$i];
                    if($champs[$i]=="codePostal"){
                        $stmt->bindValue($var, $params[$i], PDO::PARAM_INT);
                    }else{
                        $stmt->bindValue($var, $params[$i], PDO::PARAM_STR);
                    }
                }
            }
            // et on execute la QUERY
            return $stmt->execute();            
        }
        else{
            // sinon, on retourne faux pour indiquer une erreur
            return false;
        }
    }

    /**
     * Suppression d'une personne
     *
     * @param integer $id
     * @return void
     */
    public static function DeletePersonne(int $id)
    {
        // $stmt = DbConnect::getDb()->prepare("
        //     DELETE FROM personnes WHERE id=:id
        // ");
        // $stmt->bindValue(":id", $id, PDO::PARAM_INT);        
        // return $stmt->execute();  
        return DAO::Delete("Personnes", $id);
    }

}