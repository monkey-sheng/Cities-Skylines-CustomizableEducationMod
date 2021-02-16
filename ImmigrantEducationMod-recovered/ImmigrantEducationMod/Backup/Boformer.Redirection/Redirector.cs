// Decompiled with JetBrains decompiler
// Type: Boformer.Redirection.Redirector
// Assembly: ImmigrantEducationMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E82106F9-6570-4631-897B-CBA2324F016E
// Assembly location: C:\Users\hujason\Desktop\ImmigrantEducationMod\bin\Debug\ImmigrantEducationMod.dll

using System;
using System.Reflection;

namespace Boformer.Redirection
{
  public class Redirector
  {
    private RedirectCallsState state;
    private readonly IntPtr site;
    private readonly IntPtr target;

    public Redirector(MethodInfo from, MethodInfo to)
    {
      this.site = from.MethodHandle.GetFunctionPointer();
      this.target = to.MethodHandle.GetFunctionPointer();
    }

    public void Apply()
    {
      if (this.Deployed)
        return;
      this.state = RedirectionHelper.PatchJumpTo(this.site, this.target);
      this.Deployed = true;
    }

    public void Revert()
    {
      if (!this.Deployed)
        return;
      RedirectionHelper.RevertJumpTo(this.site, this.state);
      this.Deployed = false;
    }

    public bool Deployed { get; private set; }
  }
}
