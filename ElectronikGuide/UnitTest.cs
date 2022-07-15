using System;
using System.Collections.Generic;
using System.Linq;

using System.Text.RegularExpressions;
using Xunit;
using Microsoft.AspNetCore.Identity;
using CommonPasswordsValidator;

namespace SimpleUnitTests.Tests
{
    // Do not change the name of this class
    public class PasswordValidatorUnitTests : ValidationResult
    {
        // Do not change.
        // This is your SUT (System Under Test) which should be used in tests.
        // It is not null but it is not initialized i.e. Initialize method was not called.
               

        private  readonly ValidationResult _sut;
        
        private ValidationResult expectedRes = new ValidationResult();

        private string strPassword;
        public PasswordValidatorUnitTests ()
        {
             _sut = new ValidationResult();
             
        }
       
        // All your test methods should be public, have no parameters and be marked with [CustomFact] attribute
        [Fact]
        public void CheckPasswordWithoutCapital()
        {
            expectedRes.Initialize(10, 45, true, false);
            expectedRes.IsCorrect = false;
            strPassword = "testing123password";
            Assert.Equal(expectedRes, _sut.Validate(strPassword));
                  
            //
            // TODO - Assertions
            // Console.WriteLine("Sample debug output");
        }
        [Fact]
        public void CheckPasswordWithCapital()
        {
            expectedRes.Initialize(5, 35, false, true);
            expectedRes.IsCorrect = false;
            strPassword = "testingPassword";
            Assert.Equal(expectedRes, _sut.Validate(strPassword));

        }
        [Fact]
        public void CheckPasswordForMinChars()
        {
            expectedRes.Initialize(10, 35, false, true);            
            expectedRes.IsCorrect = false;            
            strPassword = "Testing1";
            Assert.Equal(expectedRes, _sut.Validate(strPassword));

        }
    }
}


public interface IPasswordValidator
{
    /// <summary>
    /// Initialize a password validator.
    /// </summary>
    ///
    /// <param name="minLength">The minimum length of the passowrd</param>
    /// <param name="maxLength">The maximum length of the passowrd</param>
    /// <param name="mustContainDigits"><c>true</c> - a password must contain at least 1 digit</param>
    /// <param name="mustContainCapitalLetters"><c>true</c> - a password must contain at least 1 capital letter</param>
    ///
    /// <exception cref="IndexOutOfRangeException">If minLength is lower than or equal to zero</exception>
    /// <exception cref="IndexOutOfRangeException">If maxLength is greater than 255</exception>
    /// <exception cref="ArgumentException">If minLength is greater than maxLength</exception>
    public void Initialize(
        int minLength,
        int maxLength,
        bool mustContainDigits,
        bool mustContainCapitalLetters);

    /// <summary>
    /// Validates a provided password
    /// </summary>
    /// <param name="password">A password to validate</param>
    /// <returns>A validator result</returns>
    ValidationResult Validate(string password);
}


public class ValidationResult : IPasswordValidator
{
    /// <summary>
    /// Returns <c>true</c> only if a password matches all the rules
    /// </summary>
    
    public bool IsCorrect { get; set; }

    public ValidationErrorEnum[] Errors { get; set; }
    public int mnLength { get; set; }
    public int mxLength { get; set; }
    public bool mustDigits { get; set; }

    public bool mustCapital { get; set; }

    public void Initialize(
       int minLength,
       int maxLength,
       bool mustContainDigits,
       bool mustContainCapitalLetters)
        {
            mnLength = minLength;
            mxLength = maxLength;
            mustDigits = mustContainDigits;
            mustCapital = mustContainCapitalLetters;
            IsCorrect = true;
    }

    /// <summary>
    /// Validates a provided password
    /// </summary>
    /// <param name="password">A password to validate</param>
    /// <returns>A validator result</returns>
    public ValidationResult Validate(string Password)
    {
        ValidationResult result = new ValidationResult();
        if (Password.Length ==0)
        {
            result.IsCorrect = false;
            result.Errors.Append(ValidationErrorEnum.IsEmpty);
        }
        if (Password.Length <= mnLength)
        {
            result.IsCorrect = false;
            result.Errors.Append(ValidationErrorEnum.IsTooShort);

        }
        if (Password.Length >= mxLength)
        {
            result.IsCorrect = false;
            result.Errors.Append(ValidationErrorEnum.IsTooLong);

        }
        Regex rx = new Regex(@"^[A-Z]");
        Match mat = rx.Match(Password);
        if (!mat.Success)
        {
            result.IsCorrect = false;
            result.Errors.Append(ValidationErrorEnum.DoesNotContainCapitalLetters);

        }
        rx = new Regex(@"^[0-9]");
        mat = rx.Match(Password);
        if (!mat.Success)
        {
            result.IsCorrect = false;
            result.Errors.Append(ValidationErrorEnum.DoesNotContainDigits);

        }
        return result;
    }

    /// <summary>
    /// If <c>IsCorrect</c> is <c>true</c> then this property returns an empty arrray.
    /// Otherwise it returns all found errors. Errors cannot be duplicated.
    /// This property must not be null.
    /// </summary>
    
}



public enum ValidationErrorEnum
{

    IsEmpty=0, // If a password is an empty string or null
    IsTooShort=1, // If the length of a password is < minLength
    IsTooLong=2, // If the length of a password is > maxLength
    DoesNotContainDigits=3,
    DoesNotContainCapitalLetters=4
}


/*
Assert.Throws<Exception>(() => ... );
Assert.True(value);
Assert.False(value);
Assert.Equal(expected, actual);
Assert.NotEqual(expected, actual);
*/
