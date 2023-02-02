<?php
            $infosTable = RecupInfos("Eleves");
            $listeCleSecondaires = ListerFK("Eleves");
            $id = (isset($_GET["id"]) ? $_GET["id"] : "");
            $elt=ElevesManager::FindById($id);
            $form ='<form methode="get" action="./PHP/CONTROLLER/ACTION/ActionEleves.php">';

        foreach ($infosTable as $colonne => $infoColonne) {
            // Pour chaque colonne de la table/attribut de la classe, on fait une ligne
            $form .= '<div class="ligne">';

            // On détermine qu'elle sera la valeur par défaut
            if ($id != null) {
                $default = ' value="' . getGet($elt, [$colonne]) . '"';
            } else {
                $default = ' value="' . $infosTable[$colonne]['Defaut'] . '"';
            }

            // On détermine si l'input sera "required"
            $required = (!$infosTable[$colonne]['Null']) ? ' required' : '';

            // On détermine le type d'input à utiliser (et le step dans le cas des numbers)
            $type=TypeToInput($infosTable[$colonne]['Type']);

            if ($infosTable[$colonne]['Cle'] == null) {
                $form .= CreateInput($type, $colonne, "");
            } elseif ($infosTable[$colonne]['Cle'] == "Primaire") {
                $form .= '<input type=hidden id=' . $colonne . '" name="' . $colonne . '" </imput>';
            } else {
                $form .= '<label for="' . $colonne . '">Entrez la valeur de "' . ucfirst($colonne) . '": </label><div class="flexMini"></div>';
                $form .= CreateComboBox(getGet($elt, [$colonne]), $listeCleSecondaires[$colonne]['table'], [ucfirst($listeCleSecondaires[$colonne]['table']::getChamps()[1])], null, null, null, null);
        
            }
            /**********************************************
             * ********************************************
             * ********************************************
             * ********************************************
             */
            // on termine la ligne
            $form .= '</div>';
        }
        // On fait une ligne pour les boutons annuler et valider
        $form .= '<div class="ligne"><div>&nbsp;</div>';
        $form .= '<input id="btnCancel" class="cancel" type="button" value="Annuler"><div>&nbsp;</div>';
        $form .= '<input id="btnValid" class="valid" type="button" value="Valider"><div>&nbsp;</div>';
        $form .= '</div>';

        // Et on termine le formulaire
        $form .= '</form>';
        echo $form;