using UnityEngine;
public class Player_2 : PlayerBase
{
    protected override void Start()
    {
        base.Start();
        // Additional code specific to Player 2
    }

    protected override void Update()
    {
        base.Update();
        HandleMovement();
        // Additional code specific to Player 2
    }

    protected override KeyCode GetShootKeyCode()
    {
        return KeyCode.Mouse0;
    }

    protected override void HandleMovement()
    {
        float x = 0f;
        float y = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y = +1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = -1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            y = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x = +1f;
        }

        Move = new Vector3(x, y).normalized;
        transform.position += Move * moveSpeed * Time.deltaTime;
    }
}
