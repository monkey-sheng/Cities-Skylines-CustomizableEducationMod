// Decompiled with JetBrains decompiler
// Type: Boformer.Redirection.Tuple`2
// Assembly: ImmigrantEducationMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E82106F9-6570-4631-897B-CBA2324F016E
// Assembly location: C:\Users\hujason\Desktop\ImmigrantEducationMod\bin\Debug\ImmigrantEducationMod.dll

namespace Boformer.Redirection
{
  public class Tuple<T1, T2>
  {
    public T1 First { get; private set; }

    public T2 Second { get; private set; }

    internal Tuple(T1 first, T2 second)
    {
      this.First = first;
      this.Second = second;
    }
  }
}
