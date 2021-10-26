using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("button");
        //onClick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("Game");
    }
}
