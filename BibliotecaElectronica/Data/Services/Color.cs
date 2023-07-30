namespace BibliotecaElectronica.Data.Services
{
    public class Color :IColor
    {
        public string ColorCode { get; set; } = null!;


        public void ChangeColor(string Value)
        {
            ColorCode = Value;
        }

        public string GetColor()
        {
            return ColorCode;
        }
    }
}
