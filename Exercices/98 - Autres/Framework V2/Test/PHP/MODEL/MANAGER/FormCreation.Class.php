<?php

class FormCreation
{
    /**
     * Creation d'un formulaire ()
     *
     * @param object $obj => l'objet pour lequel on veut un formulaire
     * @return void (temporaire, retournera void mais créera un fichier "FormulaireClasse.php" dans "PHP/VIEW/FORM")
     */
    public static function CreateForm(string $table)
    {
        
        // Détermination de la classe de l'objet
        $classe = ucfirst($table);

        // Récupération de l'ID passé en GET
        $formulaire = '<?php
            $infosTable = RecupInfos("'.$classe.'");
            $listeCleSecondaires = ListerFK("'.$classe.'");
            $id = (isset($_GET["id"]) ? $_GET["id"] : "");
            $elt=' . $classe . 'Manager::FindById($id);
            ';

        // Début du formulaire
        $formulaire .= '$form =\'<form methode="get" action="./PHP/CONTROLLER/ACTION/Action' . $classe . '.php">\';

        foreach ($infosTable as $colonne => $infoColonne) {
            // Pour chaque colonne de la table/attribut de la classe, on fait une ligne
            $form .= \'<div class="ligne">\';

            // On détermine qu\'elle sera la valeur par défaut
            if ($id != null) {
                $default = \' value="\' . getGet($elt, [$colonne]) . \'"\';
            } else {
                $default = \' value="\' . $infosTable[$colonne][\'Defaut\'] . \'"\';
            }

            // On détermine si l\'input sera "required"
            $required = (!$infosTable[$colonne][\'Null\']) ? \' required\' : \'\';

            // On détermine le type d\'input à utiliser (et le step dans le cas des numbers)
            $type=TypeToInput($infosTable[$colonne][\'Type\']);

            if ($infosTable[$colonne][\'Cle\'] == null) {
                $form .= CreateInput($type, $colonne, "");
            } elseif ($infosTable[$colonne][\'Cle\'] == "Primaire") {
                $form .= \'<input type=hidden id=\' . $colonne . \'" name="\' . $colonne . \'" </imput>\';
            } else {
                $form .= \'<label for="\' . $colonne . \'">Entrez la valeur de "\' . ucfirst($colonne) . \'": </label><div class="flexMini"></div>\';
                $form .= CreateComboBox(getGet($elt, [$colonne]), $listeCleSecondaires[$colonne][\'table\'], [ucfirst($listeCleSecondaires[$colonne][\'table\']::getChamps()[1])], null, null, null, null);
        
            }
            /**********************************************
             * ********************************************
             * ********************************************
             * ********************************************
             */
            // on termine la ligne
            $form .= \'</div>\';
        }
        // On fait une ligne pour les boutons annuler et valider
        $form .= \'<div class="ligne"><div>&nbsp;</div>\';
        $form .= \'<input id="btnCancel" class="cancel" type="button" value="Annuler"><div>&nbsp;</div>\';
        $form .= \'<input id="btnValid" class="valid" type="button" value="Valider"><div>&nbsp;</div>\';
        $form .= \'</div>\';

        // Et on termine le formulaire
        $form .= \'</form>\';
        echo $form;';

        // Pour l'instant on retourne un string 
        //return $formulaire;

        // Mais au final on aura la création du fichier correspondant
        $fichier="PHP/VIEW/FORM/Formulaire".$classe.'.php';
        if (!file_exists($fichier)) {
            file_put_contents($fichier, $formulaire);
        }
    }
}
