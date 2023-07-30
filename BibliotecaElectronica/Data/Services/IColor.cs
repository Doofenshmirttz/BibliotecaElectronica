namespace BibliotecaElectronica.Data.Services
{
    public interface IColor
    {
        string ColorCode { get; set; }

        void ChangeColor(string Value);
        string GetColor();
    }
}