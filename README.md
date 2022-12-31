# Unity Design Patterns
[Play Demo](https://midnjerry.github.io/UnityDesignPatterns)

This project follows the design patterns from the book:

<i>Game Development Patterns with Unity 2021: Explore practical game development using software design patterns and best practices in Unity and C#</i>, 2nd Edition

The design patterns discussed in the book are used to implement a single-player racing game called **Edge Racer**.

## Design Patterns

* Singleton
* State Pattern
* EventBus Pattern
* Command Pattern
* Object Pool Pattern
* Visitor Pattern

## Singleton

Sample GameManager is loaded at beginning that persists through multiple scenes.

## State Pattern

Rudimentary State Pattern set to control thrust, stop, and lateral movement.  Each State is its own class that implements `IBikeState`.
* StartBike
* StopBike
* Turn(Direction)

## Event Bus Pattern

The Event Bus Pattern is a class that acts as a central hub for subscribers, publishers, and various events.

A map is used to keep track of enums and `UnityEvent`s.  Subscribers provide callback functions and are attached as listeners to specific events.  When a publisher invokes an event, all listeners (tracked by map) are then executed.

In the example, an event bus pattern is used to track the lifecycle events of a race and is also used to implement a countdown timer.

## Command Pattern

An InputController is used to assign buttons to specific commands.  When pressed, an `Invoker` executes and records the command.  These records are then use to replay gameplay.

## Object Pool Pattern

A `DroneObjectPool` class was created to implement Unity's `ObjectPool<T>`.  Callback functions were added for the following ObjectPool events:

* OnCreatedPooledItem
* OnTakeFromPool
* OnReturnedToPool
* OnDestroyPoolObject

The Pool was created for `Drone` entities that attack the player then self-destruct after a few seconds.  Clicking a button generates multiple Drones and you can see entities get returned to ObjectPool and also destroyed.

## Observer Pattern

Abstract classes are created for `Subject` and `Observer`.  Entities that implement `Observer` can get attached to `Subject` entities.  Whenever a state changes, the `Subject` notifies all `Observer` entities and provides itself as an argument.  `Observer` entities can then update their states based on the `Subject` state.

Unlike the Event Bus Pattern, notifications are generic and no knowledge of event type (i.e. damage, spawn, death, collision, etc.) is passed to `Observer`.

## Visitor Pattern

This is an interesting pattern as it showcases the use of Unity's `CreateAssetMenu` feature.  It allows a user to create Data Objects that are then used to initialize instances of an object.  In this case, the user can make multipler variations of a `PowerUp` using the Unity Tool Interface!

PowerUp implements the `IVisitor` interface which requires implementation of 3 methods: 
* `public void Visit(BikeShield bikeShield)`
* `public void Visit(BikeEngine bikeEngine)`
* `public void Visit(BikeWeapon bikeWeapon)`

Each of these methods represents a `PowerUp` accessing a specific subsystem of `BikeController`.  Based on the values set in the Data Objects, the corresponding subsystem is modified.  This allows a `PowerUp` to modify "cross-platform" attributes.

`BikeController`, `BikeShield`, `BikeEngine`, and `BikeWeapon` all implement the `IBikeElement` interfact.  This requires the implementation of the following method:

`public void Accept(IVisitor visitor);`

Since `BikeController` is the "container" or "parent" of `BikeShield`, `BikeEngine`, and `BikeWeapon`, `BikeController` implements the method as follows:

```
public void Accept(IVisitor visitor)
{
    foreach (IBikeElement element in _bikeElements)
    {
        // BikeShield, BikeEngine, and BikeWeapon are included in this list.
        element.Accept(visitor);
    }
}
```
`BikeController.Accept` is called when Bike collides with PowerUp entity.

## Strategy Pattern

In this example, the strategy pattern is used to randomly assign an AI manuever to a spawned Drone.

## Decorater Pattern

The Decorator Pattern is used to calculate the net attributes for a weapon.  The player has two WeaponComponent slots (Main and Secondary) that can be used to modify damage, range, rate of fire, and cooldown. 

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

## Deploying Game to GitHub Pages
1. Update Unity Build Settings
    1. File -> Build Settings
    2. Select `WebGL` as Platform
    3. Click `Player Settings...` -> Publishing Settings -> Set Compression Format to `Disabled`
    4. Build to `/docs` directory of repo project.
2. Configure GitHub repo
    1. In repo, go to Settings -> Pages
    2. Set Source to `Deploy from a Branch`
    3. Set Branch to `Master` and Folder to `/docs`
3. Deploy to repo
    1. Commit changes to `/docs` folder
    2. Push up.
    3. GitHub Pages will automatically deploy.
