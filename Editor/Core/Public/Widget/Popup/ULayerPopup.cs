using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class ULayerPopup : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private int _layer = 0;

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UIntChangedEventHandler OnLayerChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layer"></param>
        public ULayerPopup(int layer)
        {
            _layer = layer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="layer"></param>
        public ULayerPopup(string caption, int layer)
            : base(caption)
        {
            _layer = layer;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        protected override void UpdateGUI()
        {
            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.LayerField(caption, _layer);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnLayerChangedHandler();
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// 
        /// </summary>
        public int layer
        {
            set
            {
                _layer = value;
                OnLayerChangedHandler();
            }

            get { return _layer; }
        }

        #endregion

        #region Private

        /// <summary>
        /// 
        /// </summary>
        private void OnLayerChangedHandler()
        {
            if (OnLayerChanged != null)
            {
                UIntEventArgs args = new UIntEventArgs(this, _layer);
                OnLayerChanged(args);
            }
        }

        #endregion
    }
}