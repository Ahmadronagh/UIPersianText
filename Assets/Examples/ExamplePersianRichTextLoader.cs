using System;
using System.Collections;
using System.Collections.Generic;
using UIPersian;
using UIPersian.Utils;
using UnityEngine;

public class ExamplePersianRichTextLoader : MonoBehaviour
{
    public RTLText RtlText;
    
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("data");
        
        var json = NiceJson.JsonObject.ParseJsonString(textAsset.text);
        if (RtlText != null)
        {
            String persianText = json["value"].ToString();
            RtlText.text = persianText;
        }
    }
    
}
