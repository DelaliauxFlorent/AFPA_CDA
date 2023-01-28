// JavaScript source code
var Shl = new ActiveXObject("WScript.Shell");
var Dsk = Shl.SpecialFolders("Desktop");
var lnk = Shl.CreateShortcut(Dsk + "\\Shuffle Stagiaires.lnk");

// Récupérer la valeur de la propriété "CustomActionData" (ici, [TARGETDIR])
var parameters = Session.Property("CustomActionData");

//Emplacement de l'exécutable après installation
lnk.TargetPath = parameters + "ShuffleStagiaires.exe";

//Emplacement du dossier contenant le programme
lnk.WorkingDirectory = parameters;

//Emplacement de l’icône du raccourci (optionnel)
lnk.IconLocation = parameters +"ShuffleStagiaires.exe";

//Description affichée au survol du raccourci
lnk.Description = "Programme d'assignement aléatoire des stagiaires aux PCs.";
lnk.Save();

