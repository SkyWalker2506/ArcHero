using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;

    public static GameManager Instance;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    private void Start()
    {
        PlayerShotBehaviour.StartShooting();
    }
}