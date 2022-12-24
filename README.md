# Unity Design Patterns
This project follows the design patterns from the book:

<i>Game Development Patterns with Unity 2021: Explore practical game development using software design patterns and best practices in Unity and C#</i>, 2nd Edition

The design patterns discussed in the book will be used to implement a single-player racing game called **Edge Racer**.

## Design Patterns
---
* Singleton
* State Pattern
* EventBus Pattern
* Command Pattern
* Object Pool Pattern
* Visitor Pattern

## Singleton
---
Sample GameManager is loaded at beginning that persists through multiple scenes.

## State Pattern
---
Rudimentary State Pattern set to control thrust, stop, and lateral movement.  Each State is its own class that implements `IBikeState`.
* StartBike
* StopBike
* Turn(Direction)

## Event Bus Pattern
---
The Event Bus Pattern is a class that acts as a central hub for subscribers, publishers, and various events.

A map is used to keep track of enums and `UnityEvent`s.  Subscribers provide callback functions and are attached as listeners to specific events.  When a publisher invokes an event, all listeners (tracked by map) are then executed.

In the example, an event bus pattern is used to track the lifecycle events of a race and is also used to implement a countdown timer.

## Command Pattern
---
An InputController is used to assign buttons to specific commands.  When pressed, an `Invoker` executes and records the command.  These records are then use to replay gameplay.

## Object Pool Pattern
---
A `DroneObjectPool` class was created to implement Unity's `ObjectPool<T>`.  Callback functions were added for the following ObjectPool events:

* OnCreatedPooledItem
* OnTakeFromPool
* OnReturnedToPool
* OnDestroyPoolObject

The Pool was created for `Drone` entities that attack the player then self-destruct after a few seconds.  Clicking a button generates multiple Drones and you can see entities get returned to ObjectPool and also destroyed.

## Visitor Pattern
---
Abstract classes are created for `Subject` and `Observer`.  Entities that implement `Observer` can get attached to `Subject` entities.  Whenever a state changes, the `Subject` notifies all `Observer` entities and provides itself as an argument.  `Observer` entities can then update their states based on the `Subject` state.

Unlike the Event Bus Pattern, notifications are generic and no knowledge of event type (i.e. damage, spawn, death, collision, etc.) is passed to `Observer`.

# Useful Links
* [Book GitHub Repo](https://github.com/PacktPublishing/Game-Development-Patterns-with-Unity-2021-Second-Edition)
* [C# Naming Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
* [Monobehavior Lifecycle Events](https://docs.unity3d.com/ScriptReference/MonoBehaviour.html)
  
# Notes

## Game Object
A `GameObject` is the basic class for a Unity entity.  It comes with a transform by default and can be customized by attaching additional Components.

## Component
* A component must extend `MonoBehavior` to be used as a `Component`.
* Monobehavior Lifecycle Handlers are inherited from `MonoBehavior`.  Refer to Useful Links for Unity documentation.

