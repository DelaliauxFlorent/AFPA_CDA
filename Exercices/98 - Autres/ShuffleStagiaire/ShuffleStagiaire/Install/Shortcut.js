// JavaScript source code
var Shl = new ActiveXObject("WScript.Shell");
var Dsk = Shl.SpecialFolders("Desktop");
var lnk = Shl.CreateShortcut(Dsk + "\\Shuffle Stagiaires.lnk");

// R�cup�rer la valeur de la propri�t� "CustomActionData" (ici, [TARGETDIR])
var parameters = Session.Property("CustomActionData");

//Emplacement de l'ex�cutable apr�s installation
lnk.TargetPath = parameters + "ShuffleStagiaires.exe";

//Emplacement du dossier contenant le programme
lnk.WorkingDirectory = parameters;

//Emplacement de l�ic�ne du raccourci (optionnel)
lnk.IconLocation = parameters +"ShuffleStagiaires.exe";

//Description affich�e au survol du raccourci
lnk.Description = "Programme d'assignement al�atoire des stagiaires aux PCs.";
lnk.Save();

