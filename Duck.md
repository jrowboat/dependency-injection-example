# Duck - First and Second Run

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

### Dependency management definition (self definition) 
    - DEF: The process by which a entity (class, project, repo, etc.) manages the services it depends upon to satisfy its intended function
### Criteria for a dependency management strategy
    - REQ: satisfy Inversion of Control
    - REQ: hide information specific to any dependency
    - REQ: promotes readability and comprehensibility in any system
    - Class level management
        - 

- Q: Difference between accidental and secondary requirements (goals):
    - Goals can be related to core problem
    - Example: REQ of 30 mpg, goal of 35 mpg
        - Related to core of problem, but not necessary to specific application

### "Readability can be enhanced via satisfying information hiding with a factory pattern (service locator) to remove the necessity of listing out inferfaces five different times (initialization, parameterization in constructor injection, and definition within constructor of class)"
- service locator is a specific application of the factory patttern
- Is factory pattern toxic?
    - Not necessarily; service locator is as it exposes one class to a whole service library just for the use of one specific service, making itself more dependent


# Ducking - Third Run
- How do I approach understanding IoC through the lens of DI?
    - Week-by-week implementations of DI, going through the different DI approaches
    - Each week, expected artifacts
        - REQ: Class (or files) implementing pattern of the week
        - REQ: Build out definition in "Toolbox" section below
        - REQ: Short answers for the following
            - How is DI satisfied by this example?
            - How is IoC satisfied by this example?
- Q: What are good scenarios for implementing each form of DI?
    - Contructor injection
    - Setter injection
    - Interface injection
    - Parameter injection

### Toolbox of common injection approaches

### How do DI and IoC differ?
- IoC is a programming principle
- DI is a design pattern, a means by which IoC is implemented in a system

### What are the common injection approaches
- Constructor Injection
- Setter Injection
- Interface Injection
- Parameter Injection

### How and Why DI manages to satisfy IoC
- Use of interfaces hides functionality behind the interface for classes consuming said interface

### How and Why DI fails to satisfy IoC


# Duck - Fourth run - Service Locator