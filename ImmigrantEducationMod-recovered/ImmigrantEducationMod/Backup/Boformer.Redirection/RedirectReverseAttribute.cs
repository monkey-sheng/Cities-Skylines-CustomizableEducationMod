// Decompiled with JetBrains decompiler
// Type: Boformer.Redirection.RedirectReverseAttribute
// Assembly: ImmigrantEducationMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E82106F9-6570-4631-897B-CBA2324F016E
// Assembly location: C:\Users\hujason\Desktop\ImmigrantEducationMod\bin\Debug\ImmigrantEducationMod.dll

using System;

namespace Boformer.Redirection
{
  [AttributeUsage(AttributeTargets.Method)]
  internal class RedirectReverseAttribute : Attribute
  {
    public RedirectReverseAttribute()
    {
      this.OnCreated = false;
    }

    public RedirectReverseAttribute(bool onCreated)
    {
      this.OnCreated = onCreated;
    }

    public bool OnCreated { get; }
  }
}
