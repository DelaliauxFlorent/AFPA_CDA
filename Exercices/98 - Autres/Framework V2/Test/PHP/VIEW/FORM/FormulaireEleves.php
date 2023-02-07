<?php
            echo '<form method="POST" action=".?afficher=ActionEleves" class="formContain">
        <input type="hidden" id="Mode" name="Mode" value='.$_GET["Mode"].'></input>
            
            <div class="noDisplay" ></div>
            <div class="noDisplay" ></div>
            <input type=hidden id="idEleve" name="idEleve"  value="""></input>
            <div class="noDisplay" ></div>
            <div class="noDisplay" ></div>
            
            <div class="ligneSepar"></div>
            
            
            <div></div>
            <div></div>
            <label for="nom">Entrez la valeur de "Nom": </label><div></div><input type="text" id="nom" name="nom" value="" required >
            <div></div>
            <div></div>
            
            <div class="ligneSepar"></div>
            
            
            <div></div>
            <div></div>
            <label for="prenom">Entrez la valeur de "Prenom": </label><div></div><input type="text" id="prenom" name="prenom" value="test" required >
            <div></div>
            <div></div>
            
            <div class="ligneSepar"></div>
            
            
            <div></div>
            <div></div>
            <label for="idClasse">Entrez la valeur de "IdClasse": </label><div></div><select id="idClasse" name="idClasse"  value=""><option value="" Selected>--Choisissez une valeur--</option><option value="1" >CP</option><option value="2" >CE1</option><option value="3" >CE2</option><option value="4" >CM1</option><option value="5" >CM2</option></select>
            <div></div>
            <div></div>
            
            <div class="ligneSepar"></div>
            
        
        <div>&nbsp;</div>
        <div>&nbsp;</div>
            <a href=".?afficher=ListeEleves"><input id="btnCancel" class="cancel" type="button" value="Annuler"/></a>
        <div>&nbsp;</div>
            <input id="btnValid" class="valid" type="submit" value="Valider"><div>&nbsp;</div>
        <div>&nbsp;</div></form>';