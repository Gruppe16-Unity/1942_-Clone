using UnityEngine;

public class SharedHP : MonoBehaviour
{
    public int CurrentHP;  // The shared HP value

    // Function to decrease the shared HP
    public void DecreaseSharedHealth(int amount)
    {
        CurrentHP -= amount;
    }
}
