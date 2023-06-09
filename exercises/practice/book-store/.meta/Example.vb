Imports System
Imports System.Linq

Public Module BookStore
    Private Const BookPrice As Decimal = 8.0D

    Public Function Total(ByVal books As Integer()) As Decimal
        If books.Length = 0 Then Return 0.0D

        Dim bookGroups = BookGroupsWithCount(books)

        Return Enumerable.Range(1, bookGroups.Length).Min(Function(size) CalculateTotalCost(bookGroups, size, 0.0D))
    End Function

    Private Function BookGroupsWithCount(ByVal books As Integer()) As Integer()
        Return books.GroupBy(Function(book) book).[Select](Function(book) book.Count()).OrderByDescending(Function(book) book).ToArray()
    End Function

    Private Function CalculateTotalCost(ByVal bookGroups As Integer(), ByVal numberOfBooksToRemove As Integer, ByVal totalCost As Decimal) As Decimal
        Dim numberOfBooks = Math.Min(numberOfBooksToRemove, bookGroups.Length)
        If numberOfBooks = 0 Then
            Return totalCost + RegularPrice(bookGroups.Sum())
        End If

        Dim updatedBookGroups = RemoveBooks(bookGroups, numberOfBooks)
        Dim updatedTotalCost = totalCost + BooksPrice(numberOfBooks)
        Return CalculateTotalCost(updatedBookGroups, numberOfBooks, updatedTotalCost)
    End Function

    Private Function RemoveBooks(ByVal bookGroups As Integer(), ByVal numberOfBooks As Integer) As Integer()
        Return bookGroups.Take(numberOfBooks).[Select](New Func(Of Integer, Integer)(AddressOf RemoveBook)).Concat(bookGroups.Skip(numberOfBooks)).Where(Function(i) i > 0).OrderByDescending(Function(x) x).ToArray()
    End Function

    Private Function RemoveBook(ByVal books As Integer) As Integer
        Return books - 1
    End Function

    Private Function BooksPrice(ByVal differentBooks As Integer) As Decimal
        Return ApplyDiscount(RegularPrice(differentBooks), DiscountPercentage(differentBooks))
    End Function

    Private Function RegularPrice(ByVal books As Integer) As Decimal
        Return books * BookPrice
    End Function

    Private Function DiscountPercentage(ByVal differentBooks As Integer) As Decimal
        Select Case differentBooks
            Case 5
                Return 25.0D
            Case 4
                Return 20.0D
            Case 3
                Return 10.0D
            Case 2
                Return 5.0D
            Case Else
                Return 0.0D
        End Select
    End Function

    Private Function ApplyDiscount(ByVal price As Decimal, ByVal discountPercentage As Decimal) As Decimal
        Return Math.Round(price * (100.0D - discountPercentage) / 100.0D, 2)
    End Function
End Module
