# Basic Unity Event Structuring System.

## Design Goals

The primary purpose of this project was to demonstrate a possible way in which to programmatically structure an event management system in unity that is flexible and simple enough to understand. 

I wanted to support tabbing and arrow based menu's and while those are hardcoded currently, they could certainly be abstracted to more flexible interfaces. The goal is to build an input system that naturally supports hovering and clicking operations, while seamlessly integrating with keyboard support as well.

## Code Structure

So there are a few important class: 

### GlobalHoverStateManager

This class ensures that exactly one entity is hovered at any given time, and when another item is hovered, or if the current item is unhovered, it notifies all the hover effects to handle this case.

### HoverMediator

This mediates events from the unity system and the `TabIndexManager` (the thing that manages the keyboard input) and is an intermediate from those to the attached hover behaviors, sometimes called "effects".

### IHoverBehavior

This interface contains two methods which can be implemented and then added to an entity to make it exhibit a certain behavior when hovered. 

### ClickMediator

Basically the same thing as hover mediator (but is dependent on having a hover mediator) but for clicks.

### IClickBehavior

When implemented and added to an entity with a click mediator, it will be notified when the entity is clicked.

### Other classes
There are a bunch of "effect" (IHoverbehavior implementors) which do transformations and color changes, but those are just mostly for demonstration purposes.

## KeyboardEventSystem

I have made what I believe is a very efficient implementation of a keyboard based event 
system.

Inside the `KeyboardEventSystem` namespace there are three classes:
 * KeyMap
 * KeyMapping
 * Key


It's a very simple three file class structure which allows for a lot of flexibility. 
To use these three classes, modify the KeyMapping class fields to be appropriate
to your use case. 

### Setting up the KeyMapping Scriptable Object
Something such as:
```c#
[CreateAssetMenu(fileName = "KeyMapping", menuName = "KeyMappings/KeyMapping", order = 0)]
    public class KeyMapping : ScriptableObject
    {
        
        [SerializeField] private Key playerMoveForwards;
        [SerializeField] private Key playerMoveBackwards;
        [SerializeField] private Key playerMoveLeft;
        [SerializeField] private Key playerMoveRight;
        
        // use your IDE to generate the following lines
        // should be called Generate Properties or something
        // analogous.
        // you can manually type them out, 
        // but you generally don't  need to.
        public Key PlayerMoveForwards => playerMoveForwards;
        public Key PlayerMoveBackwards => playerMoveBackwards;
        public Key PlayerMoveLeft => playerMoveLeft;
        public Key PlayerMoveRight => playerMoveRight;

    }
```
And that's it. Notice how we didn't specify which keys 
go where. There's a simple reason for that. We'll just do that in unity in a moment.

Open unity and go into the project tab, (where all the files are), and then 
right click `Create > KeyMappings > KeyMapping`. You should now see all your fields
(keys) and a few other details added to the inspector, when you open the newly created
scriptable object in the project explorer. Fill these out at your leisure.

### Finishing up.

We still need to register this with the KeyMap, and to do that, we'll place
an empty in the scene and then go to the inspector, go to `Add Component` and then 
type `KeyMap`. There will be one unfilled field in the `KeyMap`. To fill this field, 
find your `KeyMapping` you created in the previous step in the project explorer, and 
click and drag it over the space labeled `None` in the Unity Editor. 

#### Alternatively

You don't need to add the KeyMap to an empty. 
If you already know how to load in your scriptable objects, you can 
load it using a different object and then use `KeyMap.Active = your_key_map_name_here`.
This approach will decrease clutter and will be marginally faster. 

### Concerns
Do not worry about the Empty you added the `KeyMap` to being removed from the scene; 
it's perfectly alright if that happens. As long as the `KeyMap`'s `Awake` is called, then the 
state will be preserved, and no `NullPointerExceptions` will occur.

### Usage

To use this event system, here's a few examples

### Holding

Synonymous with `Input.GetKey`
```c#
if (KeyMap.Active.PlayerMoveForwards.IsPressed()) { 
    Debug.Log("The key move forwards key is being held.");
}
```
### KeyDown
Synonymous with `Input.GetKeyDown`
```c#
if (KeyMap.Active.PlayerMoveForwards.WasPressedThisFrame()) { 
    Debug.Log("The key move forwards key was just pressed down.");
}
```
### KeyUp
Synonymous with `Input.GetKeyUp`
```c#
if (KeyMap.Active.PlayerMoveForwards.WasReleasedThisFrame()) { 
    Debug.Log("The key move forwards key was just released.");
}
```
