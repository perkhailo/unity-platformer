using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlipFaceDirection : AbstractPhysicsBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    DirectionType faceDirectionOrigin = DirectionType.Positive;

    protected override void Awake()
    {
        base.Awake();

        if (!_spriteRenderer)
            _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();

        SetFaceDirection();
    }

    private void SetFaceDirection()
    {
        if (base._horizontalDirectionMovement.Equals(DirectionType.Positive))
        {
            if (faceDirectionOrigin.Equals(DirectionType.Positive))
                FlipX(false);
            if (faceDirectionOrigin.Equals(DirectionType.Negative))
                FlipX(true);
        }
        if (base._horizontalDirectionMovement.Equals(DirectionType.Negative))
        {
            if (faceDirectionOrigin.Equals(DirectionType.Positive))
                FlipX(true);
            if (faceDirectionOrigin.Equals(DirectionType.Negative))
                FlipX(false);
        }
    }

    private void FlipX(bool value)
    {
        _spriteRenderer.flipX = value;
    }
}
