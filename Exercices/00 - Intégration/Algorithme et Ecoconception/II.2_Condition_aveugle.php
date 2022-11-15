<?php
$tutu=readline("Tutu? ");
$toto=readline("Toto? ");
$tata=readline("Tata? ");
/*
if(($tutu>($toto+4))||($tata=="OK")){
    $tutu++;
}else{
    $tutu--;
}*/

if(($tutu<=($toto+4))&&($tata!="OK")){
    $tutu--;
}else{
    $tutu++;
}

echo "tutu=".$tutu;