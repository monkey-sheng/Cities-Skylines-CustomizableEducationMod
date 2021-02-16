// Decompiled with JetBrains decompiler
// Type: ImmigrantEducationMod.LoadingExtension
// Assembly: ImmigrantEducationMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E82106F9-6570-4631-897B-CBA2324F016E
// Assembly location: C:\Users\hujason\Desktop\ImmigrantEducationMod\bin\Debug\ImmigrantEducationMod.dll

using Boformer.Redirection;
using ColossalFramework.IO;
using ICities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace ImmigrantEducationMod
{
  public class LoadingExtension : LoadingExtensionBase
  {
    public static volatile bool isModEnabled = false;
    public static volatile bool isLevelLoaded = false;
    public static string currentFileLocation = DataLocation.localApplicationData + Path.DirectorySeparatorChar.ToString() + "CustomizableEducation.sav";
    private readonly Dictionary<MethodInfo, Redirector> redirectsOnCreated = new Dictionary<MethodInfo, Redirector>();

    private void Redirect()
    {
      foreach (System.Type type in Assembly.GetExecutingAssembly().GetTypes())
      {
        try
        {
          Dictionary<MethodInfo, Redirector> dictionary = RedirectionUtil.RedirectType(type, false);
          if (dictionary != null)
          {
            foreach (KeyValuePair<MethodInfo, Redirector> keyValuePair in dictionary)
              this.redirectsOnCreated.Add(keyValuePair.Key, keyValuePair.Value);
          }
        }
        catch (Exception ex)
        {
          Debug.Log((object) ("An error occured while applying " + type.Name + " redirects!"));
          Debug.Log((object) ex.StackTrace);
        }
      }
    }

    private void RevertRedirect()
    {
      foreach (KeyValuePair<MethodInfo, Redirector> keyValuePair in this.redirectsOnCreated)
      {
        try
        {
          keyValuePair.Value.Revert();
        }
        catch (Exception ex)
        {
          Debug.Log((object) ("An error occured while reverting " + keyValuePair.Key.Name + " redirect!"));
          Debug.Log((object) ex.StackTrace);
        }
      }
      this.redirectsOnCreated.Clear();
    }

    public override void OnCreated(ILoading loading)
    {
      if (!LoadingExtension.isModEnabled)
      {
        LoadingExtension.isModEnabled = true;
        this.Redirect();
      }
      try
      {
        XML.ReadFromBinaryFile();
        Debug.Log((object) "OnCreated() ReadIntoDataStore()");
      }
      catch
      {
      }
    }

    public override void OnReleased()
    {
      if (!LoadingExtension.isModEnabled)
        return;
      LoadingExtension.isModEnabled = false;
      this.RevertRedirect();
    }
  }
}
