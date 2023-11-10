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
    List<string> inventory = new List<string>();

    public GameObject continueButton;
    public GameObject closeButton;

 
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

       
        
        dialogueBox.SetActive(false);
        text.SetActive(false);
        closeButton.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueBox.activeInHierarchy)
            {

            }

            else
            {
                
            }
        }
        */

        if (Input.GetKeyDown("space"))
        {
            foreach (var x in inventory)
            {
                Debug.Log(x);
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
        if (!rayHit.collider)
        {
            return;
        }
        else
        {
            
            
            dialogueBox.SetActive(true);
            text.SetActive(true);
            StartCoroutine(Typing());
            
        }

        if (rayHit.collider.gameObject.name == "knife")
        {
            dialogueBox.SetActive(true);
            text.SetActive(true);
            closeButton.SetActive(true);
            Text.text = "Has a right-handed bloody handprint on the handle.";

            if (!inventory.Contains(rayHit.collider.gameObject.name))
            {
                inventory.Add(rayHit.collider.gameObject.name);
            }
        }

        if (rayHit.collider.gameObject.name == "rope")
        {
            dialogueBox.SetActive(true);
            text.SetActive(true);
            closeButton.SetActive(true);
            Text.text = "Looks like it was cut with something sharp.";

            if (!inventory.Contains(rayHit.collider.gameObject.name))
            {
                inventory.Add(rayHit.collider.gameObject.name);
            }
        }

        if (rayHit.collider.gameObject.name == "mug")
        {
            dialogueBox.SetActive(true);
            text.SetActive(true);
            closeButton.SetActive(true);
            Text.text = "An empty mug with traces of coffee.";

            if (!inventory.Contains(rayHit.collider.gameObject.name))
            {
                inventory.Add(rayHit.collider.gameObject.name);
            }
        }

        if (rayHit.collider.gameObject.name == "Cabinet")
        {
            dialogueBox.SetActive(true);
            text.SetActive(true);
            closeButton.SetActive(true);
            Text.text = "Huh, Lulieta's favorite mug is missing.";

            if (!inventory.Contains(rayHit.collider.gameObject.name))
            {
                inventory.Add(rayHit.collider.gameObject.name);
            }
        }

        if(rayHit.collider.gameObject.name == "Knife Holder")
        {
            dialogueBox.SetActive(true);
            text.SetActive(true);
            closeButton.SetActive(true);
            Text.text = "One of the knives is missing.";

            if (!inventory.Contains(rayHit.collider.gameObject.name))
            {
                inventory.Add(rayHit.collider.gameObject.name);
            }
        }

        if (rayHit.collider.gameObject.name == "exit")
        {
            Debug.Log("bbb");
            SceneManager.LoadScene("roomDoors");
        }

        if (rayHit.collider.gameObject.name == "Lulieta")
        {
            SceneManager.LoadScene("Lulieta");
        }

        if (rayHit.collider.gameObject.name == "door1")
        {
            SceneManager.LoadScene("Room 1");
        }
        if (rayHit.collider.gameObject.name == "door2")
        {
            if(inventory.Contains("knife") && inventory.Contains("mug") && inventory.Contains("rope"))
            {
                Debug.Log("lol");
                SceneManager.LoadScene("Room 2");
            }
        }
        if (rayHit.collider.gameObject.name == "door3")
        {
            //SceneManager.LoadScene("Room 1");
        }
    }

    IEnumerator Typing()
    {
        
        foreach (char letter in dialogue[index].ToCharArray())
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

    public void Close()
    {
        dialogueBox.SetActive(false);
        text.SetActive(false);
        closeButton.SetActive(false);
    }
}
