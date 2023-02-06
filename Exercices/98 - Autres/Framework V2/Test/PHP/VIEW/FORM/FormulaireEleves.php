<?php
            $infosTable = RecupInfos("Eleves");
            $listeCleSecondaires = ListerFK("Eleves");
            $id = (isset($_GET["id"]) ? $_GET["id"] : "");
            $elt=ElevesManager::FindById($id);
            $form ='<div class="container"><form methode="get" action="./PHP/CONTROLLER/ACTION/ActionEleves.php">';
            $form.='<div class="formContain">';

        foreach ($infosTable as $colonne => $infoColonne) {
            $display=($infosTable[$colonne]['Cle'] == "Primaire")?' class="noDisplay"':"";
            // Pour chaque colonne de la table/attribut de la classe, on fait une ligne
            $form .= '<div'.$display.'></div>';
            $form .= '<div'.$display.'></div>';

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
                $form .= '<label for="' . $colonne . '">Entrez la valeur de "' . ucfirst($colonne) . '": </label><div></div>';
                $form .= CreateComboBox(getGet($elt, [$colonne]), $listeCleSecondaires[$colonne]['table'], [ucfirst($listeCleSecondaires[$colonne]['table']::getChamps()[1])], $attributs, null, null, null);
        
            }
            $form .= '<div'.$display.'></div>';
            $form .= '<div'.$display.'></div>';
            $form.='<div class="ligneSepar"></div>';

        }
        // On fait une ligne pour les boutons annuler et valider
        $form .= '<div></div>';
        $form .= '<div></div>';
        $form .= '<input id="btnCancel" class="cancel" type="button" value="Annuler"><div>&nbsp;</div>';
        $form .= '<input class="valid" type="submit" value="Valider"><div></div>';

        // Et on termine le formulaire
        $form .= '</div></form></div>';
        echo $form;