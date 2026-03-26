using TMPro;
using UnityEngine;

public class CodenamesController : BaseController
{
    
    public TextMeshProUGUI firstWord;
    public TextMeshProUGUI secondWord;

    public override void Render()
    {
        firstWord.text = data.codenamesFirst;
        secondWord.text = data.codenamesSecond;
    }
}
