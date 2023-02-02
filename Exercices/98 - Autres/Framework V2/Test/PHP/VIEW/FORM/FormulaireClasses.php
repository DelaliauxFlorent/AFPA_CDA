<?php
            $infosTable = RecupInfos("Classes");
            $listeCleSecondaires = ListerFK("Classes");
            $id = (isset($_GET["id"]) ? $_GET["id"] : "");
            $elt=ClassesManager::FindById($id);
            $form ='<form methode="get" action="./PHP/CONTROLLER/ACTION/ActionClasses.php">';

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
                // Si la colonne n'est ni une clé primaire, ni une clé étrangère
                // on appele la fonction générique
                $attributs = $default.$required;
                $form .= CreateInput($type, $colonne, $attributs);
            } elseif ($infosTable[$colonne]['Cle'] == "Primaire") {
                // Si c'est une clé primaire, on la passe en "hidden"
                $form .= '<input type=hidden id=' . $colonne . '" name="' . $colonne . $default . '" </imput>';
            } else {
                // Et si c'est une clé étrangère, on appele la fonction pour avoir un select
                $form .= '<label for="' . $colonne . '">Entrez la valeur de "' . ucfirst($colonne) . '": </label><div class="flexMini"></div>';
                $form .= CreateComboBox(getGet($elt, [$colonne]), $listeCleSecondaires[$colonne]['table'], [ucfirst($listeCleSecondaires[$colonne]['table']::getChamps()[1])], $attributs, null, null, null);
        
            }
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