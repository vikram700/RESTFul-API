using System.ComponentModel;
using System;

namespace Supermarket.API.Domain.Models
{
    public enum EUnitOfMeasurement : byte
    {
        [DescriptionAttribute("UN")]
        Unity = 1,

        [Description("MG")]
        Milligram = 2,

        [Description("G")]
        Gram = 3,

        [Description("KG")]
        Killogram = 4,

        [Description("L")]
        Liter = 5
    }
}