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

function CreateClasse($table)
{
    $typePossible = [
        "CHAR" => 0, "VARCHAR" => 0, "BINARY" => 0, "VARBINARY" => 0, "TINYBLOB" => 0, "TINYTEXT" => 0, "BLOB" => 0, "TEXT" => 0, "MEDIUMBLOB" => 0, "MEDIUMTEXT" => 0, "LONGBLOB" => 0, "LONGTEXT" => 0, "ENUM" => 0, "SET" => 0, "DATE" => 0, "DATETIME" => 0, "DATE/TIME" => 0, "TIMESTAMP" => 0, "TIME" => 0, "YEAR" => 0, "NCHAR" => 0, "NVARCHAR" => 0, "NTEXT" => 0, "VARBINARY" => 0, "IMAGE" => 0, "DATETIME2" => 0, "SMALLDATETIME" => 0, "DATETIMEOFFSET" => 0, "MEMO" => 0,
        "BIT" => 1, "TINYINT" => 1, "INT" => 1, "SMALLINT" => 1, "MEDIUMINT" => 1, "BIGINT" => 1, "INTEGER" => 1, "BYTE" => 1, "LONG" => 1,
        "FLOAT" => 2, "DOUBLE PRECISION" => 2, "DOUBLE" => 2, "DEC" => 2, "DECIMAL" => 2, "NUMERIC" => 2, "SMALLMONEY" => 2, "MONEY" => 2, "REAL" => 2, "SINGLE" => 2, "CURRENCY" => 2,
        "BOOL" => 3, "BOOLEAN" => 3, "YES/NO" => 3
    ];
    $typePHP = ["string", "int", "float", "bool"];
    $stmtListAttributs = DbConnect::getDb()->prepare("DESCRIBE " . $table);
    $stmtListAttributs->execute();
    $resultListeColonnes = $stmtListAttributs->fetchAll(PDO::FETCH_ASSOC);
    $codeClasse = '
<?php
class ' . ucfirst($table) . '
{
    ////////////////////////////////////
    // Attributs

    ';
    foreach ($resultListeColonnes as $colonne) {
        $codeClasse .= 'private $_' . $colonne["Field"] . ';
    ';
    }
    $codeClasse .= '
    ////////////////////////////////////
    #region Accesseurs
    ';
    foreach ($resultListeColonnes as $colonne) {
        foreach ($typePossible as $key => $value) {
            $typage = strtoupper(explode("(", $colonne["Type"])[0]);
            if ($typage == $key) {
                $typeAttribut = $typePHP[$value];
            }
        }
        $nullable = "";
        if ($colonne["Null"] != "NO") {
            $nullable = " = null";
        }

        $codeClasse .= '
    public function get' . ucfirst($colonne["Field"]) . '()
    {
        return $this->_' . $colonne["Field"] . ';
    }

    public function set' . ucfirst($colonne["Field"]) . '(' . $typeAttribut . ' $' . $colonne["Field"] . $nullable . ')
    {
        $this->_' . $colonne["Field"] . ' = $' . $colonne["Field"] . ';
    }
    ';
    }
    $codeClasse .= '
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
    file_put_contents("PHP/CONTROLLER/CLASSE/" . ucfirst($table) . ".Class.php", $codeClasse);
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
        $listeChamps=get_class($listeObjets[0])::getChamps();
        echo '<table class="tableauDebug"><thead><tr>';
        foreach ($listeChamps as $value) {
            echo '<th>'.ltrim(ucfirst($value), "_").'</th>';
        }
        echo '</tr></thead><tbody>';
        foreach ($listeObjets as $objet) {
            echo '<tr>';
            foreach ($listeChamps as $col) {
                $getvalue="get".$col;
                echo '<td>'.$objet->$getvalue().'</td>';
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
 * @param string|null $messageSelect => Message affiché pour l'option par défaut
 * @return string
 */
function CreateComboBox(string $idSelected = null, string $table, array $affichage, ?string $attributs = null, array $condition =null, string $orderBy =null, ?string $messageSelect = null)
{
    $champsID =$table::getChamps()[0];
    $selectCol = $affichage;
    array_unshift($selectCol, $champsID);
    $selected=$idSelected==null?" Selected":"";
    $liste = DAO::select($selectCol, $table, $condition, $orderBy, null, false, false);
    $stringReturn= '<select id="' . $champsID . '" name="' . $champsID . '" ' . $attributs . '>';    
    $stringReturn.= '<option value=""'.$selected.'>' . ($messageSelect != null ? $messageSelect : '--Choisissez une valeur--') . '</option>';

    foreach ($liste as $obj) {
        $id = getGet($obj, [$champsID]);
        $selected =($id == $idSelected)?" Selected":"";
        $content = getGet($obj, $affichage);
        $stringReturn.= '<option value="' . $id . '" '.$selected.'>' . $content . '</option>';        
    }
    $stringReturn.='</select>';
    return $stringReturn;
}

function getGet(object $objet, array $listAttributs):string{
    $chaine="";
    foreach ($listAttributs as $value) {
        $methode='get'.ucfirst($value);
        $chaine.= $objet->$methode().' ';
    }

    return rtrim($chaine);
}
