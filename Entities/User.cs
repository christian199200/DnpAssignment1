﻿namespace Entities;

public class User
{
    public int Id { get; set; }
    public String UserName { get; set; }
    public String Password { get; set; }

    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}