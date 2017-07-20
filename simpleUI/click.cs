using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour {

    public GameObject text;
    public GameObject second;
	
	public void bclick()
    {
        var rt = text.GetComponent<RectTransform>();
        var rtsecond = second.GetComponent<RectTransform>();
        if (rt.localScale.y == 0)
        {
            rt.localScale = new Vector3(1, 1, 1);
            
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, xy); 
            
        } 
        else
        {
            rt.localScale = new Vector3(1, 0, 1);
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, xy); 
        }
    }


}