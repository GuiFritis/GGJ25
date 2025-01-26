using UnityEngine;

public class Exit : MonoBehaviour, IButtonDelayed
{    
    private void Start()
    {
        SetUpButtonDelay();
    }

    public void SetUpButtonDelay()
    {
        GetComponent<ButtonAnimationHelper>().OnAnimationFinished += ExitGame;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else            
        Application.Quit();
        #endif
    }
}
