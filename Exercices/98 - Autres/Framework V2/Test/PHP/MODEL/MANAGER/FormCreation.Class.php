<?php
//SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME="eleves"; 
class FormCreation
{
    public static function ListerFK(string $table)
    {
        $sql = "SELECT `COLUMN_NAME` as attribut, `REFERENCED_TABLE_NAME` as fTable,`REFERENCED_COLUMN_NAME` as fAttribut FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='" . $table . "' AND `CONSTRAINT_NAME` LIKE 'FK%'";
        $stmt = DbConnect::getDb()->prepare($sql);
        $stmt->execute();
        $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
        return $result;
    }

    public static function CreateForm(string $table,array $nomColonnes=null, string $attributs, ?int $id = null)
    {
        $infosTable = RecupInfos($table);
        $listeColonnesTraiter=DAO::select($nomColonnes, $table, [array_keys($infosTable)[0]=>$id]);
           var_dump($listeColonnesTraiter);   
        $formulaire = "<form " . $attributs . '>';
        foreach ($infosTable as $colonne => $infoColonne) {
            if($id!=null){
                $default = ' value="'.$listeColonnesTraiter["_".$colonne].'"';
            }elseif($infosTable[$colonne]['Defaut'] != null){
                $default = ' value="' . $infosTable[$colonne]['Defaut'] . '"';
            }
            $required=(!$infosTable[$colonne]['Null'])?' required':'';
            switch ($infosTable[$colonne]['Type']) {
                case 'string':
                    $type="text";
                    break;
                case 'int':
                    $type = "number";
                    $step ="1";
                    break;
                case 'float':
                    $type = "number";
                    $step="0.1";
                    break;
                default:
                    $type = "textblock";
                    break;
            }
            if ($infosTable[$colonne]['Cle'] == null) {
                $formulaire .= '<div>';
                if ($infosTable[$colonne]['Type'] != 'bool') {
                    $formulaire .= '<label for="' . $colonne . '">Entrez la valeur de "' . ucfirst($colonne) . '": </label><br />';
                    $formulaire .= '<input type="'.$type.'" id="' . $colonne . '" name="' . $colonne . '"' . $default .$required.($type=="number"?$step:""). '>';
                    $formulaire .= '</div>';
                }
            }elseif($infosTable[$colonne]['Cle'] == "Primaire"){
                $formulaire.='<input type=hidden id='. $colonne . '" name="' . $colonne . '" </imput>';
            }
        }
        $formulaire .= '</form>';
        echo $formulaire;
    }
}
//SELECT `COLUMN_NAME` as attribut, `REFERENCED_TABLE_NAME` as fTable,`REFERENCED_COLUMN_NAME` as fAttribut FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME="eleves" AND `CONSTRAINT_NAME` LIKE "FK%"; 

//SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME="eleves"; 