using System;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{

    [SerializeField] TMP_Text _messageBoxTextField;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int operand1 = UnityEngine.Random.Range(1,100); 
        int operand2 = UnityEngine.Random.Range(1,100);
        
        // Log operand
        Debug.Log(operand1);
        Debug.Log(operand2);


        _messageBoxTextField.text = "Hello world, nice to meet you";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
