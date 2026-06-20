using UnityEngine;

public class CoreLoop : MonoBehaviour
{
    public static CoreLoop coreInstance { get; private set; }

    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _player;


    private void Awake()
    {
        if (coreInstance != null)
            Destroy(coreInstance);
        else
        {
            coreInstance = this;
            DontDestroyOnLoad(coreInstance);
        }

        StartGame();

    }

    private void StartGame()
    {

    }

}
