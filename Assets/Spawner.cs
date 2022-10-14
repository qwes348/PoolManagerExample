using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Poolable spherePrefab;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var sp = PoolManager.instance.Pop(spherePrefab);
            sp.transform.position = (Vector3)GetCurrentPointerPlanePosition();
            sp.gameObject.SetActive(true);
        }
    }

    public Vector3? GetCurrentPointerPlanePosition()
    {
        float planeY = 0;
        Plane pl = new Plane(Vector3.up, Vector3.up * planeY);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;
        if (pl.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }
        else
            return null;
    }
}
