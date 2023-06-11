Imports System
Imports System.Numerics

Public Module DiffieHellman
    Private ReadOnly Random As Random = New Random()

    Public Function PrivateKey(ByVal primeP As BigInteger) As BigInteger
        Return New BigInteger(Random.Next(1, CInt(primeP) - 1))
    End Function

    Public Function PublicKey(ByVal primeP As BigInteger, ByVal primeG As BigInteger, ByVal privateKey As BigInteger) As BigInteger
        Return BigInteger.ModPow(primeG, privateKey, primeP)
    End Function

    Public Function Secret(ByVal primeP As BigInteger, ByVal publicKey As BigInteger, ByVal privateKey As BigInteger) As BigInteger
        Return BigInteger.ModPow(publicKey, privateKey, primeP)
    End Function
End Module
