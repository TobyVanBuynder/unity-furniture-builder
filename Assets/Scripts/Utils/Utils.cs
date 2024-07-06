using UnityEngine.UIElements;

public static class Utils
{
    // https://forum.unity.com/threads/is-there-no-placeholder-text-property-for-textfield.962304/
    public static void SetPlaceholderText(this TextField textField, string placeholder)
    {
        string placeholderClass = TextField.ussClassName + "__placeholder";
    
        onFocusOut();
        textField.RegisterCallback<FocusInEvent>(evt => onFocusIn());
        textField.RegisterCallback<FocusOutEvent>(evt => onFocusOut());
    
        void onFocusIn()
        {
            if (textField.ClassListContains(placeholderClass))
            {
                textField.value = string.Empty;
                textField.RemoveFromClassList(placeholderClass);
            }
        }
    
        void onFocusOut()
        {
            if (string.IsNullOrEmpty(textField.text))
            {
                textField.SetValueWithoutNotify(placeholder);
                textField.AddToClassList(placeholderClass);
            }
        }
    }
}