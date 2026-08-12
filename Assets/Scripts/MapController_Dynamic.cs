using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController_Dynamic : MonoBehaviour
{
    [Header("UI References")]
    public RectTransform mapParent;
    public GameObject areaPrefab;
    public RectTransform playerIcon;

    [Header("Colors")]
    public Color defaultColor = Color.gray; //Areas on our map that we're not in
    public Color currentAreaColor = Color.green; //Active area color

    [Header("Map Settings")]
    public GameObject mapBounds; //Parent of area colliders
    public PolygonCollider2D initialArea; //Initial starting area
    public float mapScale = 10f; //Adjust map scale on UI

    private PolygonCollider2D[] mapAreas; //Children of MapBounds
    private Dictionary<string, RectTransform> uiAreas = new Dictionary<string, RectTransform>(); //Map each PolygonCollider2D to corresponding RectTransform
    
    public static MapController_Dynamic Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        mapAreas = mapBounds.GetComponentsInChildren<PolygonCollider2D>();
    }

    //GenerateMap
    public void GenerateMap(PolygonCollider2D newCurrentArea = null) 
    {
        PolygonCollider2D currentArea = newCurrentArea != null ? newCurrentArea : initialArea;

        ClearMap();

        foreach(PolygonCollider2D area in mapAreas) 
        {
            //CreateAreaUI
        }
    }

    //ClearMap
    private void ClearMap() 
    {
        foreach(Transform child in mapParent) 
        {
            Destroy(child.gameObject);
        }

        uiAreas.Clear();
    }

    private void CreateAreaUI(PolygonCollider2D area, bool isCurrent) 
    {
        //Instantiate prefab for image

        //Get bounds

        //Scale UI image fit map and bounds
    }

    //UpdateCurrentArea

    //MovePlayerIcon
}
