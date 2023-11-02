using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class click_script : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public GameObject dialogueBox;
    public GameObject itemtext;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        itemtext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.name == "knife")
        {
            dialogueBox.SetActive(true);
            itemtext.SetActive(true);
            itemText.text = "Has a right-handed bloody handprint at the base.";
        }

        if (Input.GetMouseButtonDown(0) && gameObject.name == "rope")
        {
            dialogueBox.SetActive(true);
            itemtext.SetActive(true);
            itemText.text = "Looks like it was cut with something sharp.";
            Debug.Log("");
        }
    }
}
