using System;
using System.Collections.Generic;

namespace MovieDbAngDotNet.Models;

public partial class UserDb
{

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;
}
