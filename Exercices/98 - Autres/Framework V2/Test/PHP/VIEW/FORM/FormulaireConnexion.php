<?php
echo '
<form method="POST" action=".?afficher=ActionConnect&Mode=Connect" class="formContain">
    <div></div>
    <div></div>
    '.CreateInput("text", "pseudoUtilisateur", "required").'
    <div></div>
    <div></div>

    <div class="ligneSepar"></div>

    <div></div>
    <div></div>
    '.CreateInput("password", "password", "required").'
    <div></div>
    <div></div>

    <div class="ligneSepar"></div>

    <div></div>
    <div></div>
    <a href="."><input id="btnCancel" class="cancel" type="button" value="Annuler"/></a>
    <div></div>
    <input id="btnValid" class="valid" type="submit" value="Valider">
    <div></div>
    <div></div>

</form>
';