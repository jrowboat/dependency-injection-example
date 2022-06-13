## Dependency management
- What forms of dependency management exist?
    - Nuget: Can apply ranges to package version to limit package that can be downloaded. However, this doesn't stop a package creator from stopping support of such versions. Partially satisfies dependency inversion, but not acceptable
        - [helpful documentation](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/dependencies)
    - Dependency Injection (DI)
        - "Have a seperate object, an assembler, that populates a field in the lister class with an appropriate implementation for the finder interface,..." (Fowler)
        - This seems to be more in line with the discussion we were having, so I primarily focused on Fowler's article
        - Different kinds of DI 
            - Constructor injection (Type 3 IoC)
            - Setter injection (Type 2 IoC)
            - Interface injection (Type 1 IoC)
- How do the different versions of dependency management help satisfy dependency inversion and information hiding?
- How has microsoft baked dependency inversion into their development ecosystem?
    - [microsoft dependency injection doc](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
    - Are service containers a propogation of the service locator pattern?
    - [Fowler's <em>Inversion of Control Containers and the Dependency Injection pattern</em>](https://www.martinfowler.com/articles/injection.html)

## Random questions

### "Readability can be enhanced via satisfying information hiding with a factory pattern (service locator) to remove the necessity of listing out inferfaces five different times (initialization, parameterization in constructor injection, and definition within constructor of class)"
- service locator is a specific application of the factory patttern
- Is factory pattern toxic?
    - What is factory pattern aimed at?
