using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject textButton;
    public void ChangeSceneByIndex(int sceneIndex)
    {
        anim.SetTrigger("Clicked");
        //textButton.SetActive(false);
        StartCoroutine(ChangeSceneDelay(sceneIndex));
        
    }

    IEnumerator ChangeSceneDelay(int sceneIndex)
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(sceneIndex);

    }
}
