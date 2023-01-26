<?php
$listeDossiers = ["CSS", "HTML", "IMG", "JS", "SQL", "PHP", "PHP/CONTROLLER", "PHP/CONTROLLER/ACTION", "PHP/CONTROLLER/CLASSE", "PHP/MODEL", "PHP/MODEL/API", "PHP/MODEL/MANAGER", "PHP/VIEW", "PHP/VIEW/FORM", "PHP/VIEW/GENERAL", "PHP/VIEW/LISTE"];

$destination=".";
#region Index.php
$sourceIndex="<?php echo \"<!DOCTYPE html>
<html lang='en'>
    <head>
        <meta charset='UTF-8'>
        <meta http-equiv='X-UA-Compatible' content='IE=edge'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Sécurisation</title>
    </head>

    <body>
        <h1 align='center'>Sécurité</h1>

    </body>

</html>\";";
#endregion Index.php
#region DAO.Class.php
$sourceDAO='
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
     *  [nomColonne => \'1\'] => "WHERE nomColonne = 1"
     *  [nomColonne => [\'1\',\'3\']] => "WHERE nomColonne in (1,3)"
     *  [nomColonne => \'%abcd%\'] => "WHERE nomColonne like "%abcd%" "
     *  [nomColonne => \'1->5\'] => "WHERE nomColonne BETWEEN 1 and 5 "
     *  Si il y a plusieurs conditions alors :
     *  [nomColonne1 => \'1\', nomColonne2 => \'%abcd%\' ] => "WHERE nomColonne1 = 1 AND nomColonne2 LIKE "%abcd%"
     * 	[fullTexte]=>\'test\'=> "WHERE nomColonne1 like "%test%" OR nomColonne2 LIKE "%test%"
     *
     * @param string $orderBy => null par défaut, contient un string qui contient les noms de colonnes et le type de tri
     * Exemple :"nomColonne1 , nomColonne2 DESC" => "Order By nomColonne1 , nomColonne2 DESC"
     *
     * @param string $limit  => null par défaut, contient un string pour donner la délimitations des enregistrements de la BDD
     * Exemples :
     * "1" => "LIMIT 1"
     * "1,2"=> "LIMIT 1,2"
     *
     * @param boolean $api => false par défaut, mettre true si on souhaite recevoir la réponse sous forme de string sinon sous forme d\'objets.
     *
     * @param bool $debug => contient faux par défaut mais s\'il on le met a vrai, on affiche la requete qui est effectuée.
     *
     * @return [array ou object] $liste => résultat de la requête revoie false si la requête s\'est mal passé sinon renvoie un tableau.
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
                 * Cas où l\'on cherche une valeur dans tous les champs possibles
                 */
                elseif ($key == "fullText") {
                    $sql .= "(";
                    for ($i = 1; $i < count($champs); $i++) {
                        $sql .= " " . $champs[$i] . " LIKE \"%" . $value . "%\" OR";
                    }
                    $sql = substr($sql, 0, -3) . ") AND";
                } else {
                    /**
                     * Cas où l\'on cherche les entrées contiennent la chaîne de caractères
                     */
                    if (strpos($value, "%") !== false) {
                        $sql .= " " . $key . " LIKE \"" . $value . "\" AND";
                    }
                    /**
                     * Cas où l\'on cherche une fourchette de valeurs
                     */
                    elseif (strpos($value, "->") !== false) {
                        $betweenArray = explode("->", $value);
                        $sql .= " " . $key . " BETWEEN " . $betweenArray[0] . " AND " . $betweenArray[1] . " AND";
                    }
                    /**
                     * Cas générique où l\'on veut une valeur bien définie
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
        // On récupère la classe de l\'objet
        $table = get_class($objet);
        // On commence la requête
        $sql = "INSERT INTO " . $table . " VALUES (null, ";
        // On récupère la liste des champs de l\'objet
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
     * Mise à jour d\'un objet
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
     * Suppression d\'un objet
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
';
#endregion
#region DbConnect.Class.php
$sourceDbConnect='<?php
// Ce fichier sera inclus à chaque fois que l\'on aura besoin d\'acceder à la base de données.
// Il permet d\'ouvrir la connection à la base de données
class DbConnect
{
    private static $db;

    public static function getDb()
    {
        return self::$db;
    }

    public static function init()
    {
        try {
            // On se connecte à MySQL
           self::$db = new PDO(\'mysql:host=\' . Parametre::getHost() . \';port=\' . Parametre::getPort() . \';dbname=\' . Parametre::getBase() . \';charset=utf8\', Parametre::getUser(), Parametre::getPassword());
        }
        catch (Exception $e)
        {
            // En cas d\'erreur, on affiche un message et on arrète tout
            die(\'Erreur : \' . $e->getMessage());
        }

    }

    public static function close(){
        self::$db=null;
    }
}';
#endregion
#region Outils.php
$sourceOutils="
<?php
/* Autoload permet de charger toutes les classes necessaires */
function ChargerClasse(\$classe)
{
    if (file_exists(\"PHP/CONTROLLER/CLASSE/\" . \$classe . \".Class.php\")) {
        require \"PHP/CONTROLLER/CLASSE/\" . \$classe . \".Class.php\";
    }
    if (file_exists(\"PHP/MODEL/MANAGER/\" . \$classe . \".Class.php\")) {
        require \"PHP/MODEL/MANAGER/\" . \$classe . \".Class.php\";
    }
}


function crypte(\$mot) //fonction qui crypte le mot de passe
{
    return md5(md5(\$mot) . strlen(\$mot));
}
// A coder pour décoder les informations base de données dans le json
function decode(\$texte)
{
    return \$texte;
}

function decoder(\$string)
{
    \$encoded = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
    \$decoded = ['p', 'v', 'x', 's', 'z', 'd', 'f', 'g', 'u', 'h', 'j', 'k', 'l', 'b', 'i', 'o', 'm', 'e', 'q', 'r', 'y', 'c', 'n', 'w', 't', 'a', 'P', 'V', 'X', 'S', 'Z', 'D', 'F', 'G', 'U', 'H', 'J', 'K', 'L', 'B', 'I', 'O', 'M', 'E', 'Q', 'R', 'Y', 'C', 'N', 'W', 'T', 'A'];
    for (\$i=0; \$i < strlen(\$string); \$i++) {
        if(in_array(\$string[\$i], \$encoded)){
            \$index=array_search(\$string[\$i], \$encoded);
            \$string[\$i]=\$decoded[\$index];
        }
    }
    return \$string;
}

/**
 * Vérifie si la chaîne contient un \";\", indiquant la possibilité de tentative d'injection
 *
 * @param string \$string
 * @return boolean
 */
function DetectInject(\$string):bool{
    if(strpos(\$string, \";\") !== false){
        return true;
    }
    return false;
}
";
#endregion
#region Parametre.Class.php
$sourceParametre='
<?php
class Parametre
{
    ////////////////////////////////////
    // Attributs

    private static $_host;
    private static $_port;
    private static $_base;
    private static $_user;
    private static $_password;

    /////////////////////////////////////
    // Getters/Setters
    
    static function getHost()
    {
        return self::$_host;
    }

    static function getPort()
    {
        return self::$_port;
    }

    static function getBase()
    {
        return self::$_base;
    }

    static function getUser()
    {
        return self::$_user;
    }

    static function getPassword()
    {
        return self::$_password;
    }

    ////////////////////////////

    public static function init()
    {
        if (file_exists("config.json")) {
            $infoconnect = json_decode(file_get_contents("config.json"));
            self::$_host = decoder($infoconnect->host);
            self::$_port = $infoconnect->port;
            self::$_base = decoder($infoconnect->base);
            self::$_user = decoder($infoconnect->user);
            if (strlen($infoconnect->password) == 0) {
                self::$_password = $infoconnect->password;
            } else {
                self::$_password = decoder($infoconnect->password);
            }
        }
    }

}
';
#endregion

/**
 * Génération de l'arborescence (avec index.php dans chaque dossier pour la sécurité)
 */
foreach ($listeDossiers as $dossier) {
    if (!is_dir("{$destination}/{$dossier}")) {
        mkdir("{$destination}/{$dossier}", 0777, true);
        file_put_contents("{$destination}/{$dossier}/index.php", $sourceIndex);
    }
}
/**
 * Création de tous les fichiers devant être présent dans tous les cas
 */
file_put_contents("{$destination}/index.php", $sourceIndex);
file_put_contents("{$destination}/{$listeDossiers[11]}/DAO.Class.php", $sourceDAO);
file_put_contents("{$destination}/{$listeDossiers[11]}/DbConnect.Class.php", $sourceDbConnect);
file_put_contents("{$destination}/{$listeDossiers[6]}/Outils.php", $sourceOutils);
file_put_contents("{$destination}/{$listeDossiers[8]}/Parametre.Class.php", $sourceParametre);

/**
 * Générer les classes à partir des tables
 */
/*
include "./PHP/CONTROLLER/Outils.php";
spl_autoload_register("ChargerClasse");
Parametre::init();
DbConnect::init();

$stmtListeTables=DbConnect::getDb()->prepare("SHOW TABLES;");
$stmtListeTables->execute();
$resultListeTables = $stmtListeTables->fetchAll(PDO::FETCH_ASSOC);
foreach ($resultListeTables as $table) {
    $tableName=$table["Tables_in_modelevoitures"];
    var_dump($tableName);
    CreateClasse($tableName);
}
DbConnect::close();*/