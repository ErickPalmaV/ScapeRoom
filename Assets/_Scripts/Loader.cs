using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gameManager;
    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation= SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
        yield return new WaitUntil(() => operation.isDone);
        gameManager.ScenesLoaded.Add(gameObject.name);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadSceneAsync());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            gameManager.ScenesLoaded.Remove(gameObject.name);
        }
    }



}
