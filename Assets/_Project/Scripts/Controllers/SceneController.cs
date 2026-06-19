using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public SceneController Instance { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        //GameObject obj = this.gameObject;

        //Debug.Log("Ativei");
        //if (obj != null)
        //{
        //    Destroy(obj);
        //}
        //else
        //{
        //    Instantiate(obj);
            
        //}
    }

    public void ChangeScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }
}
