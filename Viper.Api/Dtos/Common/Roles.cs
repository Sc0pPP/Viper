using System;
using System.Collections.Generic;
namespace Viper.Api.Dtos.Common;

/// <summary>Названия ролей. Совпадают с записями в таблице Roles и с claim'ом role в JWT.</summary>
public static class Roles
{
    public const string User = "User";
    public const string Admin = "Admin";
}
