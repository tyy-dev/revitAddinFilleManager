using RevitAddinFilleManager.Entities.Enums;

namespace RevitAddinFilleManager.Entities
{//https://github.com/BimManager/RevitAddInManifestFileGenerator/blob/main/RevitAddInManifestFileGenerator.cs

    public record AddInTag<T>(string Tag, string? Description = null, AddInType RequiredFor = AddInType.None, string? Value = null, AddInType BelongsToAddInType = AddInType.All)
    {
        public string? Value { get; set; } = Value;
        public Type Type => typeof(T);

        /// <summary>
        /// Whether the current AddinTag contains a valid <see cref="Value"/>
        /// </summary>
        public bool HasValue => this.Value is not null;

        public T? GetTypedValue()
        {
            if (!this.HasValue)
                return default;

            try
            {
                if (this.Type == typeof(Guid))
                {
                    Guid guidValue = Guid.Parse(this.Value!);
                    return (T)(object)guidValue;
                }

                return (T?)Convert.ChangeType(this.Value, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }
}
