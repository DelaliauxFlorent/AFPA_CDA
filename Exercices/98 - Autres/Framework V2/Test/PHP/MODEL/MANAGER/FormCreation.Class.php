<?php

class FormCreation
{
    /**
     * Creation d'un formulaire ()
     *
     * @param object $obj => l'objet pour lequel on veut un formulaire
     * @return string (temporaire, retournera void mais créera un fichier "FormulaireClasse.php" dans "PHP/VIEW/FORM")
     */
    public static function CreateForm(object $obj):string
    {
        // inutile?
        $id = $obj->getChamps()[0];
        // Détermination de la classe de l'objet
        $table = get_class($obj);
        echo $table;
        // On récupère les infos de la table
        $infosTable = RecupInfos($table);

        // On récupère la liste des clès étrangères associées à la table actuelle
        $listeCleSecondaires = ListerFK($table);

        // Début du formulaire
        $formulaire = '<form methode="get" action="./PHP/CONTROLLER/ACTION/Action' . $table . '.php">';

        foreach ($infosTable as $colonne => $infoColonne) {
            // Pour chaque colonne de la table/attribut de la classe, on fait une ligne
            $formulaire.='<div class="ligne">';

            // On détermine qu'elle sera la valeur par défaut
            if ($id != null) {
                $default = ' value="' . getGet($obj, [$colonne]) . '"';
            } elseif ($infosTable[$colonne]['Defaut'] != null) {
                $default = ' value="' . $infosTable[$colonne]['Defaut'] . '"';
            } else {
                $default = "";
            }

            // On détermine si l'input sera "required"
            $required = (!$infosTable[$colonne]['Null']) ? ' required' : '';

            // On détermine le type d'input à utiliser (et le step dans le cas des numbers)
            switch ($infosTable[$colonne]['Type']) {
                case 'string':
                    $type = "text";
                    break;
                case 'int':
                    $type = "number";
                    $step = "1";
                    break;
                case 'float':
                    $type = "number";
                    $step = "0.1";
                    break;
                default:
                    $type = "textblock";
                    break;
            }
            
            /**
             * ********************************************
             * A NETTOYER/AMÉLIORER
             * ********************************************
             */
            if ($infosTable[$colonne]['Cle'] == null) {

                if ($infosTable[$colonne]['Type'] != 'bool') {
                    $formulaire .= '<label for="' . $colonne . '">Entrez la valeur de "' . ucfirst($colonne) . '": </label>';
                    $formulaire .= '<input type="' . $type . '" id="' . $colonne . '" name="' . $colonne . '"' . $default . $required . ($type == "number" ? $step : "") . '>';
                }
            } elseif ($infosTable[$colonne]['Cle'] == "Primaire") {
                $formulaire .= '<input type=hidden id=' . $colonne . '" name="' . $colonne . '" </imput>';
            } else {
                $formulaire .= '<label for="' . $colonne . '">Entrez la valeur de "' . ucfirst($colonne) . '": </label>';
                $formulaire .= CreateComboBox(getGet($obj, [$colonne]), $listeCleSecondaires[$colonne]['table'], ["libelle"], null, null, null, null);
            }
            /**********************************************
             * ********************************************
             * ********************************************
             * ********************************************
             */
            // on termine la ligne
            $formulaire.='</div>';
        }
        // On fait une ligne pour les boutons annuler et valider
        $formulaire.='<div class="ligne">';
        $formulaire.='<input id="btnCancel" class="cancel" type="button" value="Annuler">';
        $formulaire.='<input id="btnValid" class="valid" type="button" value="Valider">';
        $formulaire.='</div>';

        // Et on termine le formulaire
        $formulaire .= '</form>';

        // Pour l'instant on retourne un string 
        return $formulaire;

        // Mais au final on aura la création du fichier correspondant
        // $fichier="PHP/VIEW/FORM/Formulaire".$table.'.php';
        // if (!file_exists($fichier)) {
        //     file_put_contents($fichier, $formulaire);
        // }
    }
}
