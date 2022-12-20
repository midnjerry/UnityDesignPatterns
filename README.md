# Unity Design Patterns
## Summary
This project follows the design patterns from the book:

<i>Game Development Patterns with Unity 2021: Explore practical game development using software design patterns and best practices in Unity and C#</i>, 2nd Edition

The design patterns discussed in the book will be used to implement a single-player racing game called **Edge Racer**.

## Design Patterns
* Singleton
* State Pattern

### Singleton
Sample GameManager is loaded at beginning that persists through multiple scenes.

### State Pattern
Rudimentary State Pattern set to control thrust, stop, and lateral movement.  Each State is its own class that implements `IBikeState`.
* StartBike
* StopBike
* Turn(Direction)




## Useful Links
* [Book GitHub Repo](https://github.com/PacktPublishing/Game-Development-Patterns-with-Unity-2021-Second-Edition)
* [C# Naming Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
* [Monobehavior Lifecycle Events](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html)
  
## Notes

### Game Object
A `GameObject` is the basic class for a Unity entity.  It comes with a transform by default and can be customized by attaching additional Components.

### Component
* A component must extend `MonoBehavior` to be used as a `Component`.
* Monobehavior Lifecycle Handlers are inherited from `MonoBehavior`.  Refer to Useful Links for Unity documentation.

