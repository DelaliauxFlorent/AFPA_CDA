<?php
echo '<main>';
echo '<div class="cote"></div>
<div class="listArticles">';
echo '<div class="grid-columns-span-3"></div>';
echo '<div class="article">';
echo '<div class="btnAjout center"><a href=".?page=FormArticle">Ajouter</a></div>';
echo '</div>';
echo '</div><div class="cote"></div>';
echo '</main>';
echo '
<template id="tplArticle">
    <a href=".?page=FormArticle&id=ValeurIdArticle">
        <div class="article">
            <div class="left grid-columns-span-2">LibeleArticle</div>
            <div class="grid-columns-span-2 center data">ValeurLibelle</div>
            <div class="left">RefArticle</div>
            <div class="center data">ValeurRef</div>
            <div class="left">Prix</div>
            <div class="center data">ValeurPrix</div>
            <div class="left">Quantite</div>
            <div class="center data" name="qte" data-refart="ValeurRef">Information indisponible</div>
            <div class="left">Delai</div>
            <div class="center data" name="delai" data-refart="ValeurRef"></div>
        </div>
    </a>
</template>
';