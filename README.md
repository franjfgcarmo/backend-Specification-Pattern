# backend-Specification-Pattern

## Specification Pattern

### Main Use Cases.

1. In-memory validation.
2. Retrieving data from database.
3. Construction-to-order.

The most common use case: 1,2

## Module 1. Summary

### Purpose of the specification pattern:

- Encapsulate domain knowledge into a single unit
- Reuse in various scenarios

### Use cases:

- In-memory validation
- Retrieving data from the database
- Creation of new objects

The most common use case: 1,2

### Worked on a sample project

- Search functionality
- New purchase options
- Couldn't reuse domain knowledge efficiently
- Had to either introduce duplication, or realy on inefficient SQL queries

## Module 2.Summary.

### How LINQ works

- IEnumerable and IQueryable
- C# lambda can compile to either a delegate or an expression
- C# expressions can compile to delegates

### Using plain C# expressions

- Help get rid of duplication
- Don’t provide proper encapsulation

### Generic specifications

- A thin wrapper on top of expressions

### Returning IQueryable from a repository

- Violates LSP
- This is an anti-pattern. The problem here that IQueryable allow for arbitrary expressions in the Where methods that work on top of it, and that means the client of the repository can easily do somenthing tha the ORM doesn´t suppport.
- Can cause runtine exceptions.
- Could be fine for small project.
- Not suitable for medium and large projects.
- Never return IQueryable from your public methods, instead of IQueryable it´s a good idea to return IReadOnlyList because it represents an in-memory Collection, and unlike IQueryable you can use any lambda expression.
- Return IEnumerable is better IQueryable, if get an IEnumerable from some data access code, then this code closes the connection to the database before you actually use that IEnumerable. After that you try to enemerate the items in that collection. This would result in an exception because having IEnumerable añone doesn´t guarantee that your data is in the memory already. ORMs try to defer the actual data retrieval to a later stage for performance gains, which is good in some cases

## Module 3.Summary.

#### **Specificatons: General Guidelines**

- We solved the problem with encapsulation. The client code now doesn´t have to deal with low-level implementation details.
- Easier to work.
- Avoid ISpecifacion Interface.
- Make specification as specific as possible.
- Make specifications inmutable

#### **Recap: Combining Specifications**

- Combining specifications together.
- Theree types of combinations: And, Or and Not.
- Identity Specification, it´s an implementation of the null object design pattern .
- Usefull for dynamic search queries.

#### **_When Not to use Specificartions_**

- Only 1 out of 3 use cases. X
- Already low maintenance cost.
- Benefits might not justify the investment

#### **_When use Specificartions_**

- Have t least 2 out of 3 use cases.
- Codebase is complex enuough.

### **Recap: Working with Multiple Classes**

- You can use specifications for related classes as well.
- Eagerly load all related object whe you fetch data from the database.

overkill, domain classes would work just fine here.
But in more complex enterprise-level applications it´s usually a good idea not to use domain object when displaying data on the UI.
