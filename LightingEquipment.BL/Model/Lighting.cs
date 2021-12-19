using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingEquipment.BL.Model
{
	/// <summary> Освещение Коэффициентом использования </summary>
	class Lighting
	{
		/// <summary> Массив объектов коэффициентов использования </summary>
		public static CoefUsage[] CoefUsages { get; internal set; }

		/// <summary> Массив ламп </summary>
		public static Lamp[] Lamps { get; internal set; }


		/// <summary> Объект комната </summary>
		public Room Room { get; private set; }

		/// <summary> Кривая силы света </summary>
		public LightCurve LightCurve { get; private set; }

		/// <summary> Тип лампы в светильнике </summary>
		public TypeLamp TypeLamp { get; private set; }

		/// <summary> Расстояние светильников друг от друга </summary>
		public float DistanceLamps { get; private set; }

		/// <summary> Расстояние крайних светильников </summary>
		public float DistanceLastLamps { get; }



		/// <summary> коэффициент отражения потолка </summary>
		public int ReflectionCeilingCoef { get; } = 0;

		/// <summary> коэффициент отражения стен </summary>
		public int ReflectionWallCoef { get; } = 0;

		/// <summary> коэффициент отражения рабочей поверхности </summary>
		public int ReflectionWorkSurfCoef { get; } = 0;

		/// <summary> Коэффициент использования </summary>
		public float CoefUsage { get; }

		/// <summary> Выбранные лампы при расчёте </summary>
		public Lamp[] SelectLamps { get; private set; }



		/// <summary> Кол-во ламп по длине помещения </summary>
		public float CountLampLengthRoom { get; private set; }

		/// <summary> Кол-во ламп по ширине помещения </summary>
		public float CountLampWidthRoom { get; private set; }

		/// <summary> Кол-во ламп в помещении </summary>
		public float CountLamp { get; private set; }

		/// <summary> Световой поток </summary>
		public int LuminousFlux { get; private set; }


		public Lighting(
			Room room, LightCurve lightCurve, TypeLamp typeLamp,
			int reflectionCeilingCoef, int reflectionWallCoef, int reflectionWorkSurfCoef,
			float distanceLamps) : this(room, lightCurve, typeLamp, distanceLamps)
		{
			#region Проверка
			if (CoefUsages == null || CoefUsages.Length == 0)
			{
				throw new ArgumentException($"Нет данных данных о коэффициентах использования");
			}

			if (CoefUsages.FirstOrDefault(x => x.NameLightCurve == LightCurve.Name) == null)
			{
				throw new ArgumentException($"Переданная кривая силы света не соответствует ни одной кривой силы света, находящейся в данных о коэффициентах использования");
			}

			if (reflectionCeilingCoef < 0 || reflectionCeilingCoef > 100)
			{
				throw new ArgumentException($"Коэффициент отражения потолка не может быть меньше 0 или больше 100");
			}

			if (reflectionWallCoef < 0 || reflectionWallCoef > 100)
			{
				throw new ArgumentException($"Коэффициент отражения стен не может быть меньше 0 или больше 100");
			}

			if (reflectionWorkSurfCoef < 0 || reflectionWorkSurfCoef > 100)
			{
				throw new ArgumentException($"Коэффициент отражения рабочей поверхности не может быть меньше 0 или больше 100");
			} 
			#endregion

			ReflectionCeilingCoef = reflectionCeilingCoef;
			ReflectionWallCoef = reflectionWallCoef;
			ReflectionWorkSurfCoef = reflectionWorkSurfCoef;

			#region Нахождение коэффициента использования
			int nearReflection;
			int[] masTemp;
			CoefUsage[] coefUsagesSelection;


			// Выбрать все элементы с указанным наименованием кривой силы света
			coefUsagesSelection = CoefUsages.Where(x => x.NameLightCurve == LightCurve.Name).ToArray();


			if(coefUsagesSelection.FirstOrDefault(x => x.ReflectionCeilingCoef == ReflectionCeilingCoef) == null)
			{

				// Выбрать все коэффициенты отражения от потолка из сформированного выше массива
				// Удаляем повторяющиеся значения
				masTemp = coefUsagesSelection.Select(x => x.ReflectionCeilingCoef)
																	.GroupBy(n => n)
																	.Select(g => g.First())
																	.ToArray();
				// нахождение ближайшего коэффициента из списка выше, к переданному коэффициенту
				nearReflection = GetNearNum(ReflectionCeilingCoef, masTemp);
			}
			else
			{
				nearReflection = ReflectionCeilingCoef;
			}
			// Выбрать все элементы с найденным ближайшим коэффициентом отражения от потолка
			coefUsagesSelection = coefUsagesSelection.Where(x => x.ReflectionCeilingCoef == nearReflection).ToArray();



			if (coefUsagesSelection.FirstOrDefault(x => x.ReflectionWallCoef == ReflectionWallCoef) == null)
			{
				// Аналогичные действия с коэффициентом отражения от стен
				masTemp = coefUsagesSelection.Select(x => x.ReflectionWallCoef)
																	.GroupBy(n => n)
																	.Select(g => g.First())
																	.ToArray();
				nearReflection = GetNearNum(ReflectionWallCoef, masTemp);
			}
			else
			{
				nearReflection = ReflectionWallCoef;
			}
			coefUsagesSelection = coefUsagesSelection.Where(x => x.ReflectionWallCoef == nearReflection).ToArray();



			if (coefUsagesSelection.FirstOrDefault(x => x.ReflectionWorkSurfCoef == ReflectionWallCoef) == null)
			{
				// Аналогичные действия с коэффициентом отражения от рабочей поверхности
				masTemp = coefUsagesSelection.Select(x => x.ReflectionWorkSurfCoef)
																	.GroupBy(n => n)
																	.Select(g => g.First())
																	.ToArray();
				nearReflection = GetNearNum(ReflectionWorkSurfCoef, masTemp);
			}
			else
			{
				nearReflection = ReflectionWorkSurfCoef;
			}
			coefUsagesSelection = coefUsagesSelection.Where(x => x.ReflectionWorkSurfCoef == nearReflection).ToArray();



			// Выборка по индексам помещения
			if(coefUsagesSelection.FirstOrDefault(x => x.Index == Room.Index) == null)
			{
				float maxIndex = coefUsagesSelection.Max(x => x.Index);
				float minIndex = coefUsagesSelection.Min(x => x.Index);
				//CoefUsage = coefUsagesSelection.First(x => x.Index == maxIndex).Coef;
				if (maxIndex < Room.Index)
				{
					CoefUsage = coefUsagesSelection.First(x => x.Index == maxIndex).Coef;
				}
				else if(minIndex > Room.Index)
				{
					CoefUsage = coefUsagesSelection.First(x => x.Index == minIndex).Coef;
				}
				else
				{
					bool lessFlag = true;
					bool moreFlag = true;
					CoefUsage lessIndex = coefUsagesSelection[0];
					CoefUsage moreIndex = coefUsagesSelection[0];

					for (int i = 0; i < coefUsagesSelection.Length; i++)
					{
						if (Room.Index > coefUsagesSelection[i].Index)
						{
							if (coefUsagesSelection[i].Index > lessIndex.Index)
							{
								lessIndex = coefUsagesSelection[i];
								continue;
							}

							if (lessFlag)
							{
								lessIndex = coefUsagesSelection[i];
							}
						}
						else
						{
							if (coefUsagesSelection[i].Index < moreIndex.Index)
							{
								moreIndex = coefUsagesSelection[i];
								continue;
							}

							if (moreFlag)
							{
								moreIndex = coefUsagesSelection[i];
							}
						}
					}

					CoefUsage = (moreIndex.Coef - lessIndex.Coef) / (moreIndex.Index - lessIndex.Index) * Room.Index;

				}
			}
			else
			{
				CoefUsage = coefUsagesSelection.FirstOrDefault(x => x.Index == Room.Index).Coef;
			}


			#endregion


			CalculationParametrs();
		}



		public Lighting(
			Room room, LightCurve lightCurve, TypeLamp typeLamp,
			float distanceLamps, int coefUsage) : this(room, lightCurve, typeLamp, distanceLamps)
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
			#region Проверка
			Room = room ?? throw new ArgumentNullException(nameof(room));
			LightCurve = lightCurve ?? throw new ArgumentNullException(nameof(lightCurve));
			TypeLamp = typeLamp ?? throw new ArgumentNullException(nameof(typeLamp)); 
			#endregion

			if (distanceLamps <= 0)
			{
				throw new ArgumentException($"Расстояние светильников друг от друга не может быть отрицательным или равным 0");
			}
			DistanceLamps = distanceLamps;
		}


		/// <summary>
		/// Функция нахождения ближайшего числа из массива
		/// </summary>
		/// <param name="value">Число для поиска</param>
		/// <param name="valueMas">Массив чисел для поиска</param>
		/// <returns>ближайшее число из массива</returns>
		private int GetNearNum(int value, int[] valueMas)
		{
			int nearNum = 0;
			int t = int.MaxValue;

			for (int i = 0; i < valueMas.Length; i++)
			{
				int a = Math.Abs(valueMas[i] - ReflectionCeilingCoef);

				if (a < t)
				{
					nearNum = valueMas[i];
					t = a;
				}
			}

			return nearNum;
		}

		/// <summary> 
		/// Функция рассчёта параметров и выбор лампы
		/// (кол-во ламп по длине, кол-во ламп по ширине, кол-во ламп, световой поток)  
		/// </summary>
		private void CalculationParametrs()
		{
			CountLampLengthRoom = ((Room.Length - 2 * DistanceLastLamps) / DistanceLamps) + 1;
			CountLampWidthRoom = ((Room.Width - 2 * DistanceLastLamps) / DistanceLamps) + 1;
			CountLamp = CountLampLengthRoom * CountLampWidthRoom;

			LuminousFlux = (int)Math.Round((Room.NormIllumination * Room.Square * TypeLamp.CoefMinIllumination * TypeLamp.CoefStore / (CountLamp * CoefUsage)));

			//Выбор лампы, если загружен список ламп
			if (Lamps != null && Lamps.Length > 1)
			{
				int luminousFlux90Persent = (int)Math.Round(LuminousFlux * 0.9);
				int luminousFlux120Persent = (int)Math.Round(LuminousFlux * 1.2);
				 
				SelectLamps = Lamps.Where(x => (x.TypeLamp == TypeLamp.Name) && (x.LightCurveName == LightCurve.Name))
										 .Where(x => (x.LuminousFlux > luminousFlux90Persent) || (x.LuminousFlux < luminousFlux120Persent)) 
										 .ToArray();
			}
		}
	}
}
