@echo off

mkdir CSS HTML IMG JS PHP SQL
echo "<?php echo 'Wesh Monde'; ?>" > index.php

cd CSS
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
cd ../HTML
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
cd ../IMG
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
cd ../JS
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
cd ../SQL
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
cd ../PHP
mkdir CONTROLLER MODEL VIEW
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
echo "<?php echo 'Créer le config.json'; ?>" > config.json
cd CONTROLLER
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
echo "<?php echo 'Outils'; ?>" > Outils.php
mkdir ACTION CLASSE
cd ACTION
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
cd ../CLASSE
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
cd ../../MODEL
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
mkdir API MANAGER
cd API
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
cd ../MANAGER
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
echo "<?php echo 'DbConnect'; ?>" > DbConnect.php
cd ../../VIEW
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
mkdir FORM GENERAL LISTE
cd FORM
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
cd ../GENERAL
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php
cd ../LISTE
echo "<?php echo 'Wesh Sécurité'; ?>" > index.php

echo Done!
