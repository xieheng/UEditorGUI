using UnityEngine;
using UnityEditor;

namespace UEditorGUI
{
    /// <summary>
    /// 
    /// </summary>
    public class UAnimationCurveField : UCaptionWidget
    {
        #region Data

        /// <summary>
        /// 
        /// </summary>
        private AnimationCurve _curve = new AnimationCurve();

        #endregion

        #region Event

        /// <summary>
        /// 
        /// </summary>
        public event UAnimationCurveEventHandler OnCurveChanged;

        #endregion

        #region Construction

        /// <summary>
        /// 
        /// </summary>
        public UAnimationCurveField()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public UAnimationCurveField(string caption)
            : base(caption)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curve"></param>
        public UAnimationCurveField(AnimationCurve curve)
        {
            _curve = curve;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="curve"></param>
        public UAnimationCurveField(string caption, AnimationCurve curve)
            : base(caption)
        {
            _curve = curve;
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
                _curve = EditorGUILayout.CurveField(caption, _curve);
            }
            bool changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                OnAnimationCurveChangedHandler();
            }
        }

        #endregion

        #region

        /// <summary>
        /// 
        /// </summary>
        private void OnAnimationCurveChangedHandler()
        {
            if (OnCurveChanged != null)
            {
                UAnimationCurveEventArgs args = new UAnimationCurveEventArgs(this, _curve);
                OnCurveChanged(args);
            }
        }

        #endregion
    }
}