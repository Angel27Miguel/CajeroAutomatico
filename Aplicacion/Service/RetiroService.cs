

using Aplicacion.ViewModels;

namespace Aplicacion.Service
{
	public class RetiroService
	{
		private Dictionary<int, int> ProcesoEficiente(int amount)
		{
			Dictionary<int, int> result = new Dictionary<int, int>();

			// Usar la denominacion mas grande primero
			int bill1000 = amount / 1000;
			amount %= 1000;

			int bill500 = amount / 500;
			amount %= 500;

			int bill200 = amount / 200;
			amount %= 200;

			int bill100 = amount / 100;

			// Agregar solo las denominaciones que se usaron
			if (bill1000 > 0) result[1000] = bill1000;
			if (bill500 > 0) result[500] = bill500;
			if (bill200 > 0) result[200] = bill200;
			if (bill100 > 0) result[100] = bill100;

			return result;
		}
        private Dictionary<int, int> Proceso200_1000(int monto)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            // Validar que el monto sea múltiplo de 200 o 1000
            if (monto % 200 != 0 && monto % 1000 != 0)
            {
                return null; // Monto no válido para este modo
            }

            // Retirar billetes de 1,000 pesos primero
            int billetes1000 = monto / 1000;
            monto %= 1000;

            // Luego usar billetes de 200 pesos
            int billetes200 = monto / 200;

            if (billetes1000 > 0) result[1000] = billetes1000;
            if (billetes200 > 0) result[200] = billetes200;

            return result;
        }


        private Dictionary<int, int> Proceso100_500(int amount)
		{
			Dictionary<int, int> result = new Dictionary<int, int>();

			//  divisible por 100 o 500
			if (amount % 100 != 0 && amount % 500 != 0)
			{
				return null; 
			}

			// 500 primero
			int billetes500 = amount / 500;
			amount %= 500;

			// Luego de 100
			int billetes100 = amount / 100;

			result[500] = billetes500;
			result[100] = billetes100;

			return result;
		}

		public RetiroResultadoViewModel ProcesoRetiro(int monto, string modo)
		{
			Dictionary<int, int> dict = new Dictionary<int, int>();
			switch (modo)
			{
				case "Eficiente":
					dict = ProcesoEficiente(monto);
					break;
				case "200_1000":
					dict = Proceso200_1000(monto);
					break;
				case "100_500":
					dict = Proceso100_500(monto);
					break;
				default:
					return null; 
			}

			return new RetiroResultadoViewModel
			{
				MontoTotal = monto,
				Denominaciones = dict
			};
		}
	}
}
