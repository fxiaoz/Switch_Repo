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
            Text.text = "Has a right-handed bloody handprint at the base.";
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
    }
}
