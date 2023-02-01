<?php
/* Autoload permet de charger toutes les classes necessaires */
function ChargerClasse($champs)
{
    if (file_exists("PHP/CONTROLLER/CLASSE/" . $champs . ".Class.php")) {
        require "PHP/CONTROLLER/CLASSE/" . $champs . ".Class.php";
    }
    if (file_exists("PHP/MODEL/MANAGER/" . $champs . ".Class.php")) {
        require "PHP/MODEL/MANAGER/" . $champs . ".Class.php";
    }
}


function crypte($mot) //fonction qui crypte le mot de passe
{
    return md5(md5($mot) . strlen($mot));
}
// A coder pour décoder les informations base de données dans le json
function decode($texte)
{
    return $texte;
}

/**
 * Fonction de décodage perso
 *
 * @param [type] $string
 * @return void
 */
function decoder($string)
{
    $encoded = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
    $decoded = ['p', 'v', 'x', 's', 'z', 'd', 'f', 'g', 'u', 'h', 'j', 'k', 'l', 'b', 'i', 'o', 'm', 'e', 'q', 'r', 'y', 'c', 'n', 'w', 't', 'a', 'P', 'V', 'X', 'S', 'Z', 'D', 'F', 'G', 'U', 'H', 'J', 'K', 'L', 'B', 'I', 'O', 'M', 'E', 'Q', 'R', 'Y', 'C', 'N', 'W', 'T', 'A'];
    for ($i = 0; $i < strlen($string); $i++) {
        if (in_array($string[$i], $encoded)) {
            $index = array_search($string[$i], $encoded);
            $string[$i] = $decoded[$index];
        }
    }
    return $string;
}

/**
 * Vérifie si la chaîne contient un ";", indiquant la possibilité de tentative d'injection
 *
 * @param string 
 * @return boolean
 */
function DetectInject($string): bool
{
    if (strpos($string, ";") !== false) {
        return true;
    }
    return false;
}
//SELECT * FROM `COLUMNS` WHERE `TABLE_NAME` LIKE 'eleves' ORDER BY `TABLE_NAME` ASC 
/**
 * Récupère, pour chaque colonne de la table, des infos pour la création de la classe
 *
 * @param [type] $table
 * @return array => ['NomColonne']=>[
 * 'Type'=>Son type en string, 
 * 'Null'=> bool si null autorisé, 
 * 'Cle'=>'Primaire'|'Etrangere'|null, 
 * 'Defaut'=>valeur par défaut si'il y en a une]
 */
function RecupInfos($table): array
{
    // Array contenant une grande partie des types en SQL associé à une valeur (pour "traduction" vers PHP)
    $typePossible = [
        "CHAR" => 0, "VARCHAR" => 0, "BINARY" => 0, "VARBINARY" => 0, "TINYBLOB" => 0, "TINYTEXT" => 0, "BLOB" => 0, "TEXT" => 0, "MEDIUMBLOB" => 0, "MEDIUMTEXT" => 0, "LONGBLOB" => 0, "LONGTEXT" => 0, "ENUM" => 0, "SET" => 0, "DATE" => 0, "DATETIME" => 0, "DATE/TIME" => 0, "TIMESTAMP" => 0, "TIME" => 0, "YEAR" => 0, "NCHAR" => 0, "NVARCHAR" => 0, "NTEXT" => 0, "VARBINARY" => 0, "IMAGE" => 0, "DATETIME2" => 0, "SMALLDATETIME" => 0, "DATETIMEOFFSET" => 0, "MEMO" => 0,
        "BIT" => 1, "TINYINT" => 1, "INT" => 1, "SMALLINT" => 1, "MEDIUMINT" => 1, "BIGINT" => 1, "INTEGER" => 1, "BYTE" => 1, "LONG" => 1,
        "FLOAT" => 2, "DOUBLE PRECISION" => 2, "DOUBLE" => 2, "DEC" => 2, "DECIMAL" => 2, "NUMERIC" => 2, "SMALLMONEY" => 2, "MONEY" => 2, "REAL" => 2, "SINGLE" => 2, "CURRENCY" => 2,
        "BOOL" => 3, "BOOLEAN" => 3, "YES/NO" => 3
    ];
    // Types possible pour les attributs en PHP, ordre correspondant aux valeurs du tableau précédent
    $typePHP = ["string", "int", "float", "bool"];

    // Récupération de la description de la table
    $stmtListAttributs = DbConnect::getDb()->prepare("DESCRIBE " . $table);
    $stmtListAttributs->execute();
    $resultListeColonnes = $stmtListAttributs->fetchAll(PDO::FETCH_ASSOC);

    foreach ($resultListeColonnes as $colonne) {
        // Pour chaque colonne:

        // On traduit son typage SQL en typage PHP
        foreach ($typePossible as $key => $value) {
            $typage = strtoupper(explode("(", $colonne["Type"])[0]);
            if ($typage == $key) {
                $typeAttribut = $typePHP[$value];
            }
        }

        // On détermine si elle accepte les null
        $nullable = ($colonne["Null"] != "NO");

        // On détermine s'il s'agit d'une clès primaire, étrangère ou d'une colonne basique
        switch ($colonne['Key']) {
            case 'PRI':
                $cle = "Primaire";
                break;
            case "MUL":
                $cle = "Etrangere";
                break;
            default:
                $cle = null;
                break;
        }

        // On rassemble toutes les données dans la variable de retour
        $infoTable[$colonne['Field']] = ['Type' => $typeAttribut, 'Null' => $nullable, 'Cle' => $cle, 'Defaut' => $colonne['Default']];
    }
    // On renvoie le tableau complet
    return $infoTable;
}


