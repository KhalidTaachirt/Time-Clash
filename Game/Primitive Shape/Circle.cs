using System;
using UnityEngine;

public class Circle : PrimitiveShape
{
    public Circle(string name = "", Vector2 startingPosition = default) : base(name, startingPosition)
    {
        Vector2[] verticesCircle =
        {
            new (0, 0),
            new (0, -0.5f),
            new (0.3875f, -0.3305f),
            new (0.5f, 0),
            new (0.3875f, 0.3305f),
            new (0, 0.5f),
            new (-0.3875f, 0.3305f),
            new (-0.5f, 0),
            new (-0.3875f, -0.3305f)
        };

        ushort[] trianglesCircle =
        {
            0, 1, 2,
            0, 2, 3,
            0, 3, 4,
            0, 4, 5,
            0, 5, 6,
            0, 6, 7,
            0, 7, 8,
            8, 0, 1,
        };

        Sprite sprite = Utility.GenerateSpritePolygon2D(verticesCircle, trianglesCircle);

        SpriteRenderer spriteRenderer = GameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }

    protected override void AddCollider(bool isTrigger = true)
    {
        // Add Circle Collider to the GameObject
        CircleCollider2D circleCollider2D = GameObject.AddComponent<CircleCollider2D>();
        circleCollider2D.isTrigger = isTrigger;
    }

    public override void Rotate(Vector2 direction)
    {
        throw new NotImplementedException();
    }
}