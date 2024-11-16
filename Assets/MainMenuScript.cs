using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer bg;
    [SerializeField] SpriteRenderer logo;
    [SerializeField] Camera cam;
    [SerializeField] GameObject canvas;
    Vector3 direction;

    public void Start()
    {
        cam.transform.position = new Vector3(0, 10, -10);
        direction = new Vector3(0, -1 * 0.5f * .1f, 0);
    }

    public void FixedUpdate()
    {
        if (cam.transform.position.y > 0)
        {
            cam.transform.Translate(direction);
            return;
        }
        if (canvas.activeInHierarchy == false)
            canvas.SetActive(true);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}