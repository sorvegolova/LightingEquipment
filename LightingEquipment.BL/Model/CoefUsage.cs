using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingEquipment.BL.Model
{
	public class CoefUsage
	{
		/// <summary> Индекс помещения </summary>
		public string NameLightCurve { get; }

		/// <summary> коэффициент отражения потолка </summary>
		public int ReflectionCeilingCoef { get; }

		/// <summary> коэффициент отражения стен </summary>
		public int ReflectionWallCoef { get; }

		/// <summary> коэффициент отражения рабочей поверхности </summary>
		public int ReflectionWorkSurfCoef { get; }

		/// <summary> Индекс помещения </summary>
		public float Index { get; }

		/// <summary> Коэффициент использования </summary>
		public int Coef { get; }
	}
}
