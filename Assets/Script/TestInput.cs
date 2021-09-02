using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///             Classe de test pour une entré de touche
/// </summary>
public class TestInput : MonoBehaviour
{
    private Text inputText;

    KeyCode k;

    public List<KeyCode> whiteList;

    private void Awake()
    {
       
        inputText = GameObject.FindGameObjectWithTag("Input").GetComponent<Text>();
    }

    private void Start()
    {
        StartCoroutine(WaitingForAnInput()); 
    }

    IEnumerator WaitingForAnInput()
    {

            yield return new GetKeyEnumerator(x => k = x);

            if (whiteList.Contains(k))
            {
                inputText.text += k.ToString();
            }
    }
}
