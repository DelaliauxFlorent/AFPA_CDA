<?php
echo '
<main class="center">
    <form action=".?page=ActionArticle" method="POST" class="GridForm">
        <label for=refArticle>Référence de l\'article</label>
        <div><input type="text" name=refArticle id=refArticle required></div>
        <div class="bigEspace  col-span-form"></div>	
        <label for=libelleArticle>Libelle de l\'article</label>
        <div><input type="text" name=libelleArticle id=libelleArticle required></div>
        <div class="bigEspace  col-span-form"></div>	
        <label for=prix>Prix de l\'article</label>
        <div><input type="number" step="0.05" name=prix id=prix></div>
        <div class="bigEspace  col-span-form"></div>	
        <input type="submit" value=Valider>
    </form>
</