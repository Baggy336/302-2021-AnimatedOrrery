using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuControl : MonoBehaviour
{
    EventSystem events;
    void Start()
    {
        // Get the event system component
        events = GetComponentInChildren<EventSystem>();
    }
    void Update()
    {
        // If events aren't present
        if (events == null) return;
        if (events.currentSelectedGameObject == null) // If nothing is currently selected
        {
            if (events.firstSelectedGameObject != null)
                events.SetSelectedGameObject(events.firstSelectedGameObject); // Set the first selected object
        }
    }
    public void ButtonPlay()
    {
        // Switch to the scene on the play button
        SceneManager.LoadScene("AnimatedOrrery");
    }
    public void ButtonControls()
    {

    }
    public void ButtonQuit()
    {
        // Quit the application
        Application.Quit();
    }
}
