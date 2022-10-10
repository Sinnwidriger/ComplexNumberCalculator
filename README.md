# ComplexNumberCalculator
=========================

CLI calculator for complex numbers
----------------------------------
Build an app:
```
dotnet build
```

# How to use:
```
.\ComplexNumberCalculator "<expression>"
```

All parts of expression should be surrounded with round braces. Example: (3+4i)*(1+2i).
Complex numbers should be represented with real part following be imaginary part.

Additional arguments
---------------------------------------------------------------------------------------

Optionally can be set flag -p to set precision. Example:
```
.\ComplexNumberCalculator "<expression>" -p 4
```
---------------------------------------------------------------------------------------

It's possible to use basic 5 operators (+,-,*,/,^).
Calculation will be consecutive. That means that operator "*" or "/" would not have priority.
