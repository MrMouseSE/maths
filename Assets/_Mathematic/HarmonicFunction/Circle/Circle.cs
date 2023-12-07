using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Circle : MonoBehaviour
{
    public float Lenght;
    public Transform Object;

    private List<Transform> objects;
    
    public void Generate()
    {
        ClearList();
        var step = Lenght / 10;
        for (int i = 0; i < 10; i++)
        {
            objects.Add(Instantiate(Object, new Vector3(step * i, 0, 0), Quaternion.identity));
        }
    }

    private void ClearList()
    {
        if (objects!=null)
        {
            for (int i = 0; i < objects.Capacity; i++)
            {
                DestroyImmediate(objects[i]);
            }

            objects = new List<Transform>();
        }
    }
}