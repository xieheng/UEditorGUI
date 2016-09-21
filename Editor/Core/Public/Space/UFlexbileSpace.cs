using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UFlexibleSpace : UControl
    {
        #region Override

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            GUILayout.FlexibleSpace();
        }

        #endregion
    }
}