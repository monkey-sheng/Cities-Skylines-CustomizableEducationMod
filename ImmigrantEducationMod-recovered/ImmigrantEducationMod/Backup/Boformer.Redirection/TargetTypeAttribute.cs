// Decompiled with JetBrains decompiler
// Type: Boformer.Redirection.TargetTypeAttribute
// Assembly: ImmigrantEducationMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E82106F9-6570-4631-897B-CBA2324F016E
// Assembly location: C:\Users\hujason\Desktop\ImmigrantEducationMod\bin\Debug\ImmigrantEducationMod.dll

using System;

namespace Boformer.Redirection
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
  public class TargetTypeAttribute : Attribute
  {
    public TargetTypeAttribute(Type type)
    {
      this.Type = type;
    }

    public Type Type { get; }
  }
}
