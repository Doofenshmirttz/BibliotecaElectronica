namespace BibliotecaElectronica.Data.Services
{
    public interface IColor
    {
        string ColorCode { get; set; }
        bool DarkMode { get; set; }

        void ChangeColor(string Value);
        string GetColor();
        void SetMode(bool mode);
    }
}