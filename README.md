# SbTween
SbTween is plug and play tween library for S&amp;box Editor.

Inspirated by DoTween & GDTween


[Features]
Auto "Inject" - u don't need to add TweenManager to every level. system will add it by itself.

Tweens:
Local, World Position
Local, World Rotation
Local, World Scale
Color Tween
Position, Rotation, Scale Shake
Screen Panel Opacity
Float tweener

Easings, Looping
Callouts onComplete, onStart, onUpdate.
Easy system for adding custom tween extensions.

Sequences (inspirated by DoTween)

Example Level. 
> where is showcased every tween.

How to use it?
Example of basic cube movement.
this.TweenMove( new Vector3(25,25,25), 3 ).SetEase( EaseType.Linear ).SetLoops(-1,true).Play();

Shoutouts:
Braxen (TweenManager) for inspiration.
DoTween, GDTween for inspiration.
Robert Penner for easing equations.

Future:
Tweening Component (instead of writing code, you can play or setup tweens in inspector)
Improve quality
Simplify script
I wanna look into razer, scss.
Better network support.
