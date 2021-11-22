Imports System.Xml
Module Module1

    Sub Main()

        Console.WriteLine("start")

        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load("StressSetting_A1.xml")
        Dim actions As Xml.XmlNode = xmlDoc.FirstChild 'GetElementById("Action")

        Debug.Print(actions.Attributes("IsHTXAction").Value)

        SetXml(actions)
        Console.WriteLine("end")

        'Dim ResourceXMLFileName As String = "StressSetting_A1.xml"
        'Dim defaultXml As Xml.XmlNode
        'defaultXml = GetXMLNodeFormat("HoteiUnitDukeBH620A", ResourceXMLFileName)
        'SetXml(defaultXml)
    End Sub

    Function GetXMLNodeFormat(ByVal ProjectName As String, ByVal ResourceXMLFileName As String) As Xml.XmlNode

        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim sr As New System.IO.StreamReader(myAssembly.GetManifestResourceStream(ProjectName & "." & ResourceXMLFileName), _
            System.Text.Encoding.GetEncoding("utf-8"))
        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc.Load(sr)
        xmlDoc.PreserveWhitespace = True
        Return xmlDoc.FirstChild

    End Function
    Function SetXml(ByVal XMLNode As Xml.XmlNode) As Boolean
        Dim targetNode As Xml.XmlNode = XMLNode.SelectSingleNode("FunctionParameters/Input")
        Console.WriteLine(targetNode.SelectSingleNode("Parameter [@Name='StressVoltage_V']").InnerText)

        Return True
    End Function

End Module
