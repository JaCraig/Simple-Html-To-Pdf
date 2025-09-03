using SimpleHtmlToPdf.Attributes;
using SimpleHtmlToPdf.Interfaces;
using SimpleHtmlToPdf.UnmanagedHandler;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SimpleHtmlToPdf.BaseClasses
{
	/// <summary>
	/// Converter base class
	/// </summary>
	/// <seealso cref="SimpleHtmlToPdf.Interfaces.IConverter"/>
	public abstract class ConverterBaseClass : IConverter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ConverterBaseClass"/> class.
		/// </summary>
		/// <param name="tools">The tools.</param>
		protected ConverterBaseClass(BindingWrapper tools)
		{
			Tools = tools;
		}

		/// <summary>
		/// The tools
		/// </summary>
		public readonly BindingWrapper Tools;

		/// <summary>
		/// Converts the specified document.
		/// </summary>
		/// <param name="document">The document.</param>
		/// <returns>The document as a PDF byte array.</returns>
		/// <exception cref="System.ArgumentException">
		/// No objects is defined in document that was passed. At least one object must be defined.
		/// </exception>
		public virtual byte[] Convert(IDocument document)
		{
			if (!document.GetObjects().Any())
			{
				throw new ArgumentException("No objects is defined in document that was passed. At least one object must be defined.");
			}

			byte[] result = Array.Empty<byte>();
			Tools.Load();

			IntPtr converter = CreateConverter(document);

			Tools.SetPhaseChangedCallback(converter, OnPhaseChanged);
			Tools.SetProgressChangedCallback(converter, OnProgressChanged);
			Tools.SetFinishedCallback(converter, OnFinished);
			Tools.SetWarningCallback(converter, OnWarning);
			Tools.SetErrorCallback(converter, OnError);

			bool converted = Tools.DoConversion(converter);

			if (converted)
			{
				result = Tools.GetConversionResult(converter);
			}

			Tools.DestroyConverter(converter);

			return result;
		}

		/// <summary>
		/// Applies the specified configuration.
		/// </summary>
		/// <param name="config">The configuration.</param>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		/// <param name="isGlobal">if set to <c>true</c> [is global].</param>
		private void Apply(IntPtr config, string name, object value, bool isGlobal)
		{
			var type = value.GetType();

			Func<IntPtr, string, string, int> applySetting;
			if (isGlobal)
			{
				applySetting = Tools.SetGlobalSetting;
			}
			else
			{
				applySetting = Tools.SetObjectSetting;
			}

			if (typeof(bool) == type)
			{
				applySetting(config, name, (bool)value ? "true" : "false");
			}
			else if (typeof(double) == type)
			{
				applySetting(config, name, ((double)value).ToString("0.##", CultureInfo.InvariantCulture));
			}
			else if (typeof(Dictionary<string, string>).IsAssignableFrom(type))
			{
				var dictionary = (Dictionary<string, string>)value;
				int index = 0;

				foreach (var pair in dictionary)
				{
					if (pair.Key is null || pair.Value is null)
					{
						continue;
					}

					//https://github.com/wkhtmltopdf/wkhtmltopdf/blob/c754e38b074a75a51327df36c4a53f8962020510/src/lib/reflect.hh#L192
					applySetting(config, name + ".append", null);
					applySetting(config, string.Format("{0}[{1}]", name, index), pair.Key + "\n" + pair.Value);

					index++;
				}
			}
			else
			{
				applySetting(config, name, value.ToString());
			}
		}

		/// <summary>
		/// Applies the configuration.
		/// </summary>
		/// <param name="config">The configuration.</param>
		/// <param name="settings">The settings.</param>
		/// <param name="isGlobal">if set to <c>true</c> [is global].</param>
		private void ApplyConfig(IntPtr config, ISettings? settings, bool isGlobal)
		{
			if (settings is null)
			{
				return;
			}

			const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

			foreach (var prop in settings.GetType().GetProperties(bindingFlags))
			{
				WkHtmlAttribute? attr = prop.GetCustomAttribute<WkHtmlAttribute>();
				object? propValue = prop.GetValue(settings);

				if (propValue is null)
				{
					continue;
				}
				if (attr is not null)
				{
					Apply(config, attr?.Name ?? "", propValue, isGlobal);
				}
				else if (propValue is ISettings)
				{
					ApplyConfig(config, propValue as ISettings, isGlobal);
				}
			}
		}

		/// <summary>
		/// Creates the converter.
		/// </summary>
		/// <param name="document">The document.</param>
		/// <returns></returns>
		private IntPtr CreateConverter(IDocument document)
		{
			IntPtr converter;
			{
				IntPtr settings = Tools.CreateGlobalSettings();

				ApplyConfig(settings, document, true);

				converter = Tools.CreateConverter(settings);
			}

			foreach (var obj in document.GetObjects())
			{
				if (!(obj is null))
				{
					IntPtr settings = Tools.CreateObjectSettings();

					ApplyConfig(settings, obj, false);

					Tools.AddObject(converter, settings, obj.GetContent());
				}
			}

			return converter;
		}

		private void OnError(IntPtr converter, string message)
		{
		}

		private void OnFinished(IntPtr converter, int success)
		{
		}

		private void OnPhaseChanged(IntPtr converter)
		{
		}

		private void OnProgressChanged(IntPtr converter)
		{
		}

		private void OnWarning(IntPtr converter, string message)
		{
		}
	}
}