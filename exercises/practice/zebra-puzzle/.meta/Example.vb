Imports System.Runtime.CompilerServices

Public Enum Color
    Red
    Green
    Ivory
    Yellow
    Blue
End Enum

Public Enum Nationality
    Englishman
    Spaniard
    Ukrainian
    Japanese
    Norwegian
End Enum

Public Enum Pet
    Dog
    Snails
    Fox
    Horse
    Zebra
End Enum

Public Enum Drink
    Coffee
    Tea
    Milk
    OrangeJuice
    Water
End Enum

Public Enum Hobby
    Dancing
    Painting
    Reading
    Football
    Chess
End Enum

Module ZebraPuzzle
    Private ReadOnly Colors As Color() = CType([Enum].GetValues(GetType(Color)), Color())
    Private ReadOnly Nationalities As Nationality() = CType([Enum].GetValues(GetType(Nationality)), Nationality())
    Private ReadOnly Pets As Pet() = CType([Enum].GetValues(GetType(Pet)), Pet())
    Private ReadOnly Drinks As Drink() = CType([Enum].GetValues(GetType(Drink)), Drink())
    Private ReadOnly Hobbies As Hobby() = CType([Enum].GetValues(GetType(Hobby)), Hobby())

    <Extension()>
    Private Function Permutations(Of T)(ByVal input As T()) As IEnumerable(Of T())
        Return input.Permutations(input.Length)
    End Function

    <Extension()>
    Private Function Permutations(Of T)(ByVal input As T(), ByVal length As Integer) As IEnumerable(Of T())
        If length = 1 Then
            Return input.[Select](Function(myT) {myT})
        End If

        Return input.Permutations(length - 1).SelectMany(Function(myT) input.Where(Function(e) Not myT.Contains(e)), Function(t1, t2) t1.Concat({t2}).ToArray())
    End Function

    Private Structure Solution
        Public Colors As Color()
        Public Nationalities As Nationality()
        Public Pets As Pet()
        Public Drinks As Drink()
        Public Hobbies As Hobby()
    End Structure

    Private Function MatchesColorRules(ByVal colors As Color()) As Boolean
        Dim greenRightOfIvoryHouse = Array.IndexOf(colors, Color.Ivory) = Array.IndexOf(colors, Color.Green) - 1
        Return greenRightOfIvoryHouse
    End Function

    Private Function MatchesNationalityRules(ByVal colors As Color(), ByVal nationalities As Nationality()) As Boolean
        Dim englishManInRedHouse = IsIndexMatch(nationalities, Nationality.Englishman, colors, Color.Red)
        Dim norwegianInFirstHouse = nationalities(0) = Nationality.Norwegian
        Dim norwegianLivesNextToBlueHouse = IsAdjacentMatch(nationalities, Nationality.Norwegian, colors, Color.Blue)
        Return englishManInRedHouse AndAlso norwegianInFirstHouse AndAlso norwegianLivesNextToBlueHouse
    End Function

    Private Function MatchesPetRules(ByVal nationalities As Nationality(), ByVal pets As Pet()) As Boolean
        Dim spaniardOwnsDog = IsIndexMatch(nationalities, Nationality.Spaniard, pets, Pet.Dog)
        Return spaniardOwnsDog
    End Function

    Private Function MatchesDrinkRules(ByVal colors As Color(), ByVal nationalities As Nationality(), ByVal drinks As Drink()) As Boolean
        Dim coffeeDrunkInGreenHouse = IsIndexMatch(colors, Color.Green, drinks, Drink.Coffee)
        Dim ukrainianDrinksTee = IsIndexMatch(nationalities, Nationality.Ukrainian, drinks, Drink.Tea)
        Dim milkDrunkInMiddleHouse = drinks(2) = Drink.Milk
        Return coffeeDrunkInGreenHouse AndAlso ukrainianDrinksTee AndAlso milkDrunkInMiddleHouse
    End Function

    Private Function MatchesHobbyRules(ByVal colors As Color(), ByVal nationalities As Nationality(), ByVal drinks As Drink(), ByVal pets As Pet(), ByVal hobbies As Hobby()) As Boolean
        Dim dancerOwnsSnails = IsIndexMatch(hobbies, Hobby.Dancing, pets, Pet.Snails)
        Dim painterInYellowHouse = IsIndexMatch(colors, Color.Yellow, hobbies, Hobby.Painting)
        Dim readerLivesNextToFox = IsAdjacentMatch(hobbies, Hobby.Reading, pets, Pet.Fox)
        Dim painterLivesNextToHorse = IsAdjacentMatch(hobbies, Hobby.Painting, pets, Pet.Horse)
        Dim footballPlayerDrinksOrangeJuice = IsIndexMatch(hobbies, Hobby.Football, drinks, Drink.OrangeJuice)
        Dim japanesePlaysChess = IsIndexMatch(nationalities, Nationality.Japanese, hobbies, Hobby.Chess)
        Return dancerOwnsSnails AndAlso painterInYellowHouse AndAlso readerLivesNextToFox AndAlso painterLivesNextToHorse AndAlso footballPlayerDrinksOrangeJuice AndAlso japanesePlaysChess
    End Function

    Private Function Solutions() As IEnumerable(Of Solution)
        Return From validColors In Colors.Permutations().Where(AddressOf MatchesColorRules) From validNationalities In Nationalities.Permutations().Where(Function(nationalities) MatchesNationalityRules(validColors, nationalities)) From validPets In Pets.Permutations().Where(Function(pets) MatchesPetRules(validNationalities, pets)) From validDrinks In Drinks.Permutations().Where(Function(drinks) MatchesDrinkRules(validColors, validNationalities, drinks)) From validHobbies In Hobbies.Permutations().Where(Function(hobbies) MatchesHobbyRules(validColors, validNationalities, validDrinks, validPets, hobbies)) Select New Solution With {
            .Colors = validColors,
            .Nationalities = validNationalities,
            .Pets = validPets,
            .Drinks = validDrinks,
            .Hobbies = validHobbies
        }
    End Function

    Private Function Solve() As Solution
        Return Solutions().First()
    End Function

    Function DrinksWater() As Nationality
        Dim solution = Solve()
        Return solution.Nationalities(Array.IndexOf(solution.Drinks, Drink.Water))
    End Function

    Function OwnsZebra() As Nationality
        Dim solution = Solve()
        Return solution.Nationalities(Array.IndexOf(solution.Pets, Pet.Zebra))
    End Function

    Private Function IsIndexMatch(Of T1, T2)(ByVal values1 As T1(), ByVal value1 As T1, ByVal values2 As T2(), ByVal value2 As T2) As Boolean
        Return values2(Array.IndexOf(values1, value1)).Equals(value2)
    End Function

    Private Function IsAdjacentMatch(Of T1, T2)(ByVal values1 As T1(), ByVal value1 As T1, ByVal values2 As T2(), ByVal value2 As T2) As Boolean
        Dim index = Array.IndexOf(values1, value1)
        Return (index > 0 AndAlso values2(index - 1).Equals(value2)) OrElse (index < values2.Length - 1 AndAlso values2(index + 1).Equals(value2))
    End Function
End Module
