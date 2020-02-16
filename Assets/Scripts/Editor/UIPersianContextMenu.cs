using UnityEditor;
using UnityEngine;

namespace UIPersian.Editor
{
    public class UIPersianContextMenu: UnityEditor.Editor
    {

        private static RTLText _rtlText;
        
        [MenuItem("GameObject/UI Persian/RTL Text",false,10)]
        private static void CreateRTLText()
        {
            Transform parent = FindCorrectParent();
            if(parent==null) return;
            if(parent==null) return;
            if (_rtlText == null) _rtlText = Resources.Load<RTLText>("RtlText");
            RTLText rtlText = Instantiate(_rtlText);
            rtlText.transform.SetParent(parent,false);
            
        }
        
        /// <summary>
        /// find selected parent or if nothing is selected, uses canvas as parent.
        /// </summary>
        /// <returns></returns>
        private static Transform FindCorrectParent()
        {
            Canvas canvas = FindObjectOfType<Canvas>();
            if (canvas != null)
            {
                int selectionCount = Selection.gameObjects.Length;
                if (selectionCount == 0) return canvas.transform;
                GameObject selection = Selection.gameObjects[0];
                return selection.GetComponent<RectTransform>() != null ? selection.transform : canvas.transform;
            }
            Debug.Log("There is no Canvas");
            return null;
        }
    }
}