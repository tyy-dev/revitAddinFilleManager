using Autodesk.Revit.UI;
using Autodesk.RevitAddIns;

namespace RevitAddinFilleManager.Entities.Enums
{
    public static class AddInTags
    {
        // Common tags for all RevitAddInItem
        public static readonly AddInTag<string> Assembly = new(
            "Assembly",
            "The full path to the add-in assembly file. Required for all ExternalCommands and ExternalApplications.",
            RequiredFor: AddInType.All);
        public static readonly AddInTag<Guid> AddInId = new(
            "AddInId",
            "A GUID which represents the id of this particular application. AddInIds must be unique for a given session of Revit. Autodesk recommends you generate a unique GUID for each registered application or command. Required for all ExternalCommands and ExternalApplications.",
            RequiredFor: AddInType.All);
        public static readonly AddInTag<string> FullClassName = new(
            "FullClassName",
            "The full name of the class in the assembly file which implements IExternalCommand or IExternalApplication. Required for all ExternalCommands and ExternalApplications.",
            RequiredFor: AddInType.All);
        public static readonly AddInTag<string> VendorId = new(
            "VendorId",
            "A unique vendor identifier that may be used by some operations in Revit (such as identification of extensible storage). This must be unique, and thus we recommend to use reversed version of your domain name, for example, com.autodesk or uk.co.autodesk.");
        public static readonly AddInTag<string> VendorDescription = new(
            "VendorDescription",
            "Description containing vendor's legal name and/or other pertinent information. Optional.");
        public static readonly AddInTag<string> ProductImage = new(
            "ProductImage",
            "The product image.");
        public static readonly AddInTag<string> ProductDescription = new(
            "ProductDescription",
            "The product description.");
        public static readonly AddInTag<string> ProductVersion = new(
            "ProductVersion",
            "The product version.");
        public static readonly AddInTag<bool> AllowLoadingIntoExistingSession = new(
            "AllowLoadingIntoExistingSession",
            "The flag of loading permission.");

        // RevitAddInCommand specific tags
        public static readonly AddInTag<string> Text = new(
            "Text",
            "The name of the button. Optional; use this tag for ExternalCommands only. The default is \"External Tool\".",
            BelongsToAddInType: AddInType.Command);
        public static readonly AddInTag<string> Description = new(
            "Description",
            "Short description of the command, will be used as the button tooltip. Optional; use this tag for ExternalCommands only. The default is a tooltip with just the command text.",
            BelongsToAddInType: AddInType.Command);
        public static readonly AddInTag<string> LongDescription = new(
            "LongDescription",
            "Long description of the command, will be used as part of the button extended tooltip, shown when the mouse hovers over the command for a longer amount of time. Optional; use this tag for ExternalCommands only. If this property and TooltipImage are not supplied, the button will not have an extended tooltip.",
            BelongsToAddInType: AddInType.Command);
        public static readonly AddInTag<string> LargeImage = new(
            "LargeImage",
            "The icon to use for the button in the External Tools pulldown menu. Optional; use this tag for ExternalCommands only. The default is to show a button without an icon.",
            BelongsToAddInType: AddInType.Command);
        public static readonly AddInTag<string> TooltipImage = new(
            "TooltipImage",
            "An image file to show as a part of the button extended tooltip, shown when the mouse hovers over the command for a longer amount of time. Optional; use this tag for ExternalCommands only. If this property and TooltipImage are not supplied, the button will not have an extended tooltip.",
            BelongsToAddInType: AddInType.Command);
        public static readonly AddInTag<VisibilityMode> VisibilityMode = new(
            "VisibilityMode",
            "Localization setting for Text, Description, LargeImage, LongDescription, and TooltipImage of external tools buttons. Revit will load the resource values from the specified language resource dll. The value can be one of the eleven languages supported by Revit. If no LanguageType is specified, the language resource which the current session of Revit is using will be automatically loaded. For more details see the section on Localization.",
            BelongsToAddInType: AddInType.Command);
        public static readonly AddInTag<Discipline> Discipline = new(
            "Discipline",
            "The disciplines in which the external command will be visible. Multiple values may be set for this option. Optional; use this tag for ExternalCommands only. The default is to display the command in all disciplines. If any specific disciplines are listed, the command will only be visible in those disciplines. See table below for more information.",
            BelongsToAddInType: AddInType.Command);
        public static readonly AddInTag<string> AvailabilityClassName = new(
            "AvailabilityClassName",
            "The full name of the class in the assembly file which implemented IExternalCommandAvailability. This class allows the command button to be selectively grayed out depending on context. Optional; use this tag for ExternalCommands only. The default is a command that is available whenever it is visible.",
            BelongsToAddInType: AddInType.Command);
        public static readonly AddInTag<LanguageType> LanguageType = new(
            "LanguageType",
            "Localization setting for Text, Description, LargeImage, LongDescription, and TooltipImage of external tools buttons. Revit will load the resource values from the specified language resource dll. The value can be one of the eleven languages supported by Revit. If no LanguageType is specified, the language resource which the current session of Revit is using will be automatically loaded. For more details see the section on Localization.",
            BelongsToAddInType: AddInType.Command);

        // RevitAddInApplication/RevitAddInDBApplication tags
        public static readonly AddInTag<string> Name = new(
            "Name", 
            "The name of application. Required; for ExternalApplications only.",
            RequiredFor: AddInType.ExternalApplication, 
            BelongsToAddInType: AddInType.ExternalApplication);

        // RevitAddInDBApplication specific tags
        public static readonly AddInTag<bool> LoadInRevitWorker = new(
            "LoadInRevitWorker",
            "Indicates whether or not a RevitWorker process will load this add-in.",
            Value: "false",
            BelongsToAddInType: 
            AddInType.DBApplication);

        public static readonly IEnumerable<object> AllTags =
        [
            Assembly,
            AddInId,
            FullClassName,
            VendorId,
            VendorDescription,
            ProductImage,
            ProductDescription,
            ProductVersion,
            AllowLoadingIntoExistingSession,
            Text,
            Description,
            LongDescription,
            LargeImage,
            TooltipImage,
            VisibilityMode,
            Discipline,
            AvailabilityClassName,
            LanguageType,
            Name,
            LoadInRevitWorker
        ];
    }
}
