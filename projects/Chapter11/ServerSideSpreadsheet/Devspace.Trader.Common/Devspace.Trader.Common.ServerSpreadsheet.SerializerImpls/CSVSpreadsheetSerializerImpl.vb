Imports Devspace.Trader.Common.ServerSpreadsheet
Imports Devspace.Trader.Common.Tracer
Imports LumenWorks.Framework.IO.Csv
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports System.Text

Namespace Devspace.Trader.Common.ServerSpreadsheet.SerializerImpls
    Friend Class CSVSpreadsheetSerializerImpl
        Inherits TraderBaseClass
        Implements ISpreadsheetSerializer
        ' Methods
        Public Function Load(ByVal workbook As IWorkbook, ByVal path As String) As Boolean Implements ISpreadsheetSerializer.Load
            If Not Directory.Exists(path) Then
                Return False
            End If
            Using csv As CsvReader = New CsvReader(New StreamReader((path & "\workbook.csv")), False)
                Dim fieldCount As Integer = csv.FieldCount
                Do While csv.ReadNextRecord
                    Dim identifier As String = csv.Item(0)
                    Dim typeToIstantiate As String = csv.Item(1)
                    Dim sheet As IWorksheetBase = TryCast(Activator.CreateInstance(Type.GetType(typeToIstantiate)), IWorksheetBase)
                    Dim rows As Integer = Integer.Parse(csv.Item(2))
                    Dim cols As Integer = Integer.Parse(csv.Item(3))
                    sheet.Dimension(rows, cols)
                    Me.LoadSheet(typeToIstantiate, path, identifier, sheet)
                    workbook.Item(identifier) = sheet
                    If MyBase.Debug Then
                        Dim i As Integer
                        For i = 0 To fieldCount - 1
                            GenerateOutput.Write("Workbook.Load", ("Field (" & csv.Item(i) & ")"))
                        Next i
                        GenerateOutput.Write("Workbook.Load", ("Sheet(" & ChrW(10) & sheet.ToString & ")"))
                    End If
                Loop
            End Using
            Return True
        End Function

        Public Function LoadSheet(Of DataType)(ByVal path As String, ByVal rows As Integer, ByVal cols As Integer) As IWorksheet(Of DataType) Implements ISpreadsheetSerializer.LoadSheet
            Dim sheet As IWorksheet(Of DataType) = New Worksheet(Of DataType)
            sheet.Dimension(rows, cols)
            Dim celltype As Type = GetType(DataType)
            Dim paramTypes As Type() = New Type() {GetType(String)}
            Dim theMethod As MethodInfo = celltype.GetMethod("Parse", paramTypes)
            Dim sheetSerialize As IWorksheetSerialize = TryCast(sheet, IWorksheetSerialize)
            Using csv As CsvReader = New CsvReader(New StreamReader(path), False)
                Dim totalColumns As Integer = csv.FieldCount
                Dim rowCount As Integer = 0
                Do While csv.ReadNextRecord
                    Dim colCount As Integer
                    For colCount = 0 To totalColumns - 1
                        Dim objs As Object() = New Object() {csv.Item(colCount)}
                        If (theMethod Is Nothing) Then
                            If Not celltype.IsEnum Then
                                If (celltype.FullName <> "System.Object") Then
                                    Throw New NotSupportedException(("Cell type (" & celltype.AssemblyQualifiedName & ") not supported"))
                                End If
                                sheetSerialize.AssignCellState(Of String)(rowCount, colCount, csv.Item(colCount))
                            Else
                                Dim val As Object = [Enum].Parse(celltype, csv.Item(colCount))
                                sheetSerialize.AssignCellState(rowCount, colCount, Val)
                            End If
                        Else
                            Dim retval As Object = theMethod.Invoke(Nothing, objs)
                            sheetSerialize.AssignCellState(rowCount, colCount, retval)
                        End If
                    Next colCount
                    rowCount += 1
                Loop
            End Using
            Return sheet
        End Function

        Private Sub LoadSheet(ByVal typeToIstantiate As String, ByVal path As String, ByVal identifier As String, ByVal sheet As IWorksheetBase)
            Dim baseType As String() = typeToIstantiate.Split(New String() {"[[", "]]"}, StringSplitOptions.None)
            If (baseType.Length = 0) Then
                Throw New Exception("There is no base type which cannot be")
            End If
            If MyBase.Debug Then
                Dim str As String
                For Each str In baseType
                    GenerateOutput.Write("Workbook.Load", ("basetype(" & str & ")"))
                Next
            End If
            Dim sheetSerialize As IWorksheetSerialize = TryCast(sheet, IWorksheetSerialize)
            Dim celltype As Type = Type.GetType(baseType(1))
            Dim worksheetpath As String = (path & "\" & identifier.ToString & ".csv")
            Dim paramTypes As Type() = New Type() {GetType(String)}
            Dim theMethod As MethodInfo = celltype.GetMethod("Parse", paramTypes)
            Using csv As CsvReader = New CsvReader(New StreamReader(worksheetpath), False)
                Dim totalColumns As Integer = csv.FieldCount
                Dim rowCount As Integer = 0
                Do While csv.ReadNextRecord
                    Dim colCount As Integer
                    For colCount = 0 To totalColumns - 1
                        Dim objs As Object() = New Object() {csv.Item(colCount)}
                        If (theMethod Is Nothing) Then
                            If Not celltype.IsEnum Then
                                If (celltype.FullName <> "System.Object") Then
                                    Throw New NotSupportedException(("Cell type (" & celltype.AssemblyQualifiedName & ") not supported"))
                                End If
                                sheetSerialize.AssignCellState(Of String)(rowCount, colCount, csv.Item(colCount))
                            Else
                                Dim val As Object = [Enum].Parse(celltype, csv.Item(colCount))
                                sheetSerialize.AssignCellState(rowCount, colCount, Val)
                            End If
                        Else
                            Dim retval As Object = theMethod.Invoke(Nothing, objs)
                            sheetSerialize.AssignCellState(rowCount, colCount, retval)
                        End If
                    Next colCount
                    rowCount += 1
                Loop
            End Using
        End Sub

        Public Sub Save(ByVal workbook As IWorkbook, ByVal path As String) Implements ISpreadsheetSerializer.Save
            Dim builder As New StringBuilder
            Directory.CreateDirectory(path)
            Dim identifier As String
            For Each identifier In DirectCast(workbook, IEnumerable(Of String))
                builder.Append(identifier)
                builder.Append(",")
                Dim worksheet As IWorksheetBase = workbook.Item(identifier)
                builder.Append(("""" & worksheet.GetType.AssemblyQualifiedName & """"))
                builder.Append(",")
                builder.Append(worksheet.MaxRows)
                builder.Append(",")
                builder.Append(worksheet.MaxCols)
                builder.Append(ChrW(10))
                Dim sheetWriter As StreamWriter = File.CreateText((path & "\" & identifier.ToString & ".csv"))
                sheetWriter.Write(worksheet.ToString)
                sheetWriter.Close()
            Next
            Dim fwriter As StreamWriter = File.CreateText((path & "\workbook.csv"))
            fwriter.Write(builder.ToString)
            fwriter.Close()
        End Sub

        Public Sub Save(ByVal path As String, ByVal worksheetIdentifier As String, ByVal worksheet As IWorksheetBase) Implements ISpreadsheetSerializer.Save
            Dim builder As New StringBuilder
            Directory.CreateDirectory(path)
            Dim sheetWriter As StreamWriter = File.CreateText((path & "\" & worksheetIdentifier.ToString & ".csv"))
            sheetWriter.Write(worksheet.ToString)
            sheetWriter.Close()
        End Sub

    End Class
End Namespace

