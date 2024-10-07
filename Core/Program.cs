using System.Numerics;
using Core.Entities.Behaviours;
using Core.Entities.Figures;
using Core.Game;
using Core.Scene;

var scene = PlainScene3D.Create(
    name: "MyNewBox",
    new Wall(
        startX: 15,
        startY: 15,
        startZ: 0,
        width: 30,
        height: 30,
        Wall.Orientation.XY
    ),
    new Wall(
        startX: 15,
        startY: 15,
        startZ: 30,
        width: 30,
        height: 30,
        Wall.Orientation.XY
    ),
    new Wall(
        startX: 15,
        startY: 0,
        startZ: 15,
        width: 30,
        height: 30,
        Wall.Orientation.XZ
    ),
    new Wall(
        startX: 15,
        startY: 30,
        startZ: 15,
        width: 30,
        height: 30,
        Wall.Orientation.XZ
    ),
    new Wall(
        startX: 0,
        startY: 15,
        startZ: 15,
        width: 30,
        height: 30,
        Wall.Orientation.YZ
    ),
    new Wall(
        startX: 30,
        startY: 15,
        startZ: 15,
        width: 30,
        height: 30,
        Wall.Orientation.YZ
    )
);

scene.AddPlaceable(
    out var sphereId,
    new Movable(
        placeable: new Sphere(
            new(15, 15, 15),
            radius: 3
        ),
        startDirection: new Vector3(1,2,3)
    )
);

var game = Game3D.CreateGame(scene);
game.Start();
