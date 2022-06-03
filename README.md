# Through a console program that consumes an API, you can have many meanings of a word. DotNet 6


I programmed the logic of the API 'https://api.dictionaryapi.dev/api/v2/entries/en/{word}' from the web page https://dictionaryapi.dev/


Functions:
===
- Many definitions of a word.
- You can have examples of each definition.
- Save the result of the definitions in a txt file.
- You can scale the logic to complement the other API fields.

Test the logic of the program
===
https://replit.com/@MartinBetancur/API-powered-Word-Dictionary

Tools used:
==
- CSharp with dotnet 6 (Interfaces, POO, Async, JSON deserializer, Http request, exception handling, etc)

- Source JSON to C# Classes: https://json2csharp.com/

- Source API: https://dictionaryapi.dev/

- Postman

Courses that I take:
====

* Curso de Introducción a C# > https://platzi.com/cursos/introduccion-csharp/

* Curso de Fundamentos de .NET > https://platzi.com/cursos/fundamentos-net/

* Curso de fundamentos de C# .Net Core (Hector de Leon) > https://www.youtube.com/watch?v=szXfuTRIfYg&list=PLWYKfSbdsjJgKGeP2OmTJWXz8qZ7N8xU2

Warning
===

I did not remove the other unused attribute fields so this repository can be easily scaled. It is a logical base of the API.