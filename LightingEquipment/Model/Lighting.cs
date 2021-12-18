using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingEquipment.Model
{
	class Lighting
	{
		public static CoefUsage[] CoefUsages;
		public Room Room { get; private set; }
		public LightCurve LightCurve { get; private set; }
		public TypeLamp TypeLamp { get; private set; }




		/// <summary> Расстояние светильников друг от друга </summary>
		public float DistanceLamps { get; private set; }

		/// <summary> Расстояние крайних светильников </summary>
		public float DistanceLastLamps { get; }




		/// <summary> коэффициент отражения потолка </summary>
		public float ReflectionCeilingCoef { get; } = 0;

		/// <summary> коэффициент отражения стен </summary>
		public float ReflectionWallCoef { get; } = 0;

		/// <summary> коэффициент отражения рабочей поверхности </summary>
		public float ReflectionWorkSurfCoef { get; } = 0;

		/// <summary> Коэффициент использования </summary>
		public float CoefUsage { get; }



		/// <summary> Кол-во ламп по длине помещения </summary>
		public float CountLampLengthRoom { get; private set; }

		/// <summary> Кол-во ламп по ширине помещения </summary>
		public float CountLampWidthRoom { get; private set; }

		/// <summary> Кол-во ламп в помещении </summary>
		public float CountLamp { get; private set; }

		/// <summary> Световой поток </summary>
		public float LuminousFlux { get; private set; }



		public Lighting(
			Room room, LightCurve lightCurve, TypeLamp typeLamp,
			float reflectionCeilingCoef, float reflectionWallCoef, float reflectionWorkSurfCoef,
			float distanceLamps) : this(room, lightCurve, typeLamp, distanceLamps)
		{
			if(CoefUsages == null)
			{
				throw new ArgumentException($"Нет данных данных о коэффициентах использования");
			}

			if (CoefUsages.Length == 0)
			{
				throw new ArgumentException($"Нет данных данных о коэффициентах использования");
			}

			if (CoefUsages.Contains(x => x.NameLightCurve == LightCurve.Name))


			if (reflectionCeilingCoef < 0 || reflectionCeilingCoef > 1)
			{
				throw new ArgumentException($"Коэффициент отражения потолка не может быть меньше 0 или больше 1");
			}

			if (reflectionWallCoef < 0 || reflectionWallCoef > 1)
			{
				throw new ArgumentException($"Коэффициент отражения стен не может быть меньше 0 или больше 1");
			}

			if (reflectionWorkSurfCoef < 0 || reflectionWorkSurfCoef > 1)
			{
				throw new ArgumentException($"Коэффициент отражения рабочей поверхности не может быть меньше 0 или больше 1");
			}

			ReflectionCeilingCoef = reflectionCeilingCoef;
			ReflectionWallCoef = reflectionWallCoef;
			ReflectionWorkSurfCoef = reflectionWorkSurfCoef;



			CalculationParametrs();
		}



		public Lighting(
			Room room, LightCurve lightCurve, TypeLamp typeLamp,
			float distanceLamps, float coefUsage) : this(room, lightCurve, typeLamp, distanceLamps)
		{
			if(coefUsage <= 0)
			{
				throw new ArgumentException($"Коэффициент использования не может быть меньше или равным 0");
			}
			CoefUsage = coefUsage;
			CalculationParametrs();
		}



		private Lighting(
			Room room, LightCurve lightCurve, TypeLamp typeLamp,
			float distanceLamps)
		{
			Room = room ?? throw new ArgumentNullException(nameof(room));
			LightCurve = lightCurve ?? throw new ArgumentNullException(nameof(lightCurve));
			TypeLamp = typeLamp ?? throw new ArgumentNullException(nameof(typeLamp));

			if (distanceLamps <= 0)
			{
				throw new ArgumentException($"Расстояние светильников друг от друга не может быть отрицательным или равным 0");
			}
			DistanceLamps = distanceLamps;
		}



		private void CalculationParametrs()
		{
			CountLampLengthRoom = ((Room.Length - 2 * DistanceLastLamps) / DistanceLamps) + 1;
			CountLampWidthRoom = ((Room.Width - 2 * DistanceLastLamps) / DistanceLamps) + 1;
			CountLamp = CountLampLengthRoom * CountLampWidthRoom;

			LuminousFlux = Room.NormIllumination * Room.Square * TypeLamp.CoefMinIllumination * TypeLamp.CoefStore / (CountLamp * CoefUsage);
		}
	}
}
