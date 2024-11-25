using UnityEngine;
using System.Collections.Generic;

public class ObjectSortingManager : MonoBehaviour
{
    [SerializeField] private float offset = 0;
    [SerializeField] private int sortingOrderBase = 5;
    const int SortingLayerMultiplier = 10;
    [SerializeField] private bool isStatic = false;

    private List<Renderer> renderers = new List<Renderer>();

    private void Start()
    {
     
        renderers.AddRange(GetComponentsInChildren<Renderer>());
    }

    private void LateUpdate()
    {
        foreach (var renderer in renderers)
        {
            if (renderer != null)
            {
                renderer.sortingOrder = (int)(SortingLayerMultiplier * (sortingOrderBase - renderer.transform.position.y + offset));
            }
        }

        if (isStatic)
        {
           
            this.enabled = false;
        }
    }
}
