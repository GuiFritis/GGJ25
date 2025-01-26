using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour, IButtonDelayed
{
    [SerializeField] private int _sceneIndex;

    private void Start()
    {
        SetUpButtonDelay();
    }

    public void SetUpButtonDelay()
    {
        GetComponent<ButtonAnimationHelper>().OnAnimationFinished += ChangeSceneByIndex;
    }

    public void ChangeSceneByIndex()
    {
        SceneManager.LoadScene(_sceneIndex);        
    }
}
