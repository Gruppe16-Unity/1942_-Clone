using UnityEngine;
using TMPro;

public class Credit : MonoBehaviour
{
    public TextMeshProUGUI CreditText;

    private int credit;

    private void Start()
    {
        credit = 0;
        UpdateCreditText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseCredit(1);
        }
    }

    public void IncreaseCredit(int amount)
    {
        credit += amount;
        UpdateCreditText();
    }

    private void UpdateCreditText()
    {
        CreditText.text = "Credit: " + credit.ToString();
    }
}
