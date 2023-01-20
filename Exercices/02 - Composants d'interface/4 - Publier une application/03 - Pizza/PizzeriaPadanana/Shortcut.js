// JavaScript source code
var Shl = new ActiveXObject("WScript.Shell");
var Dsk = Shl.SpecialFolders("Desktop");
var lnk = Shl.CreateShortcut(Dsk + "\\Pizzeria Padanana.lnk");

//Emplacement de l'exécutable après installation (Manufacturer et ProductName en toute lettres, voir Setup)
lnk.TargetPath = "C:\\Program Files (x86)\\MaPetiteEntreprise\\Pizzeria Padanana\\PizzeriaPadanana.exe";
//Emplacement du dossier contenant le programme
lnk.WorkingDirectory = "C:\\Program Files (x86)\\MaPetiteEntreprise\\Pizzeria Padanana\\";

//Emplacement de l'icone du raccourci (optionnel)
//lnk.IconLocation = "C:\\Program Files (x86)\\Manufacturer\\ProductName\\NomExecutable.exe";

//Description affichée au survol du raccourci
lnk.Description = "Description";
lnk.Save();

