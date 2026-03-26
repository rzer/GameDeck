using UnityEngine;

public class DominoController : BaseController
{
    
    public DominoNumber firstNumber;
    public DominoNumber secondNumber;

    public override void Render()
    {
        
        firstNumber.gameObject.SetActive(false);
        secondNumber.gameObject.SetActive(false);
        
        if (!string.IsNullOrEmpty(data.dominoFirst))
        {
            firstNumber.gameObject.SetActive(true);
            firstNumber.SetData(data.dominoFirst);
        }
        
        if (!string.IsNullOrEmpty(data.dominoSecond))
        {
            secondNumber.gameObject.SetActive(true);
            secondNumber.SetData(data.dominoSecond);
        }
    }
}
