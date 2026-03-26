using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class VisualSettings:RuntimeSettings<VisualSettings>
    {
        [Header("CSV")] public string tsvUrl;

        [Header("Покер")]
        public List<PokerColors> pokerColors;
        public List<PokerSuits> pokerSuits;
        
        [Header("Рулетка")]
        public List<RouletteColors> rouletteColors;
        
        [Header("Уно")]
        public List<UnoColors> unoColors;
        public List<UnoSymbols> unoSymbols;
        
        
        [Header("Домино")]
        public Color dominoEmptyColor;
        public Color dominoFillColor;
        
        [Header("Картинки")]
        public List<Sprite> images;
        
    }

    [Serializable]
    public class PokerColors
    {
        public string name;
        public Color main;
        public Color light;
    }
    
    [Serializable]
    public class RouletteColors
    {
        public string name;
        public Color main;
    }
    
    [Serializable]
    public class PokerSuits
    {
        public string name;
        public Sprite sprite;
    }
    
    
    
    [Serializable]
    public class UnoSymbols
    {
        public string name;
        public Sprite sprite;
    }
    
    [Serializable]
    public class UnoColors
    {
        public string name;
        public Color main;
    }
}