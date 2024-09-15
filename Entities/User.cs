﻿namespace Entities;

public class User
{
    public int Id { get; set; }
    public String UserName { get; set; }
    public String Password { get; set; }

    public User(int id, string userName, string password)
    {
        Id = id;
        UserName = userName;
        Password = password;
    }
}