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

public partial class UserCreds 
{
    public UserCreds(string email, string token, string name)
    {
        this.email = email;
        this.name = name;

        this.token = token;
    }

    public string email { get; private set; } = null!;
    public string token { get;private set; } = null!;
    public string name { get;private set; } = null!;


}