/**
 * Création des fichiers POCOs
 * (à déplacer dans le générateur une fois terminé)
 *
 * @param string $table => Nom de la table telle qu'elle est nommée dans la BDD
 * @return void
 */
function CreateClasse(string $table)
{
    // On récupère les infos qui seront nécessaire pour la création du fichier
    $resultListeColonnes = RecupInfos($table);
    $codeClasse = '
<?php
class ' . ucfirst($table) . '
{
    ////////////////////////////////////
    // Attributs

    ';
    // Pour chaque colonne, on crée un attribut de type privé
    foreach ($resultListeColonnes as $nomColonne => $infoColonne) {
        $codeClasse .= 'private ?' . $infoColonne['Type'] . '$_' . $nomColonne . ';
    ';
    }
    $codeClasse .= '
    ////////////////////////////////////
    #region Accesseurs
    ';
    // Pour chaque attribut, on crée les Getters et les Setters(typé) correspondants
    foreach ($resultListeColonnes as $nomColonne => $infoColonne) {

        $nullable = ($infoColonne['Null']) ? "=null" : "";
        $codeClasse .= '
    public function get' . ucfirst($nomColonne) . '()
    {
        return $this->_' . $nomColonne . ';
    }
    
    public function set' . ucfirst($nomColonne) . '(' . $infoColonne['Type'] . ' $' . $nomColonne . $nullable . ')
    {
        $this->_' . $nomColonne . ' = $' . $nomColonne . ';
    }
    ';
    }
    // On termine par une fonction static permettant de récupérer facilement la liste de tous les attributs de la classe
    // Ainsi que le constructeur et l'hydrateur de la classe
    $codeClasse .= '
    /**
     * Récupérer la liste des attributs de la classe
     *
     * @return  array  liste des champs
     */
    public static function getChamps()
    {
        $array = get_class_vars(__CLASS__);
        foreach ($array as $key => $value) {
            $listeChamps[]=ltrim($key, "_");
        }
        return $listeChamps;
    }

    #endregion Accesseurs
    ////////////////////////////////////
    // Constructeur

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
}
';
    // On vérifie que le fichier n'éxiste pas déjà et on le crée
    $fichier = "PHP/CONTROLLER/CLASSE/" . ucfirst($table) . ".Class.php";
    if (!file_exists($fichier)) {
        file_put_contents($fichier, $codeClasse);
    }
}

/**
 * Création des fichiers des Manager des classes
 *
 * @param string $table
 * @return void
 */
function CreateManager(string $table)
{
    $class = ucfirst($table);
    $manager = '<?php 
    class ' . $class . 'Manager{
        public static function Add(' . $class . ' $obj)
        {
            return DAO::Create($obj);
        }
        
        public static function Update(' . $class . ' $obj)
        {
            return DAO::Update($obj);
        }
        
        public static function Delete(' . $class . ' $obj)
        {
            return DAO::Delete($obj);
        }
        
        public static function FindById($id)
        {
            return DAO::Select(' . $class . '::getChamps(), "' . $class . '", ["' . $class::getChamps()[0] . '"=> $id]);
        }
        
        public static function GetList(array $nomColonnes = null, array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug =false)
        {
            $nomColonnes = ($nomColonnes==null)?' . $class . '::getChamps():$nomColonnes;
            return DAO::Select($nomColonnes, "' . $class . '", $conditions, $orderBy, $limit, $api, $debug);
        }
    }';
    $fichier = "PHP/MODEL/MANAGER/" . $class . "Manager.Class.php";
    if (!file_exists($fichier)) {
        file_put_contents($fichier, $manager);
    }
}

/**
 * Génére un tableau pour débug
 *
 * @param array $listeObjets
 * @return void
 */
