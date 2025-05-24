using _Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GameManager")]
public class GameManagerSO : ScriptableObject
{
    public List<string> scenesLoaded = new List<string>();

    public List<string> ScenesLoaded { get => scenesLoaded; set => scenesLoaded = value; }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {

    }


    public void RestartGame()
    {

        scenesLoaded.Clear();
        for (int i = 0; i < scenesLoaded.Count; i++)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(scenesLoaded[i]));
        }

        SceneManager.LoadScene(0);


    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
