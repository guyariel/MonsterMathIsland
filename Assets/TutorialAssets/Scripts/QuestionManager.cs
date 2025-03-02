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
        generateQuestions();
    }

    void generateQuestions ()
    {
        /*
        Find random values for the operation
        */
        int operand1 = UnityEngine.Random.Range(1,100); 
        int operand2 = UnityEngine.Random.Range(1,100);
        
        // Addition or Subtraction
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

        clearInputField();
    }

    public void validateAnswer()
    {
        if (_answerInputField.text == answer.ToString())
        {
            generateQuestions();
        }
        else 
        {
            clearInputField();
        }
    }

    void clearInputField()
    {
        _answerInputField.text = "";
        _answerInputField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
