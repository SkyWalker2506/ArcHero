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
    static bool isShootingArrow;
    float arrowTimer;

    private void Awake()
    {
        dv = Instantiate(defaultValues);
    }

    private void Update()
    {
        arrowTimer -= Time.deltaTime;
        if (isShootingArrow && arrowTimer < 0)
            StartCoroutine(ShotArrows());
    }

    public static void StartShooting()
    {
        shotSpeed = dv.DefaultShotSpeed;
        shotFrequency = dv.DefaultShotFrequency;
        shotAmount = dv.DefaultShotAmount;
        directions = dv.Directions;
        isShootingArrow = true;
    }

    public static void StopShooting()
    {
        isShootingArrow = false;
    }

    IEnumerator ShotArrows()
    {
        arrowTimer = shotFrequency;
        for (int i = 0; i < shotAmount; i++)
        {
            yield return new WaitForSeconds(.1f);
            ShotToAllDirections(directions);
        }
    }

    void ShotToAllDirections(List<Vector3> directions)
    {
        foreach(Vector3 direction in directions)
        {
            ShotAnArrow(direction);
        }
    }

    void ShotAnArrow(Vector3 direction)
    {
       var arrowDirection = direction + transform.rotation.eulerAngles;
       var arrow = Instantiate(arrowPrefab, transform.position+transform.forward, Quaternion.Euler(arrowDirection)).GetComponent<Arrow>();
       arrow.arrowSpeed = shotSpeed;
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

    public static void AddShotAmount(int shotAmnt)
    {
        shotAmount += shotAmnt;
    }

    public static void MultiplyShotInterval(float intervalMultiplier)
    {
        shotFrequency *= intervalMultiplier;
    }

    public static void MultiplyShotSpeed(float speedMultiplier)
    {
        shotSpeed *= speedMultiplier;
    }
    
}