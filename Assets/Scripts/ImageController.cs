using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : BaseController
{
    
    public Image image;
  

    public override void Render()
    {

        var hasImage = !string.IsNullOrEmpty(data.image);
        gameObject.SetActive(hasImage);

        if (hasImage)
        {
            Debug.Log(data.image);
            image.sprite = settings.images.First(i => i.name == data.image);
            image.SetNativeSize();
        }
    }
}
