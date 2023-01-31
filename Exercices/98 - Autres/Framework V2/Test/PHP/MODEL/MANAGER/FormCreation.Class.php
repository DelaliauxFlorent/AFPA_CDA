<?php
//SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME="eleves"; 
class FormCreation{
    public static function ListerFK(string $table){
        $sql = "SELECT `COLUMN_NAME` as attribut, `REFERENCED_TABLE_NAME` as fTable,`REFERENCED_COLUMN_NAME` as fAttribut FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='".$table."' AND `CONSTRAINT_NAME` LIKE 'FK%'";
        $stmt = DbConnect::getDb()->prepare($sql);
        $stmt->execute();
        $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
        return $result;
    }

    public static function CreateForm(string $table, string $attributs, ?int $id=null){
        $infosTable=RecupInfos($table);
        var_dump($infosTable);
        $formulaire ="<form ".$attributs.'>';
        foreach ($infosTable as $colonne => $infoColonne) {
            # code...
        }
        $formulaire.='</form>';
    }

}
//SELECT `COLUMN_NAME` as attribut, `REFERENCED_TABLE_NAME` as fTable,`REFERENCED_COLUMN_NAME` as fAttribut FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME="eleves" AND `CONSTRAINT_NAME` LIKE "FK%"; 

//SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME="eleves"; 