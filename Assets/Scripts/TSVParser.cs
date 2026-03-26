using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace DefaultNamespace
{
    public class TSVParser
    {
        
        public static Dictionary<int, string> map = new Dictionary<int, string>();
        public static List<Dictionary<string, string>> lines = new List<Dictionary<string, string>>();

        private int lineIndex = 0;
        private int skipLines = 0;

        public TSVParser(int skipLines = 0)
        {
            this.skipLines = skipLines;
        }
        
        public async void DownloadAndParse(string tsvUrl, Action completeHandler = null)
        {
            using var request = UnityWebRequest.Get(tsvUrl);
            
            var operation = request.SendWebRequest();
            while (!operation.isDone) await Task.Yield();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log($"Error {request.error}");
                return;
            }
            
            Parse(request.downloadHandler.text);
            completeHandler?.Invoke();
        }

        public bool NextLine()
        {
            if (lineIndex >= lines.Count - 1) return false;
            lineIndex++;
            return true;
        }

        public string GetString(string fieldName)
        {
            return lines[lineIndex][fieldName];
        }

        public int GetInt(string fieldName)
        {
            return int.Parse(lines[lineIndex][fieldName]);
        }

        public void Parse(string content)
        {
            Debug.Log($"TSV: {content}");
            var list = content.Split("\r\n").ToList();
            
            //Создаём карту ячеек
            var indexes = list[skipLines].Split("\t");
            for (int i = 0; i < indexes.Length; i++) map[i] = indexes[i];
            
            //Парсим значения
            for (int lineIndex = skipLines+1; lineIndex < list.Count; lineIndex++)
            {
                var lineValues = list[lineIndex].Split("\t");
                var line = new Dictionary<string, string>();

                for (int i = 0; i < lineValues.Length; i++)
                {
                    if (map.Count <= i) continue;
                    
                    var fieldName = map[i];
                    var value = lineValues[i];
                    line[fieldName] = value;
                }
                
                lines.Add(line);
            }
        }
    }
}