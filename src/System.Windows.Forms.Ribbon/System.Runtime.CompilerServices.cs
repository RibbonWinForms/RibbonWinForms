// *********************************
// Message from Original Author:
//
// 2008 Jose Menendez Poo
// Please give me credit if you use this code. It's all I ask.
// Contact me for more info: menendezpoo@gmail.com
// *********************************
//
// Original project from http://ribbon.codeplex.com/
// Continue to support and maintain by http://officeribbon.codeplex.com/


namespace System.Runtime.CompilerServices
{
#if NET20
    /// <summary>
    /// Extension methods require an attribute which is normally part of .NET 3.5.
    /// 
    /// By adding this attribute, we'll get Extension methods to work with .NET 2.0.
    /// 
    /// tajbender 15/08/19: I'm really unaware if this will bring us trouble, however, I think it's worth a try
    /// <see href="https://csharpindepth.com/Articles/Versions"/>
    /// <see href="https://blogs.msmvps.com/punitganshani/2015/06/21/5-steps-to-targeting-multiple-net-frameworks/"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    public class ExtensionAttribute : Attribute { }
#endif
}
