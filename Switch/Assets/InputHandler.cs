using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera;

    public TextMeshProUGUI Text;
    public GameObject dialogueBox;
    public GameObject text;

    public string[] dialogue;
    private int index;
    public float wordspeed;

    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        dialogueBox.SetActive(false);
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueBox.activeInHierarchy)
            {

            }

            else
            {
                dialogueBox.SetActive(true);
                text.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (Text.text == dialogue[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        if (rayHit.collider.gameObject.name == "knife")
        {
            dialogueBox.SetActive(true);
            text.SetActive(true);
            Text.text = "Has a right-handed bloody handprint on the handle.";
        }

        if (rayHit.collider.gameObject.name == "rope")
        {
            dialogueBox.SetActive(true);
            text.SetActive(true);
            Text.text = "Looks like it was cut with something sharp.";
        }

        if (rayHit.collider.gameObject.name == "mug")
        {
            dialogueBox.SetActive(true);
            text.SetActive(true);
            Text.text = "An empty mug with traces of coffee.";
        }

        if (rayHit.collider.gameObject.name == "exit")
        {
            SceneManager.LoadScene("Room 2");
        }

        if (rayHit.collider.gameObject.name == "Lulieta")
        {
            SceneManager.LoadScene("Lulieta");
        }
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            Text.text += letter;
            yield return new WaitForSeconds(wordspeed);
        }
    }

    public void NextLine()
    {
        continueButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            Text.text = "";
            StartCoroutine(Typing());
        }

        else
        {
            continueButton.SetActive(false);
            dialogueBox.SetActive(false);
            text.SetActive(false);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Room 2");
    }
}
