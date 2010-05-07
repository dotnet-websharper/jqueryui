namespace IntelliFactory.WebSharper

open System.Reflection

#if DEBUG
#else
[<assembly: AssemblyVersion "1.0">]
[<assembly: AssemblyInformationalVersion "1.0.22.0">]
[<assembly: AssemblyFileVersion "1.0.22.*">]
do ()
#endif
