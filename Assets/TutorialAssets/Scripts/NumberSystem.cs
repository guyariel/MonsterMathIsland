using TMPro;
using UnityEngine;

public class NumberSystem : MonoBehaviour
{
    [SerializeField] TMP_Text _messageTextField;
    string _messageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find two random numbers
        int firstNumber = Random.Range(1,50);
        int secondNumber = Random.Range(1,50);

        if (firstNumber < secondNumber)
        {
            _messageText = $"{firstNumber} is lower than {secondNumber}";
        }
        else
        {
            _messageText = $"{firstNumber} is higher than {secondNumber}";
        }

        _messageTextField.text = _messageText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
