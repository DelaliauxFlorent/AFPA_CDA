<?php
class DAO
{
    /**
     *
     * @param array $nomColonnes => contient le noms des champs désirés dans la requête.
     * Exemple :  [nomColonne1,nomColonne2] => "SELECT nomColonne1, nomColonne2"
     *
     * @param string $table => contient Nom de la table sur laquelle la requête sera effectuée.
     * Exemple : nomTable => "FROM nomTable"
     *
     * @param array $conditions => null par défaut, attendu un tableau associatif 
     * qui peut prendre plusieurs formes en fonction de la complexité des conditions.
     *  Exemples : tableau associatif
     *  [nomColonne => '1'] => "WHERE nomColonne = 1"
     *  [nomColonne => ['1','3']] => "WHERE nomColonne in (1,3)"
     *  [nomColonne => '%abcd%'] => "WHERE nomColonne like "%abcd%" "
     *  [nomColonne => '1->5'] => "WHERE nomColonne BETWEEN 1 and 5 "
     *  Si il y a plusieurs conditions alors :
     *  [nomColonne1 => '1', nomColonne2 => '%abcd%' ] => "WHERE nomColonne1 = 1 AND nomColonne2 LIKE "%abcd%"
     * 	[fullTexte]=>'test'=> "WHERE nomColonne1 like "%test%" OR nomColonne2 LIKE "%test%"
     *
     * @param string $orderBy => null par défaut, contient un string qui contient les noms de colonnes et le type de tri
     * Exemple :"nomColonne1 , nomColonne2 DESC" => "Order By nomColonne1 , nomColonne2 DESC"
     *
     * @param string $limit  => null par défaut, contient un string pour donner la délimitations des enregistrements de la BDD
     * Exemples :
     * "1" => "LIMIT 1"
     * "1,2"=> "LIMIT 1,2"
     *
     * @param boolean $api => false par défaut, mettre true si on souhaite recevoir la réponse sous forme de string sinon sous forme d'objets.
     *
     * @param bool $debug => contient faux par défaut mais s'il on le met a vrai, on affiche la requete qui est effectuée.
     *
     * @return [array ou object] $liste => résultat de la requête revoie false si la requête s'est mal passé sinon renvoie un tableau.
     */
    public static function select(?array $nomColonnes = null, string $table, array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
    {

        $sql = "SELECT ";
        /**
         * Gestion des colonnes
         */
        if ($nomColonnes != null) {
            for ($i = 0; $i < count($nomColonnes); $i++) {
                $sql .= $nomColonnes[$i] . ", ";
            }
            $sql = substr($sql, 0, -2);
        } else {
            $sql .= "*";
        }
        /**
         * Gestion de la table
         */
        $sql .= " FROM " . $table;
        /**
         * Récupération de la liste des colonnes
         */
        $tmp = new $table();
        $champs = $tmp->getChamps();
        unset($tmp);
        /**
         * Gestion des conditions
         */
        if ($conditions != null) {
            $sql .= " WHERE";
            foreach ($conditions as $key => $value) {
                /**
                 * Cas où la condition est: NomColonne IN (X,Y,Z,etc...)
                 */
                if (is_array($value)) {
                    $sql .= " " . $key . " IN (";
                    foreach ($value as $key2 => $value2) {
                        $sql .= $value2 . ", ";
                    }
                    $sql = substr($sql, 0, -2) . ") AND";
                }
                /**
                 * Cas où l'on cherche une valeur dans tous les champs possibles
                 */
                elseif ($key == "fullText") {
                    $sql .= "(";
                    for ($i = 1; $i < count($champs); $i++) {
                        $sql .= " " . $champs[$i] . " LIKE \"%" . $value . "%\" OR";
                    }
                    $sql = substr($sql, 0, -3) . ") AND";
                } else {
                    /**
                     * Cas où l'on cherche les entrées contiennent la chaîne de caractères
                     */
                    if (strpos($value, "%") !== false) {
                        $sql .= " " . $key . " LIKE \"" . $value . "\" AND";
                    }
                    /**
                     * Cas où l'on cherche une fourchette de valeurs
                     */
                    elseif (strpos($value, "->") !== false) {
                        $betweenArray = explode("->", $value);
                        $sql .= " " . $key . " BETWEEN " . $betweenArray[0] . " AND " . $betweenArray[1] . " AND";
                    }
                    /**
                     * Cas générique où l'on veut une valeur bien définie
                     */
                    else {
                        $sql .= " " . $key . "=\"" . $value . "\" AND";
                    }
                }
            }
            $sql = substr($sql, 0, -4);
        }
        /**
         * Gestion du ORDER BY
         */
        if ($orderBy != null) {
            $sql .= " ORDER BY " . $orderBy;
        }
        /**
         * Gestion de la LIMIT
         */
        if ($limit != null) {
            $sql .= " LIMIT " . $limit;
        }
        /**
         * Gestion du débug
         */
        if ($debug) {
            var_dump($sql);
        }
        /**
         * Check anti-injection
         */
        if (DetectInject($sql)) {
            return false;
        }
        /**
         * Exécution de la requête
         */
        $stmt = DbConnect::getDb()->prepare($sql);
        $stmt->execute();
        $result = $stmt->fetchAll(PDO::FETCH_ASSOC);

        /**
         * Gestion du retour en fonction si API ou non    
         */
        if (count($result) == 0) {
            $result[0] = [];
        }
        if ($api == false) {
            if (count($result) > 1) {
                foreach ($result as $objet) {
                    $ListObjets[] = new $table($objet);
                }
            } else {
                $ListObjets = new $table($result[0]);
            }
        } else {
            $ListObjets = $result;
        }
        return $ListObjets;
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
        $champs = $objet->getChamps();

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
        $champs = $objet->getChamps();

        //Création de la QUERY
        $sql = "UPDATE " . $table . " SET ";
        for ($i = 1; $i < count($champs); $i++) {
            $sql .= $champs[$i] . "=:" . $champs[$i] . ", ";
        }

        // on finalise la QUERY
        $sql = substr($sql, 0, -2) . " WHERE ";
        $sql .= $champs[0] . "=:" . $champs[0] . ";";
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
        $champs = $objet->getChamps();
        $get = "get" . ucfirst($champs[0]);
        $get = $objet->$get();
        $sql = "DELETE FROM " . $table . " WHERE " . $champs[0] . "=:id;";
        $stmt = DbConnect::getDb()->prepare($sql);
        $stmt->bindValue(":id", $get, PDO::PARAM_INT);
        return $stmt->execute();
    }
}
