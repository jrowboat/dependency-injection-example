## Dependency management
- What forms of dependency management exist?
    - Nuget: Can apply ranges to package version to limit package that can be downloaded. However, this doesn't stop a package creator from stopping support of such versions. Partially satisfies dependency inversion, but not acceptable
        - [helpful documentation](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/dependencies)
    - Dependency Injection (DI)
        - "Have a seperate object, an assembler, that populates a field in the lister class with an appropriate implementation for the finder interface,..." (Fowler)
        - This seems to be more in line with the discussion we were having, so I primarily focused on Fowler's article
        - What about this article brings me closer to my goal? 
            - The article seems to reference a lot of concepts we have been discussing in our conversations and can provide some contextual information in both the form of good information and bad to help me "navigate" the concepts of DI and IoC.
        - In this case, does this article explain alternative dependency management approaches? 
            - Indeed. Fowler presents three different approaches.
                - Constructor injection (Type 3 IoC)
                - Setter injection (Type 2 IoC)
                - Interface injection (Type 1 IoC)
            - Article provides a prescriptive approach when to use each DI approach, seemingly prioritizing contructor injection as the primary candidate
        - Why might I trust / distrust this source? How much do I trust this source? 
            - Fowler is known to be a respected engineer with many books on best practice engineering. However, I have not experienced much of his expertise yet, so my personal confidence is limited to those who recommend his work to me.
            - Where can I get a second opinion?
                - Spencer, my IT Director (seems to always have SE blogs on his mind), past coworkers
            - How does this article agree / conflict with prior knowledge or sources? 
                - Presents an argument for service locator, which is smelly. 
- How do the different versions of dependency management help satisfy dependency inversion and information hiding?
- How has microsoft baked dependency inversion into their development ecosystem?
    - [microsoft dependency injection doc](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
    - Are service containers a propogation of the service locator pattern?
    - [Fowler's <em>Inversion of Control Containers and the Dependency Injection pattern</em>](https://www.martinfowler.com/articles/injection.html)

## Random questions

- what does it mean to be a dependency management approach? 
    - Will a class be able to manage the services it depends upon to satisfy its intended function via the use of this approach?
- What qualifies something as a dependency management approach?
    - A strategy that allows for a component to utilize services it needs to satisfy its intended function

### "Readability can be enhanced via satisfying information hiding with a factory pattern (service locator) to remove the necessity of listing out inferfaces five different times (initialization, parameterization in constructor injection, and definition within constructor of class)"
- service locator is a specific application of the factory patttern
- Is factory pattern toxic?
    - Not necessarily; service locator is as it exposes one class to a whole service library just for the use of one specific service, making itself more dependent
