// Decompiled with JetBrains decompiler
// Type: Boformer.Redirection.Tuple
// Assembly: ImmigrantEducationMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E82106F9-6570-4631-897B-CBA2324F016E
// Assembly location: C:\Users\hujason\Desktop\ImmigrantEducationMod\bin\Debug\ImmigrantEducationMod.dll

namespace Boformer.Redirection
{
  public static class Tuple
  {
    public static Tuple<T1, T2> New<T1, T2>(T1 first, T2 second)
    {
      return new Tuple<T1, T2>(first, second);
    }
  }
}
