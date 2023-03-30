using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpatanGGS;
using TMPro;
using UnityEngine.EventSystems;

public class StoreCoins : MonoBehaviour
{
    int shardsQuantity;
    int coinsQuantity;

    Button buyButton;
    bool otherValue;

    TextMeshProUGUI otherCoinsText;
    TMP_InputField inputShard;
    FormStore formStore;

    ScrollRect optionScroll;

    List<GameObject> optionsList = new List<GameObject>();
    CurrencyShopData currentCurrencyShopData;

    void Start()
    {

        formStore = transform.GetComponentInParent<FormStore>();
        shardsQuantity = 20;
        coinsQuantity = 5;
        otherValue = false;

        optionScroll = transform.Find("Options").GetComponent<ScrollRect>();

        buyButton = transform.Find("Buy Button").GetComponent<Button>();
        buyButton.onClick.AddListener(() => ClickBuy());

        LoadData();
    }

    void ClickButtons(CurrencyShopData tempCurrency, GameObject currObject)
    {
        foreach (GameObject item in optionsList)
        {
            item.transform.Find("Active").gameObject.SetActive(false);
        }

        currObject.transform.Find("Active").gameObject.SetActive(true);
        currentCurrencyShopData = tempCurrency;
    }

    void ClickBuy()
    {
        DelegateHelpers.OnShopBuyListener?.Invoke(currentCurrencyShopData);
    }

    void LoadData()
    {
        for (int i = 0; i < optionsList.Count; i++)
        {
            Destroy(optionsList[i]);
        }

        optionsList.Clear();

        ServiceLocator.Instance.GetService<ICurrencyShop>().GetData().GetCurrencyDataList();

        int count = 1;

        foreach (var item in ServiceLocator.Instance.GetService<ICurrencyShop>().GetData().GetCurrencyDataList())
        {
            Debug.Log(item.ToString());

            GameObject optionObject = Instantiate((GameObject)Resources.Load(ViewsDictionary.ComponentsDictionary[ComponentsDirectoryEnum.UI_STORE_COIN]), optionScroll.content);
            optionsList.Add(optionObject);

            optionObject.transform.Find("Quantity").GetComponent<TextMeshProUGUI>().text = item._currencyValue.ToString();
            optionObject.transform.Find("Price").GetComponent<TextMeshProUGUI>().text = item._currencyChangeValue.ToString();
            optionObject.GetComponent<Button>().onClick.AddListener(() => ClickButtons(item, optionObject));

            optionObject.transform.Find(count.ToString()).gameObject.SetActive(true);

            count++;

        }

        if (optionsList.Count > 0)
        {
            ClickButtons(ServiceLocator.Instance.GetService<ICurrencyShop>().GetData().GetCurrencyDataList()[0], optionsList[0]);
        }
    }
}
