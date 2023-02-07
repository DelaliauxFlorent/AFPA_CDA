<?php
            echo '<form method="POST" action=".?afficher=ActionUtilisateurs" class="formContain">
        <input type="hidden" id="Mode" name="Mode" value='.$_GET["Mode"].'></input>';

            //Champ idUtilisateur
            echo '            
            <div class="noDisplay" ></div>
            <div class="noDisplay" ></div>
            <input type=hidden id="idUtilisateur" name="idUtilisateur"  value="""></input>
            <div class="noDisplay" ></div>
            <div class="noDisplay" ></div>
            
            <div class="ligneSepar"></div>
            ';

            //Champ nomUtilisateur
            echo '            
            <div></div>
            <div></div>
            <label for="nomUtilisateur">Entrez la valeur de "NomUtilisateur": </label><div></div><input type="text" id="nomUtilisateur" name="nomUtilisateur" value="" required >
            <div></div>
            <div></div>
            
            <div class="ligneSepar"></div>
            ';

            //Champ pseudoUtilisateur
            echo '            
            <div></div>
            <div></div>
            <label for="pseudoUtilisateur">Entrez la valeur de "PseudoUtilisateur": </label><div></div><input type="text" id="pseudoUtilisateur" name="pseudoUtilisateur" value="" required >
            <div></div>
            <div></div>
            
            <div class="ligneSepar"></div>
            ';

            //Champ password
            echo '<input type="hidden" id="password" name="password" value="">';

            //Champ mail
            echo '            
            <div></div>
            <div></div>
            <label for="mail">Entrez la valeur de "Mail": </label><div></div><input type="text" id="mail" name="mail" value="" required >
            <div></div>
            <div></div>
            
            <div class="ligneSepar"></div>
            ';

            //Champ role
            echo '            
            <div></div>
            <div></div>
            <label for="role">Entrez la valeur de "Role": </label><div></div><input type="number" id="role" name="role" value="0" required >
            <div></div>
            <div></div>
            
            <div class="ligneSepar"></div>
            ';
        
        // Boutons
        echo '        
        <div>&nbsp;</div>
        <div>&nbsp;</div>
            <a href=".?afficher=ListeUtilisateurs"><input id="btnCancel" class="cancel" type="button" value="Annuler"/></a>
        <div>&nbsp;</div>
            <input id="btnValid" class="valid" type="submit" value="Valider"><div>&nbsp;</div>
        <div>&nbsp;</div></form>';