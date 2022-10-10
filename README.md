# ComplexNumberCalculator

CLI calculator for complex numbers
----------------------------------
Build an app:
```
dotnet build
```

# How to use:

In folder ```ComplexNumberCalculator\ComplexNumberCalculator\bin\Debug\net6.0``` you can find executable ```ComplexNumberCalculator.exe```

Open PowerShell and run it with arguments:
```
$ .\ComplexNumberCalculator "<expression>"
```

All parts of expression should be surrounded with round braces. Example: ```(3+4i)*(1+2i)```.
Complex numbers should be represented with real part following by imaginary part.

It's possible to use basic 5 operators (+ - * / ^).
Calculation will be consecutive. That means that operator "*" or "/" would not have priority.

To represent root you can raise to real power. Example: ```(3+4i)^(0,5)``` is square root.

Additional arguments
---------------------------------------------------------------------------------------

Optionally can be set flag -p to set precision. Example:
```
$ .\ComplexNumberCalculator "<expression>" -p 4
```
That means 4 numbers after floating point.
