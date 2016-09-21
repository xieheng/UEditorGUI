using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UMenuSeparator : UMenuItem
    {
        #region Override

        /// <summary>
        /// 
        /// </summary>
        public override void OnGUI()
        {
            if (!visible)
                return;

            if (_parent != null)
            {
                _parent.AddSeparator(string.Empty);
            }
        }

        #endregion
    }
}