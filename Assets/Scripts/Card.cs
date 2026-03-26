using System;
using DefaultNamespace;
using UnityEngine;

public class Card:MonoBehaviour
{

        public static Card instance;
        public CardData data;
        
        public DominoController domino;
        public PokerController poker;
        public CodenamesController codenames;
        public RouletteController roulette;
        public UnoController uno;
        public ImageController image;

        public void Awake()
        { 
                instance = this;
        }

        public void SetData(CardData data)
        {
                this.data = data; 
                domino.Render();
                poker.Render();
                codenames.Render();
                roulette.Render();
                uno.Render();
                image.Render();
        }
        
}