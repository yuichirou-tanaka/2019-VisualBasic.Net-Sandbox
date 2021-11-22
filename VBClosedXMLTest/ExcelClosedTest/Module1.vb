Imports System.Console
Imports ClosedXML.Excel
Module Module1

    Sub Main()
        Const ExcelFilePath As String = ".\\sample.xlsx"

        ' Excelファイルを作る
        Using workbook = New XLWorkbook()
            ' ワークシートを追加する
            Dim worksheet As IXLWorksheet
            worksheet = workbook.Worksheets.Add("サンプルシート1")

            worksheet.Cell("A1").Value = 10
            worksheet.Cell("A2").SetValue(20)
            worksheet.Cell("A3").FormulaA1 = "SUM(A1:A2)"
            worksheet.Cell("A3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left) ' 左寄せ

            With worksheet.Cell("A3").Style
                .Fill.BackgroundColor = XLColor.Red
                .NumberFormat.Format = "#,##0.00"
            End With

            workbook.SaveAs(ExcelFilePath)
        End Using
        WriteLine("Excelファイルを保存")


    End Sub

End Module
