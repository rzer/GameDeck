using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnoController:BaseController
{
        public Image frame;
        public Image image;
        public TextMeshProUGUI rankLabel;
        
        public override void Render()
        {
                var unoColors = settings.unoColors.First(c => c.name == data.unoColor);
                frame.color = unoColors.main;
                rankLabel.text = data.unoRank;

                var hasSymbol = !string.IsNullOrEmpty(data.unoSymbol);
                
                image.gameObject.SetActive(hasSymbol);
                if (hasSymbol)
                { 
                        Debug.Log(data.unoSymbol);
                        image.sprite = settings.unoSymbols.First(s => s.name == data.unoSymbol).sprite;
                        image.SetNativeSize();
                }
                
                
        }
}