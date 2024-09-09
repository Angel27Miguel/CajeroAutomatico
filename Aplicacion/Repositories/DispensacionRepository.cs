namespace Aplicacion.Repositories
{
    public class DispensacionRepository
    {
        private static string ModoActual = "Eficiente"; // Valor predeterminado

        public string GetMode()
        {
            return ModoActual;
        }

        public void SetMode(string modo)
        {
            ModoActual = modo;
        }
    }
}
