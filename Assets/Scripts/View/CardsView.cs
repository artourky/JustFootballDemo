using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsView : UIView<CardsModel,CardsController>
{
    public RectTransform CardsContent;
    public GameObject CardItemPrefab;
    public List<CardItem> CardsList;
    public override void RegisterDependency()
    {
        base.RegisterDependency();
        Model.ListenOnPropertyChanged("CardsList", CardsListChanged);
    }
    private void CardsListChanged()
    {
        for (int i = 0; i < Model.CardsList.Length; i++)
        {
            CardItem cardItem;
            if (CardsList.Count <= i)
            {
                GameObject ClubObject = Instantiate(CardItemPrefab, CardsContent);
                ClubObject.name = Model.CardsList[i].username + Model.CardsList[i].id;
                cardItem = ClubObject.GetComponent<CardItem>();
                CardsList.Add(cardItem);
            }
            else
            {
                cardItem = CardsList[i];
            }
            HandleClubItemData(Model.CardsList[i], cardItem);
        }
    }
    private void HandleClubItemData(CardsData.CardData cardData, CardItem cardItem)
    {
        cardItem.CardButton.onClick.RemoveAllListeners();
        cardItem.CardButton.onLongPress.RemoveAllListeners();

        cardItem.CardButton.onClick.AddListener(() => { OnCardClicked(cardData.id); });
        cardItem.CardButton.onLongPress.AddListener(() => { OnCardLongPressed(cardItem.gameObject); });
        cardItem.playerName.text = cardData.username;
    }
    private void OnCardClicked(string clubID)
    {
        Controller.OnCardItemClicked(clubID);
    }
    private void OnCardLongPressed(GameObject cardItem)
    {
        Destroy(cardItem);
    }

}
