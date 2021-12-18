using LightingEquipment.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingEquipment.Model
{
	public class LightCurve : BaseModel
	{
		/// <summary> Коэффициент экономически-наивыгоднейшего расстояния</summary>
		public float СoefEconomicDistance { get; }

		/// <summary> Коэффициент светотехнически-наивыгоднейшего расстояния</summary>
		public float СoefLightingDistance { get; }

		public LightCurve(uint id, string name, float сoefEconomicDistance, float сoefLightingDistance) : base(id, name)
		{
			СoefEconomicDistance = сoefEconomicDistance;
			СoefLightingDistance = сoefLightingDistance;
		}
	}
}
