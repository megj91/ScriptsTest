using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUserAuctionInventory : IInventoryItem, ICardTrayComponent
{
    float _experience;
    Card _gameCardInfo;
    int _cardAmmount;
    string _inventoryId;
    CardInventoryStatus _cardInventoryStatus;

    public object GetData()
    {
        return this;
    }

    public Card GetCardInfo()
    {
        return GameCardInfo;
    }
    
    public override string ToString()
    {
        return InventoryId+" "+GameCardInfo.CardName+" "+Experience+" "+_cardInventoryStatus;
    }

    public string GetId()
    {
        return _inventoryId;
    }


    public string print()
    {
        return string.Format("InvId  {0}  Name {1}  invStatus {2}  exp {3}",InventoryId,GameCardInfo.CardName, _cardInventoryStatus,Experience);
    }

    public Card GameCardInfo { get => _gameCardInfo; set => _gameCardInfo = value; }
    public float Experience { get => _experience; set => _experience = value; }
    public int CardAmmount { get => _cardAmmount; set => _cardAmmount = value; }
    public string InventoryId { get => _inventoryId; set => _inventoryId = value; }
    public CardInventoryStatus CardInventoryStatus { get => _cardInventoryStatus; set => _cardInventoryStatus = value; }
}
