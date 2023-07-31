namespace BibliotecaElectronica.Data.Services
{
    public class Color : IColor
    {
        public string ColorCode { get; set; } = null!;
        public bool DarkMode { get; set; } = false;

        public void ChangeColor(string Value)
        {
            ColorCode = Value;
        }

        public void SetMode(bool mode)
        {
            this.DarkMode = mode;
        }
        public string GetColor()
        {
            return ColorCode;
        }
    }
}
