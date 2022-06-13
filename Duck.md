## Dependency management
- What forms of dependency management exist?
    - .NET
        - Nuget: Can apply ranges to package version to limit package that can be downloaded. However, this doesn't stop a package creator from stopping support of such versions. Partially satisfies dependency inversion, but not acceptable
            - [helpful documentation](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/dependencies)
- How do the different versions of dependency management help satisfy dependency inversion and information hiding?

## Random questions

### "Readability can be enhanced via satisfying information hiding with a factory pattern (service locator) to remove the necessity of listing out inferfaces five different times (initialization, parameterization in constructor injection, and definition within constructor of class)"
- service locator is a specific application of the factory patttern
- Is factory pattern toxic?
    - What is factory pattern aimed at?