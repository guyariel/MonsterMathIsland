using System;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{

    [SerializeField] TMP_Text _messageBoxTextField;
    [SerializeField] TMP_InputField _answerInputField;

    string question;
    [SerializeField] int answer;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        Find random values for the operation
        */
        int operand1 = UnityEngine.Random.Range(1,100); 
        int operand2 = UnityEngine.Random.Range(1,100);
        
        if (UnityEngine.Random.value < 0.5f)
        {
            question = $"{operand1} + {operand2} = ";
            answer = operand1 + operand2;
        }
        else
        {
            question = $"{operand1} - {operand2} = ";
            answer = operand1 - operand2;
        }

        _messageBoxTextField.text = question;

        _answerInputField.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
