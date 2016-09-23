using UnityEngine;
using UnityEditor;
using UEditorGUI;

/// <summary>
/// 
/// </summary>
class InspectorDemoObject : UInspectorTargetObject
{
    
}

/// <summary>
/// A demo of UInspector
/// </summary>
[CustomEditor(typeof(InspectorDemoObject))]
public class InspectorDemo : UInspector
{
    const int SPACE_PIXELS = 20;

    enum EnumType
    {
        A,
        B,
        C,
        D
    }

    public InspectorDemo()
    {
        //label
        ULabel label = new ULabel("Label");
        AddWidget(label);

        AddWidget(new UFixedSpace(SPACE_PIXELS));

        //help box
        UHelpBox helpBox = new UHelpBox("HelpBox", MessageType.Info);
        AddWidget(helpBox);

        AddWidget(new UFixedSpace(SPACE_PIXELS));

        //field
        {
            UTextField textField = new UTextField("Text Filed");
            AddWidget(textField);

            UIntField intField = new UIntField("Int Field");
            AddWidget(intField);

            UFloatField floatField = new UFloatField("Float Field");
            AddWidget(floatField);

            UObjectField objectField = new UObjectField("Object Field", typeof(GameObject));
            AddWidget(objectField);

            UAnimationCurveField curveField = new UAnimationCurveField("AnimationCurve Filed");
            AddWidget(curveField);

            UColorField colorField = new UColorField("Color Field");
            AddWidget(colorField);

            UBoundsField boundsField = new UBoundsField("Bounds Field");
            AddWidget(boundsField);

            URectField rectField = new URectField("Rect Field");
            AddWidget(rectField);

            UVector2Filed vector2Field = new UVector2Filed("Vector2 Field");
            AddWidget(vector2Field);

            UVector3Filed vector3Field = new UVector3Filed("Vector3 Field");
            AddWidget(vector3Field);

            UVector4Filed vector4Field = new UVector4Filed("Vector4 Field");
            AddWidget(vector4Field);

            USearchField searchField = new USearchField("Search Field");
            AddWidget(searchField);
        }

        AddWidget(new UFixedSpace(SPACE_PIXELS));

        //int slider
        UIntSlider intSlider = new UIntSlider("Int Slider", 5, 0, 10);
        AddWidget(intSlider);

        AddWidget(new UFixedSpace(SPACE_PIXELS));

        //popup
        {
            UEnumPopup enumPopup = new UEnumPopup("Enum Popup", EnumType.B);
            AddWidget(enumPopup);

            int[] popupValues = new int[] { 1, 3, 5, 7, 9 };
            string[] popupTexts = new string[] { "1", "3", "5", "7", "9" };

            UIntPopup intPopup = new UIntPopup("Int Popup", popupValues[2], popupValues, popupTexts);
            AddWidget(intPopup);
        }

        AddWidget(new UFixedSpace(SPACE_PIXELS));

        //button
        {
            UButton button = new UButton("Button");
            button.color = Color.green;
            AddWidget(button);

            UMiniButton miniButton = new UMiniButton("Mini Button");
            miniButton.color = Color.red;
            AddWidget(miniButton);

            UToggleButton toggleButton = new UToggleButton("Toggle Button");
            AddWidget(toggleButton);
        }
    }
}
