using UnityEngine;
using UnityEngine.Tilemaps;

public class HIdeColidersColor : MonoBehaviour
{
    private TilemapRenderer tileRender;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        tileRender = GetComponent<TilemapRenderer>();
    }
    void Start()
    {
        tileRender.enabled = false;
    }
}
