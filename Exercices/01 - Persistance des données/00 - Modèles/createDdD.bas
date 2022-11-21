Attribute VB_Name = "Module2"
Sub createDdD()
Attribute createDdD.VB_Description = "Creation d'un tableau de Dictionnaire de Donnée"
Attribute createDdD.VB_ProcData.VB_Invoke_Func = " \n14"
'
' createDdD Macro
' Creation d'un tableau de Dictionnaire de Donnée
'

'
    Columns("A:A").ColumnWidth = 26.71
    Columns("B:B").ColumnWidth = 36
    Range("A1").Select
    ActiveCell.FormulaR1C1 = "Nom"
    Range("B1").Select
    ActiveCell.FormulaR1C1 = "Libellé"
    Range("C1").Select
    ActiveCell.FormulaR1C1 = "Type"
    Range("D1").Select
    ActiveCell.FormulaR1C1 = "Code"
    Range("C2").Select
    Columns("D:D").ColumnWidth = 17.57
    Range("A1:D24").Select
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlBottom
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .WrapText = False
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    With Selection
        .HorizontalAlignment = xlCenter
        .VerticalAlignment = xlCenter
        .WrapText = True
        .Orientation = 0
        .AddIndent = False
        .IndentLevel = 0
        .ShrinkToFit = False
        .ReadingOrder = xlContext
        .MergeCells = False
    End With
    ActiveSheet.ListObjects.Add(xlSrcRange, Range("$A$1:$D$24"), , xlYes).Name = _
        "Tableau1"
    Range("A1:D24").Select
    Selection.Borders(xlDiagonalDown).LineStyle = xlNone
    Selection.Borders(xlDiagonalUp).LineStyle = xlNone
    With Selection.Borders(xlEdgeLeft)
        .LineStyle = xlContinuous
        .ColorIndex = 0
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection.Borders(xlEdgeTop)
        .LineStyle = xlContinuous
        .ColorIndex = 0
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection.Borders(xlEdgeBottom)
        .LineStyle = xlContinuous
        .ColorIndex = 0
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection.Borders(xlEdgeRight)
        .LineStyle = xlContinuous
        .ColorIndex = 0
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection.Borders(xlInsideVertical)
        .LineStyle = xlContinuous
        .ColorIndex = 0
        .TintAndShade = 0
        .Weight = xlThin
    End With
    With Selection.Borders(xlInsideHorizontal)
        .LineStyle = xlContinuous
        .ColorIndex = 0
        .TintAndShade = 0
        .Weight = xlThin
    End With
    Range("A2").Select
End Sub
