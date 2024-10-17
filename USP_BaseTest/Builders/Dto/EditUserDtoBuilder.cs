﻿using USP_Application.Common.Dto;

namespace USP_BaseTest.Builders.Dto;

public class EditUserDtoBuilder
{
    private string _firstName = "-";
    private string _lastName = "-";
    private string _email = "-";
    private string? _id;

    public EditUserDetailsDto Build() => new EditUserDetailsDto(_firstName, _lastName, _email, _id);

    public EditUserDtoBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public EditUserDtoBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }

    public EditUserDtoBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public EditUserDtoBuilder WithId(string? id)
    {
        _id = id;
        return this;
    }
}