# Tests

A downloaded exercise includes these files for building and testing your solution:

```text
hello-world/
├── HelloWorld.vb          # Your solution
├── HelloWorldTests.vb     # The test suite
├── HelloWorld.vbproj      # Project and build configuration
└── packages.lock.json     # Resolved project dependencies
```

The filenames vary by exercise.
Write your solution in the first `.vb` file.
The second file ending in `Tests.vb` is the [xUnit test suite][xunit].
Generally, you'd only edit this to unskip subsequent tests.
You will not need to edit either of the last two files.
The `.vbproj` file contains the project's build settings and direct package references.
The generated `packages.lock.json` file records the resolved direct and transitive package versions.

~~~exercism/note
The tests describe the behavior a passing solution must satisfy.
They can help clarify details that are not covered by the instructions.
~~~

## Run the tests

Open a terminal in the exercise directory and run:

```bash
dotnet test
```

The command restores the project's dependencies, builds the project, and runs its tests.
You can also use `dotnet watch test` to rerun the tests whenever a source file changes.

## Skipped tests

Exercises initially enable only the first test, allowing you to solve the rest one step at a time.
Open the file ending in `Tests.vb` to find the tests.
Each test is a `Sub` subroutine marked with an xUnit `<Fact>` attribute.
A test will be skipped as long as its `<Fact>` attribute has a `Skip` argument:

```vb
<Fact(Skip:="Remove this Skip property to run this test")>
Public Sub Lowercase_words()
    Assert.Equal("ROR", Abbreviate("Ruby on Rails"))
End Sub
```

To enable the test, just remove the `Skip` argument:

```vb
<Fact>
Public Sub Lowercase_words()
    Assert.Equal("ROR", Abbreviate("Ruby on Rails"))
End Sub
```

After the newly enabled test passes, repeat this process with the next skipped test.
When every test is enabled and passing, you're done.
