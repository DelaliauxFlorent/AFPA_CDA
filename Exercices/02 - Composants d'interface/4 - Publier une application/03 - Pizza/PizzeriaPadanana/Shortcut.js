// JavaScript source code
var Shl = new ActiveXObject("WScript.Shell");
var Dsk = Shl.SpecialFolders("Desktop");
var lnk = Shl.CreateShortcut(Dsk + "\\NomDuRaccourci.lnk");

//Emplacement de l'ex�cutable apr�s installation (Manufacturer et ProductName en toute lettres, voir Setup)
//lnk.TargetPath = "C:\\Program Files (x86)\\Manufacturer\\ProductName\\NomExecutable.exe";

lnk.TargetPath = "C:\\Program Files (x86)\\MaPetiteEntreprise\\Pizzeria Padanana\\PizzeriaPadanana.exe";
lnk.WorkingDirectory = "C:\\Program Files (x86)\\MaPetiteEntreprise\\Pizzeria Padanana\\";
//Emplacement du dossier contenant le programme
//lnk.WorkingDirectory = "C:\\Program Files (x86)\\Manufacturer\\ProductName\\";

//Emplacement de l'icone du raccourci (optionnel)
//lnk.IconLocation = "C:\\Program Files (x86)\\Manufacturer\\ProductName\\NomExecutable.exe";

//Description affich�e au survol du raccourci
lnk.Description = "Description";
lnk.Save();

