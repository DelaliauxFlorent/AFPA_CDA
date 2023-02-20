<?php
global $regex;

echo '<main class="center">';

echo '  <form class=GridForm" action="." method="post">';

echo '      <div class="bigEspace"></div>';
echo '      <div class="caseForm" titreForm col-span-form">Formulaire de vote</div>';
echo '      <div class="bigEspace  col-span-form"></div>';
echo '      <label for=CodeVotant class="caseForm labelForm">Votre code de votant</label>';
echo '      <div class="caseForm donneeForm"><input type="number" id="CodeVotant" name=CodeVotant pattern="'.$regex["num"].'" required></div>';
echo '      <div class="center"><i class="fas fa-paper-plane"></i></div><div><div class="infobulle noDisplay">Code Invalide</div></div>';

echo '      <label class="caseForm labelForm">Votre vote</label>';
echo '      <div class="caseForm donneeForm">
                <div class="FlowVert center">
                    <input type="radio" name="Vote" value="Chien" id="Chien">
                        <Label for="Chien">Chien</label>
                    <input type="radio" name="Vote" value="Chat" id="Chat" required>
                        <label for="Chat">Chat<label>
                </div>
            </div>';
echo '      <div></div><div></div>';

echo '      <div class="bigEspace "></div>	';
echo '      <div class="caseForm col-span-form">
	        <div></div>
            <div></div>
            <div><button id="Voter">Voter</button></div>
            <div></div>';

echo '  </form>';

echo '</main>';