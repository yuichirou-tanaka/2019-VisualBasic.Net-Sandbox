Imports System
Imports System.Collections

Module Module1

    Structure DrawTestData
        Public exists As Boolean ' Excel上の黒い位置や×印、設定できない箇所
        Public Idx As Integer
        Public x As Integer
        Public y As Integer
        Sub Init(ByVal inidx As Integer, ByRef inExists As Boolean)
            Idx = inidx
            exists = inExists
        End Sub
    End Structure
    Structure DrawTestOneDataList
        Public mapdraw As List(Of DrawTestData)
        Sub Init(in_maxCount As Integer)
            mapdraw = New List(Of DrawTestData)(in_maxCount - 1)
            For i As Integer = 0 To in_maxCount - 1
                mapdraw.Add(New DrawTestData)
            Next
        End Sub
        Sub InitRandom()
            For i As Integer = mapdraw.Count - 1 To 0 Step -1
                Dim tmpMd As DrawTestData = mapdraw(i)
                tmpMd.x = i Mod 100
                tmpMd.y = i / 100
                mapdraw(i) = tmpMd
            Next
        End Sub
    End Structure
    Sub Main()
        Main2()
        'Main3()
        'Main4()
    End Sub

    Sub DisplayItems(Of T)(msg As String, collection As IEnumerable(Of T))
        'Console.Write(msg)
    End Sub

    Sub Main4()


        Dim list As List(Of DrawTestData) = New List(Of DrawTestData) From {New DrawTestData(), New DrawTestData(), New DrawTestData()}

        ' ソートした結果を別のコレクションにするにはLINQのOrderBy拡張メソッド
        'Dim sorted As IOrderedEnumerable(Of Integer) = list.OrderBy(Function(n) n.x > n.x And n.y > n.y)
        'DisplayItems("list", list)
        'DisplayItems("OrderBy", sorted)
        ' 出力：
        ' list: 3, 1, 2
        ' OrderBy: 1, 2, 3

        ' コレクションの内容をソートするにはList<T>クラスのSortメソッド

        list.Sort()
        DisplayItems("List.Sort", list)
        ' 出力：
        ' List.Sort: 1, 2, 3



    End Sub


    Sub Main3()


        Dim list As List(Of Integer) = New List(Of Integer) From {3, 1, 2}

        ' ソートした結果を別のコレクションにするにはLINQのOrderBy拡張メソッド
        Dim sorted As IOrderedEnumerable(Of Integer) = list.OrderBy(Function(n) n)
        DisplayItems("list", list)
        DisplayItems("OrderBy", sorted)
        ' 出力：
        ' list: 3, 1, 2
        ' OrderBy: 1, 2, 3

        ' コレクションの内容をソートするにはList<T>クラスのSortメソッド
        list.Sort()
        DisplayItems("List.Sort", list)
        ' 出力：
        ' List.Sort: 1, 2, 3

    End Sub

    Sub Main2()
        Dim a As New DrawTestOneDataList
        a.Init(1000)
        a.InitRandom()
        Dim amap = From am In a.mapdraw Order By am.x Descending Order By am.y Descending


    End Sub

End Module

