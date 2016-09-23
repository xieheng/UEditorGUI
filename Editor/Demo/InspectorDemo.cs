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

        UFolder labelFolder = new UFolder("Label Folder");
        AddWidget(labelFolder);

        ULabel label = new ULabel("This is a label");
        labelFolder.AddWidget(label);

        UFolder helpboxFolder = new UFolder("HelpBox Folder");
        AddWidget(helpboxFolder);

        UHelpBox helpBox = new UHelpBox("HelpBox", MessageType.Info);
        helpboxFolder.AddWidget(helpBox);

        UFolder fieldFolder = new UFolder("Field Folder");
        AddWidget(fieldFolder);

        UTextField textField = new UTextField("Text Filed");
        fieldFolder.AddWidget(textField);

        UIntField intField = new UIntField("Int Field");
        fieldFolder.AddWidget(intField);

        UFloatField floatField = new UFloatField("Float Field");
        fieldFolder.AddWidget(floatField);

        UObjectField objectField = new UObjectField("Object Field", typeof(GameObject));
        fieldFolder.AddWidget(objectField);

        UAnimationCurveField curveField = new UAnimationCurveField("AnimationCurve Filed");
        fieldFolder.AddWidget(curveField);

        UColorField colorField = new UColorField("Color Field");
        fieldFolder.AddWidget(colorField);

        UBoundsField boundsField = new UBoundsField("Bounds Field");
        fieldFolder.AddWidget(boundsField);

        URectField rectField = new URectField("Rect Field");
        fieldFolder.AddWidget(rectField);

        UVector2Filed vector2Field = new UVector2Filed("Vector2 Field");
        fieldFolder.AddWidget(vector2Field);

        UVector3Filed vector3Field = new UVector3Filed("Vector3 Field");
        fieldFolder.AddWidget(vector3Field);

        UVector4Filed vector4Field = new UVector4Filed("Vector4 Field");
        fieldFolder.AddWidget(vector4Field);

        USearchField searchField = new USearchField("Search Field");
        fieldFolder.AddWidget(searchField);

        UFolder sliderFolder = new UFolder("Slider Folder");
        AddWidget(sliderFolder);

        UIntSlider intSlider = new UIntSlider("Int Slider", 5, 0, 10);
        sliderFolder.AddWidget(intSlider);

        UFolder popupFolder = new UFolder("Popup Folder");
        AddWidget(popupFolder);

        UEnumPopup enumPopup = new UEnumPopup("Enum Popup", EnumType.B);
        popupFolder.AddWidget(enumPopup);

        int[] popupValues = new int[] { 1, 3, 5, 7, 9 };
        string[] popupTexts = new string[] { "1", "3", "5", "7", "9" };

        UIntPopup intPopup = new UIntPopup("Int Popup", popupValues[2], popupValues, popupTexts);
        popupFolder.AddWidget(intPopup);

        UFolder buttonFolder = new UFolder("Button Folder");
        AddWidget(buttonFolder);

        UButton button = new UButton("Button");
        button.color = Color.green;
        buttonFolder.AddWidget(button);

        UMiniButton miniButton = new UMiniButton("Mini Button");
        miniButton.color = Color.red;
        buttonFolder.AddWidget(miniButton);

        UToggleButton toggleButton = new UToggleButton("Toggle Button");
        buttonFolder.AddWidget(toggleButton);
    }
}
