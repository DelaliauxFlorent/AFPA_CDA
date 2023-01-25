<?php
class DAO
{
    ////////////////////////////////////
    // Attributs


    ////////////////////////////////////
    #region Accesseurs



    #endregion Accesseurs
    ////////////////////////////////////


    ////////////////////////////////////
    // Autres méthodes

    /**
     * Récupérer toutes les enregistrements
     *
     * @param string $table
     * @return void
     */
    public static function GetAll(string $table)
    {
        $stmt = DbConnect::getDb()->prepare("
        SELECT * FROM " . $table . ";
        ");
        $stmt->execute();
        $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
        foreach ($result as $objet) {
            $ListObjets[] = new $table($objet);
        }
        return $ListObjets;
    }

    /**
     * Récupérer un objet précis
     *
     * @param string $table
     * @param integer $idVoulu
     * @return void
     */
    public static function GetById(string $table, int $idVoulu)
    {
        $temp = new $table();
        $champs = $temp->getNomsChamps();
        $sql="SELECT * FROM " . $table . " WHERE ";
        $sql.=$champs[0]."=:idVoulu;";
        $stmt = DbConnect::getDb()->prepare($sql);
        $stmt->bindValue(':idVoulu', $idVoulu, PDO::PARAM_INT);
        $stmt->execute();
        $individu = new $table($stmt->fetch(PDO::FETCH_ASSOC));
        return $individu;
    }

    /**
     * Ajouter un objet
     *
     * @param [type] $objet
     * @return void
     */
    public static function Create($objet)
    {
        // On récupère la classe de l'objet
        $table = get_class($objet);
        // On commence la requête
        $sql = "INSERT INTO " . $table . " VALUES (null, ";
        // On récupère la liste des champs de l'objet
        $champs = $objet->getNomsChamps();

        // Pour chaque champs, on rempli la requête en conséquence, avec la préparation des bindings
        for ($i = 1; $i < count($champs); $i++) {
            $sql .= ":" . $champs[$i] . ", ";
        }
        // On finalise la requête
        $sql = substr($sql, 0, -2) . ");";

        // On prépare la requête
        $stmt = DbConnect::getDb()->prepare($sql);

        // On effectue les bindings 
        for ($j = 1; $j < count($champs); $j++) {
            // création dynamique des getAttributs()
            $get = "get" . ucfirst($champs[$j]);
            $get = $objet->$get();
            $stmt->bindValue(":" . $champs[$j], $get);
        }
        return $stmt->execute();
    }

    /**
     * Mise à jour d'un objet
     *
     * @param [type] $objet
     * @return void
     */
    public static function Update($objet)
    {
        $table = get_class($objet);
        $champs = $objet->getNomsChamps();

        //Création de la QUERY
        $sql = "UPDATE " . $table . " SET ";
        for ($i = 1; $i < count($champs); $i++) {
            $sql .= $champs[$i] . "=:" . $champs[$i] . ", ";
        }

        // on finalise la QUERY
        $sql = substr($sql, 0, -2) . " WHERE ";
        $sql.= $champs[0] . "=:" . $champs[0].";";
        $stmt = DbConnect::getDb()->prepare($sql);
        // On bind tous les paramètres nécessaires
        for ($i = 0; $i < count($champs); $i++) {            
            $get = "get" . ucfirst($champs[$i]);
            $get = $objet->$get();
            $stmt->bindValue(":" . $champs[$i], $get);
        }
        // et on execute la QUERY
        return $stmt->execute();
    }

    /**
     * Suppression d'un objet
     *
     * @param string $table
     * @param integer $id
     * @return void
     */
    public static function Delete($objet)
    {
        $table = get_class($objet);
        $champs = $objet->getNomsChamps();
        $get = "get" . ucfirst($champs[0]);
        $get = $objet->$get();
        $sql="DELETE FROM " . $table . " WHERE ".$champs[0]."=:id;";
        $stmt = DbConnect::getDb()->prepare($sql);
        $stmt->bindValue(":id", $get, PDO::PARAM_INT);
        return $stmt->execute();
    }
}
