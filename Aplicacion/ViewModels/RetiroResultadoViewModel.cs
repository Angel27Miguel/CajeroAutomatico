namespace Aplicacion.ViewModels
{
    public class RetiroResultadoViewModel
    {
        public int MontoTotal { get; set; }
        public Dictionary<int, int> Denominaciones { get; set; }
        public string ErrorMessage { get; set; }
    }
}
