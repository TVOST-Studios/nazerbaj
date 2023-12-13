# Nazerbaj

This project is made for Satakunta University of Applied sciences class Let's Make a Game!

## Starting the Development Build

Unity version 2022.3.8f1 has been used to develop the game.

All models are created using Blender and utilize the .blend method, thus it is required to install Blender version 2.60+ to run the project in Unity. [Read more from here](https://docs.unity3d.com/560/Documentation/Manual/HOWTO-ImportObjectBlender.html).

The main scene is ``Game``, but you have to start from the ``Menu`` scene for everything to work as intended.

## Dependencies

In addition to the regular Unity dependencies, this project has a dependency on the following additional Unity packages:

| Package | Version | Description |
| --- | --- | --- |
| TextMeshPro | 3.0.6 | TextMeshPro is the ultimate text solution for Unity. |
| DOTween (HOTween v2) | 1.2.745 | DOTween is a fast, efficient, fully type-safe object-oriented animation engine. |

## Scenes

The main scene is ``Game``. When you launch the game you will start in scene ``Menu``. After completing the game objective the scene ``EndScene`` will load.

## Menus & UI

The menus are created using Unity's built-in UI tools.

## Scripts

This section contains a reference to some of the key scripts that are used in the project.

| Script | Description |
| --- | --- |
| Player.cs | This script is responsible for handling everything to do with the Player GameObject |
| UI.cs | This script is responsible for handling everything to do with the in-game user interface |
| EnemyAI.cs | This script is responsible for handling everything to do with the Enemy AI´s and behavior |

## Known Issues

No quit button in-game, you have to close it by ``Alt+F4``.
