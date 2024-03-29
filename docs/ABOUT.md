# About

Visual Basic is a multi-paradigm, statically-typed programming language with object-oriented, declarative, functional, generic, lazy, integrated querying features and type inference.

**Statically-typed** means that identifiers have a [type](https://en.wikipedia.org/wiki/Type_system#Static_type_checking) set at compile time--like those in Java, C++ or Haskell--instead of holding data of any type like those in Python, Ruby or JavaScript.

**Object-oriented** means that Visual Basic provides imperative [class-based objects](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/concepts/object-oriented-programming) with features such as single inheritance, interfaces and encapsulation.

**Declarative** means programming [what is to be done](https://stackoverflow.com/questions/1784664/what-is-the-difference-between-declarative-and-imperative-programming), as opposed to how it is done (a.k.a imperative programming) (which is an implementation detail which can distract from the domain or business logic).

**Functional** means that [functions are first-class data types](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/delegates/) that can be passed as arguments to and returned from other functions.

**Generic** means that algorithms are written in terms of types [to-be-specified-later](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/data-types/generic-types) that are then instantiated, when needed, for the specific types provided as parameters.

**Lazy** [(a.k.a "deferred execution")](https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/statements/yield-statement) means that the compiler will put off evaluating an item until required. This lets one safely do weird stuff like operating on an infinite list--the language will only create the list up to the last value needed.

**Integrated Querying** means the language feature called [LINQ "Language-Integrated Query"](<https://docs.microsoft.com/en-us/previous-versions/dotnet/articles/bb308959(v=msdn.10)?redirectedfrom=MSDN>), which enables lazy querying directly within the language, not only its own objects but, also, external data sources through formats such as XML, JSON, SQL, NoSQL DBs and event streams.

**Type inference** means that the compiler will often figure out the type of an identifier by itself so you don't have to specify it. Scala and F# both do this.

**Syntax** is similar to that of other structured BASIC languages such as [Xojo](https://www.xojo.com), [PureBASIC](https://www.purebasic.com/) and the [B4X](https://www.b4x.com/) family.

**.NET** is the managed environment within which Visual Basic runs, so you get access to the entire .NET ecosystem, including all packages on [nuget.org](http://www.nuget.org). .NET used to be Windows-only but, with the release of [.NET Core](https://www.microsoft.com/net/core) -- as well as [Mono](http://www.mono-project.com/) -- you can also use Visual Basic on Mac, Linux or Unix-based systems and on mobile platforms too.

Visual Basic also has features, amongst others, to make programming with multiple threads/processors, parallelisation, asynchrony, unmanaged code in a managed environment and language interoperability easier. It is developed and maintained by Microsoft, who provides the official [documentation](https://docs.microsoft.com/en-us/dotnet/visual-basic/).
