Imports Xunit

Public Class FoodChainTests
    <Fact>
    Public Sub Fly()
        Dim expected = "I know an old lady who swallowed a fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die."
        Assert.Equal(expected, Recite(1))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Spider()
        Dim expected = "I know an old lady who swallowed a spider." & vbLf & "It wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die."
        Assert.Equal(expected, Recite(2))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Bird()
        Dim expected = "I know an old lady who swallowed a bird." & vbLf & "How absurd to swallow a bird!" & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die."
        Assert.Equal(expected, Recite(3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cat()
        Dim expected = "I know an old lady who swallowed a cat." & vbLf & "Imagine that, to swallow a cat!" & vbLf & "She swallowed the cat to catch the bird." & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die."
        Assert.Equal(expected, Recite(4))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Dog()
        Dim expected = "I know an old lady who swallowed a dog." & vbLf & "What a hog, to swallow a dog!" & vbLf & "She swallowed the dog to catch the cat." & vbLf & "She swallowed the cat to catch the bird." & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die."
        Assert.Equal(expected, Recite(5))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Goat()
        Dim expected = "I know an old lady who swallowed a goat." & vbLf & "Just opened her throat and swallowed a goat!" & vbLf & "She swallowed the goat to catch the dog." & vbLf & "She swallowed the dog to catch the cat." & vbLf & "She swallowed the cat to catch the bird." & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die."
        Assert.Equal(expected, Recite(6))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Cow()
        Dim expected = "I know an old lady who swallowed a cow." & vbLf & "I don't know how she swallowed a cow!" & vbLf & "She swallowed the cow to catch the goat." & vbLf & "She swallowed the goat to catch the dog." & vbLf & "She swallowed the dog to catch the cat." & vbLf & "She swallowed the cat to catch the bird." & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die."
        Assert.Equal(expected, Recite(7))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Horse()
        Dim expected = "I know an old lady who swallowed a horse." & vbLf & "She's dead, of course!"
        Assert.Equal(expected, Recite(8))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Multiple_verses()
        Dim expected = "I know an old lady who swallowed a fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die." & vbLf & vbLf & "I know an old lady who swallowed a spider." & vbLf & "It wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die." & vbLf & vbLf & "I know an old lady who swallowed a bird." & vbLf & "How absurd to swallow a bird!" & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die."
        Assert.Equal(expected, Recite(1, 3))
    End Sub

    <Fact(Skip:="Remove this Skip property to run this test")>
    Public Sub Full_song()
        Dim expected = "I know an old lady who swallowed a fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die." & vbLf & vbLf & "I know an old lady who swallowed a spider." & vbLf & "It wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die." & vbLf & vbLf & "I know an old lady who swallowed a bird." & vbLf & "How absurd to swallow a bird!" & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die." & vbLf & vbLf & "I know an old lady who swallowed a cat." & vbLf & "Imagine that, to swallow a cat!" & vbLf & "She swallowed the cat to catch the bird." & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die." & vbLf & vbLf & "I know an old lady who swallowed a dog." & vbLf & "What a hog, to swallow a dog!" & vbLf & "She swallowed the dog to catch the cat." & vbLf & "She swallowed the cat to catch the bird." & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die." & vbLf & vbLf & "I know an old lady who swallowed a goat." & vbLf & "Just opened her throat and swallowed a goat!" & vbLf & "She swallowed the goat to catch the dog." & vbLf & "She swallowed the dog to catch the cat." & vbLf & "She swallowed the cat to catch the bird." & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die." & vbLf & vbLf & "I know an old lady who swallowed a cow." & vbLf & "I don't know how she swallowed a cow!" & vbLf & "She swallowed the cow to catch the goat." & vbLf & "She swallowed the goat to catch the dog." & vbLf & "She swallowed the dog to catch the cat." & vbLf & "She swallowed the cat to catch the bird." & vbLf & "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her." & vbLf & "She swallowed the spider to catch the fly." & vbLf & "I don't know why she swallowed the fly. Perhaps she'll die." & vbLf & vbLf & "I know an old lady who swallowed a horse." & vbLf & "She's dead, of course!"
        Assert.Equal(expected, Recite(1, 8))
    End Sub
End Class
