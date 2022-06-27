## Questions

### What ways exist to implement the service locator design pattern in a system?
- Strong type
- Generic type

### How does the service locator pattern satisfy the "Dependency Inversion" principle of SOLID?

### How does the service locator pattern not satisfy the "Dependency Inversion" principle of SOLID?

## Ducking
- [Geeks for Geeks Service locator example article](https://www.geeksforgeeks.org/service-locator-pattern/)
- [CSharp Corner Service locator example article](https://www.c-sharpcorner.com/UploadFile/dacca2/service-locator-design-pattern/)
- GOAL: keep each example in line with the OrderService problem domain
- Treating order service as the repo name, no longer a class name
- Q: How to decouple low level implementation (service classes responsible for management of returns and order updates) from high level concerns (requirements)
- SMELL: service class names contain requirements information