using System;
using System.Diagnostics;
using UnityEngine;

namespace EvrikaGames.UnityCore
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    [Conditional("UNITY_EDITOR")]
    public class ButtonAttribute : PropertyAttribute
    {
        public string name;
        public string actionFunc;
        public bool showField;
        
        public ButtonAttribute(string name, string actionFunc, bool showField = true)
        {
            this.name = name;
            this.actionFunc = actionFunc;
            this.showField = showField;
        }
       
    }
}