using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MyFacebookApp.View
{
	public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
	{
		public AbstractControlDescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
		{
		}

		public override Type GetReflectionType(Type i_ObjectType, object i_Instance)
		{
			if (i_ObjectType == typeof(TAbstract))
			{
				return typeof(TBase);
			}

			return base.GetReflectionType(i_ObjectType, i_Instance);
		}

		public override object CreateInstance(IServiceProvider i_Provider, Type i_ObjectType, Type[] i_ArgTypes, object[] i_Args)
		{
			if (i_ObjectType == typeof(TAbstract))
			{
				i_ObjectType = typeof(TBase);
			}

			return base.CreateInstance(i_Provider, i_ObjectType, i_ArgTypes, i_Args);
		}
	}
}
