﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Reflection;


public static class EnumExtensions
{
    /// <summary>
    /// Retrieves the <see cref="DisplayAttribute.Name" /> property on the <see cref="DisplayAttribute" />
    /// of the current enum value, or the enum's member name if the <see cref="DisplayAttribute" /> is not present.
    /// </summary>
    /// <param name="val">This enum member to get the name for.</param>
    /// <returns>The <see cref="DisplayAttribute.Name" /> property on the <see cref="DisplayAttribute" /> attribute, if present.</returns>
    public static string GetDisplayName(this Enum val)
    {
        return val.GetType()
                  .GetMember(val.ToString())
                  .FirstOrDefault()
                  ?.GetCustomAttribute<DisplayAttribute>(false)
                  ?.Name
                  ?? val.ToString();
    }
}