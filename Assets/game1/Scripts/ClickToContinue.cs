using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClickToContinue : MonoBehaviour
{
    public string scene;

    private bool loadLock;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !loadLock)
        {
            LoadScene();
            Player.isDead = false;
        }
    }
    void LoadScene()
    {
        loadLock = true;
        SceneManager.LoadScene(scene);

    }
}
