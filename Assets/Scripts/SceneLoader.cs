using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    bool shouldLoad;
    bool isLoaded;
    string playerName = "Player";

    private void Update()
    {
        if (shouldLoad)
        {
            LoadScene();
        }
        else
        {
            UnloadScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != this)
        {
            if (other.CompareTag(playerName))
            {
                shouldLoad = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other != this)
        {
            if (other.CompareTag(playerName))
            {
                shouldLoad = false;
            }
        }
    }

    private void UnloadScene()
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
        }
    }

    private void LoadScene()
    {
        if (!isLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isLoaded = true;
        }
    }
}
