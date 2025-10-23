## Extensions for RevitAddIns

```cs

RevitAddInManifest manifest = AddInManifestUtility.GetRevitAddInManifest("Autodesk.WorksharingMonitor.Application.addin");

RevitAddInCommand? addin = manifest.GetRevitAddInItemByFullClassName("WorksharingCommand.WorksharingApp") as RevitAddInCommand;
XmlDocument document = addin!.ToXmlDocument();

XmlNode? addinIdNode = document.GetElementByAddinTag(AddInTags.AddInId);

AddInTag<Guid> addinIdTagFromAddinCommand = addin!.GetAddInTag(AddInTags.AddInId);

Console.WriteLine(addinIdNode.OuterXml); // -> <AddInId>8ed11396-f33d-4378-9b75-fd1874064495</AddInId>
Console.WriteLine(addinIdTagFromAddinCommand); // -> AddInTag {
                                               // Tag = AddInId,
                                               // Description = A GUID which represents the id of this particular application. AddInIds must be unique for a given session of Revit. Autodesk recommends you generate a unique GUID for each registered application or command. Required for all ExternalCommands and ExternalApplications.,
                                               // RequiredFor = All,
                                               // BelongsToAddInType = All,
                                               // Value = 8ed11396-f33d-4378-9b75-fd1874064495,
                                               // Type = System.Guid,
                                               // HasValue = True
                                               // }

Console.WriteLine($"Found AddIn: {addin!.FullClassName}"); // -> WorksharingCommand.WorksharingApp
Console.WriteLine($"Assembly: {addin.Assembly}"); // -> C:\Program Files\Autodesk\Worksharing Monitor for Revit 2026\Autodesk.WorksharingMonitor.Utilities.dll

```
