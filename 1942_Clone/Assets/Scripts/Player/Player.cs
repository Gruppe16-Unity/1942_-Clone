using UnityEngine;
public class Player : PlayerBase
{
    protected override void Start()
    {
        base.Start();
        // Additional code specific to Player 1
    }

    protected override void Update()
    {
        base.Update();
        HandleMovement();
        // Additional code specific to Player 1
    }

    protected override KeyCode GetShootKeyCode()
    {
        return KeyCode.Space;
    }

    protected override void HandleMovement()
    {
        float x = 0f;
        float y = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            y = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x = -1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = +1f;
        }

        Move = new Vector3(x, y).normalized;
        transform.position += Move * moveSpeed * Time.deltaTime;
    }
}

