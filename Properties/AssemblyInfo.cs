using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(Mu3Assist.BuildInfo.Description)]
[assembly: AssemblyDescription(Mu3Assist.BuildInfo.Description)]
[assembly: AssemblyCompany(Mu3Assist.BuildInfo.Company)]
[assembly: AssemblyProduct(Mu3Assist.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + Mu3Assist.BuildInfo.Author)]
[assembly: AssemblyTrademark(Mu3Assist.BuildInfo.Company)]
[assembly: AssemblyVersion(Mu3Assist.BuildInfo.Version)]
[assembly: AssemblyFileVersion(Mu3Assist.BuildInfo.Version)]
[assembly: MelonInfo(typeof(Mu3Assist.Mu3Assist), Mu3Assist.BuildInfo.Name, Mu3Assist.BuildInfo.Version, Mu3Assist.BuildInfo.Author, Mu3Assist.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]