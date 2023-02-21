<?php
global $regex;

echo '<main class="center">';

echo '  <form class=GridForm" method="POST" action=".">';

echo '      <div class="bigEspace"></div>';
echo '      <div class="caseForm" titreForm col-span-form">Formulaire de vote</div>';
echo '      <div class="bigEspace  col-span-form"></div>';
echo '      <label for=CodeVotant class="caseForm labelForm">Votre code de votant</label>';
echo '      <div class="caseForm donneeForm"><input type="number" id="CodeVotant" name=CodeVotant pattern="'.$regex["num"].'" required></div>';
echo '      <div class="center"></div><div></div>';

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
            <div><input type="button" id="Voter" value="Voter"></div>
            <div></div>';

echo '  </form>';

echo '</main>';