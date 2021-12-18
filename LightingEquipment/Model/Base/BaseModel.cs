using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingEquipment.Model.Base
{
	public abstract class BaseModel
	{
		public uint Id { get; }
		public string Name { get; }

		protected BaseModel(uint id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
