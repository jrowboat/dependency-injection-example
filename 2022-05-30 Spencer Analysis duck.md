
## Motivation
Examine Jack's sample to understand what dependency injection issue's he may be dealing with, and clarify proper dependency injection approaches.

Also provide feedback on the ducking and problem identification work to refine core problem solving skills.


## Understanding the sample

Give a readme... says to pay attention to DI in "the file". I'd guess that means OrderService

Order and PlaceOrderResponse are just stubs

Order service is pretty clearly using constructor injection.

The list of dependencies is rather long (8), not out of acceptable range, but a sign for worry.

The names of the services seem to indicate a variety of problems
- Everything is behind an interface, but there's little actual abstraction going on. The interfaces are just lists of methods in some other service. I'd guess most of these interfaces have only one implementation, a lot of methods, and many of the methods are not used in this service
- "Helpers" are never a service. Usually the weak name means it has a weak cohesion or reason to exist. 
  - This helper seems to be doing work that belongs to the storage component. Not clear why it's separated
- I have no idea what the difference is between `IOrderAccessor` and `IOrderRecordAccessor`.
  - `PlaceOrder` seems to be a command, but then it also seems to enact a separate storage update through the record accessor
- Entirely too much information is being passed to the `_customerEventService.GetOrderPlacedMessage`. Fat events cause coupling (and slow queues)

In short, it looks like there is dependency *injection* but the lack of dependency *inversion* is leading to coupled services, proliferating weak services abstractions in attempt at resuse and leading to rigid dependency structures.


## Code Sample evaluation

Small size is helpful for drawing attention to core issue. There's pretty much only one thing to look at.

Does capture the class's dependency strategy. There is some for who owns the abstractions that are injected, but I can guess by the name that they are large header interfaces owned by some other singular service.


## Duck

Pretty minimal. No discussion of why this example was chosen or what demonstrated issues/patterns i'm supposed to observe beyond the obvious topic of dependency injection.



## Direct questions
- How well is dependency injection done in the example?
  - A: The *injection* itself is fine, but this does not follow the Dependency *Inversion* principle. Abstractions should belong to the caller (in this case, `OrderService`)
- What are the cons of praticing dependency injection in the way the example does?
  - constructor injection is the most accessible dependency injection approach in languages like C#. It allows services to make dependencies clear at configuration time, but hide dependencies from call-time consumers of the service. The benefits are many and contextual, but the main one is that it prevents semantic coupling (like Service locator requires) and offers portability of services to different systems or contexts.
    - Other reasonable approaches can be found in Scott Wlaschin's series https://fsharpforfunandprofit.com/posts/dependencies/
- What are the concerns that are cared for by dependency injection?
  - I'd like you to think about this one before I answer it