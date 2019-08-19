using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

using JetBrains.Core;
using JetBrains.Diagnostics;
using JetBrains.Collections;
using JetBrains.Collections.Viewable;
using JetBrains.Lifetimes;
using JetBrains.Serialization;
using JetBrains.Rd;
using JetBrains.Rd.Base;
using JetBrains.Rd.Impl;
using JetBrains.Rd.Tasks;
using JetBrains.Rd.Util;
using JetBrains.Rd.Text;


// ReSharper disable RedundantEmptyObjectCreationArgumentList
// ReSharper disable InconsistentNaming
// ReSharper disable RedundantOverflowCheckingContext


namespace JetBrains.Rider.Model
{
  
  
  public class RiderDevExpressPluginModel : RdExtBase
  {
    //fields
    //public fields
    [NotNull] public IViewableProperty<string> PluginTemplatesPath => _PluginTemplatesPath;
    
    //private fields
    [NotNull] private readonly RdProperty<string> _PluginTemplatesPath;
    
    //primary constructor
    private RiderDevExpressPluginModel(
      [NotNull] RdProperty<string> pluginTemplatesPath
    )
    {
      if (pluginTemplatesPath == null) throw new ArgumentNullException("pluginTemplatesPath");
      
      _PluginTemplatesPath = pluginTemplatesPath;
      _PluginTemplatesPath.OptimizeNested = true;
      BindableChildren.Add(new KeyValuePair<string, object>("pluginTemplatesPath", _PluginTemplatesPath));
    }
    //secondary constructor
    internal RiderDevExpressPluginModel (
    ) : this (
      new RdProperty<string>(JetBrains.Rd.Impl.Serializers.ReadString, JetBrains.Rd.Impl.Serializers.WriteString)
    ) {}
    //statics
    
    
    
    protected override long SerializationHash => -267406047508532528L;
    
    protected override Action<ISerializers> Register => RegisterDeclaredTypesSerializers;
    public static void RegisterDeclaredTypesSerializers(ISerializers serializers)
    {
      
      serializers.RegisterToplevelOnce(typeof(IdeRoot), IdeRoot.RegisterDeclaredTypesSerializers);
    }
    
    //custom body
    //equals trait
    //hash code trait
    //pretty print
    public override void Print(PrettyPrinter printer)
    {
      printer.Println("RiderDevExpressPluginModel (");
      using (printer.IndentCookie()) {
        printer.Print("pluginTemplatesPath = "); _PluginTemplatesPath.PrintEx(printer); printer.Println();
      }
      printer.Print(")");
    }
    //toString
    public override string ToString()
    {
      var printer = new SingleLinePrettyPrinter();
      Print(printer);
      return printer.ToString();
    }
  }
  public static class SolutionRiderDevExpressPluginModelEx
   {
    public static RiderDevExpressPluginModel GetRiderDevExpressPluginModel(this Solution solution)
    {
      return solution.GetOrCreateExtension("riderDevExpressPluginModel", () => new RiderDevExpressPluginModel());
    }
  }
}
