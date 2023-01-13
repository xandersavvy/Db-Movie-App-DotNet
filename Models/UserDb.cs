using System;
using System.Collections.Generic;

namespace MovieDbAngDotNet.Models;

public partial class UserDb
{

    public UserDb(string email,string name,string password) { 
        Email= email;
        Name= name;
        Password= password;
    }

    public string Email { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public string Password { get; set; } = null!;
}
