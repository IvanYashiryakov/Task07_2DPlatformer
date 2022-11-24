using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private KeyCode _restartKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(_restartKey))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
