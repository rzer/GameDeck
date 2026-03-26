using System.IO;
using UnityEngine;

public abstract class RuntimeSettings<T>:ScriptableObject where T:ScriptableObject
{
    
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance != null) return instance;
            instance = Load(typeof(T).Name);
            return instance;
        }
    }

    public static T Load(string fileName)
    {
        
#if UNITY_EDITOR
        
        var filePath = Path.Combine($"Assets/Resources/Settings/{fileName}.asset");
        var asset =  (T)UnityEditor.AssetDatabase.LoadAssetAtPath(filePath, typeof(T));
        if (asset == null)
        {
            asset = CreateInstance<T>();
            Directory.CreateDirectory("Assets/Resources/Settings");
            UnityEditor.AssetDatabase.CreateAsset(asset, filePath);
        }
#endif
        
        return Resources.Load<T>($"Settings/{fileName}");
    }

    
}

   
