﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleportAPI.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; } = new List<string>();

        public ValidationException(List<ValidationFailure> errors)
        {
            foreach (var error in errors)
                Errors.Add(error.ErrorMessage);
        }

        public ValidationException(string error)
        {
            Errors.Add(error);
        }
    }
}
