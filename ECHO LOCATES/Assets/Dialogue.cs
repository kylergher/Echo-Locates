using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject activator;
    public GameObject panel; 
    public MeshRenderer mesh;
   
    private int index;

    void Start()
    {
        activator.SetActive(true);
        panel.SetActive(false);
	mesh.enabled=true;
    }

    void OnTriggerEnter(Collider other)
    {
        GetComponent<Collider>().enabled = false;

        panel.SetActive(true);
	mesh.enabled=false;

        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
	if(panel.activeInHierarchy == true)
	{
        	if (Input.GetMouseButtonDown(0))
        	{
            		if (textComponent.text == lines[index])
            		{
                		NextLine();
            		}
            		else
            		{
                		StopAllCoroutines();
                		textComponent.text = lines[index];
            		}
        	}
	}
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            panel.SetActive(false);
            activator.SetActive(false);
        }
    }
}