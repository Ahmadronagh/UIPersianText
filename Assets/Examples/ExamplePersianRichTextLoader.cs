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
    public Text SampleText1;
    public Text SampleText2;
    public Text SampleText3;
    public Text SampleText4;
    
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("data");
        
        var json = NiceJson.JsonObject.ParseJsonString(textAsset.text);



        SampleText.text = json["value"].ToString().ToPersianWithMeta();
        SampleText1.text = json["value1"].ToString().ToPersianWithMeta();
        SampleText2.text = json["value2"].ToString().ToPersianWithMeta();
        SampleText3.text = json["value5"].ToString().ToPersianWithMeta();
        SampleText4.text = json["value4"].ToString().ToPersianWithMeta();
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