function AfficherTable(array $listeObjets)
{

    if (count($listeObjets) != 0) {
        $listeChamps = get_class($listeObjets[0])::getChamps();
        echo '<table class="tableauDebug"><thead><tr>';
        foreach ($listeChamps as $value) {
            echo '<th>' . ltrim(ucfirst($value), "_") . '</th>';
        }
        echo '</tr></thead><tbody>';
        foreach ($listeObjets as $objet) {
            echo '<tr>';
            foreach ($listeChamps as $col) {
                $getvalue = "get" . $col;
                echo '<td>' . (($objet->$getvalue() != null) ? $objet->$getvalue() : "NULL") . '</td>';
            }
            echo '</tr>';
        }
        echo '</tbody></table>';
    }
}


/**
 * Création d'une ComboBox
 *
 * @param string|null $idSelected => la valeur sélectionné par défaut
 * @param string $table => nom de la table sur laquelle porte la ComboBox
 * @param array $affichage => Contenu de la balise "option"
 * @param string|null $attributs => Attributs supplémentaires du Select
 * @param array|null $condition => conditions pour le DAO::Select
 * @param string|null $orderBy => orderBy pour le DAO::Select
 * @param string|null $messageSelect => Message affiché pour l'option par défaut
 * @return string
 */
function CreateComboBox(string $idSelected = null, string $table, array $affichage, ?string $attributs = null, array $condition = null, string $orderBy = null, ?string $messageSelect = null)
{
    $champsID = $table::getChamps()[0];
    $selectCol = $affichage;
    array_unshift($selectCol, $champsID);
    $selected = $idSelected == null ? " Selected" : "";
    $liste = DAO::Select($selectCol, $table, $condition, $orderBy, null, false, false);
    $stringReturn = '<select id="' . $champsID . '" name="' . $champsID . '" ' . $attributs . '>';
    $stringReturn .= '<option value=""' . $selected . '>' . ($messageSelect != null ? $messageSelect : '--Choisissez une valeur--') . '</option>';

    foreach ($liste as $obj) {
        $id = getGet($obj, [$champsID]);
        $selected = ($id == $idSelected) ? " Selected" : "";
        $content = getGet($obj, $affichage);
        $stringReturn .= '<option value="' . $id . '" ' . $selected . '>' . $content . '</option>';
    }
    $stringReturn .= '</select>';
    return $stringReturn;
}

/**
 * Récupère la concaténation des valeurs des atrributs choisi de l'objet
 *
 * @param object $objet => objet dont on veut les attributs concaténé
 * @param array $listAttributs => liste des attributs que l'on veut qu'ils soient concaténés
 * @return string
 */
function getGet(object $objet, array $listAttributs): string
{
    $chaine = "";
    foreach ($listAttributs as $value) {
        $methode = 'get' . ucfirst($value);
        $chaine .= $objet->$methode() . ' ';
    }
    // On retourne la chaîne après avoir retiré l'espace à la fin
    return rtrim($chaine);
}

/**
 * Récuperer la liste des clés étrangères associés à la table
 *
 * @param string $table => table pour laquelle on veut les clès étrangères
 * @return array $retour => liste des clès étrangères organisé tel que 'idForeignKey'=>['ForeignTable', 'PrimaryKeyOfForeignTable']
 */
function ListerFK(string $table): array
{
    $sql = "SELECT `COLUMN_NAME` as attribut, `REFERENCED_TABLE_NAME` as fTable,`REFERENCED_COLUMN_NAME` as fAttribut FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='" . $table . "' AND `CONSTRAINT_NAME` LIKE 'FK%'";
    $stmt = DbConnect::getDb()->prepare($sql);
    $stmt->execute();
    $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
    $retour = [];
    foreach ($result as $key => $value) {
        $retour[$value['attribut']] = ['table' => $value['fTable'], 'colonne' => $value['fAttribut']];
    }
    return $retour;
}

function TypeToInput(string $type): string
{
    switch ($type) {
        case 'char':
        case 'varchar':
        case 'tinytext':
        case 'char':
        case 'char':
        case 'char':
        case 'char':
        case 'char':
            case 'char':
        case 'string':
            $iType = "text";
            break;
        case 'tinyint':
        case 'smallint':
        case 'mediumint':
        case 'int':
        case 'bigint':
        case 'decimal':
        case 'float':
        case 'double':
        case 'real':
        case "year":
            $iType = "number";
            break;
        case 'bit':
        case 'boolean':
            $iType = "radio";
            break;
        case 'date':
            $iType = "date";
            break;
        case 'datetime':
        case 'timestamp':
            $iType="datetime-local";
            break;
        case 'time':
            $iType="time";
            break;
        default:
            $iType = "textblock";
            break;
    }
    return $iType;
}

function CreateInput(string $type, string $nom, string $attributs): string
{
    if ($type) {
        switch ($type) {
            case 'text':
                $retour = '<label for="' . $nom . '">Entrez la valeur de "' . ucfirst($nom) . '": </label><div class="flexMini"></div>';
                $retour .= '<input type="' . $type . '" id="' . $nom . '" name="' . $nom . '"' . $attributs . '>';
                break;
            case 'number':
                break;
            default:
                # code...
                break;
        }
    }
    return $retour;
}
