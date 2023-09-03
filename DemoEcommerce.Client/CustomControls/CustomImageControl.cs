namespace DemoEcommerce.Client.CustomControls
{
    public class CustomImageControl : Image
    {

        public static readonly BindableProperty Base64SourceProperty =
            BindableProperty.Create(
                nameof(Base64Source),
                typeof(string),
                typeof(CustomImageControl),
                string.Empty,
                propertyChanged: OnBase64SourceChanged);

        public string Base64Source
        {
            set
            {
                SetValue(Base64SourceProperty, value);
            }
            get
            {
                return (string)GetValue(Base64SourceProperty);
            }
        }

        private static void OnBase64SourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue is null) return;
            MemoryStream stream = new MemoryStream(Convert.FromBase64String((string)newValue));
            ((Image)bindable).Source = ImageSource.FromStream(() => stream);
        }
    }
}
