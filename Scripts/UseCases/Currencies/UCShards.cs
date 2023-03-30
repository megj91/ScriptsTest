using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCShards : ICurrencyShop
{
    CurrencyShopInformation _currencyData;

    public void BuyCurrency(CurrencyShopData currencyShopData)
    {
        BuyCurrencyCallBack(currencyShopData);
    }

    void BuyCurrencyCallBack(CurrencyShopData currencyShopData)
    {
        DelegateHelpers.OnShopBought?.Invoke(currencyShopData);
    }

    public void GetCurrencies()
    {
        string url = WebServicesUrls._webServicesUrls[WebServicesEnum.GENERAL] + WebServicesUrls._webServicesUrls[WebServicesEnum.GETACTIVECARDSBYUSER] + "?";
        Dictionary<object, object> formulary = new Dictionary<object, object>();


        url += WebServicesController.Instance.BuildQuery(formulary);

        Debug.Log(url);

        GetCurrenciesCallback("", new Dictionary<string, string>());

        //WebServicesController.Instance.SendGet(GetActiveCardsByUserCallback, url, true, null, null);
    }

    public void GetCurrenciesCallback(string json, Dictionary<string, string> headers)
    {
        _currencyData = new CurrencyShopInformation();

        _currencyData.AddCurrencyShopInformation(CurrencyType.SHARDS, CurrencyType.COINS, 20, 5);
        _currencyData.AddCurrencyShopInformation(CurrencyType.SHARDS, CurrencyType.COINS, 50, 15);
        _currencyData.AddCurrencyShopInformation(CurrencyType.SHARDS, CurrencyType.COINS, 100, 30);

        DelegateHelpers.OnCurrencyDataLoaded?.Invoke();

    }

    public CurrencyShopInformation GetData()
    {
        return _currencyData;
    }
}
