using System;
using System.Collections;
using System.Collections.Generic;
using UIPersian;
using UIPersian.Utils;
using UnityEngine;
using UnityEngine.UI;

public class ExamplePersianRichTextLoader : MonoBehaviour
{
    public RTLText RtlText;
    public Text SampleText;
    
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("data");
        
        var json = NiceJson.JsonObject.ParseJsonString(textAsset.text);



        SampleText.text = json["valuemetaa"].ToString().ToPersianWithMeta();
//        if (RtlText != null)
//        {
//            String persianText = json["value"].ToString();
//            RtlText.text = persianText;
//        }

//        Char NonBrakingSpace = (char)0x00a0;
//        char x = (char)0x200d;
//        textBox1.Text = "می@شود ".Replace('@', NonBrakingSpace);
//        textBox1.Text += string.Format("می{0}رود", x);
    }
    
}
