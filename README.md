# Csharp_Delegate_Event

## Resources
- (https://www.youtube.com/watch?v=35JaFeaBupQ&list=PL8uXoSVYVb8TalGgO6vWd2dfyPkuNJC83&index=35)
- Pro.CSharp.10.with.NET.6.pdf page-521

## Delegate is a type-safe function pointer.
-- It allows me to:
-- Store a method in a variable
-- Pass methods as parameters to other methods
-- Call methods dynamically at runtime

## example: 
In a banking system, credit approval rules vary by customer type. Instead of writing if-else for each case, I define a delegate CreditCheck, create different methods for different rules, and assign the appropriate one at runtime.
Events are built on delegates - they provide a way to notify other parts of the application when something happens (like when money is withdrawn from an account).

## Key features:
Multicast: Can hold multiple methods using +=
Type-safe: Compiler checks method signatures
Flexible: Methods can be assigned and removed at runtime""
