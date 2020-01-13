using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField]GameObject gameField;
    static GameObject GameField;

    private void Awake()
    {
        if (!GameField)
            GameField = gameField;
    }

    public static Vector3 GetRandomPositionOnField()
    {
        Vector3 randomPosition=new Vector3();
        var boundSize = GameField.GetComponent<Collider>().bounds.size;
        var position = GameField.transform.position;
        randomPosition.x = position.x + Random.Range(-boundSize.x, boundSize.x)*.5f;
        randomPosition.z = position.z + Random.Range(-boundSize.z, boundSize.z)*.5f;
        randomPosition.y = position.y + boundSize.y;
        return randomPosition;
    }
}