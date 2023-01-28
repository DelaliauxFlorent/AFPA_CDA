// JavaScript source code
Shell = new ActiveXObject("WScript.Shell");
FSO = new ActiveXObject("Scripting.FileSystemObject");
// Chemin vers le bureau
DesktopPath = Shell.SpecialFolders("Desktop");
// Nom du raccourci
FSO.DeleteFile(DesktopPath + "\\Shuffle Stagiaires.lnk");