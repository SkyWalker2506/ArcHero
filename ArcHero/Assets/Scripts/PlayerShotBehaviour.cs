using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotBehaviour : MonoBehaviour
{
    [SerializeField] PlayerShotStats defaultValues;
    static PlayerShotStats dv;
    [SerializeField] GameObject arrowPrefab;
    static float shotSpeed;
    static float shotFrequency;
    static int shotAmount;
    static List<Vector3> directions;
    bool isShootingArrow;
    float arrowTimer;

    private void Awake()
    {
        dv = Instantiate(defaultValues);
        shotSpeed = dv.DefaultShotSpeed;
        shotFrequency = dv.DefaultShotFrequency;
        shotAmount = dv.DefaultShotAmount;
        directions = dv.Directions;
        StartShooting();
    }

    private void Update()
    {
        arrowTimer -= Time.deltaTime;
        if (isShootingArrow && arrowTimer < 0)
            StartCoroutine(ShotArrows());
    }

    void StartShooting()
    {
        isShootingArrow = true;
        arrowTimer = 0;
    }

    void StopShooting()
    {
        isShootingArrow = false;
        arrowTimer = shotFrequency;
    }

    void ShotAnArrow(Vector3 direction)
    {
       var arrowDirection = direction + transform.rotation.eulerAngles;
       var arrow = Instantiate(arrowPrefab, transform.position+transform.forward, Quaternion.Euler(arrowDirection)).GetComponent<Arrow>();
       arrow.arrowSpeed = shotSpeed;
    }

    void ShotAllArrows(List<Vector3> directions)
    {
        foreach(Vector3 direction in directions)
        {
            ShotAnArrow(direction);
        }
    }

    IEnumerator ShotArrows()
    {
        arrowTimer = shotFrequency;
        for (int i = 0; i < shotAmount; i++)
        {
            yield return new WaitForSeconds(.1f);
           ShotAllArrows(directions); 
        }
    }

    public static void AddDirection(Vector3 direction)
    {
        if(!directions.Exists(d=>d==direction))
        directions.Add(direction);
    }

    public static void RemoveDirection(Vector3 direction)
    {
        if (directions.Exists(d => d == direction))
            directions.Remove(direction);
    }

    public static void ActivateConsecutiveShot()
    {
        shotAmount = dv.DefaultShotAmount+1;
    }

    public static void DeActivateConsecutiveShot()
    {
        shotAmount = dv.DefaultShotAmount;
    }

    public static void ActivateFasterShot()
    {
        shotFrequency = 1;
    }

    public static void DeActivateFasterShot()
    {
        shotFrequency = dv.DefaultShotFrequency;
    }
}