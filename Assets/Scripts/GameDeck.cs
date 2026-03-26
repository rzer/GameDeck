using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace DefaultNamespace
{
    public class GameDeck:MonoBehaviour
    {
        private TSVParser tsv;
        public List<CardData> cardsData = new List<CardData>();

        public Card card;
        
        [ContextMenu("Build Cards")]
        public void Build()
        {
            tsv = new TSVParser(1);
            tsv.DownloadAndParse(VisualSettings.Instance.tsvUrl, SetupCards);
        }

        [ContextMenu("Open output folder")]
        public void OpenFolder()
        {
            var path = Path.GetFullPath( Application.dataPath + "/../Output/");
            Debug.Log(path);
            EditorUtility.RevealInFinder(path);
        }

        private void SetupCards()
        {
            cardsData.Clear();
            do
            {
                var cardData = new CardData();
                
                cardData.rouletteNumber = tsv.GetString("rouletteNumber");
                cardData.rouletteColor = tsv.GetString("rouletteColor");
                
                cardData.pokerColor = tsv.GetString("pokerColor");
                cardData.pokerRank = tsv.GetString("pokerRank");
                //cardData.pokerRankImage = tsv.GetString("pokerRankImage");
                cardData.pokerSuit = tsv.GetString("pokerSuit");
                
                cardData.dominoFirst = tsv.GetString("dominoFirst");
                cardData.dominoSecond = tsv.GetString("dominoSecond");
                
                cardData.codenamesFirst = tsv.GetString("codenamesFirst");
                cardData.codenamesSecond = tsv.GetString("codenamesSecond");
                
                cardData.unoRank = tsv.GetString("unoRank");
                cardData.unoSymbol = tsv.GetString("unoSymbol");
                cardData.unoColor = tsv.GetString("unoColor");
                
                cardData.image = tsv.GetString("image");
                
                
                cardsData.Add(cardData);

            } while (tsv.NextLine());

            RenderCards();
        }

        private async void RenderCards()
        {
            for (int i = 0; i < cardsData.Count; i++)
            {
                card.SetData(cardsData[i]);
                var fileName = Application.dataPath + "/../Output/" + card.data.rouletteNumber + ".png";
                //ScreenCapture.CaptureScreenshot(fileName);
                Debug.Log($"Save {fileName}");
                await Task.Delay(TimeSpan.FromSeconds(0.2f));
                if (!Application.isPlaying) return;
            }
            
            Debug.Log($"Generation completed!");
            
            
        }
    }
}