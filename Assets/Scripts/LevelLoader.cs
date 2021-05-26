using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int LoadLevelusingInt;
    public string LoadLevelusingStr;

    public bool IntegerLevelLoader = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if (IntegerLevelLoader)
            SceneManager.LoadScene(LoadLevelusingInt);
        else
            SceneManager.LoadScene(LoadLevelusingStr);
    }
}
