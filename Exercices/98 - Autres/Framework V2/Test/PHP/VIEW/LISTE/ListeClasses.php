<?php
    $numParPage = 10;
    $debutLimite = 0;
    $pageActu = 1;
    if (isset($_GET['page']) && (is_numeric($_GET['page']))) {
        $pageActu = intval($_GET['page']);
        $debutLimite = ($pageActu-1) * $numParPage;
    }
    $limite = $debutLimite . ',' . $numParPage;
    $pagePath="ListeClasses";
    $listeObjets = ClassesManager::GetList(null, null, null, $limite, false, false);
    $nbObjets=((ClassesManager::GetList(null, null, null, $limite, false, false)!=false)?count($listeObjets):0);

    $totalEntrees=((ClassesManager::GetList(null, null, null, null, false, false)!=false)?count(ClassesManager::GetList(null, null, null, null, false, false)):0);

    if ($totalEntrees < $numParPage) {
        $lastPage = 1;
    } else {
        $lastPage = $totalEntrees / $numParPage;
    }
    $listeChamps = Classes::getChamps();
    $numLign = 0;
    echo '
    <div class="ligne">
        <div></div>
        <div class="centered"><a href=".?afficher=FormClasses&Mode=Ajouter" class="buttonDash">Ajouter</a></div>
        <div></div>
    </div>
    <div class="ligne">    
        <div>' . (($pageActu != 1) ? '<a class="buttonDash" href="index.php?afficher=' . $pagePath . '"><<</a>' : '') . '</div>
        <div>' . (($pageActu != 1) ? '<a class="buttonDash" href="index.php?afficher=' . $pagePath . '&page=' . ($pageActu - 1) . '"><</a>' : '') . '</div>
        <div>' . ($debutLimite + 1) . ' à ' .((($debutLimite + $numParPage)>$totalEntrees)?$totalEntrees:($debutLimite + $numParPage)) . '/' . $totalEntrees . '</div>
        <div>' . (($pageActu != $lastPage) ? '<a class="buttonDash" href="index.php?afficher=' . $pagePath . '&page=' . ($pageActu + 1) . '">></a>' : '') . '</div>
        <div>' . (($pageActu != $lastPage) ? '<a class="buttonDash" href="index.php?afficher=' . $pagePath . '&page=' . $lastPage . '">>></a>' : '') . '</div>
    </div>
    <div class="container liste' . (count($listeChamps) - 1) . 'attribut">';
    if ($nbObjets != 0) {
        
        for ($i = 1; $i < count($listeChamps); $i++) {
            echo '<div class="liste listeHead">' . ltrim(ucfirst($listeChamps[$i]), "_") . '</div>';
        }
        echo '<div class="listeHead">Affic.</div>';
        echo '<div class="listeHead">Modif.</div>';
        echo '<div class="listeHead">Suppr.</div>';
        foreach ($listeObjets as $objet) {
            $ligneAlter = ($numLign % 2 == 0) ? " class='alterLigne'" : "";
            $getid="get".$listeChamps[0];
            $id=$objet->$getid();
            for ($i = 1; $i < count($listeChamps); $i++) {
                $getvalue = "get" . $listeChamps[$i];
                $valeurActu = $objet->$getvalue();

                echo '<div' . $ligneAlter . '>' . (($valeurActu != null) ? $valeurActu : "") . '</div>';
            }
            echo '<div' . $ligneAlter . '><a href=".?afficher=FormClasses&Mode=Visu&id='.$id.'"><img src="./IMG/afficher.png" alt="Voir"></a></div>';
            echo '<div' . $ligneAlter . '><a href=".?afficher=FormClasses&Mode=Modifier&id='.$id.'"><img src="./IMG/editer.png" alt="Éditer"></a></div>';
            echo '<div' . $ligneAlter . '><a href=".?afficher=FormClasses&Mode=Supprimer&id='.$id.'"><img src="./IMG/effacer.png" alt="Éffacer"></a></div>';
            $numLign++;
        }
    }
    echo '</div></div>';