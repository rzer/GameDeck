using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RouletteController : BaseController
{
    public Image frameBackground;
    public Image rouletteBackground;
    public TextMeshProUGUI rouletteNumber;

    public override void Render()
    {
        rouletteNumber.text = data.rouletteNumber;
        
        var pokerColors = settings.pokerColors.First(c => c.name == data.pokerColor);
        var rouletteColors = settings.rouletteColors.First(c => c.name == data.rouletteColor);
        frameBackground.color = pokerColors.light;
        rouletteBackground.color = rouletteColors.main;

    }
}
