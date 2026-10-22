using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;

    [Header("UI")]
    public GameObject shopPanel;
    public Transform shopInventoryGrid, playerInventoryGrid;
    public GameObject shopSlotPrefab;
    public TMP_Text playerMoneyText, shopMoneyText;

    private ItemDictionary itemDictionary;
    //private ShopNPC currentShop;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    
}
