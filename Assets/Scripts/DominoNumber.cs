using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class DominoNumber:MonoBehaviour
{
    public Image[] images;
    public NumberConfig[] numbers;

    public void SetData(string value)
    {
        var cardData = Card.instance.data;
        var colors = VisualSettings.Instance.pokerColors.First(c => c.name == cardData.pokerColor);
        
        foreach (var image in images) image.color = colors.light;
        var number = int.Parse(value);
        var cfg = numbers[number];
        foreach (var image in cfg.points) image.color = colors.main;
        
    }
}

[Serializable]
public class NumberConfig
{
     public List<Image> points = new();
}