using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{

    public void OnSelectPlayer1()
    {
        SceneManager.LoadScene("Player Male");
    }
    public void OnSelectPlayer2()
    {
        SceneManager.LoadScene("Player Female");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
