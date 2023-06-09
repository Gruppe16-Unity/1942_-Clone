using UnityEngine;
using TMPro;

public class Credit : MonoBehaviour
{
    public static Credit CI;
    public TextMeshProUGUI CreditText;
    private void Start()
    {
        UpdateCreditText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameManager.Instance.IncreaseCredit(1);
        }


        UpdateCreditText();
    }



    public void UpdateCreditText()
    {
        CreditText.text = "Credit: " + GameManager.Instance.GetCredit().ToString();
    }

    private void Awake()
    {
        if (CI == null)
        {
            CI = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}