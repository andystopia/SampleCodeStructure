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


