// Oz
using UnityEngine; 
using UnityEngine.SceneManagement;

public class SceneNav : MonoBehaviour
{
    public void LoadScene()
    {
        // load scene with build index
        SceneManager.LoadScene(1);
    }
}
