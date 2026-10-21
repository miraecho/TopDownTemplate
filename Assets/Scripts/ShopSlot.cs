using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopSlot : MonoBehaviour
{
    public GameObject currentItem;
    public int itemPrice;
    public TMP_Text priceText;
    public bool isShopSlot = true; //In shop menu, true = shop side and false = player side

    //Shop fields
    public int buyPrice = 10; //Buy from shop
    [Range(0, 1)]
    public float sellPriceMultiplier = 0.5f; //Sell for 50% buy price

    private void Awake()
    {
        if (!priceText) 
        {
            priceText = transform.Find("PriceText").GetComponent<TMP_Text>();
        }
    }

    public int GetSellPrice() 
    {
        return Mathf.RoundToInt(buyPrice * sellPriceMultiplier);
    }

    public void UpdatePriceDisplay() 
    {
        if (priceText && currentItem) 
        {
            priceText.text = itemPrice.ToString();
        }
    }

    public void SetItem(GameObject item, int price) 
    {
        currentItem = item;
        itemPrice = price;
        UpdatePriceDisplay();
    }

}
