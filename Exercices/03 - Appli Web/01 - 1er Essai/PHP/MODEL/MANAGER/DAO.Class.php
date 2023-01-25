<?php
class DAO{
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
        SELECT * FROM ".$table.";
        ");
        $stmt->execute();
        $result=$stmt->fetchAll(PDO::FETCH_ASSOC);
        foreach ($result as $objet) {
            $ListObjets[] = new $table ($objet);
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
        $stmt = DbConnect::getDb()->prepare("
        SELECT * FROM ".$table." WHERE id=:idVoulu;
        ");
        $stmt->bindValue(':idVoulu', $idVoulu, PDO::PARAM_INT);
        $stmt->execute();
        $individu=new $table($stmt->fetch(PDO::FETCH_ASSOC));
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
        $sql="INSERT INTO ".$table." VALUES (null, ";
        // On récupère la liste des champs de l'objet
        $champs=$objet->getNomsChamps();

        // Pour chaque champs, on rempli la requête en conséquence, avec la préparation des bindings
        for ($i=1; $i < count($champs); $i++) { 
            $sql.=":".$champs[$i].", ";
        }
        // On finalise la requête
        $sql=substr($sql, 0, -2).");";

        // On prépare la requête
        $stmt = DbConnect::getDb()->prepare($sql);

        // On effectue les bindings 
        for ($j=1; $j < count($champs); $j++) { 
            // création dynamique des getAttributs()
            $get="get".ucfirst($champs[$j]);
            $get=$objet->$get();
            $stmt->bindValue(":".$champs[$j], $get);
        }
        return $stmt->execute();
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
    public static function Update($objet)
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
     * Suppression d'un objet
     *
     * @param string $table
     * @param integer $id
     * @return void
     */
    public static function Delete($objet)
    {
        $table= get_class($objet);
        $stmt = DbConnect::getDb()->prepare("
            DELETE FROM ".$table." WHERE id=:id
        ");
        $champs=$objet->getNomsChamps();
        $get="get".ucfirst($champs[0]);        
        $get=$objet->$get();
        $stmt->bindValue(":id", $get, PDO::PARAM_INT);        
        return $stmt->execute();  
    }
}