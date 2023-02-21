<?php
echo '
<main class="center">
    <form action=".?page=ActionArticle" method="POST" class="GridForm">';
if(isset($_GET["id"])){
    $infoArt=ArticlesManager::FindById($_GET["id"])[0];
}else{
    $infoArt=new Articles();
}

    echo '
        <input type="hidden" value='.$infoArt->getIdArticle().' name=idArticle>
        <div class="center">
            <label for=refArticle>Référence de l\'article</label>
        </div>
        <div class="center">
            <input type="text" name=refArticle id=refArticle required value="'.$infoArt->getRefArticle().'">
        </div>
        <div class="bigEspace  col-span-form"></div>	
        <div class="center"><label for=libelleArticle>Libelle de l\'article</label></div></div>
        <div><input type="text" name=libelleArticle id=libelleArticle required value="'.$infoArt->getLibelleArticle().'"></div>
        <div class="bigEspace  col-span-form"></div>	
        <div class="center"><label for=prix>Prix de l\'article</label></div>
        <div><input type="number" step="0.05" name=prix id=prix required value="'.$infoArt->getPrix().'"></div>
        <div class="bigEspace  col-span-form"></div>
        <button class="btnRetour">Annuler</button>	
        <input type="submit" value="Valider">
    </form>
</main>';