using System.Runtime.Serialization;

namespace Xenolope.Extensions.Tests.Entities
{
    public enum Position
    {
        [EnumMember(Value = "position_boss")]
        Boss,
        [EnumMember(Value = "position_employee")]
        Employee,
        [EnumMember(Value = "position_intern")]
        Intern
    }
}