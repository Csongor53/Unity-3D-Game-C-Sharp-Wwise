using System;
using System.Collections;
using System.Collections.Generic;
using SojaExiles;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[Serializable]
public struct DialogElements
{
    [TextAreaAttribute]
    public string dialogText;
    public string answerText1;
    public UnityEvent answerAction1;
    public string answerText2;
    public UnityEvent answerAction2;
    
}

public class Dialog : MonoBehaviour
{
    [SerializeField] 
    private GameObject dialogDisplay;
    [SerializeField] 
    private TextMeshProUGUI textElement;
    [SerializeField]
    private Button answer1Button;
    [SerializeField] 
    private Button answer2Button;
    [SerializeField] 
    private DialogElements[] dialogElements;


    private GameObject playerReference;
    private bool wasTriggered = false;


    public void OpenDialog()
    {
        dialogDisplay.SetActive(true);
        LoadDialogElements(0);
    }
    
    public void CloseDialog()
    {
        playerReference.GetComponent<PlayerInput>().enabled = true;
        Camera.main.GetComponent<PlayerInput>().enabled = true;
        dialogDisplay.SetActive(false);
    }

    public void LoadDialogElements(int index)
    {

        if (index == 2 && DataStorage.instance.score < 5)
            index++;
        if (index == 2 && DataStorage.instance.score >= 5)
            DataStorage.instance.IncreaseHealth(5);



        textElement.text = dialogElements[index].dialogText;
        if (dialogElements[index].answerAction1 != null)
        {
            answer1Button.gameObject.SetActive(true);
            answer1Button.GetComponentInChildren<TextMeshProUGUI>().text = dialogElements[index].answerText1;
            answer1Button.onClick.RemoveAllListeners();
            answer1Button.onClick.AddListener(() => dialogElements[index].answerAction1.Invoke());
        }
        else
            answer1Button.gameObject.SetActive(false);

        if (dialogElements[index].answerAction2 != null)
        {
            answer2Button.gameObject.SetActive(true);
            answer2Button.GetComponentInChildren<TextMeshProUGUI>().text = dialogElements[index].answerText2;
            answer2Button.onClick.RemoveAllListeners();
            answer2Button.onClick.AddListener(() => dialogElements[index].answerAction2.Invoke());
        }
        else
            answer2Button.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (wasTriggered)
            return;
        if (other.gameObject.CompareTag("Player"))
        {
            wasTriggered = true;
            OpenDialog();
            playerReference = other.gameObject;
            playerReference.GetComponent<PlayerInput>().enabled = false;
            Camera.main.GetComponent<PlayerInput>().enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            wasTriggered = false;
        }
    }
}
