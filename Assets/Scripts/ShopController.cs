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
    public TMP_Text playerMoneyText, shopTitleText;

    private ItemDictionary itemDictionary;
    private ShopNPC currentShop;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemDictionary = FindAnyObjectByType<ItemDictionary>();
        shopPanel.SetActive(false);
        if (CurrencyController.Instance != null) 
        {
            CurrencyController.Instance.OnGoldChanged += UpdateMoneyDisplay;
            UpdateMoneyDisplay(CurrencyController.Instance.GetGold());
        }
    }

    private void UpdateMoneyDisplay(int amount) 
    {
        if (playerMoneyText != null) 
        {
            playerMoneyText.text = amount.ToString();
        }
        
    }
    
    public void OpenShop(ShopNPC shop) 
    {
        currentShop = shop;
        shopPanel.SetActive(true);
        if (shopTitleText != null) shopTitleText.text = shop.shopkeeperName + "'s Shop";
        //RefreshShopDisplay
        //RefreshInventoryDisplay
        PauseController.SetPause(true);

    }

    public void CloseShop() 
    {
        shopPanel.SetActive(false);
        currentShop = null;
        PauseController.SetPause(false);
    }
}
