using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StratGame : MonoBehaviour
{

    public string nameScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Image>().color.a == 1)
        {
            SceneManager.LoadScene(nameScene, LoadSceneMode.Single);
        }
    }
}
