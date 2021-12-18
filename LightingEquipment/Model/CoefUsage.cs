using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingEquipment.Model
{
	public class CoefUsage
	{
		/// <summary> Индекс помещения </summary>
		public float Index { get; }

		/// <summary> коэффициент отражения потолка </summary>
		public float ReflectionCeilingCoef { get; }

		/// <summary> коэффициент отражения стен </summary>
		public float ReflectionWallCoef { get; }

		/// <summary> коэффициент отражения рабочей поверхности </summary>
		public float ReflectionWorkSurfCoef { get; }

		/// <summary> Индекс помещения </summary>
		public string NameLightCurve { get; }

		/// <summary> Коэффициент использования </summary>
		public float Coef { get; }
	}
}
