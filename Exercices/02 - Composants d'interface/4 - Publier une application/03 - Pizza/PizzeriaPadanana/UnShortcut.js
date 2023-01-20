// JavaScript source code
Shell = new ActiveXObject("WScript.Shell");
FSO = new ActiveXObject("Scripting.FileSystemObject");
DesktopPath = Shell.SpecialFolders("Desktop");
FSO.DeleteFile(DesktopPath + "\\Pizzeria Padanana.lnk")