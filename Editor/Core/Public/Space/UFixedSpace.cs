using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UFixedSpace : UControl
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private int _pixel = 3;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixel"></param>
        public UFixedSpace(int pixel)
        {
            _pixel = pixel;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            GUILayout.Space(_pixel);
        }

        #endregion
    }
}