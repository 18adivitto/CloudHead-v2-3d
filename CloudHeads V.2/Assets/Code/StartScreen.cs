using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    bool startIsSelected = true;
    bool quitIsSelected = false;
    public Sprite startScreen;
    public Sprite quitScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            quitIsSelected = false;
            startIsSelected = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = startScreen;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            startIsSelected = false;
            quitIsSelected = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = quitScreen;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(quitIsSelected == true)
            {
                QuitGame();
            }
            else if (startIsSelected == true)
            {
                StartGame();
            }
        }
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
