using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokerController:BaseController
{
        public Image frame;
        public Image suitImage;
        public Image rankImage;
        public TextMeshProUGUI rankLabel;
    
        public override void Render()
        {
                var pokerColors = settings.pokerColors.First(c => c.name == data.pokerColor);
                frame.color = pokerColors.light;
                rankImage.color = rankLabel.color = suitImage.color = pokerColors.main;
                rankImage.gameObject.SetActive(data.pokerRank.Length > 2);
                rankLabel.gameObject.SetActive(data.pokerRank.Length <= 2);
                rankLabel.text = data.pokerRank;
                
                
                
                suitImage.sprite = settings.pokerSuits.First(s => s.name == data.pokerSuit).sprite;
                suitImage.SetNativeSize();
                
        }
}